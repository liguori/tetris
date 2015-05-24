using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris {
    public partial class frmStart : Form {
        public frmStart() {
            InitializeComponent();
        }

        private void btnGioca_Click(object sender, EventArgs e) {
            frmTetris game = new frmTetris();
            game.Show();
            game.CallerForm = this;
            this.Visible = false;
        }

        private void btnImpostazioni_Click(object sender, EventArgs e) {
            frmSettings sett = new frmSettings();
            sett.Show();
            sett.CallerForm = this;
            this.Visible = false;
        }

        private void frmInizio_Load(object sender, EventArgs e) {
            TetrisSettings.FormBackgroundColor = Color.LemonChiffon;
            TetrisSettings.PictureBoxBackgroundColor = Color.Pink;
            TetrisSettings.TetrisBorderColor = Color.Black;
            Scores.LoadScores();
        }

        private void btnInfo_Click(object sender, EventArgs e) {
            AboutBox info = new AboutBox();
            info.Show();
        }

        private void btnPunteggi_Click(object sender, EventArgs e) {
            frmScore scoreViewer = new frmScore();
            scoreViewer.Show();
        }
    }
}