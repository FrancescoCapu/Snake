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
    /*
    public partial class frmMultiplayer : Form
    {
        enum Tasto
        {
            sinistra,
            destra,
            su,
            giu,
            fermo
        }

        enum Elementi
        {
            libero = 0,
            muro = 1
        }

        private Elementi[,] campoGioco;
        private Menu nomeChiamante;
        private int heightCampoGioco, widthCampoGioco;
        private Serpente serpente1, serpente2;
        private Cibo cibo;
        private RootNomiFile rootNomiFile;
        private Livello livello;
        private int numLivello;
        private Tasto tasto = Tasto.fermo;
        private Tasto tastoPrec = Tasto.destra;
        private Point posLastPrec;
        private Queue<Panel> queueserpente1 = new Queue<Panel>();
        private List<Panel> lstPanelCibo = new List<Panel>();
        private Panel panelLingua;
        private bool useTongue;
        private int contIntervalTongue = 0;
        private Ranking classifica;
        private RecordUtente recordutente = new RecordUtente();
        private readonly Color color;

        /// <summary>
        /// costruttore del form. bisogna passargli il nome della form chiamante, altezza e larghezza del campo gioco e intervallo del timer
        /// </summary>
        /// <param name="frmChiamante"></param>
        /// <param name="HeightCampoGioco"></param>
        /// <param name="WidthCampoGioco"></param>
        /// <param name="timerTick"></param>
        public frmMultiplayer(Menu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, string nome, Color color, int numLivello = 0)
        {
            InitializeComponent();
            nomeChiamante = frmChiamante;
            this.heightCampoGioco = heightCampoGioco;
            this.widthCampoGioco = widthCampoGioco;
            this.color = color;
            this.numLivello = numLivello;
            recordutente.NomePlayer = nome;
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
            livello = new Livello();
            rootNomiFile = new RootNomiFile();
            CaricamentoLivello();
            Inizializza(heightCampoGioco, widthCampoGioco);
            serpente1 = new Serpente(livello.head.X, livello.head.Y);
            posLastPrec = new Point(serpente1.GetX(serpente1.GetLength() - 1), serpente1.GetY(serpente1.GetLength() - 1));
            cibo = new Cibo(widthCampoGioco, heightCampoGioco);
            AddMuri();
            StampaCampoGioco();
            Stampaserpente(serpente1);
            PrintTongue();
            NewCibo(ref cibo, serpente);
            PrintFood(cibo);
            classifica = new Ranking();
        }

        /// <summary>
        /// inizializza la matrice e la dimensione dei pannelli/form
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        private void Inizializza(int height, int width)
        {
            campoGioco = new Elementi[width, height];
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    campoGioco[i, j] = Elementi.libero;
                }
            }
            pnlCampoGioco.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato);
            pnlElementiDinamici.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato);
            pnlElementiDinamici.Location = new Point(0, 0);
            pnlElementiDinamici.BorderStyle = BorderStyle.None;
            this.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato);
        }

        /// <summary>
        /// incremento della lunghezza del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="serpente"></param>
        private void IncSnake(Cibo c, Serpente serpente)
        {
            serpente.IncLength(posLastPrec);
        }

        /// <summary>
        /// resetta le variabili relative all'utilizzo della lingua
        /// </summary>
        /// <param name="s"></param>
        private void ResetTongue(ref Serpente s)
        {
            useTongue = false;
            panelLingua.Visible = false;
            s.SetTonguePosition(s.GetX(0), s.GetY(0));
        }

        /// <summary>
        /// controlla se l'utilizzo della lingua è stato richiesto
        /// </summary>
        /// <param name="s"></param>
        /// <param name="incX"></param>
        /// <param name="incY"></param>
        private void CheckUseTongue(ref Serpente s, int incX, int incY)
        {
            if (useTongue)
                UseTongue(ref s, incX, incY);
            else
            {
                s.SetTonguePosition(s.GetX(0), s.GetY(0));
            }
        }

        /// <summary>
        /// rende visibile la lingua e aggiorna la posizione della stessa
        /// </summary>
        /// <param name="s"></param>
        /// <param name="incX"></param>
        /// <param name="incY"></param>
        private void UseTongue(ref Serpente s, int incX, int incY)
        {
            panelLingua.Visible = true;
            s.SetTonguePosition(s.GetX(0) + incX, s.GetY(0) + incY);
        }

        #region Funzioni stampa

        /// <summary>
        /// stampa il campo gioco
        /// </summary>
        private void StampaCampoGioco()
        {
            DrawingControl.SuspendDrawing(pnlCampoGioco);
            pnlCampoGioco.Controls.Clear();
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    if (campoGioco[i, j] == Elementi.muro)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = Color.White;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Location = new Point(i * Config.sizeQuadrato, j * Config.sizeQuadrato);
                        panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                        panel.Visible = true;
                        pnlCampoGioco.Controls.Add(panel);
                    }
                }
            }
            DrawingControl.ResumeDrawing(pnlCampoGioco);
            pnlCampoGioco.Controls.Add(pnlElementiDinamici);
        }

        /// <summary>
        /// stampa il serpente in base alla propria posizione. da usare solo per la prima stampa
        /// </summary>
        /// <param name="serpente"></param>
        private void StampaSerpente(Serpente s)
        {
            DrawingControl.SuspendDrawing(pnlElementiDinamici);
            pnlElementiDinamici.Controls.Clear();
            for (int i = s.GetLength() - 1; i > -1; i--)
            {
                Panel panel = new Panel();
                panel.Location = new Point(s.GetX(i) * Config.sizeQuadrato, s.GetY(i) * Config.sizeQuadrato);
                panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = color;
                panel.Visible = true;
                //lstPanelSerpente.Add(panel);
                queueSerpente.Enqueue(panel); //se funziona usare questo
                pnlElementiDinamici.Controls.Add(panel);
            }
            DrawingControl.ResumeDrawing(pnlElementiDinamici);
        }

        /// <summary>
        /// aggiorna la posizione dei pannelli che compongono il serpente senza doverli cancellare e ristampare ogni volta
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hasEaten"></param>
        private void UpdateSnake(ref Serpente s, bool hasEaten = false)
        {
            Panel temp;
            if (hasEaten)
            {
                Panel panel = new Panel();
                panel.Location = new Point(s.GetX(0) * Config.sizeQuadrato, s.GetY(0) * Config.sizeQuadrato);
                panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = color;
                panel.Visible = true;
                queueSerpente.Enqueue(panel);

                //Se si può evitare il for è meglio...

                for (int i = 0; i < s.GetLength() - 1; i++)
                {
                    temp = queueSerpente.Dequeue();
                    queueSerpente.Enqueue(temp);
                }

                pnlElementiDinamici.Controls.Add(panel);
            }
            else
            {
                temp = queueSerpente.Dequeue();
                temp.Location = new Point(s.GetX(0) * Config.sizeQuadrato, s.GetY(0) * Config.sizeQuadrato);
                queueSerpente.Enqueue(temp);
            }
        }

        /// <summary>
        /// creazione pannello per il cibo. da usare solo per la prima stampa
        /// </summary>
        /// <param name="cibo"></param>
        private void PrintFood(Cibo c)
        {
            Panel pannello = new Panel();
            PictureBox mela = new PictureBox();
            mela.Visible = true;
            mela.Enabled = true;
            mela.SizeMode = PictureBoxSizeMode.StretchImage;
            mela.Image = Image.FromFile("Data/imgs/mela.png");
            pannello.Controls.Add(mela);
            pannello.BorderStyle = BorderStyle.None;
            pannello.Location = new Point(c.GetFoodX() * Config.sizeQuadrato, c.GetFoodY() * Config.sizeQuadrato);
            pannello.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
            mela.Size = pannello.Size;
            pannello.Visible = true;
            pnlElementiDinamici.Controls.Add(pannello);
            lstPanelCibo.Add(pannello);
            Console.WriteLine(c.GetFoodX().ToString() + " " + c.GetFoodY().ToString());
        }

        /// <summary>
        /// aggiorna la posizione del pannello del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="foodIndex"></param>
        private void UpdateFood(ref Cibo c, int foodIndex = 0)
        {
            lstPanelCibo[foodIndex].Location = new Point(c.GetFoodX() * Config.sizeQuadrato, c.GetFoodY() * Config.sizeQuadrato);
        }

        /// <summary>
        /// Inizializza il pannello della lingua e lo aggiunge a pnlElementiDinamici
        /// </summary>
        private void PrintTongue(ref Serpente s)
        {
            panelLingua = new Panel();
            panelLingua.Visible = false;
            panelLingua.Enabled = true;
            panelLingua.BackColor = Color.Red;
            panelLingua.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato / 3);
            panelLingua.Location = new Point((s.GetX(0)) * Config.sizeQuadrato, (s.GetY(0) * Config.sizeQuadrato) + Config.sizeQuadrato / 3);
            pnlElementiDinamici.Controls.Add(panelLingua);
        }

        /// <summary>
        /// aggriorna la posizione e l'orientamento della lingua in base alla direzione corrente
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdateTongue(int x, int y)
        {
            if (tasto == Tasto.su || tasto == Tasto.giu)
            {
                panelLingua.Location = new Point(x * Config.sizeQuadrato + Config.sizeQuadrato / 3, y * Config.sizeQuadrato);
                panelLingua.Size = new Size(Config.sizeQuadrato / 3, Config.sizeQuadrato);
            }
            else
            {
                panelLingua.Location = new Point(x * Config.sizeQuadrato, y * Config.sizeQuadrato + Config.sizeQuadrato / 3);
                panelLingua.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato / 3);
            }
        }

        #endregion

        /// <summary>
        /// ritorna l'altezza del campo gioco
        /// </summary>
        /// <returns></returns>
        private int GetWidth()
        {
            return campoGioco.GetLength(0);
        }

        /// <summary>
        /// ritorna la larghezza del campo gioco
        /// </summary>
        /// <returns></returns>
        private int GetHeigth()
        {
            return campoGioco.GetLength(1);
        }

        /// <summary>
        /// gestisce la logica del gioco ad ogni tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Tick(object sender, EventArgs e)
        {
            switch (tasto)
            {
                case Tasto.sinistra:
                    if (tastoPrec != Tasto.destra)
                    {
                        serpente.AggiornaSnake(-1, 0);
                        tastoPrec = Tasto.sinistra;
                        CheckUseTongue(ref serpente, -1, 0);
                    }
                    else
                    {
                        goto case Tasto.destra;
                    }
                    break;
                case Tasto.destra:
                    if (tastoPrec != Tasto.sinistra)
                    {
                        serpente.AggiornaSnake(1, 0);
                        tastoPrec = Tasto.destra;
                        CheckUseTongue(ref serpente, 1, 0);
                    }
                    else
                    {
                        goto case Tasto.sinistra;
                    }
                    break;
                case Tasto.su:
                    if (tastoPrec != Tasto.giu)
                    {
                        serpente.AggiornaSnake(0, -1);
                        tastoPrec = Tasto.su;
                        CheckUseTongue(ref serpente, 0, -1);
                    }
                    else
                    {
                        goto case Tasto.giu;
                    }
                    break;
                case Tasto.giu:
                    if (tastoPrec != Tasto.su)
                    {
                        serpente.AggiornaSnake(0, 1);
                        tastoPrec = Tasto.giu;
                        CheckUseTongue(ref serpente, 0, 1);
                    }
                    else
                    {
                        goto case Tasto.su;
                    }
                    break;
                case Tasto.fermo:
                    break;
            }
            //Console.WriteLine(serpente.GetX(0) + " " + serpente.GetY(0));
            posLastPrec = new Point(serpente.GetX(serpente.GetLength() - 1), serpente.GetY(serpente.GetLength() - 1));
            UpdateTongue(serpente.GetTongueX(), serpente.GetTongueY());
            if ((serpente.GetX(0) < 0 || serpente.GetX(0) > GetWidth() - 1 || serpente.GetY(0) < 0 || serpente.GetY(0) > GetHeigth() - 1) || Collisioni(serpente))
                GameOver();
            else
            {
                if (HasEaten(ref serpente, ref cibo))
                {
                    IncSnake(cibo, serpente);
                    UpdateSnake(ref serpente, true);
                    NewCibo(ref cibo, serpente);
                    UpdateFood(ref cibo);
                }
                if (tasto != Tasto.fermo)
                    UpdateSnake(ref serpente, false);
            }
            if (contIntervalTongue != 3 && useTongue)
                contIntervalTongue++;
            else
            {
                ResetTongue(ref serpente);
                contIntervalTongue = 0;
            }
        }

        /// <summary>
        /// spostamento della serpe e utilizzo della lingua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMultiplayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Config.up)
                tasto = Tasto.su;
            else if (e.KeyCode == Config.left)
                tasto = Tasto.sinistra;
            else if (e.KeyCode == Config.down)
                tasto = Tasto.giu;
            else if (e.KeyCode == Config.right)
                tasto = Tasto.destra;
            else if (e.KeyCode == Config.tongue)
                useTongue = true;
        }

        /// <summary>
        /// controlla se la testa del serpente sbatte contro un muro o contro il serpente
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool Collisioni(Serpente s)
        {
            if (campoGioco[s.GetX(0), s.GetY(0)] == Elementi.muro)
                return true;
            else
            {
                for (int i = 1; i < s.GetLength(); i++)
                {
                    if (s.GetX(0) == s.GetX(i) && s.GetY(0) == s.GetY(i))
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// controlla se il serpente ha mangiato o no. ritorna un booleano
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool HasEaten(ref Serpente s, ref Cibo c)
        {
            if (s.GetX(0) == c.GetFoodX() && s.GetY(0) == c.GetFoodY() || s.GetTongueX() == c.GetFoodX() && s.GetTongueY() == c.GetFoodY())
                return true;
            return false;
        }
     

        /// <summary>
        /// deserializza il file json nella classe Livello
        /// </summary>
        private void CaricamentoLivello()
        {
            /*
            StreamReader reader1 = new StreamReader("Data/levels/indice_livelli.json");
            rootNomiFile = JsonConvert.DeserializeObject<RootNomiFile>(reader1.ReadToEnd());
            reader1.Close();
            */
   /*
            GetNomiFile(ref rootNomiFile);
            StreamReader reader = new StreamReader("Data/levels/" + rootNomiFile.nomeFileDaLeggere[numLivello]);
            livello = JsonConvert.DeserializeObject<Livello>(reader.ReadToEnd());
            reader.Close();
            if (numLivello != 0)
            {
                switch (livello.dimensioneCampo)
                {
                    case DimensioniCampoGioco.Piccolo:
                        widthCampoGioco = Snake.Menu.WIDTH_CAMPO_PICCOLO;
                        heightCampoGioco = Snake.Menu.HEIGHT_CAMPO_PICCOLO;
                        break;
                    case DimensioniCampoGioco.Medio:
                        widthCampoGioco = Snake.Menu.WIDTH_CAMPO_MEDIO;
                        heightCampoGioco = Snake.Menu.HEIGHT_CAMPO_MEDIO;
                        break;
                    case DimensioniCampoGioco.Grande:
                        widthCampoGioco = Snake.Menu.WIDTH_CAMPO_GRANDE;
                        heightCampoGioco = Snake.Menu.HEIGHT_CAMPO_GRANDE;
                        break;
                    default:
                        goto case DimensioniCampoGioco.Medio;
                }
            }
        }

        public static void GetNomiFile(ref RootNomiFile rnf)
        {
            StreamReader reader = new StreamReader("Data/levels/indice_livelli.json");
            rnf = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
        }

        /// <summary>
        /// aggiunge i muri alla matrice
        /// </summary>
        private void AddMuri()
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    for (int k = 0; k < livello.posMuri.Count; k++)
                    {
                        if (i == livello.posMuri[k]._x && j == livello.posMuri[k]._y)
                        {
                            campoGioco[i, j] = Elementi.muro;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// chiude il gioco
        /// </summary>
        private void GameOver()
        {
            tmr.Enabled = false;
            MessageBox.Show("GAME OVER\nPunteggio: " + serpente.GetLength(), "GAME OVER ");
            this.Close();
        }

        /// <summary>
        /// salva la classifica del livello selezionato su un file esterno
        /// </summary>
        /// <param name="classifica"></param>
        /// <param name="index"></param>
        private static void SaveClassifica(ref Ranking classifica, int index)
        {
            if (!System.IO.Directory.Exists("Data/Classifica"))
                System.IO.Directory.CreateDirectory("Data/Classifica");
            string json = JsonConvert.SerializeObject(classifica);
            string nome = "Data/Classifica/classifica" + index + ".json";
            System.IO.File.WriteAllText(@nome, json);
        }

        /// <summary>
        /// legge la classifica dal file esterno del livello selezionato
        /// </summary>
        /// <param name="c"></param>
        /// <param name="index"></param>
        public static void ReadClassifica(ref Ranking c, int index)
        {
            try
            {
                StreamReader reader = new StreamReader("Data/Classifica/classifica" + index + ".json");
                c = JsonConvert.DeserializeObject<Ranking>(reader.ReadToEnd());
                reader.Close();
            }
            catch (FileNotFoundException)
            {

            }
            catch (DirectoryNotFoundException)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// riapre il menu se si chiude il gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMultiplayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadClassifica(ref classifica, numLivello);
            recordutente.PunteggioPlayer = serpente.GetLength();
            nomeChiamante.Show();
            classifica.ClassificaPunteggi.Add(recordutente);
            classifica.ClassificaPunteggi.Sort((s1, s2) => s2.PunteggioPlayer.CompareTo(s1.PunteggioPlayer));
            if (classifica.ClassificaPunteggi.Count > 10)
            {
                for (int i = classifica.ClassificaPunteggi.Count - 1; i > 9; i--)
                {
                    classifica.ClassificaPunteggi.Remove(classifica.ClassificaPunteggi[i]);
                }
            }
            SaveClassifica(ref classifica, numLivello);
        }

        /// <summary>
        /// istanzia un nuovo cibo e controlla se la sua posizione è valida
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        private void NewCibo(ref Cibo c, Serpente s)
        {
            bool flag;
            if (livello.numLev == 0)
            {
                do
                {
                    flag = false;
                    c = new Cibo(GetWidth(), GetHeigth());
                    for (int i = 0; i < s.GetLength(); i++)
                    {
                        if (c.GetFoodX() == s.GetX(i) && c.GetFoodY() == s.GetY(i))
                        {
                            flag = true;
                        }
                    }
                } while (flag);
            }
            else
            {
                do
                {
                    flag = false;
                    c = new Cibo(GetWidth(), GetHeigth());
                    Console.WriteLine(c.GetFoodX().ToString() + " " + c.GetFoodY().ToString());
                    for (int i = 0; i < s.GetLength(); i++)
                    {
                        if (c.GetFoodX() == s.GetX(i) && c.GetFoodY() == s.GetY(i) || campoGioco[c.GetFoodX(), c.GetFoodY()] == Elementi.muro)
                        {
                            flag = true;
                            break;
                        }
                    }
                } while (flag);
            }
        }
    }
   */
}