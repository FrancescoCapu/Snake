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
    public partial class frmMenu : Form
    {
        private int HeightCampoGioco, WidthCampoGioco;
        enum DimensioniCampoGioco
        {
            Piccolo,
            Medio,
            Grande
        }

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            cmbDimensioneCampo.Items.Add(DimensioniCampoGioco.Piccolo);
            cmbDimensioneCampo.Items.Add(DimensioniCampoGioco.Medio);
            cmbDimensioneCampo.Items.Add(DimensioniCampoGioco.Grande);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //da cambiare la grandezza
            switch ((DimensioniCampoGioco)cmbDimensioneCampo.SelectedIndex)
            {
                case DimensioniCampoGioco.Piccolo:
                    HeightCampoGioco = 12;
                    WidthCampoGioco = 17;
                    break;
                case DimensioniCampoGioco.Medio:
                    HeightCampoGioco = 17;
                    WidthCampoGioco = 25;
                    break;
                case DimensioniCampoGioco.Grande:
                    HeightCampoGioco = 25;
                    WidthCampoGioco = 37;
                    break;
            }
            frmSnake frmSnake = new frmSnake(this, HeightCampoGioco, WidthCampoGioco);
            frmSnake.Show();
            this.Hide();
        }
    }
}
