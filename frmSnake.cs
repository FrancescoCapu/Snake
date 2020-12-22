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

    //Non so se "serpente = 2" e "cibo = 3" servano realmente
    enum Elementi
    {
        libero = 0,
        muro = 1,
        serpente = 2,
        cibo = 3
    }

    public partial class frmSnake : Form
    {
        private Elementi[,] campoGioco;
        // per debug
        //private Elementi[,] matSerpente;
        //private Elementi[,] matCibo;
        private int sizeStampa;
        private frmMenu nomeChiamante;
        private int heightCampoGioco, widthCampoGioco;
        private Serpente serpente;
        private Cibo cibo;  
        private RootNomiFile rootNomiFile;
        private Livello livello;
        private int numLivello;
        private Tasto tasto = Tasto.fermo;
        private Tasto tastoPrec = Tasto.destra;
        private Point posLastPrec;
        //private List<Panel> lstPanelSerpente = new List<Panel>();
        private Queue<Panel> queueSerpente = new Queue<Panel>();
        private List<Panel> lstPanelCibo = new List<Panel>();
        private Classifica classifica;
        private RecordUtente recordutente =new RecordUtente();
        private Color color;

        /// <summary>
        /// costruttore del form. bisogna passargli il nome della form chiamante, altezza e larghezza del campo gioco e intervallo del timer
        /// </summary>
        /// <param name="frmChiamante"></param>
        /// <param name="HeightCampoGioco"></param>
        /// <param name="WidthCampoGioco"></param>
        /// <param name="timerTick"></param>
        public frmSnake(frmMenu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, string nome, Color color, int numLivello = 0)
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
            serpente = new Serpente(livello.head.X, livello.head.Y);
            posLastPrec = new Point(serpente.GetX(serpente.GetLength() - 1), serpente.GetY(serpente.GetLength() - 1));
            cibo = new Cibo(widthCampoGioco, heightCampoGioco);
            AddMuri();
            //AggiornaMatSnake(serpente, false, true);
            //TrasferelloCibo(cibo);
            StampaCampoGioco();
            StampaSerpente(serpente);
            NewCibo(ref cibo, serpente);
            PrintFood(cibo);
            classifica = new Classifica();
        }

        /// <summary>
        /// inizializza la matrice e la dimensione dei pannelli/form
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        private void Inizializza(int height, int width)
        {
            //per il momento è 16, in seguito bisgona fare una funzione getGrandezza per impostarla di conseguenza ??
            sizeStampa = 16;
            //stesso ragionamento per la dimensione del campo gioco
            campoGioco = new Elementi[width, height];
            //matSerpente = new Elementi[width, height];
            //matCibo = new Elementi[width, height];
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    campoGioco[i, j] = Elementi.libero;
                    //matSerpente[i, j] = Elementi.libero;
                    //matCibo[i, j] = Elementi.libero;
                }
            }
            /*
            for (int i = 0; i < serpente.GetLength(); i++)
            {
                //matSerpente[serpente.GetX(i), serpente.GetY(i)] = Elementi.serpente;
            }
            */
            pnlCampoGioco.Size = new Size(GetWidth() * sizeStampa, GetHeigth() * sizeStampa);
            pnlElementiDinamici.Size = new Size(GetWidth() * sizeStampa, GetHeigth() * sizeStampa);
            pnlElementiDinamici.Location = new Point(0, 0);
            pnlElementiDinamici.BorderStyle = BorderStyle.None;
            this.Size = new Size(GetWidth() * sizeStampa, GetHeigth() * sizeStampa);
        }

        /// <summary>
        /// incremento della lunghezza del cibo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="serpente"></param>
        private void IncSnake(Cibo c, Serpente serpente)
        {
            //if (c.GetFoodX() == serpente.GetX(0) && c.GetFoodY() == serpente.GetY(0))
            serpente.IncLength(posLastPrec);
            //cibo = new Cibo(cibo.GetFoodX(),cibo.GetFoodY());
        }

        /*
        /// <summary>
        /// riporta tutti i valori della matrice campoGioco a 0
        /// </summary>
        private void Reset()
        {
            for (int i = 0; i < GetWidth(); i++)
            {
                for (int j = 0; j < GetHeigth(); j++)
                {
                    campoGioco[i, j] = Elementi.libero;
                    matSerpente[i, j] = Elementi.libero;
                }
            }
        }
        */

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
                        panel.Location = new Point(i * sizeStampa, j * sizeStampa);
                        panel.Size = new Size(sizeStampa, sizeStampa);
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
        private void StampaSerpente(Serpente serpente)
        {
            DrawingControl.SuspendDrawing(pnlElementiDinamici);
            pnlElementiDinamici.Controls.Clear();
            for (int i = serpente.GetLength()- 1 ; i > - 1; i--)
            {
                Panel panel = new Panel();
                panel.Location = new Point(serpente.GetX(i) * sizeStampa, serpente.GetY(i) * sizeStampa);
                panel.Size = new Size(sizeStampa, sizeStampa);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = color;
                panel.Visible = true;
                //lstPanelSerpente.Add(panel);
                queueSerpente.Enqueue(panel); //se funziona usare questo
                pnlElementiDinamici.Controls.Add(panel);
            }
            DrawingControl.ResumeDrawing(pnlElementiDinamici);
        }

        // --- Da ricontrollare come viene aggiunto l'ultimo pannello quando si mangia, perché viene visualizzato solo quando l'ultimo elemento del serpente passa sopra al cibo e non viene visualizzato quando la testa passa sopra al cibo, incrementando immediatamente la lunghezza
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
                panel.Location = new Point(posLastPrec.X * sizeStampa, posLastPrec.Y * sizeStampa);
                panel.Size = new Size(sizeStampa, sizeStampa);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = color;
                panel.Visible = true;
                //lstPanelSerpente.Add(panel);
                queueSerpente.Enqueue(panel);

                //Se si può evitare il for è meglio...

                for (int i = 0; i < s.GetLength() - 1; i++)
                {
                    temp = queueSerpente.Dequeue();
                    queueSerpente.Enqueue(temp);
                }
                pnlElementiDinamici.Controls.Add(panel);
                /*
                for (int i = s.getLength() - 2; i > 0; i--)
                {
                    lstPanelSerpente[i].Location = lstPanelSerpente[i - 1].Location;
                }
                */
                //queueSerpente.Enqueue(queueSerpente.Dequeue().Location = new Point(s.GetX(0), s.GetY(0));
            }
            else
            {
                /*
                for (int i = s.getLength() - 1; i > 0; i--)
                {
                    lstPanelSerpente[i].Location = lstPanelSerpente[i - 1].Location;
                }
                */
                temp = queueSerpente.Dequeue();
                temp.Location = new Point(s.GetX(0) * sizeStampa, s.GetY(0) * sizeStampa);
                queueSerpente.Enqueue(temp);
            }
            //lstPanelSerpente[0].Location = new Point(s.GetX(0) * sizeStampa, s.GetY(0) * sizeStampa);
            /*
            if (hasEaten == false)
            {
                lstPanelSerpente[lstPanelSerpente.Count - 1].Location = new Point(s.GetX(0) * sizeStampa, s.GetY(0) * sizeStampa);
            }
            else
            {
                Panel panel = new Panel();
                panel.Location = new Point(posLastPrec.X * sizeStampa, posLastPrec.Y * sizeStampa);
                panel.Size = new Size(sizeStampa, sizeStampa);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.Orange;
                panel.Visible = true;
                lstPanelSerpente.Add(panel);
                pnlElementiDinamici.Controls.Add(panel);
            }
            */
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
            //pannello.BackgroundImage =Image.FromFile("Data/imgs/ezgif-1-b94c4881a805.png");
            pannello.BorderStyle = BorderStyle.None;
            pannello.Location = new Point(c.GetFoodX() * sizeStampa, c.GetFoodY() * sizeStampa);
            pannello.Size = new Size(sizeStampa, sizeStampa);
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
            lstPanelCibo[foodIndex].Location = new Point(c.GetFoodX() * sizeStampa, c.GetFoodY() * sizeStampa);
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
        /// stampa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Tick(object sender, EventArgs e)
        {
            //TrasferelloSerpente(serpente);
            //TrasferelloCibo(cibo);
            //StampaSerpente(serpente);
            //PrintFood(cibo);
            switch (tasto)
            {
                case Tasto.sinistra:
                    if (tastoPrec != Tasto.destra)
                    {
                        serpente.AggiornaSnake(-1, 0);
                        tastoPrec = Tasto.sinistra;
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
                    }
                    else
                    {
                        goto case Tasto.su;
                    }
                    break;
                case Tasto.fermo:
                    break;
            }
            posLastPrec = new Point(serpente.GetX(serpente.GetLength() - 1), serpente.GetY(serpente.GetLength() - 1));
            if ((serpente.GetX(0) < 0 || serpente.GetX(0) > GetWidth() - 1 || serpente.GetY(0) < 0 || serpente.GetY(0) > GetHeigth() - 1) || Collisioni(serpente))
                GameOver();
            else
            {
                if (HasEaten(serpente, cibo))
                {
                    IncSnake(cibo, serpente);
                    UpdateSnake(ref serpente, true);
                    NewCibo(ref cibo, serpente);
                    UpdateFood(ref cibo);
                }
                //AggiornaMatSnake(serpente, HasEaten(serpente, cibo));
                //StampaSerpente(serpente);
                if (tasto != Tasto.fermo)
                    UpdateSnake(ref serpente, false);
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
                case Keys.A:
                    {
                        goto case Keys.Left;
                    }
                case Keys.D:
                    {
                        goto case Keys.Right;
                    }
                case Keys.W:
                    {
                        goto case Keys.Up;
                    }
                case Keys.S:
                    {
                        goto case Keys.Down;
                    }
            }
            //Queste funzioni vanno messe altrove, credo nel timer
            //ResetMatrice();
            //AggiornaMatrice();
            //TrasferelloSnake(serpente);
            //StampaSerpente(serpente);
            //StampaCampoGioco();
        }

        /// <summary>
        /// imposta a 2 i campi della matrice campoGioco occupati dal serpente
        /// </summary>
        /// <param name="s"></param> 
        private void AggiornaMatSnake(Serpente s, bool mangiato, bool init = false)
        {
            /*
            for (int i = 0; i < s.getLength(); i++)
            {
                matSerpente[s.GetX(i), s.GetY(i)] = Elementi.serpente;
            }
            */

            if (tasto != Tasto.fermo)
            {
                if (!mangiato && !init)
                    //matSerpente[posLastPrec.X, posLastPrec.Y] = Elementi.libero;
                posLastPrec = new Point(s.GetX(s.GetLength() - 1), s.GetY(s.GetLength() - 1));
                //matSerpente[s.GetX(0), s.GetY(0)] = Elementi.serpente;
            }

            Console.Write("\n------------------------------");
            for (int j = 0; j < GetHeigth(); j++)
            {
                Console.Write("\n");
                for (int i = 0; i < GetWidth(); i++)
                {
                    //Console.Write((int)matSerpente[i, j] + " ");
                }
            }
        }

        // --- Non serve a nienteeeeeeee ---
        private void TrasferelloCibo(Cibo c)
        {
            //matCibo[c.GetFoodX(), c.GetFoodY()] = Elementi.cibo;
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
        private bool HasEaten(Serpente s, Cibo c)
        {
            if (s.GetX(0) == c.GetFoodX() && s.GetY(0) == c.GetFoodY())
                return true;
            return false;
        }

        /// <summary>
        /// deserializza il file json nella classe Livello
        /// </summary>
        private void CaricamentoLivello() 
        {
            StreamReader reader1 = new StreamReader("Data/levels/indice_livelli.json");
            rootNomiFile = JsonConvert.DeserializeObject<RootNomiFile>(reader1.ReadToEnd());
            reader1.Close();
            StreamReader reader2 = new StreamReader("Data/levels/" + rootNomiFile.nomeFileDaLeggere[numLivello]);
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

        //rivedere cartella Classifica
        private void SaveClassifica(Classifica classifica,int index)
        {
            string json = JsonConvert.SerializeObject(classifica);
            string nome = "Data/Classifica/classifica" + index + ".json";
            System.IO.File.WriteAllText(@nome, json);
        }

        private void ReadClassifica(ref Classifica c, int index)
        {
            try
            {
                StreamReader reader = new StreamReader("Data/CLassifica/classifica" + index + ".json");
                c = JsonConvert.DeserializeObject<Classifica>(reader.ReadToEnd());
                reader.Close();
            }
            catch (FileNotFoundException e)
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
        private void frmSnake_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadClassifica(ref classifica, numLivello);
            recordutente.PunteggioPlayer = serpente.GetLength();
            nomeChiamante.Show();
            classifica.ClassificaPunteggi.Add(recordutente);
            classifica.ClassificaPunteggi.Sort((s1, s2) => s2.PunteggioPlayer.CompareTo(s1.PunteggioPlayer));
            if(classifica.ClassificaPunteggi.Count>10)
            {
                for (int i = classifica.ClassificaPunteggi.Count-1;i > 9;i --)
                {
                    classifica.ClassificaPunteggi.Remove(classifica.ClassificaPunteggi[i]);
                }
            }
            SaveClassifica(classifica, numLivello);
        }

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
