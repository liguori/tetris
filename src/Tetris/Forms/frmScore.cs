using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris {
    public partial class frmScore : Form {
        public frmScore() {
            InitializeComponent();
        }

        private void ViewEmptyScoreInterface() {
            lblNomi.Visible = false;
            lstNomi.Visible = false;
            lblPunti.Visible = false;
            lstPunti.Visible = false;
            btnAzzera.Visible = false;
            lblNoScoreMessage.Visible = true;
        }

        private void frmScore_Load(object sender, EventArgs e) {
            lblNoScoreMessage.Visible = false;
            if (Scores.ScoreCount == -1) {
                ViewEmptyScoreInterface();
            }
            for (int i = 0; i <= Scores.ScoreCount; i++) {
                lstNomi.Items.Add((i + 1).ToString() + " " + Scores.CurrentScores[i].PlayerName);
                lstPunti.Items.Add(Scores.CurrentScores[i].Value);
                lstNomi.SelectedIndex = 0;
            }          
        }

        private void lstNomi_SelectedIndexChanged(object sender, EventArgs e) {
            lstPunti.SelectedIndex = lstNomi.SelectedIndex;
        }

        private void lstPunti_SelectedIndexChanged(object sender, EventArgs e) {
            lstNomi.SelectedIndex = lstPunti.SelectedIndex;
        }

        private void btnAzzera_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Reset all saved scores?", "Warning!!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes) {
                Scores.ResetScores();
                ViewEmptyScoreInterface();
            }
        }
    }
}