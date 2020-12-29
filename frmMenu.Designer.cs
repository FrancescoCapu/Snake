
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
            this.pnlVelocita = new System.Windows.Forms.Panel();
            this.lblVelocita = new System.Windows.Forms.Label();
            this.lblDimensioneCampo = new System.Windows.Forms.Label();
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
            this.btnClassifica = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblSelezionaLivello = new System.Windows.Forms.Label();
            this.lblColorSnake = new System.Windows.Forms.Label();
            this.trackBarVelocita = new System.Windows.Forms.TrackBar();
            this.trackBarDimensioneCampo = new System.Windows.Forms.TrackBar();
            this.pnlDimensioneCampo = new System.Windows.Forms.Panel();
            this.radioButtonSinglePlayer = new System.Windows.Forms.RadioButton();
            this.radioButtonMultiplayer = new System.Windows.Forms.RadioButton();
            this.pnlNumeroGiocatori = new System.Windows.Forms.Panel();
            this.lblNumeroGiocatori = new System.Windows.Forms.Label();
            this.pnlVelocita.SuspendLayout();
            this.pnlLivelli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).BeginInit();
            this.pnlNickname.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensioneCampo)).BeginInit();
            this.pnlDimensioneCampo.SuspendLayout();
            this.pnlNumeroGiocatori.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(0, 907);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(789, 66);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlVelocita
            // 
            this.pnlVelocita.Controls.Add(this.trackBarVelocita);
            this.pnlVelocita.Controls.Add(this.lblVelocita);
            this.pnlVelocita.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVelocita.Location = new System.Drawing.Point(0, 707);
            this.pnlVelocita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlVelocita.Name = "pnlVelocita";
            this.pnlVelocita.Size = new System.Drawing.Size(789, 100);
            this.pnlVelocita.TabIndex = 1;
            // 
            // lblVelocita
            // 
            this.lblVelocita.AutoSize = true;
            this.lblVelocita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocita.Location = new System.Drawing.Point(20, 58);
            this.lblVelocita.Name = "lblVelocita";
            this.lblVelocita.Size = new System.Drawing.Size(82, 25);
            this.lblVelocita.TabIndex = 3;
            this.lblVelocita.Text = "Velocità";
            // 
            // lblDimensioneCampo
            // 
            this.lblDimensioneCampo.AutoSize = true;
            this.lblDimensioneCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimensioneCampo.Location = new System.Drawing.Point(193, 36);
            this.lblDimensioneCampo.Name = "lblDimensioneCampo";
            this.lblDimensioneCampo.Size = new System.Drawing.Size(179, 25);
            this.lblDimensioneCampo.TabIndex = 2;
            this.lblDimensioneCampo.Text = "Dimensione campo";
            // 
            // pnlLivelli
            // 
            this.pnlLivelli.Controls.Add(this.pnlNumeroGiocatori);
            this.pnlLivelli.Controls.Add(this.pnlDimensioneCampo);
            this.pnlLivelli.Controls.Add(this.lblColorSnake);
            this.pnlLivelli.Controls.Add(this.lblSelezionaLivello);
            this.pnlLivelli.Controls.Add(this.pnlColors);
            this.pnlLivelli.Controls.Add(this.btnLeft);
            this.pnlLivelli.Controls.Add(this.btnRight);
            this.pnlLivelli.Controls.Add(this.pnlVelocita);
            this.pnlLivelli.Controls.Add(this.picRight1);
            this.pnlLivelli.Controls.Add(this.picLeft1);
            this.pnlLivelli.Controls.Add(this.picCenter);
            this.pnlLivelli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLivelli.Location = new System.Drawing.Point(0, 0);
            this.pnlLivelli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLivelli.Name = "pnlLivelli";
            this.pnlLivelli.Size = new System.Drawing.Size(789, 807);
            this.pnlLivelli.TabIndex = 2;
            // 
            // pnlColors
            // 
            this.pnlColors.Location = new System.Drawing.Point(289, 202);
            this.pnlColors.Name = "pnlColors";
            this.pnlColors.Size = new System.Drawing.Size(200, 240);
            this.pnlColors.TabIndex = 13;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(41, 106);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "button2";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(611, 106);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 8;
            this.btnRight.Text = "button1";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // picRight1
            // 
            this.picRight1.Location = new System.Drawing.Point(414, 106);
            this.picRight1.Name = "picRight1";
            this.picRight1.Size = new System.Drawing.Size(100, 50);
            this.picRight1.TabIndex = 7;
            this.picRight1.TabStop = false;
            // 
            // picLeft1
            // 
            this.picLeft1.Location = new System.Drawing.Point(202, 106);
            this.picLeft1.Name = "picLeft1";
            this.picLeft1.Size = new System.Drawing.Size(100, 50);
            this.picLeft1.TabIndex = 6;
            this.picLeft1.TabStop = false;
            // 
            // picCenter
            // 
            this.picCenter.Location = new System.Drawing.Point(308, 106);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(100, 50);
            this.picCenter.TabIndex = 5;
            this.picCenter.TabStop = false;
            // 
            // pnlNickname
            // 
            this.pnlNickname.Controls.Add(this.lblNome);
            this.pnlNickname.Controls.Add(this.txtNome);
            this.pnlNickname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNickname.Location = new System.Drawing.Point(0, 807);
            this.pnlNickname.Name = "pnlNickname";
            this.pnlNickname.Size = new System.Drawing.Size(789, 100);
            this.pnlNickname.TabIndex = 12;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(23, 32);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(217, 25);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Inserisci il tuo nickname";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(190, 32);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(152, 30);
            this.txtNome.TabIndex = 11;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnClassifica);
            this.pnlSettings.Controls.Add(this.btnSettings);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(789, 67);
            this.pnlSettings.TabIndex = 13;
            // 
            // btnClassifica
            // 
            this.btnClassifica.Location = new System.Drawing.Point(347, 0);
            this.btnClassifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClassifica.Name = "btnClassifica";
            this.btnClassifica.Size = new System.Drawing.Size(84, 67);
            this.btnClassifica.TabIndex = 6;
            this.btnClassifica.Text = "Classifica";
            this.btnClassifica.UseVisualStyleBackColor = true;
            this.btnClassifica.Click += new System.EventHandler(this.btnClassifica_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.Location = new System.Drawing.Point(714, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 67);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblSelezionaLivello
            // 
            this.lblSelezionaLivello.AutoSize = true;
            this.lblSelezionaLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelezionaLivello.Location = new System.Drawing.Point(332, 83);
            this.lblSelezionaLivello.Name = "lblSelezionaLivello";
            this.lblSelezionaLivello.Size = new System.Drawing.Size(179, 25);
            this.lblSelezionaLivello.TabIndex = 14;
            this.lblSelezionaLivello.Text = "Seleziona un livello";
            // 
            // lblColorSnake
            // 
            this.lblColorSnake.AutoSize = true;
            this.lblColorSnake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorSnake.Location = new System.Drawing.Point(362, 163);
            this.lblColorSnake.Name = "lblColorSnake";
            this.lblColorSnake.Size = new System.Drawing.Size(282, 25);
            this.lblColorSnake.TabIndex = 15;
            this.lblColorSnake.Text = "Seleziona il colore del serpente";
            // 
            // trackBarVelocita
            // 
            this.trackBarVelocita.LargeChange = 1;
            this.trackBarVelocita.Location = new System.Drawing.Point(93, 45);
            this.trackBarVelocita.Maximum = 2;
            this.trackBarVelocita.Name = "trackBarVelocita";
            this.trackBarVelocita.Size = new System.Drawing.Size(183, 56);
            this.trackBarVelocita.TabIndex = 1;
            this.trackBarVelocita.Value = 1;
            this.trackBarVelocita.Scroll += new System.EventHandler(this.trackBarVelocità_Scroll);
            // 
            // trackBarDimensioneCampo
            // 
            this.trackBarDimensioneCampo.LargeChange = 1;
            this.trackBarDimensioneCampo.Location = new System.Drawing.Point(327, 23);
            this.trackBarDimensioneCampo.Maximum = 2;
            this.trackBarDimensioneCampo.Name = "trackBarDimensioneCampo";
            this.trackBarDimensioneCampo.Size = new System.Drawing.Size(209, 56);
            this.trackBarDimensioneCampo.TabIndex = 1;
            this.trackBarDimensioneCampo.Value = 1;
            this.trackBarDimensioneCampo.Scroll += new System.EventHandler(this.trackBarDimensioneCampo_Scroll);
            // 
            // pnlDimensioneCampo
            // 
            this.pnlDimensioneCampo.Controls.Add(this.trackBarDimensioneCampo);
            this.pnlDimensioneCampo.Controls.Add(this.lblDimensioneCampo);
            this.pnlDimensioneCampo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDimensioneCampo.Location = new System.Drawing.Point(0, 607);
            this.pnlDimensioneCampo.Name = "pnlDimensioneCampo";
            this.pnlDimensioneCampo.Size = new System.Drawing.Size(789, 100);
            this.pnlDimensioneCampo.TabIndex = 16;
            // 
            // radioButtonSinglePlayer
            // 
            this.radioButtonSinglePlayer.AutoSize = true;
            this.radioButtonSinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSinglePlayer.Location = new System.Drawing.Point(331, 43);
            this.radioButtonSinglePlayer.Name = "radioButtonSinglePlayer";
            this.radioButtonSinglePlayer.Size = new System.Drawing.Size(141, 29);
            this.radioButtonSinglePlayer.TabIndex = 0;
            this.radioButtonSinglePlayer.TabStop = true;
            this.radioButtonSinglePlayer.Text = "Singleplayer";
            this.radioButtonSinglePlayer.UseVisualStyleBackColor = true;
            // 
            // radioButtonMultiplayer
            // 
            this.radioButtonMultiplayer.AutoSize = true;
            this.radioButtonMultiplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMultiplayer.Location = new System.Drawing.Point(499, 43);
            this.radioButtonMultiplayer.Name = "radioButtonMultiplayer";
            this.radioButtonMultiplayer.Size = new System.Drawing.Size(127, 29);
            this.radioButtonMultiplayer.TabIndex = 17;
            this.radioButtonMultiplayer.TabStop = true;
            this.radioButtonMultiplayer.Text = "Multiplayer";
            this.radioButtonMultiplayer.UseVisualStyleBackColor = true;
            // 
            // pnlNumeroGiocatori
            // 
            this.pnlNumeroGiocatori.Controls.Add(this.lblNumeroGiocatori);
            this.pnlNumeroGiocatori.Controls.Add(this.radioButtonMultiplayer);
            this.pnlNumeroGiocatori.Controls.Add(this.radioButtonSinglePlayer);
            this.pnlNumeroGiocatori.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNumeroGiocatori.Location = new System.Drawing.Point(0, 507);
            this.pnlNumeroGiocatori.Name = "pnlNumeroGiocatori";
            this.pnlNumeroGiocatori.Size = new System.Drawing.Size(789, 100);
            this.pnlNumeroGiocatori.TabIndex = 18;
            // 
            // lblNumeroGiocatori
            // 
            this.lblNumeroGiocatori.AutoSize = true;
            this.lblNumeroGiocatori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroGiocatori.Location = new System.Drawing.Point(80, 32);
            this.lblNumeroGiocatori.Name = "lblNumeroGiocatori";
            this.lblNumeroGiocatori.Size = new System.Drawing.Size(158, 25);
            this.lblNumeroGiocatori.TabIndex = 18;
            this.lblNumeroGiocatori.Text = "Modalità di gioco";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 973);
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
            this.pnlVelocita.ResumeLayout(false);
            this.pnlVelocita.PerformLayout();
            this.pnlLivelli.ResumeLayout(false);
            this.pnlLivelli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).EndInit();
            this.pnlNickname.ResumeLayout(false);
            this.pnlNickname.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensioneCampo)).EndInit();
            this.pnlDimensioneCampo.ResumeLayout(false);
            this.pnlDimensioneCampo.PerformLayout();
            this.pnlNumeroGiocatori.ResumeLayout(false);
            this.pnlNumeroGiocatori.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlVelocita;
        private System.Windows.Forms.Label lblDimensioneCampo;
        private System.Windows.Forms.Panel pnlLivelli;
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
        private System.Windows.Forms.Label lblSelezionaLivello;
        private System.Windows.Forms.Label lblColorSnake;
        private System.Windows.Forms.TrackBar trackBarVelocita;
        private System.Windows.Forms.TrackBar trackBarDimensioneCampo;
        private System.Windows.Forms.Panel pnlDimensioneCampo;
        private System.Windows.Forms.RadioButton radioButtonMultiplayer;
        private System.Windows.Forms.RadioButton radioButtonSinglePlayer;
        private System.Windows.Forms.Panel pnlNumeroGiocatori;
        private System.Windows.Forms.Label lblNumeroGiocatori;
    }
}