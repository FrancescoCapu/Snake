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
        private const int TIMER_INTERVAL_LENTO = 300;
        private const int TIMER_INTERVAL_NORMALE = 150;
        private const int TIMER_INTERVAL_VELOCE = 75;
        private int heightCampoGioco = HEIGHT_CAMPO_MEDIO, widthCampoGioco = WIDTH_CAMPO_MEDIO;
        private int timerInterval = TIMER_INTERVAL_NORMALE;
        private int numeroLivello = 0;
        private RootNomiFile rootNomiFileMenu;
        public Classifica classifica;
        private List<Image> lstPreviewLevels = new List<Image>();
        private List<Color> lstColor = new List<Color>();
        private Color color = Color.Orange;
        private Player player1;
        private Player player2;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            rootNomiFileMenu = new RootNomiFile();

            /*
            StreamReader reader = new StreamReader("Data/levels/indice_livelli.json");
            rootNomiFileMenu = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
            */

            player1 = new Player(Color.White, 1, "");
            player2 = new Player(Color.White, 2, "");

            frmSnake.GetNomiFile(ref rootNomiFileMenu);
            
            GetPictures();
            InizializzaPic();
            CreatePicColors();
            InizializzaButtons();
            InizializzaGraficaMenu();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {
                if (radioButtonSinglePlayer.Checked || radioButtonMultiplayer.Checked)
                {
                    if (radioButtonSinglePlayer.Checked)
                    {
                        player1.ChangeName(txtNamePlayer2.Text);
                        player1.ChangeColor(color);
                        Settings.ReadPreviousPlayerSettings(player1);
                        //string nome = txtNome.Text;
                        frmSnake frmSnake = new frmSnake(this, heightCampoGioco, widthCampoGioco, timerInterval, player1, numeroLivello);
                        frmSnake.Show();
                        this.Hide();
                    }
                    else
                    {
                        player1.ChangeName(txtNamePlayer2.Text);
                        player2.ChangeName(txtNamePlayer2.Text);
                        //string nomePlayer1 = txtNome.Text;
                        //string nomePlayer2 = txtNamePlayer2.Text;
                        //Color colorPlayer2 = Color.Red;
                        frmMultiplayer frmMultiplayer = new frmMultiplayer(this, heightCampoGioco, widthCampoGioco, timerInterval, player1, player2, numeroLivello);
                    }
                }
                else
                {
                    MessageBox.Show("Devi prima selezionare una modalità di gioco", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Inserisci un nickname per poter iniziare la partita", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// ridimensiona la posizione e la grandezza delle picturebox e delle label
        /// </summary>
        private void InizializzaPic()
        {
            lblSelezionaLivello.Location = new Point(pnlLivelli.Width / 2 - lblSelezionaLivello.Width / 2, pnlSettings.Location.Y + pnlSettings.Height + lblSelezionaLivello.Height + 25);

            picCenter.Size = new Size(200, 136);    //200, 136 è esattamente la metà della grandezza in pixel del campo gioco medio
            picCenter.Location = new Point(pnlLivelli.Width / 2 - picCenter.Width / 2, lblSelezionaLivello.Location.Y + lblSelezionaLivello.Height + 15);
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
            picLeft1.Click += delegate { btnLeft.PerformClick(); };
            pnlLivelli.Controls.Add(picLeft1);

            picRight1.Size = new Size(100, 68);
            picRight1.Location = new Point((int)(pnlLivelli.Width / 2 + picCenter.Width / 2 - picRight1.Width / 3), picCenter.Location.Y + picCenter.Height / 2 - picRight1.Height / 2);
            picRight1.Image = lstPreviewLevels[1];
            picRight1.BackColor = Color.FromArgb(0, 0, 0, 0);
            picRight1.Visible = true;
            picRight1.Enabled = true;
            picRight1.SizeMode = PictureBoxSizeMode.StretchImage;
            picRight1.Click += delegate { btnRight.PerformClick(); };
            pnlLivelli.Controls.Add(picRight1);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(ref player1, ref player2);
            settings.ShowDialog();
        }

        private void btnClassifica_Click(object sender, EventArgs e)
        {
            Classifica classifica = new Classifica(numeroLivello);
            classifica.ShowDialog();
        }

        private void trackBarVelocità_Scroll(object sender, EventArgs e)
        {
            switch (trackBarVelocita.Value)
            {
                case 0:
                    timerInterval = TIMER_INTERVAL_LENTO;
                    break;
                case 1:
                    timerInterval = TIMER_INTERVAL_NORMALE;
                    break;
                case 2:
                    timerInterval = TIMER_INTERVAL_VELOCE;
                    break;
                default:
                    goto case 1;
            }
        }

        private void trackBarDimensioneCampo_Scroll(object sender, EventArgs e)
        {
            switch (trackBarDimensioneCampo.Value)
            {
                case 0:
                    heightCampoGioco = HEIGHT_CAMPO_PICCOLO;
                    widthCampoGioco = WIDTH_CAMPO_PICCOLO;
                    break;
                case 1:
                    heightCampoGioco = HEIGHT_CAMPO_MEDIO;
                    widthCampoGioco = WIDTH_CAMPO_MEDIO;
                    break;
                case 2:
                    heightCampoGioco = HEIGHT_CAMPO_GRANDE;
                    widthCampoGioco = WIDTH_CAMPO_GRANDE;
                    break;
                default:
                    goto case 1;
            }
        }

        private void CreatePicColors()
        {
            lblColorSnake.Location = new Point(pnlLivelli.Width / 2 - lblColorSnake.Width / 2, picCenter.Location.Y + picCenter.Height + 25);

            PictureBox pictureBox = new PictureBox();
            try
            {
                pictureBox.Image = Image.FromFile("Data/imgs/selectionArrow.png");
                pictureBox.Visible = true;
                pictureBox.Enabled = true;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(30, 41);
                pictureBox.Location = new Point(85, 50);
                pnlColors.Controls.Add(pictureBox);
            }
            catch (FileNotFoundException)
            {
                pictureBox.Visible = false;
                pictureBox.Enabled = false;
            }
                

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
                    pictureBox.Location = new Point(pic.Location.X + 5, pic.Location.Y + pic.Height + 5);
                    color = pic.BackColor;
                    Console.WriteLine(color);
                };
                pnlColors.Controls.Add(pic);
            }
            pnlColors.Size = new Size(this.Size.Width, 103);
            pnlColors.Location = new Point((this.Size.Width - 400) / 2, lblColorSnake.Location.Y  + lblColorSnake.Height + 15);
        }

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
            //btnSettings
            btnSettings.Size = new Size(pnlSettings.Height, pnlSettings.Height);
            try
            {
                btnSettings.BackgroundImage = Image.FromFile("Data/imgs/settings.png");
                btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
                btnSettings.Text = "";
            }
            catch (FileNotFoundException)
            {
                btnSettings.Text = "Settings";
            }

            btnClassifica.Size = new Size(pnlSettings.Height, pnlSettings.Height);
            try
            {
                btnClassifica.BackgroundImage = Image.FromFile("Data/imgs/trofeo.png");
                btnClassifica.BackgroundImageLayout = ImageLayout.Stretch;
                btnClassifica.Text = "";
            }
            catch(FileNotFoundException)
            {
                btnClassifica.Text = "Ranking";
            }

            //btnRight
            try
            {
                btnRight.BackgroundImage = Image.FromFile("Data/imgs/rightArrow.png");
                btnRight.BackgroundImageLayout = ImageLayout.Stretch;
                btnRight.Text = "";
                btnRight.Location = new Point(picRight1.Location.X + picRight1.Size.Width, picRight1.Location.Y + picRight1.Size.Height / 5);
                btnRight.Size = new Size(picRight1.Size.Height / 5 * 3, picRight1.Size.Height / 5 * 3);
            }
            catch (FileNotFoundException)
            {
                btnRight.Text = "+";
                btnRight.Size = new Size(30, 30);
                btnRight.Location = new Point(picRight1.Location.X + picRight1.Width, picCenter.Location.Y + picCenter.Height / 2 - btnRight.Size.Height / 2);
            }

            //btnLeft
            try
            {
                btnLeft.BackgroundImage = Image.FromFile("Data/imgs/leftArrow.png");
                btnLeft.BackgroundImageLayout = ImageLayout.Stretch;
                btnLeft.Text = "";
                btnLeft.Location = new Point(picLeft1.Location.X - picLeft1.Size.Height / 5 * 3, picLeft1.Location.Y + picLeft1.Size.Height / 5);
                btnLeft.Size = new Size(picLeft1.Size.Height / 5 * 3, picLeft1.Size.Height / 5 * 3);
            }
            catch (FileNotFoundException)
            {
                btnLeft.Text = "-";
                btnLeft.Size = new Size(30, 30);
                btnLeft.Location = new Point(picLeft1.Location.X - btnLeft.Width, picCenter.Location.Y + picCenter.Height / 2 - btnLeft.Size.Height / 2);
            }
            btnLeft.Enabled = false;
            btnLeft.Visible = false;
        }

        private void radioButtonMultiplayer_CheckedChanged(object sender, EventArgs e)
        {
            pnlNickname.Size = new Size(pnlNickname.Width, 200);

            lblNome.Location = new Point(lblVelocita.Location.X, pnlNickname.Height / 4 - lblNome.Height / 2);
            lblNome.Text = "Inserisci il nome del giocatore 1";
            txtNome.Size = new Size(200, 30);
            txtNome.Location = new Point(lblNome.Location.X + lblNome.Width + 25, pnlNickname.Height / 4 - txtNome.Height / 2);

            pnlNicknamePlayer2.Enabled = true;
            pnlNicknamePlayer2.Visible = true;
            txtNamePlayer2.Location = new Point(lblNamePlayer2.Location.X + lblNamePlayer2.Width + 25, pnlNicknamePlayer2.Height / 2 - txtNamePlayer2.Height / 2);

        }

        private void radioButtonSinglePlayer_CheckedChanged(object sender, EventArgs e)
        {
            pnlNickname.Size = new Size(pnlNickname.Width, 100);

            lblNome.Location = new Point(lblVelocita.Location.X, pnlNickname.Height / 2 - lblNome.Height / 2);
            lblNome.Text = "Inserisci il tuo nickname";
            txtNome.Size = new Size(200, 30);
            txtNome.Location = new Point(trackBarVelocita.Location.X, pnlNickname.Height / 2 - txtNome.Height / 2);

            pnlNicknamePlayer2.Enabled = false;
            pnlNicknamePlayer2.Visible = false;
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

        private void InizializzaGraficaMenu()
        {
            lblDimensioneCampo.Location = new Point(this.Width / 10, pnlDimensioneCampo.Height / 2 - lblDimensioneCampo.Height / 2);
            trackBarDimensioneCampo.Location = new Point(lblDimensioneCampo.Location.X + lblDimensioneCampo.Width + 50, pnlDimensioneCampo.Height / 2 - trackBarDimensioneCampo.Height / 2);
            trackBarDimensioneCampo.Size = new Size(300, 56);

            lblVelocita.Location = new Point(lblDimensioneCampo.Location.X, pnlVelocita.Height / 2 - lblVelocita.Height / 2);
            trackBarVelocita.Location = new Point(trackBarDimensioneCampo.Location.X, pnlVelocita.Height / 2 - trackBarVelocita.Height / 2);
            trackBarVelocita.Size = new Size(300, 56);

            lblNome.Location = new Point(lblVelocita.Location.X, pnlNickname.Height / 2 - lblNome.Height / 2);
            txtNome.Size = new Size(200, 30);
            txtNome.Location = new Point(trackBarVelocita.Location.X, pnlNickname.Height / 2 - txtNome.Height / 2);

            lblNumeroGiocatori.Location = new Point(lblDimensioneCampo.Location.X, pnlNumeroGiocatori.Height / 2 - lblNumeroGiocatori.Height / 2);
            radioButtonSinglePlayer.Location = new Point(trackBarDimensioneCampo.Location.X + 8, pnlNumeroGiocatori.Height / 2 - radioButtonSinglePlayer.Height / 2);
            radioButtonSinglePlayer.Checked = true;
            radioButtonMultiplayer.Location = new Point(radioButtonSinglePlayer.Location.X + radioButtonSinglePlayer.Width + 60, radioButtonSinglePlayer.Location.Y);

            trackBarVelocita.Value = 1;
            trackBarDimensioneCampo.Value = 1;

            pnlNickname.Controls.Add(pnlNicknamePlayer2);
            pnlNicknamePlayer2.Dock = DockStyle.Bottom;
            pnlNicknamePlayer2.Size = new Size(pnlNicknamePlayer2.Width, 100);
            pnlNicknamePlayer2.Enabled = false;
            pnlNicknamePlayer2.Visible = false;

            lblNamePlayer2.Text = "Inserisci il nome del giocatore 2";
            lblNamePlayer2.Location = new Point(lblNome.Location.X, pnlNicknamePlayer2.Height / 2 - lblNamePlayer2.Height / 2);

            txtNamePlayer2.Size = txtNome.Size;

            try
            {
                pnlSettings.Controls.Add(picLogo);
                picLogo.Image = Image.FromFile("Data/imgs/logoSnake.png");
                picLogo.Size = new Size((int)(pnlSettings.Height * 2.133), pnlSettings.Height);     //2.133 è il rapporto tra la larghezza e l'altezza dell'immagine logoSnake.png
                picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                picLogo.Location = new Point(this.Width / 2 - picLogo.Width / 2, 1);
            }
            catch (FileNotFoundException)
            {
                ImageLogoExceptionSolution(ref picLogo);
            }
            catch (OutOfMemoryException)
            {
                ImageLogoExceptionSolution(ref picLogo);
            }
            catch (ArgumentException)
            {
                ImageLogoExceptionSolution(ref picLogo);
            }
            catch (Exception)
            {
                ImageLogoExceptionSolution(ref picLogo);
                Console.WriteLine("Errore ignoto :/");
            }
        }

        private void ImageLogoExceptionSolution(ref PictureBox pic)
        {
            pnlSettings.Controls.Remove(pic);
            pic.Image = null;
            pic.Enabled = false;
            pic.Visible = false;
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
                pnlDimensioneCampo.Enabled = false;
                pnlDimensioneCampo.Visible = false;
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
                pnlDimensioneCampo.Enabled = true;
                pnlDimensioneCampo.Visible = true;
            }
        }
    }
}
