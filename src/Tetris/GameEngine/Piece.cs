using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris {
    /// <summary>It contains all of the procedures and the properties that represent the pieces of Tetris</summary>
    class Piece {
        /// <summary>It indicates the number of interface columns</summary>
        public const int nColumn = 13;

        /// <summary>It indicates the number of interface rows</summary>
        public const int nRows = 17;

        /// <summary>Class constructor</summary>
        /// <param name="interfaccia">The interface of squares on which the game is played</param>
        public Piece(Square[,] interf) {

            for (short i = 0; i < 4; i++)
                for (short j = 0; j < 4; j++) {
                    Shape[i, j] = new Square();
                    nextPiece[i, j] = new Square();
                }
            for (int i = 0; i <= nRows; i++)
                for (int j = 0; j <= nColumn; j++) {
                    gameInterface[i, j] = new Square();
                    gameInterface[i, j] = interf[i, j];
                }
            this.GetCasualPiece();//Generate the first piece   
        }

        /// <summary>Indicates the number of rotation of the workpiece current</summary>
        public int CurrentRotation { get; set; }


        private Square[,] gameInterface = new Square[nRows + 1, nColumn + 1];
        /// <summary>Contains space expressed in PictureBox matrix</summary>
        public Square[,] GameInterface {
            get { return gameInterface; }
        }

        public Label X = new Label();
        /// <summary>Contains the X coordinate of the part of the game interface</summary>
        int posX {
            get { return Convert.ToInt32(X.Text); }
            set { X.Text = Convert.ToString(value); }
        }

        public Label Y = new Label();
        /// <summary>Contains the Y coordinate of the part of the game interface</summary>
        int posY {
            get { return Convert.ToInt32(Y.Text); }
            set { Y.Text = Convert.ToString(value); }
        }

        public Square[,] shape = new Square[4, 4];
        /// <summary>Contains the piece space expressed in PictureBox matrix</summary>
        public Square[,] Shape {
            get { return shape; }
            set { gameInterface = value; }
        }

        int[,] PieceCoordinate = new int[4, 2];
        /// <summary>Returns the coordinates of the squares of the piece</summary>
        public int[,] CoordinatePiece {
            get { return PieceCoordinate; }
        }

        private PieceType pieceType;
        /// <summary>It returns a value that indicates the type of piece generated</summary>
        public PieceType PieceType {
            get { return pieceType; }
        }

        /// <summary>It returns a Boolean value that indicates whether the part can rotate</summary>
        /// <param name="x">The vertical position of the workpiece in the interface</param>
        /// <param name="y">The horizontal position of the workpiece in the interface</param>
        private bool CanRotate(int x, int y) {
            Square[,] temp = new Square[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++) {
                    temp[j, 3 - i] = new Square();
                    temp[j, 3 - i].IsOccuped = Shape[i, j].IsOccuped;
                }

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++) {
                    try {
                        /*Check if rotating the piece overlaps the wall: if it happens it returns false*/
                        if ((temp[i, j].IsOccuped == Occuped.Yes ||
                            temp[i, j].IsOccuped == Occuped.No) &&
                            Shape[i, j].IsOccuped == Occuped.No &&
                            GameInterface[x + i, y + j].IsOccuped == Occuped.Yes) {
                            return false;
                        }
                    } catch {
                        /*If it returns an exception (index out of the matrix) means that turning the piece comes from the interface,
                         * then it returns false, indicating that the component can not run*/
                        return false;
                    }
                }
            return true;
        }


        /// <summary>Rotates the part to the right in a clockwise direction</summary>
        public void CanRotate() {
            if (posX >= 0 && CanRotate(posX, posY) == true) {
                this.CurrentRotation++;
                if (this.CurrentRotation == 4) this.CurrentRotation = 0;
                if (CurrentRotation == 3 && this.PieceType == PieceType.T) {
                    for (int i = StartX; i <= EndX; i++)
                        for (int j = CoordinatePiece[i, 0]; j <= CoordinatePiece[i, 1]; j++) {
                            GameInterface[posX + i, posY + j].IsOccuped = Occuped.No;
                            Shape[i, j].IsOccuped = Occuped.No;
                        }

                    GameInterface[posX + 0, posY + 0].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 0, posY + 1].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 0, posY + 2].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 1, posY + 1].IsOccuped = Occuped.Yes;
                    this.iniX = 0;
                    this.finX = 1;
                    this.iniY = 0;
                    this.finY = 2;
                    CoordinatePiece[0, 0] = 0;
                    CoordinatePiece[0, 1] = 2;
                    CoordinatePiece[1, 0] = 1;
                    CoordinatePiece[1, 1] = 1;

                    Shape[0, 0].IsOccuped = Occuped.Yes;
                    Shape[0, 1].IsOccuped = Occuped.Yes;
                    Shape[0, 2].IsOccuped = Occuped.Yes;
                    Shape[1, 1].IsOccuped = Occuped.Yes;

                } else if (this.PieceType == PieceType.S && (CurrentRotation == 1 || CurrentRotation == 3)) {

                    for (int i = StartX; i <= EndX; i++)
                        for (int j = CoordinatePiece[i, 0]; j <= CoordinatePiece[i, 1]; j++) {
                            GameInterface[posX + i, posY + j].IsOccuped = Occuped.No;
                            Shape[i, j].IsOccuped = Occuped.No;
                        }

                    GameInterface[posX + 0, posY + 2].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 0, posY + 3].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 1, posY + 1].IsOccuped = Occuped.Yes;
                    GameInterface[posX + 1, posY + 2].IsOccuped = Occuped.Yes;
                    this.iniX = 0;
                    this.finX = 1;
                    this.iniY = 1;
                    this.finY = 3;
                    CoordinatePiece[0, 0] = 2;
                    CoordinatePiece[0, 1] = 3;
                    CoordinatePiece[1, 0] = 1;
                    CoordinatePiece[1, 1] = 2;

                    Shape[0, 2].IsOccuped = Occuped.Yes;
                    Shape[0, 3].IsOccuped = Occuped.Yes;
                    Shape[1, 1].IsOccuped = Occuped.Yes;
                    Shape[1, 2].IsOccuped = Occuped.Yes;

                } else if (this.PieceType != PieceType.O) {
                    Square[,] temp = new Square[4, 4];

                    //Remove the piece from the old location
                    for (int i = this.StartX; i <= this.EndX; i++)
                        for (int j = this.StartY; j <= this.EndY; j++)
                            GameInterface[posX + i, posY + j].IsOccuped = Occuped.No;

                    //Create a copy of the array form in the matrix temp
                    for (int i = 0; i <= 3; i++) {
                        for (int j = 0; j <= 3; j++) {
                            temp[i, j] = new Square();
                            temp[i, j].IsOccuped = Shape[i, j].IsOccuped;
                        }
                    }

                    for (int i = 0; i <= 3; i++)
                        for (int j = 0; j <= 3; j++) {
                            Shape[j, 3 - i].IsOccuped = temp[i, j].IsOccuped;
                            if (Shape[j, 3 - i].IsOccuped == Occuped.Yes)
                                GameInterface[posX + j, posY + 3 - i].IsOccuped = Occuped.Yes;

                        }
                    CalculateNewPieceLimits(Shape, ref iniX, ref finX, ref iniY, ref finY);
                    CalculateCurrentPieceCoordinates();
                }
            }
        }

        /// <summary>Calculate the new piece limits</summary>
        /// <param name="Forma">The space which contains the piece</param>
        /// <param name="inix">The variable that must contain the start of the X</param>
        /// <param name="finx">The variable that will contain the end of the X</param>
        /// <param name="iniy">The variable that must contain the start of Y</param>
        /// <param name="finy">The variable that will contain the end of the X/param>
        public void CalculateNewPieceLimits(Square[,] Forma, ref int inix, ref int finx, ref int iniy, ref int finy) {
            bool finded = false;
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 3; j++) {
                    if (this.Shape[i, j].IsOccuped == Occuped.Yes) {
                        if (finded == false) {
                            this.iniX = i;
                            this.finX = i;
                            this.iniY = j;
                            this.finY = j;
                            finded = true;
                        } else {
                            if (i < iniX) iniX = i;
                            if (i > finX) finX = i;
                            if (j < iniY) iniY = j;
                            if (j > iniY) finY = j;
                        }
                    }
                }
        }

        int iniX;
        public int StartX {
            get { return iniX; }
        }
        int finX;
        public int EndX {
            get { return finX; }
        }

        int iniY;
        public int StartY {
            get { return iniY; }
        }
        int finY;
        public int EndY {
            get { return finY; }
        }

        /// <summary>Calculates the coordinates of the square of the current price and puts them in the structure CoordinatePiece</summary>
        private void CalculateCurrentPieceCoordinates() {
            for (int i = 0; i <= 3; i++) {
                bool calculated = false;
                for (int j = 0; j <= 3; j++) {
                    if (Shape[i, j].IsOccuped == Occuped.Yes) {
                        if (calculated == false) {
                            this.PieceCoordinate[i, 0] = j;
                            this.PieceCoordinate[i, 1] = j;
                            calculated = true;
                        } else {
                            this.PieceCoordinate[i, 1] = j;
                        }
                    }
                }
                if (calculated == false) {
                    this.PieceCoordinate[i, 0] = 0;
                    this.PieceCoordinate[i, 1] = -1;
                }
            }
        }

        PieceType nextPieceType;
        //It contains the type of the next piece
        private PieceType NextPieceType {
            get { return nextPieceType; }
            set { nextPieceType = value; }
        }


        private Square[,] nextPiece = new Square[4, 4];
        /// <summary>Contains space expressed in matrix PictureBox next piece</summary>
        public Square[,] NextPiece {
            get { return nextPiece; }
            set { nextPiece = value; }
        }

        /// <summary>Set as part of the class in the matrix form casual one among the four types</summary>
        public void GetCasualPiece() {
            for (short i = 0; i < 4; i++) {
                for (short j = 0; j < 4; j++) {
                    this.Shape[i, j].IsOccuped = NextPiece[i, j].IsOccuped;
                    this.NextPiece[i, j].IsOccuped = Occuped.No;

                }
            }
            pieceType = NextPieceType;

            switch (PieceType) {
                case PieceType.I:
                    this.iniX = 0;
                    this.finX = 3;
                    this.iniY = 2;
                    this.finY = 2;
                    break;
                case PieceType.L:
                    this.iniX = 1;
                    this.finX = 3;
                    this.iniY = 2;
                    this.finY = 3;
                    break;
                case PieceType.J:
                    this.iniX = 1;
                    this.finX = 3;
                    this.iniY = 2;
                    this.finY = 3;
                    break;
                case PieceType.Z:
                    this.iniX = 1;
                    this.finX = 3;
                    this.iniY = 1;
                    this.finY = 2;
                    break;
                case PieceType.S:
                    this.iniX = 0;
                    this.finX = 2;
                    this.iniY = 0;
                    this.finY = 1;
                    break;
                case PieceType.O:
                    this.iniX = 1;
                    this.finX = 2;
                    this.iniY = 2;
                    this.finY = 3;
                    break;
                case PieceType.T:
                    this.iniX = 0;
                    this.finX = 2;
                    this.iniY = 1;
                    this.finY = 2;
                    break;


            }

            Random caso = new Random();

            switch (caso.Next(0, 7)) {
                case 0:
                    //Set as piece:
                    //[*][*][*][*]         
                    this.NextPiece[0, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[3, 2].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.I;
                    break;
                case 1:
                    //Set as piece:
                    //   [*]
                    //[*][*]
                    //   [*]             
                    this.NextPiece[0, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 1].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.T;
                    break;
                case 2:
                    //Set as piece:
                    //[*][*] 
                    //   [*]
                    //   [*]                
                    this.NextPiece[1, 3].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 3].IsOccuped = Occuped.Yes;
                    this.NextPiece[3, 3].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.L;
                    break;
                case 3:
                    //Set as piece:
                    //[*][*]
                    //[*][*]              
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 3].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 3].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.O;
                    break;
                case 4:
                    //Set as piece:
                    //   [*]
                    //[*][*]
                    //[*]                   
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 1].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[3, 1].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.Z;
                    break;
                case 5:
                    //Imposta come pezzo:
                    //[*][*] 
                    //[*]
                    //[*]                
                    this.NextPiece[1, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[3, 2].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 3].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.J;
                    break;
                case 6:
                    //Set as piece:
                    //[*]
                    //[*][*]
                    //   [*]                                        
                    this.NextPiece[0, 0].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 0].IsOccuped = Occuped.Yes;
                    this.NextPiece[1, 1].IsOccuped = Occuped.Yes;
                    this.NextPiece[2, 1].IsOccuped = Occuped.Yes;
                    this.NextPieceType = PieceType.S;
                    break;
            }
            CalculateCurrentPieceCoordinates();
            this.CurrentRotation = 0;
        }
    }
}