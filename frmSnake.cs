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

namespace Snake
{
    public partial class frmSnake : Form
    {
        private int[,] campoGioco;
        private int sizeStampa;
        private frmMenu nomeChiamante;
        private int HeightCampoGioco, WidthCampoGioco;

        /// <summary>
        /// costruttore del form. bisogna passargli il nome della form chiamante, altezza e larghezza del campo gioco e intervallo del timer
        /// </summary>
        /// <param name="frmChiamante"></param>
        /// <param name="HeightCampoGioco"></param>
        /// <param name="WidthCampoGioco"></param>
        /// <param name="timerTick"></param>
        public frmSnake(frmMenu frmChiamante, int HeightCampoGioco, int WidthCampoGioco, int timerInterval)
        {
            InitializeComponent();
            nomeChiamante = frmChiamante;
            this.HeightCampoGioco = HeightCampoGioco;
            this.WidthCampoGioco = WidthCampoGioco;
            tmr.Interval = timerInterval;
        }

        /// <summary>
        /// inizializza il campo di gioco. stampa di tutti gli oggetti iniziali
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Inizializza(HeightCampoGioco, WidthCampoGioco);
            StampaCampoGioco();
        }

        /// <summary>
        /// inizializza la grndezza del campo gioco
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        private void Inizializza(int Height, int Width)
        {
            //per il momento è 16, in seguito bisgona fare una funzione getGrandezza per impostarla di conseguenza ??
            sizeStampa = 16;
            //stesso ragionamento per la dimensione del campo gioco
            campoGioco = new int[Width, Height];
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    campoGioco[i, j] = 0;
                }
            }
            pnlCampoGioco.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
            this.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
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
                    if (campoGioco[i, j] == 0)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = Color.Black;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Location = new Point(i * sizeStampa, j * sizeStampa);
                        panel.Size = new Size(sizeStampa, sizeStampa);
                        panel.Visible = true;
                        pnlCampoGioco.Controls.Add(panel);
                    }
                    else
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
        }

        /// <summary>
        /// stampa il serpente in base alla propria posizione
        /// </summary>
        /// <param name="serpente"></param>
        /*
        
        private void StampaSerpente(Serpente serpente)
        {
            for (int i = 0; i < serpente.GetLength(); i++)
            {
                Panel panel = new Panel();
                panel.Location = new Point(serpente.GetPosition.X, serpente.GetPosition.Y);
                panel.Size = new Size(sizeStampa, sizeStampa);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Visible = true;
                pnlCampoGioco.Controls.Add(panel);
            }
        }

        */

        /// <summary>
        /// stampa l'istanza della classe cibo
        /// </summary>
        /// <param name="cibo"></param>
        private void StampaCibo(Cibo cibo)
        {
            MessageBox.Show("","");
        }

        #endregion

        /// <summary>
        /// per ridimensionare la finestra se troppo grande per il campo gioco
        /// </summary>
        /// <returns></returns>
        private void RegolazioniVisualizzazione()
        {

        }

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
            StampaCampoGioco();
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
