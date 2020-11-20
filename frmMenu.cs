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
        private int HeightCampoGioco, WidthCampoGioco, timerInterval;
        enum DimensioniCampoGioco
        {
            Piccolo,
            Medio,
            Grande
        }

        enum Velocita
        {
            Lento,
            Normale,
            Veloce
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
            cmbDimensioneCampo.SelectedItem = DimensioniCampoGioco.Medio;
            cmbVelocita.Items.Add(Velocita.Lento);
            cmbVelocita.Items.Add(Velocita.Normale);
            cmbVelocita.Items.Add(Velocita.Veloce);
            cmbVelocita.SelectedItem = Velocita.Normale;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbDimensioneCampo.SelectedItem != null && cmbVelocita.SelectedItem != null)
            {
                switch (cmbDimensioneCampo.SelectedItem)
                {
                    case DimensioniCampoGioco.Piccolo:
                        HeightCampoGioco = 13;
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
                    default:
                        //non verrà mai eseguito
                        goto case DimensioniCampoGioco.Medio;
                }
                switch (cmbVelocita.SelectedItem)
                {
                    case Velocita.Lento:
                        timerInterval = 450;
                        break;
                    case Velocita.Normale:
                        timerInterval = 300;
                        break;
                    case Velocita.Veloce:
                        timerInterval = 150;
                        break;
                    default:
                        //non verrà mai eseguito
                        goto case Velocita.Normale;
                }
                frmSnake frmSnake = new frmSnake(this, HeightCampoGioco, WidthCampoGioco, timerInterval);
                frmSnake.Show();
                this.Hide();
            }
            else    //non verrà mai eseguito
            {
                MessageBox.Show("Errore durante la selezione delle impostazioni di gioco", "Errore");
            }
        }
    }
}
