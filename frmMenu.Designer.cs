
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
            this.lblVelocita = new System.Windows.Forms.Label();
            this.lblDimensioneCampo = new System.Windows.Forms.Label();
            this.cmbDimensioneCampo = new System.Windows.Forms.ComboBox();
            this.pnlLivelli = new System.Windows.Forms.Panel();
            this.pnlColors = new System.Windows.Forms.Panel();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.picRight1 = new System.Windows.Forms.PictureBox();
            this.picLeft1 = new System.Windows.Forms.PictureBox();
            this.picCenter = new System.Windows.Forms.PictureBox();
            this.pnlNickname = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnClassifica = new System.Windows.Forms.Button();
            this.pnlDimensioneCampo.SuspendLayout();
            this.pnlLivelli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).BeginInit();
            this.pnlNickname.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Location = new System.Drawing.Point(0, 664);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(867, 82);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlDimensioneCampo
            // 
            this.pnlDimensioneCampo.Controls.Add(this.cmbVelocita);
            this.pnlDimensioneCampo.Controls.Add(this.lblVelocita);
            this.pnlDimensioneCampo.Controls.Add(this.lblDimensioneCampo);
            this.pnlDimensioneCampo.Controls.Add(this.cmbDimensioneCampo);
            this.pnlDimensioneCampo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDimensioneCampo.Location = new System.Drawing.Point(0, 379);
            this.pnlDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDimensioneCampo.Name = "pnlDimensioneCampo";
            this.pnlDimensioneCampo.Size = new System.Drawing.Size(867, 160);
            this.pnlDimensioneCampo.TabIndex = 1;
            // 
            // cmbVelocita
            // 
            this.cmbVelocita.FormattingEnabled = true;
            this.cmbVelocita.Location = new System.Drawing.Point(26, 96);
            this.cmbVelocita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVelocita.Name = "cmbVelocita";
            this.cmbVelocita.Size = new System.Drawing.Size(145, 28);
            this.cmbVelocita.TabIndex = 4;
            // 
            // lblVelocita
            // 
            this.lblVelocita.AutoSize = true;
            this.lblVelocita.Location = new System.Drawing.Point(22, 72);
            this.lblVelocita.Name = "lblVelocita";
            this.lblVelocita.Size = new System.Drawing.Size(66, 20);
            this.lblVelocita.TabIndex = 3;
            this.lblVelocita.Text = "Velocità";
            // 
            // lblDimensioneCampo
            // 
            this.lblDimensioneCampo.AutoSize = true;
            this.lblDimensioneCampo.Location = new System.Drawing.Point(370, 72);
            this.lblDimensioneCampo.Name = "lblDimensioneCampo";
            this.lblDimensioneCampo.Size = new System.Drawing.Size(145, 20);
            this.lblDimensioneCampo.TabIndex = 2;
            this.lblDimensioneCampo.Text = "Dimensione campo";
            // 
            // cmbDimensioneCampo
            // 
            this.cmbDimensioneCampo.FormattingEnabled = true;
            this.cmbDimensioneCampo.Location = new System.Drawing.Point(374, 96);
            this.cmbDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDimensioneCampo.Name = "cmbDimensioneCampo";
            this.cmbDimensioneCampo.Size = new System.Drawing.Size(145, 28);
            this.cmbDimensioneCampo.TabIndex = 2;
            // 
            // pnlLivelli
            // 
            this.pnlLivelli.Controls.Add(this.pnlColors);
            this.pnlLivelli.Controls.Add(this.btnLeft);
            this.pnlLivelli.Controls.Add(this.btnRight);
            this.pnlLivelli.Controls.Add(this.pnlDimensioneCampo);
            this.pnlLivelli.Controls.Add(this.picRight1);
            this.pnlLivelli.Controls.Add(this.picLeft1);
            this.pnlLivelli.Controls.Add(this.picCenter);
            this.pnlLivelli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLivelli.Location = new System.Drawing.Point(0, 0);
            this.pnlLivelli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLivelli.Name = "pnlLivelli";
            this.pnlLivelli.Size = new System.Drawing.Size(867, 539);
            this.pnlLivelli.TabIndex = 2;
            // 
            // pnlColors
            // 
            this.pnlColors.Location = new System.Drawing.Point(314, 203);
            this.pnlColors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlColors.Name = "pnlColors";
            this.pnlColors.Size = new System.Drawing.Size(225, 300);
            this.pnlColors.TabIndex = 13;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(46, 132);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(84, 29);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "button2";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(687, 132);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(84, 29);
            this.btnRight.TabIndex = 8;
            this.btnRight.Text = "button1";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // picRight1
            // 
            this.picRight1.Location = new System.Drawing.Point(466, 132);
            this.picRight1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picRight1.Name = "picRight1";
            this.picRight1.Size = new System.Drawing.Size(112, 62);
            this.picRight1.TabIndex = 7;
            this.picRight1.TabStop = false;
            // 
            // picLeft1
            // 
            this.picLeft1.Location = new System.Drawing.Point(227, 132);
            this.picLeft1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLeft1.Name = "picLeft1";
            this.picLeft1.Size = new System.Drawing.Size(112, 62);
            this.picLeft1.TabIndex = 6;
            this.picLeft1.TabStop = false;
            // 
            // picCenter
            // 
            this.picCenter.Location = new System.Drawing.Point(346, 132);
            this.picCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(112, 62);
            this.picCenter.TabIndex = 5;
            this.picCenter.TabStop = false;
            // 
            // pnlNickname
            // 
            this.pnlNickname.Controls.Add(this.lblNome);
            this.pnlNickname.Controls.Add(this.txtNome);
            this.pnlNickname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNickname.Location = new System.Drawing.Point(0, 539);
            this.pnlNickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlNickname.Name = "pnlNickname";
            this.pnlNickname.Size = new System.Drawing.Size(867, 125);
            this.pnlNickname.TabIndex = 12;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(26, 40);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(180, 20);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Inserisci il tuo nickname:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(214, 40);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(170, 26);
            this.txtNome.TabIndex = 11;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnClassifica);
            this.pnlSettings.Controls.Add(this.btnSettings);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(867, 84);
            this.pnlSettings.TabIndex = 13;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.Location = new System.Drawing.Point(783, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(84, 84);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClassifica
            // 
            this.btnClassifica.Location = new System.Drawing.Point(390, 0);
            this.btnClassifica.Name = "btnClassifica";
            this.btnClassifica.Size = new System.Drawing.Size(95, 84);
            this.btnClassifica.TabIndex = 6;
            this.btnClassifica.Text = "Classifica";
            this.btnClassifica.UseVisualStyleBackColor = true;
            this.btnClassifica.Click += new System.EventHandler(this.btnClassifica_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 746);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlLivelli);
            this.Controls.Add(this.pnlNickname);
            this.Controls.Add(this.btnStart);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlDimensioneCampo.ResumeLayout(false);
            this.pnlDimensioneCampo.PerformLayout();
            this.pnlLivelli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).EndInit();
            this.pnlNickname.ResumeLayout(false);
            this.pnlNickname.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlDimensioneCampo;
        private System.Windows.Forms.ComboBox cmbDimensioneCampo;
        private System.Windows.Forms.Label lblDimensioneCampo;
        private System.Windows.Forms.Panel pnlLivelli;
        private System.Windows.Forms.ComboBox cmbVelocita;
        private System.Windows.Forms.Label lblVelocita;
        private System.Windows.Forms.PictureBox picRight1;
        private System.Windows.Forms.PictureBox picLeft1;
        private System.Windows.Forms.PictureBox picCenter;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Panel pnlNickname;
        private System.Windows.Forms.Panel pnlColors;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClassifica;
    }
}