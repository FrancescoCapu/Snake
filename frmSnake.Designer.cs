
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
            this.pnlCampoGioco = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlCampoGioco
            // 
            this.pnlCampoGioco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCampoGioco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampoGioco.Location = new System.Drawing.Point(0, 0);
            this.pnlCampoGioco.Name = "pnlCampoGioco";
            this.pnlCampoGioco.Size = new System.Drawing.Size(800, 450);
            this.pnlCampoGioco.TabIndex = 0;
            this.pnlCampoGioco.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCampoGioco_Paint);
            // 
            // frmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCampoGioco);
            this.Name = "frmSnake";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCampoGioco;
    }
}

