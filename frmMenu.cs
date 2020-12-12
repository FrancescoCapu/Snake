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
        private List<Image> lstPreviewLevels = new List<Image>();

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
            StreamReader reader = new StreamReader("Data/levels/indice_livelli.json");
            rootNomiFileMenu = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
            for (int i = 0; i < rootNomiFileMenu.nomeFileDaLeggere.Count; i++)
            {
                cmbLivelli.Items.Add(i);
            }
            cmbLivelli.SelectedIndex = 0;
            InizializzaPic();
            InizializzaButtons();
            GetPictures();
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
                        timerInterval = 300;
                        break;
                    case Velocita.Normale:
                        timerInterval = 150;
                        break;
                    case Velocita.Veloce:
                        timerInterval = 75;
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

        /// <summary>
        /// ridimensiona la grandezza delle picturebox
        /// </summary>
        private void InizializzaPic()
        {
            picCenter.Size = new Size(200, 136);    //200, 136 è esattamente la metà della grandezza in pixel del campo gioco medio
            picCenter.Location = new Point(pnlLivelli.Width / 2 - picCenter.Width / 2, pnlLivelli.Height / 8);
            //picCenter.Image = Image.FromFile();
            picCenter.BackColor = Color.FromArgb(100, 0, 0, 0);
            picCenter.Visible = true;
            picCenter.Enabled = true;
            pnlLivelli.Controls.Add(picCenter);

            picLeft1.Size = new Size(100, 68);
            picLeft1.Location = new Point((int)(pnlLivelli.Width / 2 - picCenter.Width + picLeft1.Width / 3), pnlLivelli.Height / 8 + picCenter.Height / 2 - picLeft1.Height / 2);
            //picLeft1.Image = Image.FromStream();
            picLeft1.BackColor = Color.FromArgb(50, 0, 0, 0);
            picLeft1.Visible = true;
            picLeft1.Enabled = true;
            pnlLivelli.Controls.Add(picLeft1);

            picRight1.Size = new Size(100, 68);
            picRight1.Location = new Point((int)(pnlLivelli.Width / 2 + picCenter.Width / 2 - picRight1.Width / 3), pnlLivelli.Height / 8 + picCenter.Height / 2 - picRight1.Height / 2);
            //picRight1.Image = Image.FromStream();
            picRight1.BackColor = Color.FromArgb(50, 0, 0, 0);
            picRight1.Visible = true;
            picRight1.Enabled = true;
            pnlLivelli.Controls.Add(picRight1);
        }

        // --- da finire - così non funziona ---
        private void GetPictures()
        {
            string aus;
            try
            {
                for (int i = 0; i < rootNomiFileMenu.nomeFileDaLeggere.Count; i++)
                {
                    aus = "Data/imgs/preview_level_" + i + ".PNG";
                    lstPreviewLevels.Add(Image.FromFile(aus));
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show(e.Message + " file not found", "Errore");
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Errore");
            }
        }

        private void InizializzaButtons()
        {
            btnRight.Size = new Size(30, 30);
            btnRight.Location = new Point(picRight1.Location.X + picRight1.Width , picCenter.Location.Y + picCenter.Height / 2 - btnRight.Size.Height / 2);

            btnLeft.Size = new Size(30, 30);
            btnLeft.Location = new Point(picLeft1.Location.X - btnLeft.Width, picCenter.Location.Y + picCenter.Height / 2 - btnLeft.Size.Height / 2);
        }

        private void UpdatePics(int index)
        {
            picCenter.Image = lstPreviewLevels[index];
            if (index == 0)
            {
                picLeft1.Image = null;
            }
            else
            {
                picLeft1.Image = lstPreviewLevels[index - 1];
            }
            if (index == rootNomiFileMenu.nomeFileDaLeggere.Count)
            {
                picRight1.Image = null;
            }
            else
            {
                picRight1.Image = lstPreviewLevels[index + 1];
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (numeroLivello < rootNomiFileMenu.nomeFileDaLeggere.Count)
            {
                numeroLivello++;
                UpdatePics(numeroLivello);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (numeroLivello > 0)
            {
                numeroLivello--;
                UpdatePics(numeroLivello);
            }
        }
    }
}
