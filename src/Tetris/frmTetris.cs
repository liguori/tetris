using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Tetris
{
    public partial class frmTetris : Form{
        const string GAME_PAUSE_STRING = "PAUSE";


        public frmTetris(){
            InitializeComponent();        
        }
       
        Tetris g;

        /// <summary>Initializes the PictureBox and the label of the interface in the Class</summary>
        private void InizializzaInterfacciaInClasse() {            
            this.lblMessage.Text = "";//Clean the message
            g = new Tetris();
            #region "Initialization of the PictureBox that compose interface in class"
            g.P[0, 0].P = pictureBox1;            
            g.P[0, 1].P = pictureBox2;
            g.P[0, 2].P = pictureBox3;
            g.P[0, 3].P = pictureBox4;
            g.P[0, 4].P = pictureBox5;
            g.P[0, 5].P = pictureBox6;
            g.P[0, 6].P = pictureBox7;
            g.P[0, 7].P = pictureBox8;
            g.P[0, 8].P = pictureBox9;
            g.P[0, 9].P = pictureBox10;
            g.P[0, 10].P = pictureBox11;
            g.P[0, 11].P = pictureBox12;
            g.P[0, 12].P = pictureBox13;
            g.P[0, 13].P = pictureBox14;
            g.P[1, 0].P = pictureBox15;
            g.P[1, 1].P = pictureBox16;
            g.P[1, 2].P = pictureBox17;
            g.P[1, 3].P = pictureBox18;
            g.P[1, 4].P = pictureBox19;
            g.P[1, 5].P = pictureBox20;
            g.P[1, 6].P = pictureBox21;
            g.P[1, 7].P = pictureBox22;
            g.P[1, 8].P = pictureBox23;
            g.P[1, 9].P = pictureBox24;
            g.P[1, 10].P = pictureBox25;
            g.P[1, 11].P = pictureBox26;
            g.P[1, 12].P = pictureBox27;
            g.P[1, 13].P = pictureBox28;
            g.P[2, 0].P = pictureBox29;
            g.P[2, 1].P = pictureBox30;
            g.P[2, 2].P = pictureBox31;
            g.P[2, 3].P = pictureBox32;
            g.P[2, 4].P = pictureBox33;
            g.P[2, 5].P = pictureBox34;
            g.P[2, 6].P = pictureBox35;
            g.P[2, 7].P = pictureBox36;
            g.P[2, 8].P = pictureBox37;
            g.P[2, 9].P = pictureBox38;
            g.P[2, 10].P = pictureBox39;
            g.P[2, 11].P = pictureBox40;
            g.P[2, 12].P = pictureBox41;
            g.P[2, 13].P = pictureBox42;
            g.P[3, 0].P = pictureBox43;
            g.P[3, 1].P = pictureBox44;
            g.P[3, 2].P = pictureBox45;
            g.P[3, 3].P = pictureBox46;
            g.P[3, 4].P = pictureBox47;
            g.P[3, 5].P = pictureBox48;
            g.P[3, 6].P = pictureBox49;
            g.P[3, 7].P = pictureBox50;
            g.P[3, 8].P = pictureBox51;
            g.P[3, 9].P = pictureBox52;
            g.P[3, 10].P = pictureBox53;
            g.P[3, 11].P = pictureBox54;
            g.P[3, 12].P = pictureBox55;
            g.P[3, 13].P = pictureBox56;
            g.P[4, 0].P = pictureBox57;
            g.P[4, 1].P = pictureBox58;
            g.P[4, 2].P = pictureBox59;
            g.P[4, 3].P = pictureBox60;
            g.P[4, 4].P = pictureBox61;
            g.P[4, 5].P = pictureBox62;
            g.P[4, 6].P = pictureBox63;
            g.P[4, 7].P = pictureBox64;
            g.P[4, 8].P = pictureBox65;
            g.P[4, 9].P = pictureBox66;
            g.P[4, 10].P = pictureBox67;
            g.P[4, 11].P = pictureBox68;
            g.P[4, 12].P = pictureBox69;
            g.P[4, 13].P = pictureBox70;
            g.P[5, 0].P = pictureBox71;
            g.P[5, 1].P = pictureBox72;
            g.P[5, 2].P = pictureBox73;
            g.P[5, 3].P = pictureBox74;
            g.P[5, 4].P = pictureBox75;
            g.P[5, 5].P = pictureBox76;
            g.P[5, 6].P = pictureBox77;
            g.P[5, 7].P = pictureBox78;
            g.P[5, 8].P = pictureBox79;
            g.P[5, 9].P = pictureBox80;
            g.P[5, 10].P = pictureBox81;
            g.P[5, 11].P = pictureBox82;
            g.P[5, 12].P = pictureBox83;
            g.P[5, 13].P = pictureBox84;
            g.P[6, 0].P = pictureBox85;
            g.P[6, 1].P = pictureBox86;
            g.P[6, 2].P = pictureBox87;
            g.P[6, 3].P = pictureBox88;
            g.P[6, 4].P = pictureBox89;
            g.P[6, 5].P = pictureBox90;
            g.P[6, 6].P = pictureBox91;
            g.P[6, 7].P = pictureBox92;
            g.P[6, 8].P = pictureBox93;
            g.P[6, 9].P = pictureBox94;
            g.P[6, 10].P = pictureBox95;
            g.P[6, 11].P = pictureBox96;
            g.P[6, 12].P = pictureBox97;
            g.P[6, 13].P = pictureBox98;
            g.P[7, 0].P = pictureBox99;
            g.P[7, 1].P = pictureBox100;
            g.P[7, 2].P = pictureBox101;
            g.P[7, 3].P = pictureBox102;
            g.P[7, 4].P = pictureBox103;
            g.P[7, 5].P = pictureBox104;
            g.P[7, 6].P = pictureBox105;
            g.P[7, 7].P = pictureBox106;
            g.P[7, 8].P = pictureBox107;
            g.P[7, 9].P = pictureBox108;
            g.P[7, 10].P = pictureBox109;
            g.P[7, 11].P = pictureBox110;
            g.P[7, 12].P = pictureBox111;
            g.P[7, 13].P = pictureBox112;
            g.P[8, 0].P = pictureBox113;
            g.P[8, 1].P = pictureBox114;
            g.P[8, 2].P = pictureBox115;
            g.P[8, 3].P = pictureBox116;
            g.P[8, 4].P = pictureBox117;
            g.P[8, 5].P = pictureBox118;
            g.P[8, 6].P = pictureBox119;
            g.P[8, 7].P = pictureBox120;
            g.P[8, 8].P = pictureBox121;
            g.P[8, 9].P = pictureBox122;
            g.P[8, 10].P = pictureBox123;
            g.P[8, 11].P = pictureBox124;
            g.P[8, 12].P = pictureBox125;
            g.P[8, 13].P = pictureBox126;
            g.P[9, 0].P = pictureBox127;
            g.P[9, 1].P = pictureBox128;
            g.P[9, 2].P = pictureBox129;
            g.P[9, 3].P = pictureBox130;
            g.P[9, 4].P = pictureBox131;
            g.P[9, 5].P = pictureBox132;
            g.P[9, 6].P = pictureBox133;
            g.P[9, 7].P = pictureBox134;
            g.P[9, 8].P = pictureBox135;
            g.P[9, 9].P = pictureBox136;
            g.P[9, 10].P = pictureBox137;
            g.P[9, 11].P = pictureBox138;
            g.P[9, 12].P = pictureBox139;
            g.P[9, 13].P = pictureBox140;
            g.P[10, 0].P = pictureBox141;
            g.P[10, 1].P = pictureBox142;
            g.P[10, 2].P = pictureBox143;
            g.P[10, 3].P = pictureBox144;
            g.P[10, 4].P = pictureBox145;
            g.P[10, 5].P = pictureBox146;
            g.P[10, 6].P = pictureBox147;
            g.P[10, 7].P = pictureBox148;
            g.P[10, 8].P = pictureBox149;
            g.P[10, 9].P = pictureBox150;
            g.P[10, 10].P = pictureBox151;
            g.P[10, 11].P = pictureBox152;
            g.P[10, 12].P = pictureBox153;
            g.P[10, 13].P = pictureBox154;
            g.P[11, 0].P = pictureBox155;
            g.P[11, 1].P = pictureBox156;
            g.P[11, 2].P = pictureBox157;
            g.P[11, 3].P = pictureBox158;
            g.P[11, 4].P = pictureBox159;
            g.P[11, 5].P = pictureBox160;
            g.P[11, 6].P = pictureBox161;
            g.P[11, 7].P = pictureBox162;
            g.P[11, 8].P = pictureBox163;
            g.P[11, 9].P = pictureBox164;
            g.P[11, 10].P = pictureBox165;
            g.P[11, 11].P = pictureBox166;
            g.P[11, 12].P = pictureBox167;
            g.P[11, 13].P = pictureBox168;
            g.P[12, 0].P = pictureBox169;
            g.P[12, 1].P = pictureBox170;
            g.P[12, 2].P = pictureBox171;
            g.P[12, 3].P = pictureBox172;
            g.P[12, 3].P = pictureBox172;
            g.P[12, 4].P = pictureBox173;
            g.P[12, 5].P = pictureBox174;
            g.P[12, 6].P = pictureBox175;
            g.P[12, 7].P = pictureBox176;
            g.P[12, 8].P = pictureBox177;
            g.P[12, 9].P = pictureBox178;
            g.P[12, 10].P = pictureBox179;
            g.P[12, 11].P = pictureBox180;
            g.P[12, 12].P = pictureBox181;
            g.P[12, 13].P = pictureBox182;
            g.P[13, 0].P = pictureBox183;
            g.P[13, 1].P = pictureBox184;
            g.P[13, 2].P = pictureBox185;
            g.P[13, 3].P = pictureBox186;
            g.P[13, 4].P = pictureBox187;
            g.P[13, 5].P= pictureBox188;
            g.P[13, 6].P = pictureBox189;
            g.P[13, 7].P = pictureBox190;
            g.P[13, 8].P = pictureBox191;
            g.P[13, 9].P = pictureBox192;
            g.P[13, 10].P = pictureBox193;
            g.P[13, 11].P = pictureBox194;
            g.P[13, 12].P = pictureBox195;
            g.P[13, 13].P = pictureBox196;
            g.P[14, 0].P = pictureBox197;
            g.P[14, 1].P = pictureBox198;
            g.P[14, 2].P = pictureBox199;
            g.P[14, 3].P = pictureBox200;
            g.P[14, 4].P = pictureBox201;
            g.P[14, 5].P = pictureBox202;
            g.P[14, 6].P = pictureBox203;
            g.P[14, 7].P = pictureBox204;
            g.P[14, 8].P = pictureBox205;
            g.P[14, 9].P = pictureBox206;
            g.P[14, 10].P = pictureBox207;
            g.P[14, 11].P = pictureBox208;
            g.P[14, 12].P = pictureBox209;
            g.P[14, 13].P = pictureBox210;
            g.P[15, 0].P = pictureBox211;
            g.P[15, 1].P = pictureBox212;
            g.P[15, 2].P = pictureBox213;
            g.P[15, 3].P = pictureBox214;
            g.P[15, 4].P = pictureBox215;
            g.P[15, 5].P = pictureBox216;
            g.P[15, 6].P = pictureBox217;
            g.P[15, 7].P = pictureBox218;
            g.P[15, 8].P = pictureBox219;
            g.P[15, 9].P = pictureBox220;
            g.P[15, 10].P = pictureBox221;
            g.P[15, 11].P = pictureBox222;
            g.P[15, 12].P = pictureBox223;
            g.P[15, 13].P = pictureBox224;
            g.P[16, 0].P = pictureBox225;
            g.P[16, 1].P = pictureBox226;
            g.P[16, 2].P = pictureBox227;
            g.P[16, 3].P = pictureBox228;
            g.P[16, 4].P = pictureBox229;
            g.P[16, 5].P = pictureBox230;
            g.P[16, 6].P = pictureBox231;
            g.P[16, 7].P = pictureBox232;
            g.P[16, 8].P = pictureBox233;
            g.P[16, 9].P = pictureBox234;
            g.P[16, 10].P = pictureBox235;
            g.P[16, 11].P = pictureBox236;
            g.P[16, 12].P = pictureBox237;
            g.P[16, 13].P = pictureBox238;
            g.P[17, 0].P = pictureBox239;
            g.P[17, 1].P = pictureBox240;
            g.P[17, 2].P = pictureBox241;
            g.P[17, 3].P = pictureBox242;
            g.P[17, 4].P = pictureBox243;
            g.P[17, 5].P = pictureBox244;
            g.P[17, 6].P = pictureBox245;
            g.P[17, 7].P = pictureBox246;
            g.P[17, 8].P = pictureBox247;
            g.P[17, 9].P = pictureBox248;
            g.P[17, 10].P = pictureBox249;
            g.P[17, 11].P = pictureBox250;
            g.P[17, 12].P = pictureBox251;
            g.P[17, 13].P = pictureBox252;
            #endregion
            #region "Initialization of the PictureBox that compose the next piece in the class"
            g.Piece.NextPiece[0, 0].P = pictureBo00;
            g.Piece.NextPiece[0, 1].P = pictureBo01;
            g.Piece.NextPiece[0, 2].P = pictureBo02;
            g.Piece.NextPiece[0, 3].P = pictureBo03;
            g.Piece.NextPiece[1, 0].P = pictureBo10;
            g.Piece.NextPiece[1, 1].P = pictureBo11;
            g.Piece.NextPiece[1, 2].P = pictureBo12;
            g.Piece.NextPiece[1, 3].P = pictureBo13;
            g.Piece.NextPiece[2, 0].P = pictureBo20;
            g.Piece.NextPiece[2, 1].P = pictureBo21;
            g.Piece.NextPiece[2, 2].P = pictureBo22;
            g.Piece.NextPiece[2, 3].P = pictureBo23;
            g.Piece.NextPiece[3, 0].P = pictureBo30;
            g.Piece.NextPiece[3, 1].P = pictureBo31;
            g.Piece.NextPiece[3, 2].P = pictureBo32;
            g.Piece.NextPiece[3, 3].P = pictureBo33;
            #endregion
            g.ScoreLabel = lblScore;
            g.LevelLabel = lblLevel;
            g.MessageLabel = lblMessage;
            g.GameForm = this;
            g.Piece.GetCasualPiece();//It is generated the first piece to the interface

        }

        /// <summary>Apply the settings saved in Settings class in the interface object</summary>
        private void ApplySettings() {
            #region ApplicaImpostazioni
            this.BackColor = TetrisSettings.FormBackgroundColor;//Apply the background color of the window
            for (int i = 0; i <= 17; i++)
                for (int j = 0; j <= 13; j++)//Apply the background color of picturebox
                    g.P[i, j].P.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo00.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo01.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo02.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo03.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo10.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo11.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo12.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo13.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo20.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo21.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo22.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo23.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo30.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo31.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo32.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            pictureBo33.BackColor = TetrisSettings.PictureBoxBackgroundColor;
            //Apply the color to the border
            //Apply the color to the border of the box of tetris
            BordoAlto.BackColor = TetrisSettings.TetrisBorderColor;
            BordoBasso.BackColor = TetrisSettings.TetrisBorderColor;
            BordoDestro.BackColor = TetrisSettings.TetrisBorderColor;
            BordoSinistro.BackColor = TetrisSettings.TetrisBorderColor;
            //Apply the color to the border of the box next piece
            BordoAltoProssimo.BackColor = TetrisSettings.TetrisBorderColor;
            BordoBassoProssimo.BackColor = TetrisSettings.TetrisBorderColor;
            BordoDestroProssimo.BackColor = TetrisSettings.TetrisBorderColor;
            BordoSinistroProssimo.BackColor = TetrisSettings.TetrisBorderColor;
            //Apply the color to the titles of the blocks
            gbxLivello.ForeColor = TetrisSettings.TitleColor;
            gbxNextPiece.ForeColor = TetrisSettings.TitleColor;
            gbxPunti.ForeColor = TetrisSettings.TitleColor;
            //Apply the color to written in the blocks
            lblTestoLivello.ForeColor = TetrisSettings.TextColor;
            lblLevel.ForeColor = TetrisSettings.TextColor;         
            lblScore.ForeColor = TetrisSettings.TextColor;
            lblNomeGiocatore.ForeColor = TetrisSettings.TetrisBorderColor;
            lblMessage.ForeColor = TetrisSettings.TextColor;
            #endregion
        }

        private void frmTetris_Load(object sender, EventArgs e) {
            InizializzaInterfacciaInClasse();
            ApplySettings(); 
        }
      
        Form callerForm = new Form();
        /// <summary>It contains the form caller to be displayed again at the end of this</summary>
        public Form CallerForm {
            get { return callerForm; }
            set { callerForm = value; }
        }


        /// <summary>Manages keystrokes moving bricks on Tetris</summary>
        private void frmTetris_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Right:
                    if (g.Pausa == false) g.posY++;//The brick is moved to the right
                    break;
                case Keys.Left:
                    if (g.Pausa == false) g.posY--;//The brick is moved to the left
                    break;
                case Keys.Down:
                    if (g.Pausa == false) g.posX++;//The brick that falls, will fall faster    
                    break;
                case Keys.Space://It will rotate the shape of the brick
                case Keys.Up:
                    if (g.Pausa == false) g.Piece.CanRotate();
                    break;
                case Keys.P://Put the game on pause
                    if (g.Pausa == false) {
                        g.Pausa = true;
                        lblMessage.Text = GAME_PAUSE_STRING;
                    } else {
                        g.Pausa = false;
                        lblMessage.Text="";
                    }
                    break;
                case Keys.Escape://Quits the game
                    this.Close();
                    break;
                default:
                    e.SuppressKeyPress = true;
                break;
            }
        }

        private void frmTetris_FormClosing(object sender, FormClosingEventArgs e) {
            //Check if you quit the game because you lost if you do not have to show the exit confirmation
            if (g.ExitForLosing == false) {
                g.Pausa = true;//Pause the game
                if (MessageBox.Show("Are you sure to exit game?", "Exit!", MessageBoxButtons.YesNo) ==
                    DialogResult.No) {
                    e.Cancel = true;//Cancel the game exit
                    g.Pausa = false;//Resume the game
                } else
                    callerForm.Visible = true;//Show the caller form
            } else
                callerForm.Visible = true;//Show the caller form
        }

        //When the form loses the display or state of the business game is paused
        private void frmTetris_Deactivate(object sender, EventArgs e) {
            g.Pausa = true;           
        }

        private void frmTetris_Activated(object sender, EventArgs e) {
            if (!(lblMessage.Text == GAME_PAUSE_STRING)) g.Pausa = false;            
        }

     
    }
}