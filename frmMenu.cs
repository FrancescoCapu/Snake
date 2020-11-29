using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Snake
{
    public enum DimensioniCampoGioco
    {
        Piccolo,
        Medio,
        Grande
    }

    public partial class frmMenu : Form
    {
        public const int WIDTH_CAMPO_PICCOLO = 17, HEIGHT_CAMPO_PICCOLO = 13;
        public const int WIDTH_CAMPO_MEDIO = 25, HEIGHT_CAMPO_MEDIO = 17;
        public const int WIDTH_CAMPO_GRANDE = 37, HEIGHT_CAMPO_GRANDE = 25;
        private int heightCampoGioco, widthCampoGioco, timerInterval, numeroLivello;
        private RootNomiFile rootNomiFileMenu;

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

            rootNomiFileMenu = new RootNomiFile();
            StreamReader reader = new StreamReader("levels/indice_livelli.json");
            rootNomiFileMenu = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
            for (int i = 0; i < rootNomiFileMenu.nomeFileDaLeggere.Count; i++)
            {
                cmbLivelli.Items.Add(i);
            }
            cmbLivelli.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbDimensioneCampo.SelectedItem != null && cmbVelocita.SelectedItem != null)
            {
                switch (cmbDimensioneCampo.SelectedItem)
                {
                    case DimensioniCampoGioco.Piccolo:
                        heightCampoGioco = HEIGHT_CAMPO_PICCOLO;
                        widthCampoGioco = WIDTH_CAMPO_PICCOLO;
                        break;
                    case DimensioniCampoGioco.Medio:
                        heightCampoGioco = HEIGHT_CAMPO_MEDIO;
                        widthCampoGioco = WIDTH_CAMPO_MEDIO;
                        break;
                    case DimensioniCampoGioco.Grande:
                        heightCampoGioco = HEIGHT_CAMPO_GRANDE;
                        widthCampoGioco = WIDTH_CAMPO_GRANDE;
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
                if (cmbLivelli.SelectedItem == null)
                {
                    numeroLivello = 0;
                }
                else
                {
                    numeroLivello = cmbLivelli.SelectedIndex;
                }
                frmSnake frmSnake = new frmSnake(this, heightCampoGioco, widthCampoGioco, timerInterval, numeroLivello);
                frmSnake.Show();
                this.Hide();
            }
            else    //non verrà mai eseguito
            {
                MessageBox.Show("Errore durante la selezione delle impostazioni di gioco", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
