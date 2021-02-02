
namespace Snake
{
    partial class frmMultiplayer
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
            this.components = new System.ComponentModel.Container();
            this.tmrMulti = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrMulti
            // 
            this.tmrMulti.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // frmMultiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 518);
            this.Name = "frmMultiplayer";
            this.Text = "frmMultiplayer";
            this.Load += new System.EventHandler(this.frmMultiplayer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSnake_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrMulti;
    }
}