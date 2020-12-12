
namespace Snake
{
    partial class frmMenu
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
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlDimensioneCampo = new System.Windows.Forms.Panel();
            this.cmbVelocita = new System.Windows.Forms.ComboBox();
            this.lblPropreta = new System.Windows.Forms.Label();
            this.lblDimensioneCampo = new System.Windows.Forms.Label();
            this.cmbDimensioneCampo = new System.Windows.Forms.ComboBox();
            this.pnlLivelli = new System.Windows.Forms.Panel();
            this.cmbLivelli = new System.Windows.Forms.ComboBox();
            this.lblLivelli = new System.Windows.Forms.Label();
            this.picCenter = new System.Windows.Forms.PictureBox();
            this.picLeft1 = new System.Windows.Forms.PictureBox();
            this.picRight1 = new System.Windows.Forms.PictureBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.pnlDimensioneCampo.SuspendLayout();
            this.pnlLivelli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Location = new System.Drawing.Point(0, 294);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(711, 66);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlDimensioneCampo
            // 
            this.pnlDimensioneCampo.Controls.Add(this.cmbVelocita);
            this.pnlDimensioneCampo.Controls.Add(this.lblPropreta);
            this.pnlDimensioneCampo.Controls.Add(this.lblDimensioneCampo);
            this.pnlDimensioneCampo.Controls.Add(this.cmbDimensioneCampo);
            this.pnlDimensioneCampo.Location = new System.Drawing.Point(501, 191);
            this.pnlDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDimensioneCampo.Name = "pnlDimensioneCampo";
            this.pnlDimensioneCampo.Size = new System.Drawing.Size(198, 103);
            this.pnlDimensioneCampo.TabIndex = 1;
            // 
            // cmbVelocita
            // 
            this.cmbVelocita.FormattingEnabled = true;
            this.cmbVelocita.Location = new System.Drawing.Point(14, 77);
            this.cmbVelocita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVelocita.Name = "cmbVelocita";
            this.cmbVelocita.Size = new System.Drawing.Size(129, 24);
            this.cmbVelocita.TabIndex = 4;
            // 
            // lblPropreta
            // 
            this.lblPropreta.AutoSize = true;
            this.lblPropreta.Location = new System.Drawing.Point(11, 58);
            this.lblPropreta.Name = "lblPropreta";
            this.lblPropreta.Size = new System.Drawing.Size(58, 17);
            this.lblPropreta.TabIndex = 3;
            this.lblPropreta.Text = "Velocità";
            // 
            // lblDimensioneCampo
            // 
            this.lblDimensioneCampo.AutoSize = true;
            this.lblDimensioneCampo.Location = new System.Drawing.Point(11, 7);
            this.lblDimensioneCampo.Name = "lblDimensioneCampo";
            this.lblDimensioneCampo.Size = new System.Drawing.Size(128, 17);
            this.lblDimensioneCampo.TabIndex = 2;
            this.lblDimensioneCampo.Text = "Dimensione campo";
            // 
            // cmbDimensioneCampo
            // 
            this.cmbDimensioneCampo.FormattingEnabled = true;
            this.cmbDimensioneCampo.Location = new System.Drawing.Point(14, 26);
            this.cmbDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDimensioneCampo.Name = "cmbDimensioneCampo";
            this.cmbDimensioneCampo.Size = new System.Drawing.Size(129, 24);
            this.cmbDimensioneCampo.TabIndex = 2;
            // 
            // pnlLivelli
            // 
            this.pnlLivelli.Controls.Add(this.btnLeft);
            this.pnlLivelli.Controls.Add(this.btnRight);
            this.pnlLivelli.Controls.Add(this.picRight1);
            this.pnlLivelli.Controls.Add(this.picLeft1);
            this.pnlLivelli.Controls.Add(this.picCenter);
            this.pnlLivelli.Controls.Add(this.pnlDimensioneCampo);
            this.pnlLivelli.Controls.Add(this.cmbLivelli);
            this.pnlLivelli.Controls.Add(this.lblLivelli);
            this.pnlLivelli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLivelli.Location = new System.Drawing.Point(0, 0);
            this.pnlLivelli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLivelli.Name = "pnlLivelli";
            this.pnlLivelli.Size = new System.Drawing.Size(711, 294);
            this.pnlLivelli.TabIndex = 2;
            // 
            // cmbLivelli
            // 
            this.cmbLivelli.FormattingEnabled = true;
            this.cmbLivelli.Location = new System.Drawing.Point(9, 258);
            this.cmbLivelli.Name = "cmbLivelli";
            this.cmbLivelli.Size = new System.Drawing.Size(121, 24);
            this.cmbLivelli.TabIndex = 4;
            // 
            // lblLivelli
            // 
            this.lblLivelli.AutoSize = true;
            this.lblLivelli.Location = new System.Drawing.Point(6, 241);
            this.lblLivelli.Name = "lblLivelli";
            this.lblLivelli.Size = new System.Drawing.Size(109, 17);
            this.lblLivelli.TabIndex = 3;
            this.lblLivelli.Text = "Selezione livello";
            // 
            // picCenter
            // 
            this.picCenter.Location = new System.Drawing.Point(308, 72);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(100, 50);
            this.picCenter.TabIndex = 5;
            this.picCenter.TabStop = false;
            // 
            // picLeft1
            // 
            this.picLeft1.Location = new System.Drawing.Point(202, 72);
            this.picLeft1.Name = "picLeft1";
            this.picLeft1.Size = new System.Drawing.Size(100, 50);
            this.picLeft1.TabIndex = 6;
            this.picLeft1.TabStop = false;
            // 
            // picRight1
            // 
            this.picRight1.Location = new System.Drawing.Point(414, 72);
            this.picRight1.Name = "picRight1";
            this.picRight1.Size = new System.Drawing.Size(100, 50);
            this.picRight1.TabIndex = 7;
            this.picRight1.TabStop = false;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(610, 81);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 8;
            this.btnRight.Text = "button1";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(35, 80);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "button2";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.pnlLivelli);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlDimensioneCampo.ResumeLayout(false);
            this.pnlDimensioneCampo.PerformLayout();
            this.pnlLivelli.ResumeLayout(false);
            this.pnlLivelli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlDimensioneCampo;
        private System.Windows.Forms.ComboBox cmbDimensioneCampo;
        private System.Windows.Forms.Label lblDimensioneCampo;
        private System.Windows.Forms.Panel pnlLivelli;
        private System.Windows.Forms.Label lblLivelli;
        private System.Windows.Forms.ComboBox cmbVelocita;
        private System.Windows.Forms.Label lblPropreta;
        private System.Windows.Forms.ComboBox cmbLivelli;
        private System.Windows.Forms.PictureBox picRight1;
        private System.Windows.Forms.PictureBox picLeft1;
        private System.Windows.Forms.PictureBox picCenter;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
    }
}