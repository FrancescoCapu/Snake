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
        Panel pnlGlobalPlayer1;
        Panel pnlLblPlayer1;
        Panel pnlPlayer1Settings;

        public Settings()
        {
            InitializeComponent();
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

            pnlGlobalPlayer1 = new Panel();
            pnlGlobalPlayer1.Enabled = true;
            pnlGlobalPlayer1.Visible = true;
            pnlGlobalPlayer1.BackColor = Color.Transparent;
            pnlGlobalPlayer1.Location = new Point(this.Width / 6, lblNumPlayers.Location.Y + lblNumPlayers.Size.Height + 25);

            lblPlayer1.Text = "--- Impostazioni giocatore 1 ---";

            pnlLblPlayer1 = new Panel();
            pnlLblPlayer1.Enabled = false;
            pnlLblPlayer1.Visible = false;
            pnlLblPlayer1.Controls.Add(lblPlayer1);
            pnlLblPlayer1.BackColor = Color.Transparent;
            pnlGlobalPlayer1.Controls.Add(pnlLblPlayer1);
            pnlLblPlayer1.Dock = DockStyle.Top;
            pnlLblPlayer1.Size = new Size(pnlGlobalPlayer1.Width, lblPlayer1.Height + 10);

            lblPlayer1.Location = new Point(pnlLblPlayer1.Width / 2 - lblPlayer1.Width / 2, pnlLblPlayer1.Height / 2 - lblPlayer1.Height / 2);

            pnlPlayer1Settings = new Panel();
            pnlPlayer1Settings.Enabled = true;
            pnlPlayer1Settings.Visible = true;
            pnlGlobalPlayer1.Controls.Add(pnlPlayer1Settings);
            pnlPlayer1Settings.Location = new Point(0, 1);
            pnlPlayer1Settings.Dock = DockStyle.Bottom;

            lblUp.Location = new Point(0, 0);
            cmbKeyUp.Location = new Point(pnlPlayer1Settings.Width / 2 + pnlPlayer1Settings.Width / 4, lblUp.Location.Y);
            pnlPlayer1Settings.Controls.Add(lblUp);
            pnlPlayer1Settings.Controls.Add(cmbKeyUp);

            lblLeft.Location = new Point(lblUp.Location.X, lblUp.Location.Y + lblUp.Size.Height + 15);
            cmbKeyLeft.Location = new Point(cmbKeyUp.Location.X, lblLeft.Location.Y);
            pnlPlayer1Settings.Controls.Add(lblLeft);
            pnlPlayer1Settings.Controls.Add(cmbKeyLeft);

            lblDown.Location = new Point(lblLeft.Location.X, lblLeft.Location.Y + lblLeft.Size.Height + 15);
            cmbKeyDown.Location = new Point(cmbKeyLeft.Location.X, lblDown.Location.Y);
            pnlPlayer1Settings.Controls.Add(lblDown);
            pnlPlayer1Settings.Controls.Add(cmbKeyDown);

            lblRight.Location = new Point(lblDown.Location.X, lblDown.Location.Y + lblDown.Size.Height + 15);
            cmbKeyRight.Location = new Point(cmbKeyDown.Location.X, lblRight.Location.Y);
            pnlPlayer1Settings.Controls.Add(lblRight);
            pnlPlayer1Settings.Controls.Add(cmbKeyRight);

            lblUseTongue.Location = new Point(lblRight.Location.X, lblRight.Location.Y + lblRight.Size.Height + 15);
            cmbKeyTongue.Location = new Point(cmbKeyRight.Location.X, lblUseTongue.Location.Y);
            pnlPlayer1Settings.Controls.Add(lblUseTongue);
            pnlPlayer1Settings.Controls.Add(cmbKeyTongue);

            int widthPnlSettings = cmbKeyUp.Location.X + cmbKeyUp.Width - lblUp.Location.X;
            int heightPnlSettings = cmbKeyTongue.Location.Y + cmbKeyTongue.Height - cmbKeyUp.Location.Y;

            pnlPlayer1Settings.Size = new Size(widthPnlSettings, heightPnlSettings + 5);
            pnlGlobalPlayer1.Size = new Size(widthPnlSettings, pnlPlayer1Settings.Height + pnlLblPlayer1.Height);
            panel1.Controls.Add(pnlGlobalPlayer1);

            lblSizeQuadrati.Location = new Point(this.Width / 6, pnlGlobalPlayer1.Location.Y + pnlGlobalPlayer1.Size.Height + 20);
            lblSizeQuadrati.Text = "Grandezza\nquadratini";
            trackBarSizeQuadrati.Location = new Point(cmbKeyTongue.Location.X - 8, lblSizeQuadrati.Location.Y);
            trackBarSizeQuadrati.Size = new Size(this.Width - trackBarSizeQuadrati.Location.X - 30, 72);

            pnlButtons.Size = new Size(this.Width - 30 * 2, 85);
            pnlButtons.Location = new Point(30, lblSizeQuadrati.Location.Y + lblSizeQuadrati.Size.Height + 35);
            pnlButtons.Controls.Add(btnDefaultSettings);
            pnlButtons.Controls.Add(btnSalva);

            btnDefaultSettings.Size = new Size(pnlButtons.Size.Width / 2 - 15, 85);

            btnSalva.Size = btnDefaultSettings.Size;
        }

        private void UpdateCommands()
        {
            cmbKeyUp.SelectedItem = Config.up;
            cmbKeyLeft.SelectedItem = Config.left;
            cmbKeyDown.SelectedItem = Config.down;
            cmbKeyRight.SelectedItem = Config.right;
            cmbKeyTongue.SelectedItem = Config.tongue;
            trackBarSizeQuadrati.Value = Config.sizeQuadrato;
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
        }

        private void cmbKeyLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void cmbKeyDown_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void cmbKeyRight_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void cmbKeyTongue_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void cmbNumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbNumPlayers.SelectedItem == 1)
            {
                //Visualizza impostazioni per giocatore singolo
                pnlLblPlayer1.Enabled = false;
                pnlLblPlayer1.Visible = false;
            }
            else
            {
                //Visualizza impostazioni per multigiocatore
                pnlLblPlayer1.Enabled = true;
                pnlLblPlayer1.Visible = true;
            }
        }
    }
}
