using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.Properties;

namespace Tetris {
    public partial class frmSettings : Form {
        public frmSettings() {
            InitializeComponent();
        }

        Form formChiamante = new Form();
        /// <summary>Contiene il form chiamante che dovrà essere rivisualizzato alla chiusura di questo</summary>
        public Form CallerForm {
            get { return formChiamante; }
            set { formChiamante = value; }
        }

        private void frmOpzioni_FormClosing(object sender, FormClosingEventArgs e) {
            formChiamante.Visible = true;//Viene visualizzato il form chiamante
        }

        private void lblColoreTitoli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (dlgColore.ShowDialog() == DialogResult.OK) {
                lblTitleColor.LinkColor = dlgColore.Color;
                gbxNextPiece.ForeColor = dlgColore.Color;
                gbxLivello.ForeColor = dlgColore.Color;
                gbxPunteggio.ForeColor = dlgColore.Color;
                TetrisSettings.TitleColor = dlgColore.Color;
            }
        }

        private void frmOpzioni_Load(object sender, EventArgs e) {
            //Colore dei titoli
            lblTitleColor.LinkColor = TetrisSettings.TitleColor;
            gbxNextPiece.ForeColor = TetrisSettings.TitleColor;
            gbxLivello.ForeColor = TetrisSettings.TitleColor;
            gbxPunteggio.ForeColor = TetrisSettings.TitleColor;
            //Colore delle scritte
            lblLabelColor.LinkColor = TetrisSettings.TextColor;
            lblTestoLivello.ForeColor = TetrisSettings.TextColor;
            lblLivello.ForeColor = TetrisSettings.TextColor;
            lblPunteggio.ForeColor = TetrisSettings.TextColor;
            //Colore di sfondo del form di gioco
            lblFormColor.LinkColor = TetrisSettings.FormBackgroundColor;
            panel1.BackColor = TetrisSettings.FormBackgroundColor;
            //Colore di sfondo del riquadro del tetris
            lblTetrisColor.LinkColor = TetrisSettings.PictureBoxBackgroundColor;
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
            //Colore del bordo del Tetris
            lblTetrisBorderColor.LinkColor = TetrisSettings.TetrisBorderColor;
            BordoDestro.BackColor = TetrisSettings.TetrisBorderColor;
            BordoSinistro.BackColor = TetrisSettings.TetrisBorderColor;
            BordoInferiore.BackColor = TetrisSettings.TetrisBorderColor;
            BordoSuperiore.BackColor = TetrisSettings.TetrisBorderColor;
            if (TetrisSettings.SourceImage == TetrisSettings.SingleImageSource.File) {
                rdbSfogliaUnImmagine.Checked = true;
                txtPerocorsoFileSingolo.Text = TetrisSettings.SingleImage;
                pictureBo21.Image = Image.FromFile(TetrisSettings.SingleImage);
                pictureBo22.Image = Image.FromFile(TetrisSettings.SingleImage);
                pictureBo31.Image = Image.FromFile(TetrisSettings.SingleImage);
                pictureBo32.Image = Image.FromFile(TetrisSettings.SingleImage);
                pbxUnImmagine.Image = Image.FromFile(TetrisSettings.SingleImage);
            } else {
                rdbImmaginePredefinita.Checked = true;
            }
        }

        private void lblColoreScritte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (dlgColore.ShowDialog() == DialogResult.OK) {
                lblLabelColor.LinkColor = dlgColore.Color;
                lblTestoLivello.ForeColor = dlgColore.Color;
                lblLivello.ForeColor = dlgColore.Color;
                lblPunteggio.ForeColor = dlgColore.Color;
                TetrisSettings.TextColor = dlgColore.Color;
            }
        }

        private void lblColoreForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (dlgColore.ShowDialog() == DialogResult.OK) {
                lblFormColor.LinkColor = dlgColore.Color; ;
                panel1.BackColor = dlgColore.Color;
                TetrisSettings.FormBackgroundColor = dlgColore.Color;
            }
        }

        private void lblColoreTetris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (dlgColore.ShowDialog() == DialogResult.OK) {
                lblTetrisColor.LinkColor = dlgColore.Color;
                pictureBo00.BackColor = dlgColore.Color;
                pictureBo01.BackColor = dlgColore.Color;
                pictureBo02.BackColor = dlgColore.Color;
                pictureBo03.BackColor = dlgColore.Color;
                pictureBo10.BackColor = dlgColore.Color;
                pictureBo11.BackColor = dlgColore.Color;
                pictureBo12.BackColor = dlgColore.Color;
                pictureBo13.BackColor = dlgColore.Color;
                pictureBo20.BackColor = dlgColore.Color;
                pictureBo21.BackColor = dlgColore.Color;
                pictureBo22.BackColor = dlgColore.Color;
                pictureBo23.BackColor = dlgColore.Color;
                pictureBo30.BackColor = dlgColore.Color;
                pictureBo31.BackColor = dlgColore.Color;
                pictureBo32.BackColor = dlgColore.Color;
                pictureBo33.BackColor = dlgColore.Color;
                TetrisSettings.PictureBoxBackgroundColor = dlgColore.Color;
            }
        }

        private void lblBordoTetris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (dlgColore.ShowDialog() == DialogResult.OK) {
                lblTetrisBorderColor.LinkColor = dlgColore.Color;
                BordoSuperiore.BackColor = dlgColore.Color;
                BordoInferiore.BackColor = dlgColore.Color;
                BordoSinistro.BackColor = dlgColore.Color;
                BordoDestro.BackColor = dlgColore.Color;
                TetrisSettings.TetrisBorderColor = dlgColore.Color;
            }
        }

        private void btnSfogliaUnImmagine_Click(object sender, EventArgs e) {
            bool FinestraAperta = dlgApri.ShowDialog() == DialogResult.OK;
            if (FinestraAperta &&(
                Image.FromFile(dlgApri.FileName).Height == 30 &&
                Image.FromFile(dlgApri.FileName).Width == 30)) {
                TetrisSettings.SingleImage = dlgApri.FileName;
                pbxUnImmagine.Image = Image.FromFile(dlgApri.FileName);
                pictureBo21.Image = Image.FromFile(dlgApri.FileName);
                pictureBo22.Image = Image.FromFile(dlgApri.FileName);
                pictureBo31.Image = Image.FromFile(dlgApri.FileName);
                pictureBo32.Image = Image.FromFile(dlgApri.FileName);
                txtPerocorsoFileSingolo.Text = dlgApri.FileName;
            } else if (FinestraAperta && (Image.FromFile(dlgApri.FileName).Height != 30 ||
                Image.FromFile(dlgApri.FileName).Width != 30)) {
                    MessageBox.Show("They are allowed only images from simensioni 30x30 px");
            }
        }
        
        private void rdbSfogliaUnImmagine_CheckedChanged(object sender, EventArgs e) {
            if (rdbSfogliaUnImmagine.Checked) {
                txtPerocorsoFileSingolo.Enabled = true;
                pbxUnImmagine.Enabled = true;
                btnSfogliaUnImmagine.Enabled = true;
                if (txtPerocorsoFileSingolo.Text.Trim() != "") {
                    pictureBo21.Image = Image.FromFile(txtPerocorsoFileSingolo.Text.Trim());
                    pictureBo22.Image = Image.FromFile(txtPerocorsoFileSingolo.Text.Trim());
                    pictureBo31.Image = Image.FromFile(txtPerocorsoFileSingolo.Text.Trim());
                    pictureBo32.Image = Image.FromFile(txtPerocorsoFileSingolo.Text.Trim());
                }
            }
            TetrisSettings.SourceImage = TetrisSettings.SingleImageSource.File;
        }

        private void rdbImmaginePredefinita_CheckedChanged(object sender, EventArgs e) {
            txtPerocorsoFileSingolo.Enabled = false;
            pbxUnImmagine.Enabled = false;
            btnSfogliaUnImmagine.Enabled = false;
            pictureBo21.Image = Properties.Resources.block;
            pictureBo22.Image = Properties.Resources.block;
            pictureBo31.Image = Properties.Resources.block;
            pictureBo32.Image = Properties.Resources.block;
            TetrisSettings.SourceImage = TetrisSettings.SingleImageSource.Resources;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (rdbSfogliaUnImmagine.Checked && txtPerocorsoFileSingolo.Text.Trim() == "") {
                MessageBox.Show("Please select the image to compose the piece", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else {
                this.Close();
            }
        }

    }
}