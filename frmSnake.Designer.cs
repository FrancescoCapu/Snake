﻿
namespace Snake
{
    partial class frmSnake
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlCampoGioco = new System.Windows.Forms.Panel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.pnl = new System.Windows.Forms.Panel();
            this.pnlCampoGioco.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampoGioco
            // 
            this.pnlCampoGioco.AutoSize = true;
            this.pnlCampoGioco.BackColor = System.Drawing.Color.Black;
            this.pnlCampoGioco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCampoGioco.Controls.Add(this.pnl);
            this.pnlCampoGioco.Location = new System.Drawing.Point(0, 0);
            this.pnlCampoGioco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCampoGioco.Name = "pnlCampoGioco";
            this.pnlCampoGioco.Size = new System.Drawing.Size(862, 423);
            this.pnlCampoGioco.TabIndex = 0;
            // 
            // tmr
            // 
            this.tmr.Interval = 300;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // pnl
            // 
            this.pnl.Location = new System.Drawing.Point(57, 33);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(200, 100);
            this.pnl.TabIndex = 0;
            // 
            // frmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(936, 479);
            this.Controls.Add(this.pnlCampoGioco);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSnake";
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSnake_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSnake_KeyDown);
            this.pnlCampoGioco.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCampoGioco;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Panel pnl;
    }
}

