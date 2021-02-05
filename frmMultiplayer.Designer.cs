
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
            this.LblScorePlayer1 = new System.Windows.Forms.Label();
            this.LblPartialScorePlayer1 = new System.Windows.Forms.Label();
            this.LblPartialScorePlayer2 = new System.Windows.Forms.Label();
            this.LblScorePlayer2 = new System.Windows.Forms.Label();
            this.pnlCampoGioco.SuspendLayout();
            this.pnlScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.LblScorePlayer2);
            this.pnlScore.Controls.Add(this.LblPartialScorePlayer2);
            this.pnlScore.Controls.Add(this.LblPartialScorePlayer1);
            this.pnlScore.Controls.Add(this.LblScorePlayer1);
            this.pnlScore.Controls.SetChildIndex(this.lblScore, 0);
            this.pnlScore.Controls.SetChildIndex(this.lblTotalScore, 0);
            this.pnlScore.Controls.SetChildIndex(this.LblScorePlayer1, 0);
            this.pnlScore.Controls.SetChildIndex(this.LblPartialScorePlayer1, 0);
            this.pnlScore.Controls.SetChildIndex(this.LblPartialScorePlayer2, 0);
            this.pnlScore.Controls.SetChildIndex(this.LblScorePlayer2, 0);
            // 
            // tmrMulti
            // 
            this.tmrMulti.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // LblScorePlayer1
            // 
            this.LblScorePlayer1.AutoSize = true;
            this.LblScorePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.LblScorePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScorePlayer1.ForeColor = System.Drawing.Color.White;
            this.LblScorePlayer1.Location = new System.Drawing.Point(227, 39);
            this.LblScorePlayer1.Name = "LblScorePlayer1";
            this.LblScorePlayer1.Size = new System.Drawing.Size(177, 36);
            this.LblScorePlayer1.TabIndex = 2;
            this.LblScorePlayer1.Text = "Giocatore 1:";
            // 
            // LblPartialScorePlayer1
            // 
            this.LblPartialScorePlayer1.AutoSize = true;
            this.LblPartialScorePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.LblPartialScorePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPartialScorePlayer1.ForeColor = System.Drawing.Color.White;
            this.LblPartialScorePlayer1.Location = new System.Drawing.Point(410, 39);
            this.LblPartialScorePlayer1.Name = "LblPartialScorePlayer1";
            this.LblPartialScorePlayer1.Size = new System.Drawing.Size(32, 36);
            this.LblPartialScorePlayer1.TabIndex = 3;
            this.LblPartialScorePlayer1.Text = "4";
            // 
            // LblPartialScorePlayer2
            // 
            this.LblPartialScorePlayer2.AutoSize = true;
            this.LblPartialScorePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.LblPartialScorePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPartialScorePlayer2.ForeColor = System.Drawing.Color.White;
            this.LblPartialScorePlayer2.Location = new System.Drawing.Point(800, 39);
            this.LblPartialScorePlayer2.Name = "LblPartialScorePlayer2";
            this.LblPartialScorePlayer2.Size = new System.Drawing.Size(32, 36);
            this.LblPartialScorePlayer2.TabIndex = 4;
            this.LblPartialScorePlayer2.Text = "4";
            // 
            // LblScorePlayer2
            // 
            this.LblScorePlayer2.AutoSize = true;
            this.LblScorePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.LblScorePlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScorePlayer2.ForeColor = System.Drawing.Color.White;
            this.LblScorePlayer2.Location = new System.Drawing.Point(617, 39);
            this.LblScorePlayer2.Name = "LblScorePlayer2";
            this.LblScorePlayer2.Size = new System.Drawing.Size(177, 36);
            this.LblScorePlayer2.TabIndex = 5;
            this.LblScorePlayer2.Text = "Giocatore 2:";
            // 
            // frmMultiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 581);
            this.Name = "frmMultiplayer";
            this.Text = "frmMultiplayer";
            this.Load += new System.EventHandler(this.frmMultiplayer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSnake_KeyDown);
            this.pnlCampoGioco.ResumeLayout(false);
            this.pnlScore.ResumeLayout(false);
            this.pnlScore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrMulti;
        private System.Windows.Forms.Label LblScorePlayer2;
        private System.Windows.Forms.Label LblPartialScorePlayer2;
        private System.Windows.Forms.Label LblPartialScorePlayer1;
        private System.Windows.Forms.Label LblScorePlayer1;
    }
}