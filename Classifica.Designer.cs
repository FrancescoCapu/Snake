
namespace Snake
{
    partial class Classifica
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
            this.cmbClassifica = new System.Windows.Forms.ComboBox();
            this.lstClassifica = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbClassifica
            // 
            this.cmbClassifica.FormattingEnabled = true;
            this.cmbClassifica.Items.AddRange(new object[] {
            "livello 1",
            "livello 2",
            "livello 3"});
            this.cmbClassifica.Location = new System.Drawing.Point(12, 12);
            this.cmbClassifica.Name = "cmbClassifica";
            this.cmbClassifica.Size = new System.Drawing.Size(260, 28);
            this.cmbClassifica.TabIndex = 0;
            // 
            // lstClassifica
            // 
            this.lstClassifica.FormattingEnabled = true;
            this.lstClassifica.ItemHeight = 20;
            this.lstClassifica.Location = new System.Drawing.Point(13, 47);
            this.lstClassifica.Name = "lstClassifica";
            this.lstClassifica.Size = new System.Drawing.Size(259, 364);
            this.lstClassifica.TabIndex = 1;
            // 
            // Classifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 429);
            this.Controls.Add(this.lstClassifica);
            this.Controls.Add(this.cmbClassifica);
            this.Name = "Classifica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classifica";
            this.Load += new System.EventHandler(this.Classifica_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClassifica;
        private System.Windows.Forms.ListBox lstClassifica;
    }
}