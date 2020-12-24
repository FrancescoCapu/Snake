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

namespace Snake
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            UpdateCommands();
        }

        private void UpdateCommands()
        {
            lblKeyUp.Text = Config.up.ToString();
            lblKeyLeft.Text = Config.left.ToString();
            lblKeyDown.Text = Config.down.ToString();
            lblKeyRight.Text = Config.right.ToString();
            lblKeyTongue.Text = Config.tongue.ToString();
        }

        private void btnChangeKeyUp_Click(object sender, EventArgs e)
        {
            Config.up = Keys.I;
            UpdateCommands();
        }

        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            Config.DefaultSettings();
            UpdateCommands();
        }

        private void lblKeyUp_DoubleClick(object sender, EventArgs e)
        {
            lblKeyUp.Focus();
            Config.up = Keys.B;
            UpdateCommands();
        }
    }
}
