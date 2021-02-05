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
    public partial class frmSnake : Form
    {
        protected enum Tasto
        {
            sinistra,
            destra,
            su,
            giu,
            fermo
        }

        protected enum Elementi
        {
            libero = 0,
            muro = 1
        }

        protected Elementi[,] campoGioco;
        protected frmMenu nomeChiamante;
        protected int heightCampoGioco, widthCampoGioco;
        protected Serpente serpente;
        protected Cibo cibo;
        protected RootNomiFile rootNomiFile;
        protected Livello livello;
        protected int numLivello;
        protected Tasto tasto = Tasto.fermo;
        protected Tasto tastoPrec = Tasto.destra;
        protected Point posLastPrec;
        //protected Queue<Panel> queueSerpente = new Queue<Panel>();
        protected ModQueue modQueueSerpente = new ModQueue();
        protected List<Panel> lstPanelCibo = new List<Panel>();
        protected Panel pnlLingua;
        protected Ranking classifica;
        protected RecordUtente recordutente = new RecordUtente();
        //protected readonly Color color;
        protected const int TICK_TO_RESET_TONGUE = 3;
        protected Player player1;
        protected bool gameOver = false;

        /// <summary>
        /// costruttore del form. bisogna passargli il nome della form chiamante, altezza e larghezza del campo gioco e intervallo del timer
        /// </summary>
        /// <param name="frmChiamante"></param>
        /// <param name="HeightCampoGioco"></param>
        /// <param name="WidthCampoGioco"></param>
        /// <param name="timerTick"></param>
        public frmSnake(frmMenu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, Player player, int numLivello = 0)
        {
            InitializeComponent();
            nomeChiamante = frmChiamante;
            this.heightCampoGioco = heightCampoGioco;
            this.widthCampoGioco = widthCampoGioco;
            //this.color = color;
            this.numLivello = numLivello;
            //recordutente.NomePlayer = nome;
            tmr.Interval = timerInterval;
            tmr.Enabled = true;
            player1 = player;
            recordutente.NomePlayer = player.Name;   
        }

        public frmSnake()
        {
            InitializeComponent();
        }

        /// <summary>
        /// inizializza il campo di gioco. stampa di tutti gli oggetti iniziali
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void frmSnake_Load(object sender, EventArgs e)
        {
            
            if ((sender) == this) {
                livello = new Livello();
                rootNomiFile = new RootNomiFile();
                CaricamentoLivello();
                Inizializza(heightCampoGioco, widthCampoGioco, ref pnlCampoGioco, ref pnlElementiDinamici, ref pnlScore, ref lblScore, ref lblTotalScore); //, ref pnlScore);
                serpente = new Serpente(livello.head.X, livello.head.Y);
                posLastPrec = new Point(serpente.GetX(serpente.GetLength() - 1), serpente.GetY(serpente.GetLength() - 1));
                cibo = new Cibo(widthCampoGioco, heightCampoGioco);
                if (numLivello != 0)
                    AddMuri();
                StampaCampoGioco(ref pnlCampoGioco, ref pnlElementiDinamici);
                //StampaSerpente(ref serpente, ref player1, ref pnlElementiDinamici, ref queueSerpente);
                StampaSerpente(ref serpente, ref player1, ref pnlElementiDinamici, ref modQueueSerpente);
                PrintTongue(ref serpente, ref pnlElementiDinamici, ref pnlLingua);
                NewCibo(ref cibo, ref serpente);
                PrintFood(ref cibo, ref pnlElementiDinamici, ref lstPanelCibo);
                classifica = new Ranking();
            }
            
        }

        /// <summary>
        /// inizializza la matrice e la dimensione dei pannelli/form
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        /// <param name="pnlCampo">pnlCampoGioco</param>
        /// <param name="pnlSnake">pnlElementiDinamici</param>
        private void Inizializza(int height, int width, ref Panel pnlCampo, ref Panel pnlSnake, ref Panel pnlScore, ref Label lblScore, ref Label lblTotalScore) //, ref Panel pnlScore)
        {
            campoGioco = new Elementi[width, height];
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    campoGioco[i, j] = Elementi.libero;
                }
            }
            pnlCampo.Location = new Point(0, 0);
            //pnlSnake.Location = new Point(0, 0);
            //pnlScore.Size = new Size(GetWidth() * Config.sizeQuadrato, 50);
            pnlCampo.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato); // + pnlScore.Height);
            pnlSnake.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato);
            pnlSnake.Location = new Point(0, 0);
            pnlSnake.BorderStyle = BorderStyle.None;
            pnlScore.Location = new Point(0, pnlCampo.Height);
            pnlScore.Size = new Size(GetWidth() * Config.sizeQuadrato + 4, 100);
            lblScore.Location = new Point(25, pnlScore.Height / 2 - lblScore.Height / 2);
            lblTotalScore.Location = new Point(lblScore.Location.X + lblScore.Width + 15, lblScore.Location.Y);
            //pnlScore.Location = new Point(0, GetHeigth() * Config.sizeQuadrato);
            //pnlCampo.Controls.Add(pnlScore);
            this.Size = new Size(GetWidth() * Config.sizeQuadrato, GetHeigth() * Config.sizeQuadrato + pnlScore.Height); // + pnlScore.Height);
        }

        /// <summary>
        /// incremento della lunghezza del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="serpente"></param>
        protected void IncSnake(ref Serpente s)
        {
            s.IncLength(posLastPrec);
        }

        /// <summary>
        /// resetta le variabili relative all'utilizzo della lingua
        /// </summary>
        /// <param name="s"></param>
        protected void ResetTongue(ref Serpente s, ref Panel pnlTongue)
        {
            s.useTongue = false;
            pnlTongue.Visible = false;
            s.SetTonguePosition(s.GetX(0), s.GetY(0));
        }

        /// <summary>
        /// controlla se l'utilizzo della lingua è stato richiesto
        /// </summary>
        /// <param name="s"></param>
        /// <param name="incX"></param>
        /// <param name="incY"></param>
        protected void CheckUseTongue(ref Serpente s, ref Panel pnlTongue, int incX, int incY)
        {
            if (s.useTongue)
                UseTongue(ref s, ref pnlTongue, incX, incY);
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
        protected void UseTongue(ref Serpente s, ref Panel pnlTongue, int incX, int incY)
        {
            pnlTongue.Visible = true;
            s.SetTonguePosition(s.GetX(0) + incX, s.GetY(0) + incY);
        }

        #region Funzioni stampa

        /// <summary>
        /// stampa il campo gioco
        /// </summary>
        protected void StampaCampoGioco(ref Panel pnlCampo, ref Panel pnlSnake)
        {
            DrawingControl.SuspendDrawing(pnlCampo);
            pnlCampo.Controls.Clear();
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
                        pnlCampo.Controls.Add(panel);
                    }
                }
            }
            DrawingControl.ResumeDrawing(pnlCampo);
            pnlCampo.Controls.Add(pnlSnake);
        }

        /// <summary>
        /// stampa il serpente in base alla propria posizione. da usare solo per la prima stampa
        /// </summary>
        /// <param name="serpente"></param>
        //protected void StampaSerpente(ref Serpente s, ref Player player, ref Panel pnlSnake, ref Queue<Panel> queueSnake)
        protected void StampaSerpente(ref Serpente s, ref Player player, ref Panel pnlSnake, ref ModQueue modQueue, bool leftToRight = true)
        {
            
            DrawingControl.SuspendDrawing(pnlSnake);
            //pnlSnake.Controls.Clear();
            if (leftToRight)
            {
                for (int i = s.GetLength() - 1; i > -1; i--)
                {
                    Panel panel = new Panel();
                    panel.Location = new Point(s.GetX(i) * Config.sizeQuadrato, s.GetY(i) * Config.sizeQuadrato);
                    panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    //panel.BackColor = player.GetColor();
                    panel.BackColor = player.Color;
                    panel.Visible = true;
                    //queueSnake.Enqueue(panel); //se funziona usare questo
                    modQueue.Enqueue(panel);
                    pnlSnake.Controls.Add(panel);
                }
            }
            else
            {
                for (int i = 0; i < s.GetLength(); i++)
                {
                    Panel panel = new Panel();
                    panel.Location = new Point(s.GetX(i) * Config.sizeQuadrato, s.GetY(i) * Config.sizeQuadrato);
                    panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    //panel.BackColor = player.GetColor();
                    panel.BackColor = player.Color;
                    panel.Visible = true;
                    //queueSnake.Enqueue(panel); //se funziona usare questo
                    modQueue.Enqueue(panel);
                    pnlSnake.Controls.Add(panel);
                }
            }
            DrawingControl.ResumeDrawing(pnlSnake);
        }

        /// <summary>
        /// aggiorna la posizione dei pannelli che compongono il serpente senza doverli cancellare e ristampare ogni volta
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hasEaten"></param>
        //protected void UpdateSnake(ref Serpente s, ref Player player, ref Panel pnlSnake, ref Queue<Panel> queueSnake, bool hasEaten = false)
        protected void UpdateSnake(ref Serpente s, ref Player player, ref Panel pnlSnake, ref ModQueue modQueueSnake, bool hasEaten = false)
        {
            Panel temp;
            if (hasEaten)
            {
                Panel panel = new Panel();
                panel.Location = new Point(s.GetX(0) * Config.sizeQuadrato, s.GetY(0) * Config.sizeQuadrato);
                panel.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato);
                panel.BorderStyle = BorderStyle.FixedSingle;
                //panel.BackColor = player.GetColor();
                panel.BackColor = player.Color;
                panel.Visible = true;
                //queueSnake.Enqueue(panel);
                modQueueSnake.InserisciInTesta(panel);

                //Se si può evitare il for è meglio...
                /*
                for (int i = 0; i < s.GetLength() - 1; i++)
                {
                    temp = queueSnake.Dequeue();
                    queueSnake.Enqueue(temp);
                }
                */
                pnlSnake.Controls.Add(panel);
            }
            else
            {
                temp = modQueueSnake.Dequeue();
                temp.Location = new Point(s.GetX(0) * Config.sizeQuadrato, s.GetY(0) * Config.sizeQuadrato);
                modQueueSnake.Enqueue(temp);
            }
        }

        /// <summary>
        /// creazione pannello per il cibo. da usare solo per la prima stampa
        /// </summary>
        /// <param name="cibo"></param>
        protected void PrintFood(ref Cibo c, ref Panel pnlSnake, ref List<Panel> lstPnlCibo)
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
            pnlSnake.Controls.Add(pannello);
            lstPnlCibo.Add(pannello);
            Console.WriteLine(c.GetFoodX().ToString() + " " + c.GetFoodY().ToString());
        }

        /// <summary>
        /// aggiorna la posizione del pannello del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="foodIndex"></param>
        protected void UpdateFood(ref Cibo c, ref List<Panel> lstPnlCibo, int foodIndex = 0)
        {
            lstPnlCibo[foodIndex].Location = new Point(c.GetFoodX() * Config.sizeQuadrato, c.GetFoodY() * Config.sizeQuadrato);
        }

        /// <summary>
        /// Inizializza il pannello della lingua e lo aggiunge a pnlElementiDinamici
        /// </summary>
        protected void PrintTongue(ref Serpente s, ref Panel pnlSnake, ref Panel pnlTongue)
        {
            pnlTongue = new Panel();
            pnlTongue.Visible = false;
            pnlTongue.Enabled = true;
            pnlTongue.BackColor = Color.Red;
            pnlTongue.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato / 3);
            pnlTongue.Location = new Point((s.GetX(0)) * Config.sizeQuadrato, (s.GetY(0) * Config.sizeQuadrato) + Config.sizeQuadrato / 3);
            pnlSnake.Controls.Add(pnlTongue);
        }

        /// <summary>
        /// aggriorna la posizione e l'orientamento della lingua in base alla direzione corrente
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected void UpdateTongue(int x, int y, ref Panel pnlTongue, ref Tasto tastoDirezione)
        {
            if (tastoDirezione == Tasto.su || tastoDirezione == Tasto.giu)
            {
                pnlTongue.Location = new Point(x * Config.sizeQuadrato + Config.sizeQuadrato / 3, y * Config.sizeQuadrato);
                pnlTongue.Size = new Size(Config.sizeQuadrato / 3, Config.sizeQuadrato);
            }
            else
            {
                pnlTongue.Location = new Point(x * Config.sizeQuadrato, y * Config.sizeQuadrato + Config.sizeQuadrato / 3);
                pnlTongue.Size = new Size(Config.sizeQuadrato, Config.sizeQuadrato / 3);
            }
        }

        #endregion

        /// <summary>
        /// ritorna l'altezza del campo gioco
        /// </summary>
        /// <returns></returns>
        public int GetWidth()
        {
            return campoGioco.GetLength(0);
        }

        /// <summary>
        /// ritorna la larghezza del campo gioco
        /// </summary>
        /// <returns></returns>
        public int GetHeigth()
        {
            return campoGioco.GetLength(1);
        }

        /// <summary>
        /// gestisce la logica del gioco ad ogni tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void tmr_Tick(object sender, EventArgs e)
        {
            //LogicaGioco(ref serpente, ref cibo, ref pnlElementiDinamici, ref queueSerpente, ref pnlLingua, ref lstPanelCibo, ref tasto, ref tastoPrec, ref posLastPrec);
            LogicaGioco(ref serpente, ref player1, ref cibo, ref pnlElementiDinamici, ref modQueueSerpente, ref pnlLingua, ref lstPanelCibo, ref tasto, ref tastoPrec, ref posLastPrec, ref tmr);
            if (((Timer)sender) == tmr)
                UpdateTotalScore(ref lblTotalScore, serpente);
        }

        //protected void LogicaGioco(ref Serpente s, ref Cibo c, ref Panel pnlSnake, ref Queue<Panel> queueSnake, ref Panel pnlTongue, ref List<Panel> lstPnlCibo, ref Tasto tasto, ref Tasto tastoPrec, ref Point posLastPrecedente)
        protected void LogicaGioco(ref Serpente s, ref Player player, ref Cibo c, ref Panel pnlSnake, ref ModQueue modQueueSnake, ref Panel pnlTongue, ref List<Panel> lstPnlCibo, ref Tasto tasto, ref Tasto tastoPrec, ref Point posLastPrecedente, ref Timer timer, Serpente s2 = null, bool multiplayerCollision = false, bool invert = false)
        {
            switch (tasto)
            {
                case Tasto.sinistra:
                    if (tastoPrec != Tasto.destra)
                    {
                        s.AggiornaSnake(-1, 0);
                        tastoPrec = Tasto.sinistra;
                        CheckUseTongue(ref s, ref pnlTongue, -1, 0);
                    }
                    else
                    {
                        goto case Tasto.destra;
                    }
                    break;
                case Tasto.destra:
                    if (tastoPrec != Tasto.sinistra)
                    {
                        s.AggiornaSnake(1, 0);
                        tastoPrec = Tasto.destra;
                        CheckUseTongue(ref s, ref pnlTongue, 1, 0);
                    }
                    else
                    {
                        goto case Tasto.sinistra;
                    }
                    break;
                case Tasto.su:
                    if (tastoPrec != Tasto.giu)
                    {
                        s.AggiornaSnake(0, -1);
                        tastoPrec = Tasto.su;
                        CheckUseTongue(ref s, ref pnlTongue, 0, -1);
                    }
                    else
                    {
                        goto case Tasto.giu;
                    }
                    break;
                case Tasto.giu:
                    if (tastoPrec != Tasto.su)
                    {
                        s.AggiornaSnake(0, 1);
                        tastoPrec = Tasto.giu;
                        CheckUseTongue(ref s, ref pnlTongue, 0, 1);
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
            posLastPrecedente = new Point(s.GetX(s.GetLength() - 1), s.GetY(s.GetLength() - 1));
            UpdateTongue(s.GetTongueX(), s.GetTongueY(), ref pnlTongue, ref tasto);
            if ((s.GetX(0) < 0 || s.GetX(0) > GetWidth() - 1 || s.GetY(0) < 0 || s.GetY(0) > GetHeigth() - 1) || Collisioni(ref s) || multiplayerCollision)
            {
                if (invert)
                    GameOver(ref timer, s2, s);
                else
                    GameOver(ref timer, s, s2);
            }
            else
            {
                if (HasEaten(ref s, ref c))
                {
                    IncSnake(ref s);
                    UpdateSnake(ref s, ref player, ref pnlSnake, ref modQueueSnake, true);
                    NewCibo(ref c, ref s);
                    UpdateFood(ref c, ref lstPnlCibo);
                }
                if (tasto != Tasto.fermo)
                    UpdateSnake(ref s, ref player, ref pnlSnake, ref modQueueSnake, false);
                if (s.CountToStop != TICK_TO_RESET_TONGUE && s.useTongue)
                    s.IncCounterTongue();
                else
                {
                    ResetTongue(ref s, ref pnlTongue);
                    s.CountToStop = 0;
                }
            }
        }

        /// <summary>
        /// spostamento della serpe e utilizzo della lingua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void frmSnake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == player1.up || e.KeyCode == player1.left || e.KeyCode == player1.down || e.KeyCode == player1.right || e.KeyCode == player1.tongue)
                TastoScelto(ref serpente, ref e, player1, ref tasto);
        }

        protected void TastoScelto(ref Serpente s, ref KeyEventArgs e, Player player, ref Tasto tasto)
        {
            if (e.KeyCode == player.up)
                tasto = Tasto.su;
            else if (e.KeyCode == player.left)
                tasto = Tasto.sinistra;
            else if (e.KeyCode == player.down)
                tasto = Tasto.giu;
            else if (e.KeyCode == player.right)
                tasto = Tasto.destra;
            else if (e.KeyCode == player.tongue)
                s.useTongue = true;
        }

        protected virtual void UpdateTotalScore(ref Label lblTotalScore, Serpente s1, Serpente s2 = null)
        {
            int total;
            if (s2 == null)
                total = s1.GetLength();
            else
                total = s1.GetLength() + s2.GetLength();
            lblTotalScore.Text = total.ToString();
        }

        /// <summary>
        /// controlla se la testa del serpente sbatte contro un muro o contro il serpente
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected bool Collisioni(ref Serpente s)
        {
            if (campoGioco[s.GetX(0), s.GetY(0)] == Elementi.muro)
                return true;
            else
            {
                for (int i = 1; i < s.GetLength(); i++) // i potrebbe essere inizializzato direttamente come 5 anziché 1
                    if (s.GetX(0) == s.GetX(i) && s.GetY(0) == s.GetY(i))
                        return true;
                return false;
            }
        }

        /// <summary>
        /// controlla se il serpente ha mangiato o no. ritorna un booleano
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        protected bool HasEaten(ref Serpente s, ref Cibo c)
        {
            if (s.GetX(0) == c.GetFoodX() && s.GetY(0) == c.GetFoodY() || s.GetTongueX() == c.GetFoodX() && s.GetTongueY() == c.GetFoodY())
                return true;
            return false;
        }

        /// <summary>
        /// deserializza il file json nella classe Livello
        /// </summary>
        protected void CaricamentoLivello()
        {
            /*
            StreamReader reader1 = new StreamReader("Data/levels/indice_livelli.json");
            rootNomiFile = JsonConvert.DeserializeObject<RootNomiFile>(reader1.ReadToEnd());
            reader1.Close();
            */
            GetNomiFile(ref rootNomiFile);
            StreamReader reader = new StreamReader("Data/levels/" + rootNomiFile.nomeFileDaLeggere[numLivello]);
            livello = JsonConvert.DeserializeObject<Livello>(reader.ReadToEnd());
            reader.Close();
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

        public static void GetNomiFile(ref RootNomiFile rnf)
        {
            StreamReader reader = new StreamReader("Data/levels/indice_livelli.json");
            rnf = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
        }

        /// <summary>
        /// aggiunge i muri alla matrice
        /// </summary>
        protected void AddMuri()
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
        protected virtual void GameOver(ref Timer timer, Serpente s1, Serpente s2 = null)
        {
            gameOver = true;
            timer.Enabled = false;
            if (s2 == null)
                MessageBox.Show("GAME OVER\nPunteggio: " + s1.GetLength(), "GAME OVER");
            else
            {
                int tot = s1.GetLength() + s2.GetLength();
                MessageBox.Show("GAME OVER\nPunteggio: " + tot + "\nGiocatore 1: " + s1.GetLength() + "\nGiocatore 2: " + s2.GetLength(), "GAME OVER");
            }
            this.Close();
        }

        /// <summary>
        /// salva la classifica del livello selezionato su un file esterno
        /// </summary>
        /// <param name="classifica"></param>
        /// <param name="index"></param>
        protected static void SaveClassifica(ref Ranking classifica, int index)
        {
            if (!System.IO.Directory.Exists("Data/Classifica"))
                System.IO.Directory.CreateDirectory("Data/Classifica");
            string json = JsonConvert.SerializeObject(classifica);
            string nome = "Data/Classifica/classifica" + index + ".json";
            System.IO.File.WriteAllText(@nome, @json);
        }

        /// <summary>
        /// legge la classifica dal file esterno del livello selezionato
        /// </summary>
        /// <param name="c"></param>
        /// <param name="index"></param>
        public static bool ReadClassifica(ref Ranking c, int index)
        {
            try
            {
                StreamReader reader = new StreamReader("Data/Classifica/classifica" + index + ".json");
                c = JsonConvert.DeserializeObject<Ranking>(reader.ReadToEnd());
                reader.Close();
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>
        /// riapre il menu se si chiude il gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSnake_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadClassifica(ref classifica, numLivello);
            recordutente.PunteggioPlayer = serpente.GetLength();
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
            nomeChiamante.Show();
        }

        /// <summary>
        /// istanzia un nuovo cibo e controlla se la sua posizione è valida
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        protected void NewCibo(ref Cibo c, ref Serpente s)
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
}
