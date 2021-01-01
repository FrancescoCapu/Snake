
namespace Snake
{
    partial class Settings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSizeQuadrati = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDefaultSettings = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.trackBarSizeQuadrati = new System.Windows.Forms.TrackBar();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.cmbKeyTongue = new System.Windows.Forms.ComboBox();
            this.cmbKeyRight = new System.Windows.Forms.ComboBox();
            this.cmbKeyDown = new System.Windows.Forms.ComboBox();
            this.cmbKeyLeft = new System.Windows.Forms.ComboBox();
            this.cmbKeyUp = new System.Windows.Forms.ComboBox();
            this.lblUseTongue = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblUp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeQuadrati)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSizeQuadrati);
            this.panel1.Controls.Add(this.pnlButtons);
            this.panel1.Controls.Add(this.trackBarSizeQuadrati);
            this.panel1.Controls.Add(this.lblTitolo);
            this.panel1.Controls.Add(this.cmbKeyTongue);
            this.panel1.Controls.Add(this.cmbKeyRight);
            this.panel1.Controls.Add(this.cmbKeyDown);
            this.panel1.Controls.Add(this.cmbKeyLeft);
            this.panel1.Controls.Add(this.cmbKeyUp);
            this.panel1.Controls.Add(this.lblUseTongue);
            this.panel1.Controls.Add(this.lblRight);
            this.panel1.Controls.Add(this.lblDown);
            this.panel1.Controls.Add(this.lblLeft);
            this.panel1.Controls.Add(this.lblUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 949);
            this.panel1.TabIndex = 0;
            // 
            // lblSizeQuadrati
            // 
            this.lblSizeQuadrati.AutoSize = true;
            this.lblSizeQuadrati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeQuadrati.Location = new System.Drawing.Point(119, 348);
            this.lblSizeQuadrati.Name = "lblSizeQuadrati";
            this.lblSizeQuadrati.Size = new System.Drawing.Size(219, 26);
            this.lblSizeQuadrati.TabIndex = 24;
            this.lblSizeQuadrati.Text = "Grandezza quadratini";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDefaultSettings);
            this.pnlButtons.Controls.Add(this.btnSalva);
            this.pnlButtons.Location = new System.Drawing.Point(48, 624);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(440, 160);
            this.pnlButtons.TabIndex = 23;
            // 
            // btnDefaultSettings
            // 
            this.btnDefaultSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDefaultSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultSettings.Location = new System.Drawing.Point(0, 0);
            this.btnDefaultSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDefaultSettings.Name = "btnDefaultSettings";
            this.btnDefaultSettings.Size = new System.Drawing.Size(190, 160);
            this.btnDefaultSettings.TabIndex = 15;
            this.btnDefaultSettings.Text = "Ripristina impostazioni di default";
            this.btnDefaultSettings.UseVisualStyleBackColor = true;
            this.btnDefaultSettings.Click += new System.EventHandler(this.btnDefaultSettings_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.Location = new System.Drawing.Point(253, 0);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(187, 160);
            this.btnSalva.TabIndex = 21;
            this.btnSalva.Text = "Salva impostazioni";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // trackBarSizeQuadrati
            // 
            this.trackBarSizeQuadrati.Location = new System.Drawing.Point(263, 348);
            this.trackBarSizeQuadrati.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarSizeQuadrati.Maximum = 32;
            this.trackBarSizeQuadrati.Minimum = 8;
            this.trackBarSizeQuadrati.Name = "trackBarSizeQuadrati";
            this.trackBarSizeQuadrati.Size = new System.Drawing.Size(117, 69);
            this.trackBarSizeQuadrati.TabIndex = 1;
            this.trackBarSizeQuadrati.TickFrequency = 2;
            this.trackBarSizeQuadrati.Value = 8;
            this.trackBarSizeQuadrati.Scroll += new System.EventHandler(this.trackBarSizeQuadrati_Scroll);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(118, 16);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(346, 46);
            this.lblTitolo.TabIndex = 22;
            this.lblTitolo.Text = "Impostazioni tasti";
            // 
            // cmbKeyTongue
            // 
            this.cmbKeyTongue.FormattingEnabled = true;
            this.cmbKeyTongue.Location = new System.Drawing.Point(263, 288);
            this.cmbKeyTongue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKeyTongue.Name = "cmbKeyTongue";
            this.cmbKeyTongue.Size = new System.Drawing.Size(136, 33);
            this.cmbKeyTongue.TabIndex = 20;
            this.cmbKeyTongue.SelectedIndexChanged += new System.EventHandler(this.cmbKeyTongue_SelectedIndexChanged);
            // 
            // cmbKeyRight
            // 
            this.cmbKeyRight.FormattingEnabled = true;
            this.cmbKeyRight.Location = new System.Drawing.Point(263, 240);
            this.cmbKeyRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKeyRight.Name = "cmbKeyRight";
            this.cmbKeyRight.Size = new System.Drawing.Size(136, 33);
            this.cmbKeyRight.TabIndex = 19;
            this.cmbKeyRight.SelectedIndexChanged += new System.EventHandler(this.cmbKeyRight_SelectedIndexChanged);
            // 
            // cmbKeyDown
            // 
            this.cmbKeyDown.FormattingEnabled = true;
            this.cmbKeyDown.Location = new System.Drawing.Point(266, 185);
            this.cmbKeyDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKeyDown.Name = "cmbKeyDown";
            this.cmbKeyDown.Size = new System.Drawing.Size(136, 33);
            this.cmbKeyDown.TabIndex = 18;
            this.cmbKeyDown.SelectedIndexChanged += new System.EventHandler(this.cmbKeyDown_SelectedIndexChanged);
            // 
            // cmbKeyLeft
            // 
            this.cmbKeyLeft.FormattingEnabled = true;
            this.cmbKeyLeft.Location = new System.Drawing.Point(266, 118);
            this.cmbKeyLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKeyLeft.Name = "cmbKeyLeft";
            this.cmbKeyLeft.Size = new System.Drawing.Size(136, 33);
            this.cmbKeyLeft.TabIndex = 17;
            this.cmbKeyLeft.SelectedIndexChanged += new System.EventHandler(this.cmbKeyLeft_SelectedIndexChanged);
            // 
            // cmbKeyUp
            // 
            this.cmbKeyUp.FormattingEnabled = true;
            this.cmbKeyUp.Location = new System.Drawing.Point(263, 72);
            this.cmbKeyUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKeyUp.Name = "cmbKeyUp";
            this.cmbKeyUp.Size = new System.Drawing.Size(136, 33);
            this.cmbKeyUp.TabIndex = 16;
            this.cmbKeyUp.SelectedIndexChanged += new System.EventHandler(this.cmbKeyUp_SelectedIndexChanged);
            // 
            // lblUseTongue
            // 
            this.lblUseTongue.AutoSize = true;
            this.lblUseTongue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseTongue.Location = new System.Drawing.Point(115, 291);
            this.lblUseTongue.Name = "lblUseTongue";
            this.lblUseTongue.Size = new System.Drawing.Size(121, 26);
            this.lblUseTongue.TabIndex = 4;
            this.lblUseTongue.Text = "Usa lingua:";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.Location = new System.Drawing.Point(115, 240);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(82, 26);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Destra:";
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.Location = new System.Drawing.Point(117, 185);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(52, 26);
            this.lblDown.TabIndex = 2;
            this.lblDown.Text = "Giù:";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(117, 129);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(91, 26);
            this.lblLeft.TabIndex = 1;
            this.lblLeft.Text = "Sinistra:";
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.Location = new System.Drawing.Point(115, 72);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(45, 26);
            this.lblUp.TabIndex = 0;
            this.lblUp.Text = "Su:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 949);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeQuadrati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUseTongue;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Button btnDefaultSettings;
        private System.Windows.Forms.ComboBox cmbKeyTongue;
        private System.Windows.Forms.ComboBox cmbKeyRight;
        private System.Windows.Forms.ComboBox cmbKeyDown;
        private System.Windows.Forms.ComboBox cmbKeyLeft;
        private System.Windows.Forms.ComboBox cmbKeyUp;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblSizeQuadrati;
        private System.Windows.Forms.TrackBar trackBarSizeQuadrati;
    }
}