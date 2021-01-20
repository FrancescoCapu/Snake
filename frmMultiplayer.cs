using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class frmMultiplayer : frmSnake
    {
        public frmMultiplayer(frmMenu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, string nomePlayer1, string nomePlayer2, Color colorPlayer1, Color colorPlayer2, int numLivello = 0) : base (frmChiamante, heightCampoGioco, widthCampoGioco, timerInterval, nomePlayer1, colorPlayer1, numLivello = 0)
        {
            InitializeComponent();
        }

        private void frmMultiplayer_Load(object sender, EventArgs e)
        {

        }
    }
}
