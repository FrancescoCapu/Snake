using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;

namespace Snake
{
    public partial class Settings : Form
    {
        Player player1;
        Player player2;

        public Settings(ref Player player1, ref Player player2)
        {
            InitializeComponent();
            this.player1 = player1;
            this.player2 = player2;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                cmbNumPlayers.Items.Add(i + 1);
            }

            SetPositions();

            AddKeysCmbUp(cmbKeyUp);
            AddKeysCmbLeft(cmbKeyLeft);
            AddKeysCmbDown(cmbKeyDown);
            AddKeysCmbRight(cmbKeyRight);
            AddKeysCmbTongue(cmbKeyTongue);

            AddKeysCmbUp(cmbKeyUpPlayer2);
            AddKeysCmbLeft(cmbKeyLeftPlayer2);
            AddKeysCmbDown(cmbKeyDownPlayer2);
            AddKeysCmbRight(cmbKeyRightPlayer2);
            AddKeysCmbTongue(cmbKeyTonguePlayer2);

            if (!ReadPreviousConfig())
                Config.DefaultSettings();
            UpdateCommands();

            cmbNumPlayers.SelectedItem = 1;
        }

        private void SetPositions()
        {
            this.Size = new Size(400, 630);

            lblTitolo.Location = new Point(this.Width / 2 - lblTitolo.Size.Width / 2, 20);

            lblNumPlayers.Location = new Point(this.Width / 2 - lblNumPlayers.Width - 20, lblTitolo.Location.Y + lblTitolo.Height + 20);
            cmbNumPlayers.Location = new Point(this.Width / 2 + 20, lblNumPlayers.Location.Y);

            pnlTop.Size = new Size(pnlTop.Width, cmbNumPlayers.Location.Y + cmbNumPlayers.Height + 15);

            SetPositionForPlayerSettings(lblPlayer1SettingsPrint, lblUp, cmbKeyUp, lblLeft, cmbKeyLeft, lblDown, cmbKeyDown, lblRight, cmbKeyRight, lblUseTongue, cmbKeyTongue, pnlSettingsPlayer1);
            SetPositionForPlayerSettings(lblPlayer2SettingsPrint, lblUpPlayer2, cmbKeyUpPlayer2, lblLeftPlayer2, cmbKeyLeftPlayer2, lblDownPlayer2, cmbKeyDownPlayer2, lblRightPlayer2, cmbKeyRightPlayer2, lblUseTonguePlayer2, cmbKeyTonguePlayer2, pnlSettingsPlayer2);

            pnlSettingsPlayers.Size = new Size(pnlSettingsPlayers.Width, pnlSettingsPlayer1.Height);

            lblSizeQuadrati.Location = new Point(pnlSettingsQuadratini.Width / 8, 0);
            lblSizeQuadrati.Text = "Grandezza\nquadratini";
            trackBarSizeQuadrati.Location = new Point(pnlSettingsQuadratini.Width / 3, lblSizeQuadrati.Location.Y);
            trackBarSizeQuadrati.Size = new Size(pnlSettingsQuadratini.Width - trackBarSizeQuadrati.Location.X - 30, 72);

            pnlButtons.Size = new Size(this.Width - 30 * 2, 85);
            pnlButtons.Location = new Point(30, lblSizeQuadrati.Location.Y + lblSizeQuadrati.Size.Height + 35);
            pnlButtons.Controls.Add(btnDefaultSettings);
            pnlButtons.Controls.Add(btnSalva);

            btnDefaultSettings.Size = new Size(pnlButtons.Size.Width / 2 - 15, 85);

            btnSalva.Size = btnDefaultSettings.Size;
        }

        private void SetPositionForPlayerSettings(Label lblPlayerNumber, Label lblUp, ComboBox cmbKeyUp, Label lblLeft, ComboBox cmbKeyLeft, Label lblDown, ComboBox cmbKeyDown, Label lblRight, ComboBox cmbKeyRight, Label lblUseTongue, ComboBox cmbKeyTongue, Panel pnlPadre)
        {
            lblPlayerNumber.Location = new Point(pnlSettingsPlayer1.Width / 2 - lblPlayer2SettingsPrint.Width / 2, 0);

            lblUp.Location = new Point(pnlSettingsPlayer1.Width / 2 - pnlSettingsPlayer1.Width / 4, lblPlayerNumber.Location.Y + lblPlayerNumber.Height + 20);
            cmbKeyUp.Location = new Point(pnlSettingsPlayer1.Width / 2, lblUp.Location.Y);

            lblLeft.Location = new Point(lblUp.Location.X, lblUp.Location.Y + lblUp.Size.Height + 15);
            cmbKeyLeft.Location = new Point(cmbKeyUp.Location.X, lblLeft.Location.Y);

            lblDown.Location = new Point(lblLeft.Location.X, lblLeft.Location.Y + lblLeft.Size.Height + 15);
            cmbKeyDown.Location = new Point(cmbKeyLeft.Location.X, lblDown.Location.Y);

            lblRight.Location = new Point(lblDown.Location.X, lblDown.Location.Y + lblDown.Size.Height + 15);
            cmbKeyRight.Location = new Point(cmbKeyDown.Location.X, lblRight.Location.Y);

            lblUseTongue.Location = new Point(lblRight.Location.X, lblRight.Location.Y + lblRight.Size.Height + 15);
            cmbKeyTongue.Location = new Point(cmbKeyRight.Location.X, lblUseTongue.Location.Y);

            int heightPnlSettings = cmbKeyTongue.Location.Y + cmbKeyTongue.Height - lblPlayerNumber.Location.Y;

            pnlPadre.Size = new Size(pnlPadre.Width, heightPnlSettings + 20);

            int heightForm = pnlTop.Height + pnlSettingsPlayers.Height + pnlSettingsQuadratini.Height + pnlButtons.Height;

            Size = new Size(400, heightForm);
        }

        private void UpdateCommands()
        {
            cmbKeyUp.SelectedItem = player1.up;
            if (player1.up == Keys.None)
                cmbKeyUp.SelectedItem = null;
            cmbKeyLeft.SelectedItem = player1.left;
            cmbKeyDown.SelectedItem = player1.down;
            cmbKeyRight.SelectedItem = player1.right;
            cmbKeyTongue.SelectedItem = player1.tongue;

            cmbKeyUpPlayer2.SelectedItem = player2.up;
            cmbKeyLeftPlayer2.SelectedItem = player2.left;
            cmbKeyDownPlayer2.SelectedItem = player2.down;
            cmbKeyRightPlayer2.SelectedItem = player2.right;
            cmbKeyTonguePlayer2.SelectedItem = player2.tongue;

            trackBarSizeQuadrati.Value = Config.sizeQuadrato;
        }

        private void cmbNumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbNumPlayers.SelectedItem == 1)
            {
                //Visualizza impostazioni per giocatore singolo
                /*
                pnlLblPlayer1.Enabled = false;
                pnlLblPlayer1.Visible = false;
                */
                lblPlayer1SettingsPrint.Enabled = false;
                lblPlayer1SettingsPrint.Visible = false;

                pnlSettingsPlayer2.Enabled = false;
                pnlSettingsPlayer2.Visible = false;

                /*
                lblPlayer2SettingsPrint.Enabled = false;
                lblPlayer2SettingsPrint.Visible = false;
                */

                pnlSettingsPlayers.Size = new Size(pnlSettingsPlayers.Width, pnlSettingsPlayer1.Height);

                /*
                int heightForm = pnlTop.Height + pnlSettingsPlayers.Height + pnlSettingsQuadratini.Height + pnlButtons.Height;

                this.Size = new Size(400, heightForm);
                */
            }
            else
            {
                //Visualizza impostazioni per multigiocatore
                /*
                pnlLblPlayer1.Enabled = true;
                pnlLblPlayer1.Visible = true;
                */
                lblPlayer1SettingsPrint.Enabled = true;
                lblPlayer1SettingsPrint.Visible = true;

                pnlSettingsPlayer2.Enabled = true;
                pnlSettingsPlayer2.Visible = true;

                /*
                lblPlayer2SettingsPrint.Enabled = true;
                lblPlayer2SettingsPrint.Visible = true;
                */

                pnlSettingsPlayers.Size = new Size(pnlSettingsPlayers.Width, pnlSettingsPlayer1.Height + pnlSettingsPlayer2.Height);

                /*
                int heightForm = pnlTop.Height + pnlSettingsPlayers.Height + pnlSettingsQuadratini.Height + pnlButtons.Height;

                this.Size = new Size(400, heightForm);
                */
            }
        }

        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            Config.DefaultSettings();
            trackBarSizeQuadrati.Value = Config.sizeQuadrato;
            UpdateCommands();
        }

        private void AddKeysCmbUp(ComboBox cmbKeyUp)
        {
            cmbKeyUp.Items.Add(Keys.A);
            cmbKeyUp.Items.Add(Keys.B);
            cmbKeyUp.Items.Add(Keys.C);
            cmbKeyUp.Items.Add(Keys.D);
            cmbKeyUp.Items.Add(Keys.E);
            cmbKeyUp.Items.Add(Keys.F);
            cmbKeyUp.Items.Add(Keys.G);
            cmbKeyUp.Items.Add(Keys.H);
            cmbKeyUp.Items.Add(Keys.I);
            cmbKeyUp.Items.Add(Keys.J);
            cmbKeyUp.Items.Add(Keys.K);
            cmbKeyUp.Items.Add(Keys.L);
            cmbKeyUp.Items.Add(Keys.M);
            cmbKeyUp.Items.Add(Keys.N);
            cmbKeyUp.Items.Add(Keys.O);
            cmbKeyUp.Items.Add(Keys.P);
            cmbKeyUp.Items.Add(Keys.Q);
            cmbKeyUp.Items.Add(Keys.R);
            cmbKeyUp.Items.Add(Keys.S);
            cmbKeyUp.Items.Add(Keys.T);
            cmbKeyUp.Items.Add(Keys.U);
            cmbKeyUp.Items.Add(Keys.V);
            cmbKeyUp.Items.Add(Keys.W);
            cmbKeyUp.Items.Add(Keys.X);
            cmbKeyUp.Items.Add(Keys.Y);
            cmbKeyUp.Items.Add(Keys.Z);
            cmbKeyUp.Items.Add(Keys.Up);
            cmbKeyUp.Items.Add(Keys.Left);
            cmbKeyUp.Items.Add(Keys.Down);
            cmbKeyUp.Items.Add(Keys.Right);
        }

        private void AddKeysCmbLeft(ComboBox cmbKeyLeft)
        {
            cmbKeyLeft.Items.Add(Keys.A);
            cmbKeyLeft.Items.Add(Keys.B);
            cmbKeyLeft.Items.Add(Keys.C);
            cmbKeyLeft.Items.Add(Keys.D);
            cmbKeyLeft.Items.Add(Keys.E);
            cmbKeyLeft.Items.Add(Keys.F);
            cmbKeyLeft.Items.Add(Keys.G);
            cmbKeyLeft.Items.Add(Keys.H);
            cmbKeyLeft.Items.Add(Keys.I);
            cmbKeyLeft.Items.Add(Keys.J);
            cmbKeyLeft.Items.Add(Keys.K);
            cmbKeyLeft.Items.Add(Keys.L);
            cmbKeyLeft.Items.Add(Keys.M);
            cmbKeyLeft.Items.Add(Keys.N);
            cmbKeyLeft.Items.Add(Keys.O);
            cmbKeyLeft.Items.Add(Keys.P);
            cmbKeyLeft.Items.Add(Keys.Q);
            cmbKeyLeft.Items.Add(Keys.R);
            cmbKeyLeft.Items.Add(Keys.S);
            cmbKeyLeft.Items.Add(Keys.T);
            cmbKeyLeft.Items.Add(Keys.U);
            cmbKeyLeft.Items.Add(Keys.V);
            cmbKeyLeft.Items.Add(Keys.W);
            cmbKeyLeft.Items.Add(Keys.X);
            cmbKeyLeft.Items.Add(Keys.Y);
            cmbKeyLeft.Items.Add(Keys.Z);
            cmbKeyLeft.Items.Add(Keys.Up);
            cmbKeyLeft.Items.Add(Keys.Left);
            cmbKeyLeft.Items.Add(Keys.Down);
            cmbKeyLeft.Items.Add(Keys.Right);
        }

        private void AddKeysCmbDown(ComboBox cmbKeyDown)
        {
            cmbKeyDown.Items.Add(Keys.A);
            cmbKeyDown.Items.Add(Keys.B);
            cmbKeyDown.Items.Add(Keys.C);
            cmbKeyDown.Items.Add(Keys.D);
            cmbKeyDown.Items.Add(Keys.E);
            cmbKeyDown.Items.Add(Keys.F);
            cmbKeyDown.Items.Add(Keys.G);
            cmbKeyDown.Items.Add(Keys.H);
            cmbKeyDown.Items.Add(Keys.I);
            cmbKeyDown.Items.Add(Keys.J);
            cmbKeyDown.Items.Add(Keys.K);
            cmbKeyDown.Items.Add(Keys.L);
            cmbKeyDown.Items.Add(Keys.M);
            cmbKeyDown.Items.Add(Keys.N);
            cmbKeyDown.Items.Add(Keys.O);
            cmbKeyDown.Items.Add(Keys.P);
            cmbKeyDown.Items.Add(Keys.Q);
            cmbKeyDown.Items.Add(Keys.R);
            cmbKeyDown.Items.Add(Keys.S);
            cmbKeyDown.Items.Add(Keys.T);
            cmbKeyDown.Items.Add(Keys.U);
            cmbKeyDown.Items.Add(Keys.V);
            cmbKeyDown.Items.Add(Keys.W);
            cmbKeyDown.Items.Add(Keys.X);
            cmbKeyDown.Items.Add(Keys.Y);
            cmbKeyDown.Items.Add(Keys.Z);
            cmbKeyDown.Items.Add(Keys.Up);
            cmbKeyDown.Items.Add(Keys.Left);
            cmbKeyDown.Items.Add(Keys.Down);
            cmbKeyDown.Items.Add(Keys.Right);
        }

        private void AddKeysCmbRight(ComboBox cmbKeyRight)
        {
            cmbKeyRight.Items.Add(Keys.A);
            cmbKeyRight.Items.Add(Keys.B);
            cmbKeyRight.Items.Add(Keys.C);
            cmbKeyRight.Items.Add(Keys.D);
            cmbKeyRight.Items.Add(Keys.E);
            cmbKeyRight.Items.Add(Keys.F);
            cmbKeyRight.Items.Add(Keys.G);
            cmbKeyRight.Items.Add(Keys.H);
            cmbKeyRight.Items.Add(Keys.I);
            cmbKeyRight.Items.Add(Keys.J);
            cmbKeyRight.Items.Add(Keys.K);
            cmbKeyRight.Items.Add(Keys.L);
            cmbKeyRight.Items.Add(Keys.M);
            cmbKeyRight.Items.Add(Keys.N);
            cmbKeyRight.Items.Add(Keys.O);
            cmbKeyRight.Items.Add(Keys.P);
            cmbKeyRight.Items.Add(Keys.Q);
            cmbKeyRight.Items.Add(Keys.R);
            cmbKeyRight.Items.Add(Keys.S);
            cmbKeyRight.Items.Add(Keys.T);
            cmbKeyRight.Items.Add(Keys.U);
            cmbKeyRight.Items.Add(Keys.V);
            cmbKeyRight.Items.Add(Keys.W);
            cmbKeyRight.Items.Add(Keys.X);
            cmbKeyRight.Items.Add(Keys.Y);
            cmbKeyRight.Items.Add(Keys.Z);
            cmbKeyRight.Items.Add(Keys.Up);
            cmbKeyRight.Items.Add(Keys.Left);
            cmbKeyRight.Items.Add(Keys.Down);
            cmbKeyRight.Items.Add(Keys.Right);
        }

        private void AddKeysCmbTongue(ComboBox cmbKeyTongue)
        {
            cmbKeyTongue.Items.Add(Keys.A);
            cmbKeyTongue.Items.Add(Keys.B);
            cmbKeyTongue.Items.Add(Keys.C);
            cmbKeyTongue.Items.Add(Keys.D);
            cmbKeyTongue.Items.Add(Keys.E);
            cmbKeyTongue.Items.Add(Keys.F);
            cmbKeyTongue.Items.Add(Keys.G);
            cmbKeyTongue.Items.Add(Keys.H);
            cmbKeyTongue.Items.Add(Keys.I);
            cmbKeyTongue.Items.Add(Keys.J);
            cmbKeyTongue.Items.Add(Keys.K);
            cmbKeyTongue.Items.Add(Keys.L);
            cmbKeyTongue.Items.Add(Keys.M);
            cmbKeyTongue.Items.Add(Keys.N);
            cmbKeyTongue.Items.Add(Keys.O);
            cmbKeyTongue.Items.Add(Keys.P);
            cmbKeyTongue.Items.Add(Keys.Q);
            cmbKeyTongue.Items.Add(Keys.R);
            cmbKeyTongue.Items.Add(Keys.S);
            cmbKeyTongue.Items.Add(Keys.T);
            cmbKeyTongue.Items.Add(Keys.U);
            cmbKeyTongue.Items.Add(Keys.V);
            cmbKeyTongue.Items.Add(Keys.W);
            cmbKeyTongue.Items.Add(Keys.X);
            cmbKeyTongue.Items.Add(Keys.Y);
            cmbKeyTongue.Items.Add(Keys.Z);
            cmbKeyTongue.Items.Add(Keys.Space);
        }

        private void cmbKeyUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Keys temp = Config.up;
            try
            {
                Config.up = (Keys)cmbKeyUp.SelectedItem;
                if (Config.up == Config.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (Config.up == Config.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (Config.up == Config.right)
                    cmbKeyRight.SelectedItem = temp;
                else if (Config.up == Config.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
            */

            ChangeKeyUp(player1, player2, cmbKeyUp, cmbKeyLeft, cmbKeyDown, cmbKeyRight, cmbKeyTongue);
            UpdateCommands();
        }

        private void cmbKeyUpPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKeyUp(player2, player1, cmbKeyUpPlayer2, cmbKeyLeftPlayer2, cmbKeyDownPlayer2, cmbKeyRightPlayer2, cmbKeyTonguePlayer2);
            UpdateCommands();
        }

        private void ChangeKeyUp(Player player, Player otherplayer, ComboBox cmbUp, ComboBox cmbLeft, ComboBox cmbDown, ComboBox cmbRight, ComboBox cmbTongue)
        {
            Keys temp = player.up;
            if (cmbUp.SelectedItem != null)
            {
                try
                {
                    player.up = (Keys)cmbUp.SelectedItem;
                    if (player.up == player.left)
                        cmbLeft.SelectedItem = temp;
                    else if (player.up == player.down)
                        cmbDown.SelectedItem = temp;
                    else if (player.up == player.right)
                        cmbRight.SelectedItem = temp;
                    else if (player.up == player.tongue)
                        cmbTongue.SelectedItem = temp;
                }
                catch (System.NullReferenceException)
                {

                }
            }
            player.ComparisonCommands(ref otherplayer);
        }

        private void cmbKeyLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Keys temp = Config.left;
            try
            {
                Config.left = (Keys)cmbKeyLeft.SelectedItem;
                if (Config.left == Config.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (Config.left == Config.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (Config.left == Config.right)
                    cmbKeyRight.SelectedItem = temp;
                else if (Config.left == Config.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
            */

            ChangeKeyLeft(player1);
        }

        private void cmbKeyLeftPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKeyLeft(player2);
        }

        private void ChangeKeyLeft(Player player)
        {
            Keys temp = player.left;
            try
            {
                player.left = (Keys)cmbKeyLeft.SelectedItem;
                if (player.left == player.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (player.left == player.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (player.left == player.right)
                    cmbKeyRight.SelectedItem = temp;
                else if (player.left == player.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
        }

        private void cmbKeyDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Keys temp = Config.down;
            try
            {
                Config.down = (Keys)cmbKeyDown.SelectedItem;
                if (Config.down == Config.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (Config.down == Config.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (Config.down == Config.right)
                    cmbKeyRight.SelectedItem = temp;
                else if (Config.down == Config.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
            */

            ChangeKeyDown(player1);
        }

        private void cmbKeyDownPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKeyDown(player2);
        }

        private void ChangeKeyDown(Player player)
        {
            Keys temp = player.down;
            try
            {
                player.down = (Keys)cmbKeyDown.SelectedItem;
                if (player.down == player.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (player.down == player.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (player.down == player.right)
                    cmbKeyRight.SelectedItem = temp;
                else if (player.down == player.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
        }

        private void cmbKeyRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Keys temp = Config.right;
            try
            {
                Config.right = (Keys)cmbKeyRight.SelectedItem;
                if (Config.right == Config.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (Config.right == Config.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (Config.right == Config.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (Config.right == Config.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
            */

            ChangeKeyRight(player1);
        }

        private void cmbKeyRightPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKeyRight(player2);
        }

        private void ChangeKeyRight(Player player)
        {
            Keys temp = player.right;
            try
            {
                player.right = (Keys)cmbKeyRight.SelectedItem;
                if (player.right == player.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (player.right == player.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (player.right == player.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (player.right == player.tongue)
                    cmbKeyTongue.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
        }

        private void cmbKeyTongue_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Keys temp = Config.tongue;
            try
            {
                Config.tongue = (Keys)cmbKeyTongue.SelectedItem;
                if (Config.tongue == Config.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (Config.tongue== Config.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (Config.tongue == Config.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (Config.tongue == Config.right)
                    cmbKeyRight.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
            */

            ChangeKeyTongue(player1);
        }

        private void cmbKeyTonguePlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKeyTongue(player2);
        }

        private void ChangeKeyTongue(Player player)
        {
            Keys temp = player.tongue;
            try
            {
                player.tongue = (Keys)cmbKeyTongue.SelectedItem;
                if (player.tongue == player.up)
                    cmbKeyUp.SelectedItem = temp;
                else if (player.tongue == player.left)
                    cmbKeyLeft.SelectedItem = temp;
                else if (player.tongue == player.down)
                    cmbKeyDown.SelectedItem = temp;
                else if (player.tongue == player.right)
                    cmbKeyRight.SelectedItem = temp;
            }
            catch (System.NullReferenceException)
            {

            }
        }

        private void trackBarSizeQuadrati_Scroll(object sender, EventArgs e)
        {
            Config.sizeQuadrato = trackBarSizeQuadrati.Value;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            SaveCurrentConfig();
            Close();
        }

        private void SaveCurrentConfig()
        {
            try
            {
                if (!System.IO.Directory.Exists("Data/Settings"))
                {
                    System.IO.Directory.CreateDirectory("Data/Settings");
                }
                SaveConfig saveConfig = new SaveConfig(Config.up, Config.left, Config.down, Config.right, Config.tongue, Config.sizeQuadrato);
                string Configserialized = JsonConvert.SerializeObject(saveConfig);
                string path = "Data/Settings/userSettingsConfig.json";
                File.WriteAllText(@path, Configserialized);
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.ToString(), "");
            }
        }
        public static bool ReadPreviousConfig()
        {
            try
            {
                StreamReader reader = new StreamReader("Data/Settings/userSettingsConfig.json");
                SaveConfig saveConfig = JsonConvert.DeserializeObject<SaveConfig>(reader.ReadToEnd());
                reader.Close();
                Config.up = saveConfig.up;
                Config.left = saveConfig.left;
                Config.down = saveConfig.down;
                Config.right = saveConfig.right;
                Config.tongue = saveConfig.tongue;
                Config.sizeQuadrato = saveConfig.sizeQuadrato;
                return true;
            }
            catch (FileNotFoundException)
            {
                Config.DefaultSettings();
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                Config.DefaultSettings();
                return false;
            }
            catch (NullReferenceException)
            {
                Config.DefaultSettings();
                return false;
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCurrentConfig();
        }
    }
}
