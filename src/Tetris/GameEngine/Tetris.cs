using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tetris.Properties;

namespace Tetris {
    /// <summary>This class contains all the properties and methods to manage the game of Tetris</summary>
    class Tetris {

        /// <summary>Columns number</summary>
        public const int nColumns = 13;

        /// <summary>Rows number</summary>
        public const int nRows = 17;

        /// <summary>Score for each lowering of the wall</summary>
        public const int SCORE_WALL_DOWN = 13;

        public const int START_VELOCITY = 500;

        /// <summary>Increase in the Speed at each change of level</summary>
        public const int VELOCITY_INCREMENT_LEVEL = 50;

        /// <summary>Tetris construnctor</summary>
        public Tetris() {
            X.Text = "-3";
            Y.Text = "4";
            for (int i = 0; i <= nRows; i++)
                for (int j = 0; j <= nColumns; j++)
                    this.p[i, j] = new Square();//It creates a new instance of the square

            gameTime.Tick += new EventHandler(time_Tick);//Add the procedure that handles the timer Tick event
            gameTime.Interval = START_VELOCITY;//Set the time interval that updates the game interface
            gameTime.Start();//Start the timer
            piece = new Piece(p);
            Piece.X = this.X;
            Piece.Y = this.Y;
        }

        Square[,] p = new Square[nRows + 1, nColumns + 1];
        /// <summary>It contains picturebox where the game is played</summary>
        public Square[,] P {
            get { return p; }
            set { p = value; }
        }

        bool paused;
        //Contains values that allow you to put the game on paus
        public bool Pausa {
            get { return paused; }
            set {
                paused = value;
                if (value == true)
                    gameTime.Stop();//Stops the timer to stop the game
                else
                    gameTime.Start();//Restart the timer to resume the game         
            }
        }

        /// <summary>Label that show the score</summary>
        public Label ScoreLabel = new Label();
        /// <summary>Game score</summary>
        private int CurrentGameScore {
            get { return Convert.ToInt32(ScoreLabel.Text); }
            set { ScoreLabel.Text = Convert.ToString(value); }
        }

        /// <summary>Label that show the level</summary>
        public Label LevelLabel = new Label();
        /// <summary>Game level</summary>
        private int CurrentGameLevel {
            get { return Convert.ToInt32(LevelLabel.Text); }
            set { LevelLabel.Text = Convert.ToString(value); }
        }

        /// <summary>Label that show the message</summary>
        public Label MessageLabel = new Label();
        /// <summary>Game message</summary>
        private string CurrentGameMessage {
            get { return MessageLabel.Text; }
            set { MessageLabel.Text = value; }
        }

        private Form gameForm = new Form();
        /// <summary>Game form</summary>
        public Form GameForm {
            get { return gameForm; }
            set { gameForm = value; }
        }


        Piece piece;
        /// <summary>Current game piece</summary>
        public Piece Piece {
            get { return piece; }
            set { piece = value; }
        }

        /// <summary>It contains a value indicating if the player leaves the game because he lost</summary>
        public bool ExitForLosing = false;

        /// <summary>Clean game interface</summary>
        private void YouLost() {
            for (int i = nRows; i >= 0; i--)
                for (int j = nColumns; j >= 0; j--)
                    P[i, j].IsOccuped = Occuped.No;
            gameTime.Stop();
            MessageBox.Show("Hai perso, ti puzzano le palle. Your score is:" + ScoreLabel.Text);
            Scores.CheckIfSaveScore(int.Parse(ScoreLabel.Text));
            if (MessageBox.Show(" Do you want play again?", "Game Over", MessageBoxButtons.YesNo) ==
                DialogResult.Yes) {
                this.CurrentGameScore = 0;
                this.CurrentGameLevel = 1;
                this.gameTime.Interval = START_VELOCITY;
                gameTime.Start();
            } else {
                ExitForLosing = true;
                GameForm.Close();
            }
            this.CurrentGameScore = 0;
            this.CurrentGameLevel = 1;
            this.gameTime.Interval = START_VELOCITY;
        }



        /// <summary>Check whether the wall can be lowered and that filled the entire wall</summary>
        private void LowersWall() {
            for (int i = nRows; i >= 0; i--) {
                int squarePerRowCount = 0;

                for (int j = 0; j <= nColumns; j++)
                    if (P[i, j].IsOccuped == Occuped.Yes)
                        squarePerRowCount++;//It counts if it has been filled an entire row

                if (squarePerRowCount == nColumns + 1)
                {//Lowers to a position all the squares of that row
                    for (int k = i - 1; k >= 0; k--) {
                        for (int l = 0; l <= nColumns; l++) {
                            P[k + 1, l].IsOccuped = P[k, l].IsOccuped;
                        }
                    }
                    //Increase the score
                    this.CurrentGameScore += SCORE_WALL_DOWN;
                    if (Math.Abs(CurrentGameScore / (CurrentGameLevel * 100)) == 1) {
                        CurrentGameLevel += 1;
                        //Increase the game velocity
                        gameTime.Interval -= VELOCITY_INCREMENT_LEVEL;
                    }
                    i++;//The 'i' is incremented to count if the same row that has been eliminated is filled again
                }

            }
        }

        /// <summary>It provides to slide the piece down and checks if it can slide even </summary>    
        private bool Shift() {
            int i, j;
            bool canShift = true;

            //Code that checks whether a piece can go down
            for (i = piece.StartX; i <= piece.EndX; i++) {
                for (j = piece.CoordinatePiece[i, 0]; j <= piece.CoordinatePiece[i, 1]; j++) {
                    if (posX + i > 0) {
                        if (i < Piece.EndX && posY + j <= nColumns) {
                            if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                Piece.Shape[i + 1, j].IsOccuped == Occuped.No &&
                                P[posX + i, posY + j].IsOccuped == Occuped.Yes) {
                                canShift = false;
                                break;
                            }
                        } else {
                            if (i + posX <= nRows && posY + j >= 0 && posY + j <= nColumns) {
                                if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                P[posX + i, posY + j].IsOccuped == Occuped.Yes) {
                                    canShift = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }


            //Before updating the interface with the new position of the workpiece first checks whether:
            //-The piece may go down because there is no other piece in the new location that will occupy
            //-The piece came to the end and then you will have to stop
            if (posX + piece.EndX <= nRows && canShift == true) {
                for (i = piece.StartX; i <= piece.EndX; i++)
                    for (j = piece.CoordinatePiece[i, 0]; j <= piece.CoordinatePiece[i, 1]; j++)
                        if (posX + i - 1 >= 0 && posY + j >= 0 && posY + j <= nColumns) {
                            P[posX + i - 1, posY + j].IsOccuped = Occuped.No;
                        }

                for (i = piece.StartX; i <= piece.EndX; i++)
                    for (j = piece.CoordinatePiece[i, 0]; j <= piece.CoordinatePiece[i, 1]; j++)
                        if (posX + i >= 0 && posY + j >= 0 && posY + j <= nColumns) {
                            P[posX + i, posY + j].IsOccuped = Piece.Shape[i, j].IsOccuped;
                        }

                return true;
            } else {
                return false;
            }
        }

        //A label is used because it is a reference type, and serves as a reference for the object Pieces    
        Label X = new Label();
        /// <summary>It contains the vertical position of the workpiece</summary>
        public int posX
        {
            get { return Convert.ToInt32(X.Text); }
            set
            {
                X.Text = Convert.ToString(value);
                if (Shift() == false)
                {
                    LowersWall();
                    if (posX < 0) YouLost();
                    this.X.Text = "-3";
                    this.Y.Text = "4";
                    piece.GetCasualPiece();
                }
            }
        }

        /// <summary>Move the piece horizontally, it returns a Boolean value that indicates whether the piece can be moved or not</summary>
        /// <param name="valY">The y value</param>
        /// <param name="shift">The displacemente: True=RIght e False=Left</param>     
        private bool MoveHorizontally(int valY, bool shift) {
            int i, j;
            bool canMove = true;
            //Check the shift direction
            if (shift == true) {//Right displacement
                for (i = Piece.StartX; i <= Piece.EndX; i++) {
                    for (j = Piece.CoordinatePiece[i, 0]; j <= Piece.CoordinatePiece[i, 1]; j++) {
                        if (j < Piece.EndY) {
                            if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                Piece.Shape[i, j + 1].IsOccuped == Occuped.No &&
                                P[posX + i, posY + j + 1].IsOccuped == Occuped.Yes) {
                                canMove = false;
                                break;
                            }
                        } else {
                            if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                P[posX + i, posY + j + 1].IsOccuped == Occuped.Yes) {
                                canMove = false;
                                break;
                            }
                        }
                    }
                }

                if (canMove == true) {
                    for (i = Piece.StartX; i <= Piece.EndX; i++) {
                        for (j = Piece.CoordinatePiece[i, 0]; j <= Piece.CoordinatePiece[i, 1]; j++) {
                            if (j + posY >= 0)
                                this.P[i + posX, j + posY].IsOccuped = Occuped.No;
                        }
                    }
                    for (i = Piece.StartX; i <= Piece.EndX; i++) {
                        for (j = Piece.CoordinatePiece[i, 0]; j <= Piece.CoordinatePiece[i, 1]; j++) {
                            this.P[i + posX, j + posY + 1].IsOccuped = Piece.Shape[i, j].IsOccuped;
                        }
                    }
                }
            } else {//Left displacement

                for (i = Piece.StartX; i <= Piece.EndX; i++) {
                    for (j = Piece.CoordinatePiece[i, 0]; j <= Piece.CoordinatePiece[i, 1]; j++) {
                        if (j > Piece.StartY) {
                            if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                Piece.Shape[i, j - 1].IsOccuped == Occuped.No &&
                                P[posX + i, posY + j - 1].IsOccuped == Occuped.Yes) {
                                canMove = false;
                                break;
                            }
                        } else {
                            if (Piece.Shape[i, j].IsOccuped == Occuped.Yes &&
                                P[posX + i, posY + j - 1].IsOccuped == Occuped.Yes) {
                                canMove = false;
                                break;
                            }

                        }
                    }
                }
                if (canMove == true) {
                    for (i = Piece.StartX; i <= Piece.EndX; i++) {
                        for (j = Piece.CoordinatePiece[i, 0]; j <= Piece.CoordinatePiece[i, 1]; j++) {
                            if (j + posY <= nColumns) {
                                this.P[i + posX, j + posY].IsOccuped = Occuped.No;
                                this.P[i + posX, j + posY - 1].IsOccuped = Piece.Shape[i, j].IsOccuped;
                            }
                        }
                    }
                }
            }
            return canMove;
        }

        Label Y = new Label();
        /// <summary>It contains the horizontal position of the workpiece</summary>
        public int posY {
            get { return Convert.ToInt32(Y.Text); }
            set {
                if (posX >= 0) {
                    bool DisplacementDirection;
                    if (value >= 0 - piece.StartY && value + Piece.EndY <= nColumns) {
                        if (value > posY)
                            DisplacementDirection = true;//Right
                        else
                            DisplacementDirection = false;//Left
                        if (MoveHorizontally(value, DisplacementDirection) == true) {
                            Y.Text = Convert.ToString(value);
                        }
                    }
                }
            }
        }

        /// <summary>For each call of the procedure updates the game screen, you should call this procedure at every tick of the timer</summary>
        public void Aggiorna() {
            this.posX++;
        }

        Timer gameTime = new Timer();

        private void time_Tick(object sender, EventArgs e) {
            this.Aggiorna();            
        }
    }
}
