
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
            this.trackBarVelocita = new System.Windows.Forms.TrackBar();
            this.lblVelocita = new System.Windows.Forms.Label();
            this.lblDimensioneCampo = new System.Windows.Forms.Label();
            this.pnlLivelli = new System.Windows.Forms.Panel();
            this.lblColorSnakePlayer2 = new System.Windows.Forms.Label();
            this.pnlColorsPlayer2 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlNumeroGiocatori = new System.Windows.Forms.Panel();
            this.lblNumeroGiocatori = new System.Windows.Forms.Label();
            this.radioButtonMultiplayer = new System.Windows.Forms.RadioButton();
            this.radioButtonSinglePlayer = new System.Windows.Forms.RadioButton();
            this.pnlDimensioneCampo = new System.Windows.Forms.Panel();
            this.trackBarDimensioneCampo = new System.Windows.Forms.TrackBar();
            this.lblColorSnake = new System.Windows.Forms.Label();
            this.lblSelezionaLivello = new System.Windows.Forms.Label();
            this.pnlColors = new System.Windows.Forms.Panel();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.picRight1 = new System.Windows.Forms.PictureBox();
            this.picLeft1 = new System.Windows.Forms.PictureBox();
            this.picCenter = new System.Windows.Forms.PictureBox();
            this.pnlNickname = new System.Windows.Forms.Panel();
            this.pnlNicknamePlayer2 = new System.Windows.Forms.Panel();
            this.txtNamePlayer2 = new System.Windows.Forms.TextBox();
            this.lblNamePlayer2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnClassifica = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlVelocita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocita)).BeginInit();
            this.pnlLivelli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlNumeroGiocatori.SuspendLayout();
            this.pnlDimensioneCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensioneCampo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).BeginInit();
            this.pnlNickname.SuspendLayout();
            this.pnlNicknamePlayer2.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(0, 1346);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(873, 66);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlVelocita
            // 
            this.pnlVelocita.BackColor = System.Drawing.Color.Transparent;
            this.pnlVelocita.Controls.Add(this.trackBarVelocita);
            this.pnlVelocita.Controls.Add(this.lblVelocita);
            this.pnlVelocita.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVelocita.Location = new System.Drawing.Point(0, 1146);
            this.pnlVelocita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlVelocita.Name = "pnlVelocita";
            this.pnlVelocita.Size = new System.Drawing.Size(873, 100);
            this.pnlVelocita.TabIndex = 1;
            // 
            // trackBarVelocita
            // 
            this.trackBarVelocita.LargeChange = 1;
            this.trackBarVelocita.Location = new System.Drawing.Point(83, 36);
            this.trackBarVelocita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarVelocita.Maximum = 2;
            this.trackBarVelocita.Name = "trackBarVelocita";
            this.trackBarVelocita.Size = new System.Drawing.Size(163, 56);
            this.trackBarVelocita.TabIndex = 1;
            this.trackBarVelocita.Value = 1;
            this.trackBarVelocita.Scroll += new System.EventHandler(this.trackBarVelocità_Scroll);
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
            this.lblDimensioneCampo.Location = new System.Drawing.Point(194, 36);
            this.lblDimensioneCampo.Name = "lblDimensioneCampo";
            this.lblDimensioneCampo.Size = new System.Drawing.Size(179, 25);
            this.lblDimensioneCampo.TabIndex = 2;
            this.lblDimensioneCampo.Text = "Dimensione campo";
            // 
            // pnlLivelli
            // 
            this.pnlLivelli.BackColor = System.Drawing.Color.Transparent;
            this.pnlLivelli.Controls.Add(this.lblColorSnakePlayer2);
            this.pnlLivelli.Controls.Add(this.pnlColorsPlayer2);
            this.pnlLivelli.Controls.Add(this.picLogo);
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
            this.pnlLivelli.Size = new System.Drawing.Size(873, 1246);
            this.pnlLivelli.TabIndex = 2;
            // 
            // lblColorSnakePlayer2
            // 
            this.lblColorSnakePlayer2.AutoSize = true;
            this.lblColorSnakePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorSnakePlayer2.Location = new System.Drawing.Point(295, 481);
            this.lblColorSnakePlayer2.Name = "lblColorSnakePlayer2";
            this.lblColorSnakePlayer2.Size = new System.Drawing.Size(414, 25);
            this.lblColorSnakePlayer2.TabIndex = 19;
            this.lblColorSnakePlayer2.Text = "Seleziona il colore del serpente del giocatore 2";
            // 
            // pnlColorsPlayer2
            // 
            this.pnlColorsPlayer2.Location = new System.Drawing.Point(224, 289);
            this.pnlColorsPlayer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlColorsPlayer2.Name = "pnlColorsPlayer2";
            this.pnlColorsPlayer2.Size = new System.Drawing.Size(224, 240);
            this.pnlColorsPlayer2.TabIndex = 14;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(723, 105);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 50);
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // pnlNumeroGiocatori
            // 
            this.pnlNumeroGiocatori.BackColor = System.Drawing.Color.Transparent;
            this.pnlNumeroGiocatori.Controls.Add(this.lblNumeroGiocatori);
            this.pnlNumeroGiocatori.Controls.Add(this.radioButtonMultiplayer);
            this.pnlNumeroGiocatori.Controls.Add(this.radioButtonSinglePlayer);
            this.pnlNumeroGiocatori.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNumeroGiocatori.Location = new System.Drawing.Point(0, 946);
            this.pnlNumeroGiocatori.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlNumeroGiocatori.Name = "pnlNumeroGiocatori";
            this.pnlNumeroGiocatori.Size = new System.Drawing.Size(873, 100);
            this.pnlNumeroGiocatori.TabIndex = 18;
            // 
            // lblNumeroGiocatori
            // 
            this.lblNumeroGiocatori.AutoSize = true;
            this.lblNumeroGiocatori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroGiocatori.Location = new System.Drawing.Point(71, 26);
            this.lblNumeroGiocatori.Name = "lblNumeroGiocatori";
            this.lblNumeroGiocatori.Size = new System.Drawing.Size(158, 25);
            this.lblNumeroGiocatori.TabIndex = 18;
            this.lblNumeroGiocatori.Text = "Modalità di gioco";
            // 
            // radioButtonMultiplayer
            // 
            this.radioButtonMultiplayer.AutoSize = true;
            this.radioButtonMultiplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMultiplayer.Location = new System.Drawing.Point(444, 34);
            this.radioButtonMultiplayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonMultiplayer.Name = "radioButtonMultiplayer";
            this.radioButtonMultiplayer.Size = new System.Drawing.Size(127, 29);
            this.radioButtonMultiplayer.TabIndex = 17;
            this.radioButtonMultiplayer.TabStop = true;
            this.radioButtonMultiplayer.Text = "Multiplayer";
            this.radioButtonMultiplayer.UseVisualStyleBackColor = true;
            this.radioButtonMultiplayer.CheckedChanged += new System.EventHandler(this.radioButtonMultiplayer_CheckedChanged);
            // 
            // radioButtonSinglePlayer
            // 
            this.radioButtonSinglePlayer.AutoSize = true;
            this.radioButtonSinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSinglePlayer.Location = new System.Drawing.Point(294, 34);
            this.radioButtonSinglePlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSinglePlayer.Name = "radioButtonSinglePlayer";
            this.radioButtonSinglePlayer.Size = new System.Drawing.Size(141, 29);
            this.radioButtonSinglePlayer.TabIndex = 0;
            this.radioButtonSinglePlayer.TabStop = true;
            this.radioButtonSinglePlayer.Text = "Singleplayer";
            this.radioButtonSinglePlayer.UseVisualStyleBackColor = true;
            this.radioButtonSinglePlayer.CheckedChanged += new System.EventHandler(this.radioButtonSinglePlayer_CheckedChanged);
            // 
            // pnlDimensioneCampo
            // 
            this.pnlDimensioneCampo.BackColor = System.Drawing.Color.Transparent;
            this.pnlDimensioneCampo.Controls.Add(this.trackBarDimensioneCampo);
            this.pnlDimensioneCampo.Controls.Add(this.lblDimensioneCampo);
            this.pnlDimensioneCampo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDimensioneCampo.Location = new System.Drawing.Point(0, 1046);
            this.pnlDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDimensioneCampo.Name = "pnlDimensioneCampo";
            this.pnlDimensioneCampo.Size = new System.Drawing.Size(873, 100);
            this.pnlDimensioneCampo.TabIndex = 16;
            // 
            // trackBarDimensioneCampo
            // 
            this.trackBarDimensioneCampo.LargeChange = 1;
            this.trackBarDimensioneCampo.Location = new System.Drawing.Point(291, 18);
            this.trackBarDimensioneCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarDimensioneCampo.Maximum = 2;
            this.trackBarDimensioneCampo.Name = "trackBarDimensioneCampo";
            this.trackBarDimensioneCampo.Size = new System.Drawing.Size(186, 56);
            this.trackBarDimensioneCampo.TabIndex = 1;
            this.trackBarDimensioneCampo.Value = 1;
            this.trackBarDimensioneCampo.Scroll += new System.EventHandler(this.trackBarDimensioneCampo_Scroll);
            // 
            // lblColorSnake
            // 
            this.lblColorSnake.AutoSize = true;
            this.lblColorSnake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorSnake.Location = new System.Drawing.Point(322, 130);
            this.lblColorSnake.Name = "lblColorSnake";
            this.lblColorSnake.Size = new System.Drawing.Size(282, 25);
            this.lblColorSnake.TabIndex = 15;
            this.lblColorSnake.Text = "Seleziona il colore del serpente";
            // 
            // lblSelezionaLivello
            // 
            this.lblSelezionaLivello.AutoSize = true;
            this.lblSelezionaLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelezionaLivello.Location = new System.Drawing.Point(295, 66);
            this.lblSelezionaLivello.Name = "lblSelezionaLivello";
            this.lblSelezionaLivello.Size = new System.Drawing.Size(179, 25);
            this.lblSelezionaLivello.TabIndex = 14;
            this.lblSelezionaLivello.Text = "Seleziona un livello";
            // 
            // pnlColors
            // 
            this.pnlColors.Location = new System.Drawing.Point(290, 202);
            this.pnlColors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlColors.Name = "pnlColors";
            this.pnlColors.Size = new System.Drawing.Size(224, 240);
            this.pnlColors.TabIndex = 13;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(41, 106);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.picRight1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picRight1.Name = "picRight1";
            this.picRight1.Size = new System.Drawing.Size(100, 50);
            this.picRight1.TabIndex = 7;
            this.picRight1.TabStop = false;
            // 
            // picLeft1
            // 
            this.picLeft1.Location = new System.Drawing.Point(201, 106);
            this.picLeft1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLeft1.Name = "picLeft1";
            this.picLeft1.Size = new System.Drawing.Size(100, 50);
            this.picLeft1.TabIndex = 6;
            this.picLeft1.TabStop = false;
            // 
            // picCenter
            // 
            this.picCenter.Location = new System.Drawing.Point(308, 106);
            this.picCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(100, 50);
            this.picCenter.TabIndex = 5;
            this.picCenter.TabStop = false;
            // 
            // pnlNickname
            // 
            this.pnlNickname.BackColor = System.Drawing.Color.Transparent;
            this.pnlNickname.Controls.Add(this.pnlNicknamePlayer2);
            this.pnlNickname.Controls.Add(this.txtNome);
            this.pnlNickname.Controls.Add(this.lblNome);
            this.pnlNickname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNickname.Location = new System.Drawing.Point(0, 1246);
            this.pnlNickname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlNickname.Name = "pnlNickname";
            this.pnlNickname.Size = new System.Drawing.Size(873, 100);
            this.pnlNickname.TabIndex = 12;
            // 
            // pnlNicknamePlayer2
            // 
            this.pnlNicknamePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.pnlNicknamePlayer2.Controls.Add(this.txtNamePlayer2);
            this.pnlNicknamePlayer2.Controls.Add(this.lblNamePlayer2);
            this.pnlNicknamePlayer2.Location = new System.Drawing.Point(444, 5);
            this.pnlNicknamePlayer2.Name = "pnlNicknamePlayer2";
            this.pnlNicknamePlayer2.Size = new System.Drawing.Size(379, 70);
            this.pnlNicknamePlayer2.TabIndex = 19;
            // 
            // txtNamePlayer2
            // 
            this.txtNamePlayer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamePlayer2.Location = new System.Drawing.Point(167, 21);
            this.txtNamePlayer2.Name = "txtNamePlayer2";
            this.txtNamePlayer2.Size = new System.Drawing.Size(100, 30);
            this.txtNamePlayer2.TabIndex = 1;
            this.txtNamePlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNamePlayer2
            // 
            this.lblNamePlayer2.AutoSize = true;
            this.lblNamePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlayer2.Location = new System.Drawing.Point(12, 21);
            this.lblNamePlayer2.Name = "lblNamePlayer2";
            this.lblNamePlayer2.Size = new System.Drawing.Size(64, 25);
            this.lblNamePlayer2.TabIndex = 0;
            this.lblNamePlayer2.Text = "label1";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(278, 50);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(40, 30);
            this.txtNome.TabIndex = 15;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(18, 50);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(217, 25);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Inserisci il tuo nickname";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Transparent;
            this.pnlSettings.Controls.Add(this.btnClassifica);
            this.pnlSettings.Controls.Add(this.btnSettings);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(873, 68);
            this.pnlSettings.TabIndex = 13;
            // 
            // btnClassifica
            // 
            this.btnClassifica.Location = new System.Drawing.Point(0, 0);
            this.btnClassifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClassifica.Name = "btnClassifica";
            this.btnClassifica.Size = new System.Drawing.Size(84, 68);
            this.btnClassifica.TabIndex = 6;
            this.btnClassifica.Text = "Classifica";
            this.btnClassifica.UseVisualStyleBackColor = true;
            this.btnClassifica.Click += new System.EventHandler(this.btnClassifica_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.Location = new System.Drawing.Point(798, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 68);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 1412);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocita)).EndInit();
            this.pnlLivelli.ResumeLayout(false);
            this.pnlLivelli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlNumeroGiocatori.ResumeLayout(false);
            this.pnlNumeroGiocatori.PerformLayout();
            this.pnlDimensioneCampo.ResumeLayout(false);
            this.pnlDimensioneCampo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensioneCampo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).EndInit();
            this.pnlNickname.ResumeLayout(false);
            this.pnlNickname.PerformLayout();
            this.pnlNicknamePlayer2.ResumeLayout(false);
            this.pnlNicknamePlayer2.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Panel pnlNicknamePlayer2;
        private System.Windows.Forms.TextBox txtNamePlayer2;
        private System.Windows.Forms.Label lblNamePlayer2;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlColorsPlayer2;
        private System.Windows.Forms.Label lblColorSnakePlayer2;
    }
}