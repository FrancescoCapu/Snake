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
        private List<Color> lstColor = new List<Color>();
        private Color color = Color.Orange;

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
            Config.DefaultSettings();

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
            /*for (int i = 0; i < rootNomiFileMenu.nomeFileDaLeggere.Count; i++)
            {
                cmbLivelli.Items.Add(i);
            }
            cmbLivelli.SelectedIndex = 0;*/
            GetPictures();
            InizializzaPic();
            CreatePicColors();
            InizializzaButtons();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
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
                    /*if (cmbLivelli.SelectedItem == null)
                    {
                        numeroLivello = 0;
                    }
                    else
                    {
                        //numeroLivello = cmbLivelli.SelectedIndex;
                    }*/
                    string nome = txtNome.Text;
                    frmSnake frmSnake = new frmSnake(this, heightCampoGioco, widthCampoGioco, timerInterval, nome, color, numeroLivello);
                    frmSnake.Show();
                    this.Hide();
                }
                else    //non verrà mai eseguito
                {
                    MessageBox.Show("Errore durante la selezione delle impostazioni di gioco", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Inserisci un nickname per poter iniziare la partita", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// ridimensiona la grandezza delle picturebox
        /// </summary>
        private void InizializzaPic()
        {
            picCenter.Size = new Size(200, 136);    //200, 136 è esattamente la metà della grandezza in pixel del campo gioco medio
            picCenter.Location = new Point(pnlLivelli.Width / 2 - picCenter.Width / 2, pnlLivelli.Height / 8);
            picCenter.Image = lstPreviewLevels[0];
            picCenter.BackColor = Color.FromArgb(0, 0, 0, 0);
            picCenter.Visible = true;
            picCenter.Enabled = true;
            picCenter.SizeMode = PictureBoxSizeMode.StretchImage;
            pnlLivelli.Controls.Add(picCenter);

            picLeft1.Size = new Size(100, 68);
            picLeft1.Location = new Point((int)(pnlLivelli.Width / 2 - picCenter.Width + picLeft1.Width / 3), picCenter.Location.Y + picCenter.Height / 2 - picLeft1.Height / 2);
            picLeft1.Image = null;
            picLeft1.BackColor = Color.FromArgb(0, 0, 0, 0);
            picLeft1.Visible = true;
            picLeft1.Enabled = true;
            picLeft1.SizeMode = PictureBoxSizeMode.StretchImage;
            //picLeft1.Click += btnLeft.Click(btnLeft, btnLeft.Click);
            pnlLivelli.Controls.Add(picLeft1);

            picRight1.Size = new Size(100, 68);
            picRight1.Location = new Point((int)(pnlLivelli.Width / 2 + picCenter.Width / 2 - picRight1.Width / 3), picCenter.Location.Y + picCenter.Height / 2 - picRight1.Height / 2);
            picRight1.Image = lstPreviewLevels[1];
            picRight1.BackColor = Color.FromArgb(0, 0, 0, 0);
            picRight1.Visible = true;
            picRight1.Enabled = true;
            picRight1.SizeMode = PictureBoxSizeMode.StretchImage;
            //picRight1.Click = ???
            pnlLivelli.Controls.Add(picRight1);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {  
            Settings frmSettings = new Settings();
            frmSettings.ShowDialog();
        }

        private void CreatePicColors()
        {
            lstColor.Add(Color.Pink);
            lstColor.Add(Color.Red);
            lstColor.Add(Color.Orange);
            lstColor.Add(Color.Yellow);
            lstColor.Add(Color.LightGreen);
            lstColor.Add(Color.DarkGreen);
            lstColor.Add(Color.Cyan);
            lstColor.Add(Color.Blue);
            lstColor.Add(Color.Purple);
            lstColor.Add(Color.White);

            for (int i = 0; i < lstColor.Count; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Enabled = true;
                pic.Visible = true;
                pic.BackColor = lstColor[i];
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Size = new Size(40, 40);
                pic.Location = new Point(i * 40, 5);
                pic.Click += delegate
                {
                    color = pic.BackColor;
                    Console.WriteLine(color);
                };
                pnlColors.Controls.Add(pic);
            }
            pnlColors.Size = new Size(this.Size.Width, 50);
            pnlColors.Location = new Point((this.Size.Width - 400) / 2, 300);
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
                    Console.WriteLine(aus);
                    lstPreviewLevels.Add(Image.FromFile(aus));
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                MessageBox.Show(e.Message + " file not found", "Errore");
            }
            catch (System.OutOfMemoryException e)
            {
                MessageBox.Show(e.Message, "Errore");
            }
            catch (System.ArgumentException e)
            {
                MessageBox.Show(e.Message, "Errore");
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
            btnLeft.Enabled = false;
            btnLeft.Visible = false;
        }

        private void UpdatePics(int index)
        {
            picCenter.Image = lstPreviewLevels[index];
            if (index == 0)
            {
                picLeft1.Image = null;
                btnLeft.Enabled = false;
                btnLeft.Visible = false;
            }
            else
            {
                picLeft1.Image = lstPreviewLevels[index - 1];
                btnLeft.Enabled = true;
                btnLeft.Visible = true;
            }
            if (index == rootNomiFileMenu.nomeFileDaLeggere.Count - 1)
            {
                picRight1.Image = null;
                btnRight.Enabled = false;
                btnRight.Visible = false;
            }
            else
            {
                picRight1.Image = lstPreviewLevels[index + 1];
                btnRight.Enabled = true;
                btnRight.Visible = true;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (numeroLivello < rootNomiFileMenu.nomeFileDaLeggere.Count)
            {
                numeroLivello++;
                UpdatePics(numeroLivello);
            }
            if (numeroLivello == 1)
            {
                lblDimensioneCampo.Enabled = false;
                lblDimensioneCampo.Visible = false;
                cmbDimensioneCampo.Enabled = false;
                cmbDimensioneCampo.Visible = false;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (numeroLivello > 0)
            {
                numeroLivello--;
                UpdatePics(numeroLivello);
            }
            if (numeroLivello == 0)
            {
                lblDimensioneCampo.Enabled = true;
                lblDimensioneCampo.Visible = true;
                cmbDimensioneCampo.Enabled = true;
                cmbDimensioneCampo.Visible = true;
            }
        }
    }
}
