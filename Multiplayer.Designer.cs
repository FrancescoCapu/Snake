
namespace Snake
{
    partial class Multiplayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMultiplayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMultiplayer
            // 
            this.lblMultiplayer.AutoSize = true;
            this.lblMultiplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultiplayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMultiplayer.Location = new System.Drawing.Point(67, 173);
            this.lblMultiplayer.Name = "lblMultiplayer";
            this.lblMultiplayer.Size = new System.Drawing.Size(656, 113);
            this.lblMultiplayer.TabIndex = 0;
            this.lblMultiplayer.Text = "Coming Soon";
            this.lblMultiplayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Multiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMultiplayer);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Multiplayer";
            this.Text = "Multiplayer";
            this.Load += new System.EventHandler(this.Multiplayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMultiplayer;
    }
}