using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace Snake
{
    enum Tasto
    {
        sinistra,
        destra,
        su,
        giu,
        fermo
    }
    public partial class frmSnake : Form
    {
        private int[,] campoGioco;
        private int sizeStampa;
        private frmMenu nomeChiamante;
        private int heightCampoGioco, widthCampoGioco;
        private Serpente serpente;
        private Cibo cibo;
        private RootNomiFile rootNomiFile;
        private Livello livello;
        private int numLivello;
        private Point posPrec;
        private Tasto tasto = Tasto.fermo;

        /// <summary>
        /// costruttore del form. bisogna passargli il nome della form chiamante, altezza e larghezza del campo gioco e intervallo del timer
        /// </summary>
        /// <param name="frmChiamante"></param>
        /// <param name="HeightCampoGioco"></param>
        /// <param name="WidthCampoGioco"></param>
        /// <param name="timerTick"></param>
        public frmSnake(frmMenu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, int numLivello = 0)
        {
            InitializeComponent();
            nomeChiamante = frmChiamante;
            this.heightCampoGioco = heightCampoGioco;
            this.widthCampoGioco = widthCampoGioco;
            this.numLivello = numLivello;
            tmr.Interval = timerInterval;
            tmr.Enabled = true;
        }

        /// <summary>
        /// inizializza il campo di gioco. stampa di tutti gli oggetti iniziali
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            serpente = new Serpente(widthCampoGioco, heightCampoGioco);
            cibo = new Cibo(widthCampoGioco, heightCampoGioco);
            livello = new Livello();
            rootNomiFile = new RootNomiFile();
            CaricamentoLivello();
            Inizializza(heightCampoGioco, widthCampoGioco);
            AggiornaMatrice();
            TrasferelloSnake(serpente);
            StampaCampoGioco();
            PrintFood(cibo);
            IncSnake(cibo, serpente);
        }

        /// <summary>
        /// inizializza la grndezza del campo gioco
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        private void Inizializza(int height, int width)
        {
            //per il momento è 16, in seguito bisgona fare una funzione getGrandezza per impostarla di conseguenza ??
            sizeStampa = 16;
            //stesso ragionamento per la dimensione del campo gioco
            campoGioco = new int[width, height];
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    campoGioco[i, j] = 0;
                }
            }
            pnlCampoGioco.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
            pnlElementiDinamici.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
            pnlElementiDinamici.Location = new Point(0, 0);
            //pnlElementiDinamici.Visible = false;
            //pnlElementiDinamici.Enabled = false;
            this.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
            posPrec = new Point();
        }

        /// <summary>
        /// creazione pannello per il cibo
        /// </summary>
        /// <param name="cibo"></param>
        private void PrintFood(Cibo c)
        {
            Panel panello = new Panel();
            panello.BackColor = Color.Orange;
            panello.BackgroundImage = (Snake.Properties.Resources.cibo_snake);
            panello.BorderStyle = BorderStyle.FixedSingle;
            panello.Location = new Point(c.GetFoodX()*sizeStampa, c.GetFoodY()*sizeStampa);
            panello.Size = new Size(sizeStampa, sizeStampa);
            panello.Visible = true;
            pnlCampoGioco.Controls.Add(panello);
        }
        /// <summary>
        /// incremento della lunghezza del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="serpente"></param>
        private void IncSnake(Cibo c,Serpente serpente)
        {
            if (c.GetFoodX() == serpente.GetX(0) && c.GetFoodY() == serpente.GetY(0))
                serpente.IncLength();
            cibo = new Cibo(cibo.GetFoodX(),cibo.GetFoodY());
        }


        /// <summary>
        /// riporta tutti i valori della matrice campoGioco a 0
        /// </summary>
        private void ResetMatrice()
        {
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    campoGioco[i, j] = 0;
                }
            }
        }

        #region Funzioni stampa

        /// <summary>
        /// stampa il campo gioco
        /// </summary>
        private void StampaCampoGioco()
        {
            DrawingControl.SuspendDrawing(pnlCampoGioco);
            pnlCampoGioco.Controls.Clear();
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    if (campoGioco[i, j] == 1)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = Color.White;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Location = new Point(i * sizeStampa, j * sizeStampa);
                        panel.Size = new Size(sizeStampa, sizeStampa);
                        panel.Visible = true;
                        pnlCampoGioco.Controls.Add(panel);
                    }
                    // --- O si usa lo sfondo nero oppure bisogna trovare il modo di cancellare solo il serpente e ristamparlo, senza dover ristampare ogni volta tutto il campo gioco
                    /*
                    
                    else
                    {
                        Panel panel = new Panel();
                        panel.BackColor = Color.Black;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Location = new Point(i * sizeStampa, j * sizeStampa);
                        panel.Size = new Size(sizeStampa, sizeStampa);
                        panel.Visible = true;
                        pnlCampoGioco.Controls.Add(panel);
                    }

                    */
                }
            }
            DrawingControl.ResumeDrawing(pnlCampoGioco);
            pnlCampoGioco.Controls.Add(pnlElementiDinamici);
        }

        /// <summary>
        /// stampa il serpente in base alla propria posizione
        /// </summary>
        /// <param name="serpente"></param>
        private void StampaSerpente(Serpente serpente)
        {
            DrawingControl.SuspendDrawing(pnlElementiDinamici);
            pnlElementiDinamici.Controls.Clear();
            for (int i = 0; i < serpente.getLength(); i++)
            {
                Panel panel = new Panel();
                panel.Location = new Point(serpente.GetX(i) * sizeStampa, serpente.GetY(i) * sizeStampa);
                panel.Size = new Size(sizeStampa, sizeStampa);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.Orange;
                panel.Visible = true;
                pnlElementiDinamici.Controls.Add(panel);
            }
            DrawingControl.ResumeDrawing(pnlElementiDinamici);
        }

        /// <summary>
        /// stampa l'istanza della classe cibo
        /// </summary>
        /// <param name="cibo"></param>
        private void StampaCibo(Cibo cibo)
        {
        }

        #endregion

        /// <summary>
        /// ritorna l'altezza del campo gioco
        /// </summary>
        /// <returns></returns>
        private int GetHeigth()
        {
            return campoGioco.GetLength(0);
        }

        /// <summary>
        /// ritorna la larghezza del campo gioco
        /// </summary>
        /// <returns></returns>
        private int GetWidth()
        {
            return campoGioco.GetLength(1);
        }

        /// <summary>
        /// stampa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Tick(object sender, EventArgs e)
        {
            ResetMatrice();
            AggiornaMatrice();
            TrasferelloSnake(serpente);
            StampaSerpente(serpente);
            //StampaCampoGioco();
            switch (tasto)
            {
                case Tasto.sinistra:
                    serpente.AggiornaSnake(-1,0);
                    break;
                case Tasto.destra:
                    serpente.AggiornaSnake(1, 0);
                    break;
                case Tasto.su:
                    serpente.AggiornaSnake(0,-1);
                    break;
                case Tasto.giu:
                    serpente.AggiornaSnake(0, 1);
                    break;
                case Tasto.fermo:
                    break;
            }

        }

        /// <summary>
        /// spostamento della serpe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSnake_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        tasto = Tasto.sinistra;
                    }
                    break;
                case Keys.Right:
                    {
                        tasto = Tasto.destra;
                    }
                    break;
                case Keys.Up:
                    {
                        tasto = Tasto.su;
                    }
                    break;
                case Keys.Down:
                    {
                        tasto = Tasto.giu;
                    }
                    break;
            }
            //Queste funzioni vanno messe altrove, credo nel timer
            ResetMatrice();
            AggiornaMatrice();
            TrasferelloSnake(serpente);
            StampaSerpente(serpente);
            //StampaCampoGioco();
        }

        /// <summary>
        /// imposta a 2 i campi della matrice campoGioco occupati dal serpente
        /// </summary>
        /// <param name="s"></param> 
        private void TrasferelloSnake(Serpente s)
        {
            for (int i = 0; i < s.getLength(); i++)
            {
                campoGioco[s.GetX(i), s.GetY(i)] = 2;
            }
            posPrec.X = s.GetX(s.getLength() - 1);
            posPrec.Y = s.GetY(s.getLength() - 1);
        }

        /// <summary>
        /// deserializza il file json nella classe Livello
        /// </summary>
        private void CaricamentoLivello()
        {
            StreamReader reader1 = new StreamReader("levels/indice_livelli.json");
            rootNomiFile = JsonConvert.DeserializeObject<RootNomiFile>(reader1.ReadToEnd());
            reader1.Close();
            StreamReader reader2 = new StreamReader("levels/" + rootNomiFile.nomeFileDaLeggere[numLivello]);
            livello = JsonConvert.DeserializeObject<Livello>(reader2.ReadToEnd());
            reader2.Close();
            if (numLivello != 0)
            {
                switch (livello.dimensioneCampo)
                {
                    case DimensioniCampoGioco.Piccolo:
                        widthCampoGioco = frmMenu.WIDTH_CAMPO_PICCOLO;
                        heightCampoGioco = frmMenu.HEIGHT_CAMPO_PICCOLO;
                        break;
                    case DimensioniCampoGioco.Medio:
                        widthCampoGioco = frmMenu.WIDTH_CAMPO_MEDIO;
                        heightCampoGioco = frmMenu.HEIGHT_CAMPO_MEDIO;
                        break;
                    case DimensioniCampoGioco.Grande:
                        widthCampoGioco = frmMenu.WIDTH_CAMPO_GRANDE;
                        heightCampoGioco = frmMenu.HEIGHT_CAMPO_GRANDE;
                        break;
                    default:
                        goto case DimensioniCampoGioco.Medio;
                }
            }
        }

        /// <summary>
        /// aggiunge i muri alla matrice
        /// </summary>
        private void AggiornaMatrice()
        {
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    for (int k = 0; k < livello.posMuri.Count; k++)
                    {
                        if (i == livello.posMuri[k]._x && j == livello.posMuri[k]._y)
                        {
                            campoGioco[i, j] = 1;
                        }
                    }
                }
            }
            campoGioco[cibo.GetFoodX(), cibo.GetFoodY()] = 2;
        }

        /// <summary>
        /// riapre il menu se si chiude il gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSnake_FormClosing(object sender, FormClosingEventArgs e)
        {
            nomeChiamante.Show();
        }
    }

    /// <summary>
    /// Classe speciale che ha due metodi utili ad impedire l'effetto sfarfallio nel draw
    /// </summary>
    class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}
