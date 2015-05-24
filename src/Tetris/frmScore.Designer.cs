namespace Tetris {
    partial class frmScore {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.lstNomi = new System.Windows.Forms.ListBox();
            this.lstPunti = new System.Windows.Forms.ListBox();
            this.lblNomi = new System.Windows.Forms.Label();
            this.lblPunti = new System.Windows.Forms.Label();
            this.lblNoScoreMessage = new System.Windows.Forms.Label();
            this.btnAzzera = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstNomi
            // 
            this.lstNomi.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNomi.FormattingEnabled = true;
            this.lstNomi.ItemHeight = 15;
            this.lstNomi.Location = new System.Drawing.Point(17, 34);
            this.lstNomi.Name = "lstNomi";
            this.lstNomi.Size = new System.Drawing.Size(199, 289);
            this.lstNomi.TabIndex = 0;
            this.lstNomi.SelectedIndexChanged += new System.EventHandler(this.lstNomi_SelectedIndexChanged);
            // 
            // lstPunti
            // 
            this.lstPunti.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPunti.FormattingEnabled = true;
            this.lstPunti.ItemHeight = 15;
            this.lstPunti.Location = new System.Drawing.Point(216, 34);
            this.lstPunti.Name = "lstPunti";
            this.lstPunti.Size = new System.Drawing.Size(116, 289);
            this.lstPunti.TabIndex = 1;
            this.lstPunti.SelectedIndexChanged += new System.EventHandler(this.lstPunti_SelectedIndexChanged);
            // 
            // lblNomi
            // 
            this.lblNomi.AutoSize = true;
            this.lblNomi.Font = new System.Drawing.Font("Snap ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomi.ForeColor = System.Drawing.Color.Red;
            this.lblNomi.Location = new System.Drawing.Point(17, 13);
            this.lblNomi.Name = "lblNomi";
            this.lblNomi.Size = new System.Drawing.Size(51, 18);
            this.lblNomi.TabIndex = 2;
            this.lblNomi.Text = "Name";
            // 
            // lblPunti
            // 
            this.lblPunti.AutoSize = true;
            this.lblPunti.Font = new System.Drawing.Font("Snap ITC", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunti.ForeColor = System.Drawing.Color.Red;
            this.lblPunti.Location = new System.Drawing.Point(213, 13);
            this.lblPunti.Name = "lblPunti";
            this.lblPunti.Size = new System.Drawing.Size(53, 18);
            this.lblPunti.TabIndex = 3;
            this.lblPunti.Text = "Score";
            // 
            // lblMessaggioNessunPunteggio
            // 
            this.lblNoScoreMessage.AutoSize = true;
            this.lblNoScoreMessage.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoScoreMessage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblNoScoreMessage.Location = new System.Drawing.Point(94, 163);
            this.lblNoScoreMessage.Name = "lblMessaggioNessunPunteggio";
            this.lblNoScoreMessage.Size = new System.Drawing.Size(161, 19);
            this.lblNoScoreMessage.TabIndex = 4;
            this.lblNoScoreMessage.Text = "No score in list";
            // 
            // btnAzzera
            // 
            this.btnAzzera.Location = new System.Drawing.Point(238, 326);
            this.btnAzzera.Name = "btnAzzera";
            this.btnAzzera.Size = new System.Drawing.Size(93, 23);
            this.btnAzzera.TabIndex = 5;
            this.btnAzzera.Text = "Reset scores";
            this.btnAzzera.UseVisualStyleBackColor = true;
            this.btnAzzera.Click += new System.EventHandler(this.btnAzzera_Click);
            // 
            // frmScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(349, 351);
            this.Controls.Add(this.btnAzzera);
            this.Controls.Add(this.lblNoScoreMessage);
            this.Controls.Add(this.lblPunti);
            this.Controls.Add(this.lblNomi);
            this.Controls.Add(this.lstPunti);
            this.Controls.Add(this.lstNomi);
            this.MaximizeBox = false;
            this.Name = "frmScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Score list";
            this.Load += new System.EventHandler(this.frmScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNomi;
        private System.Windows.Forms.ListBox lstPunti;
        private System.Windows.Forms.Label lblNomi;
        private System.Windows.Forms.Label lblPunti;
        private System.Windows.Forms.Label lblNoScoreMessage;
        private System.Windows.Forms.Button btnAzzera;
    }
}