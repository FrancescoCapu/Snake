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
    public partial class frmSnake : Form
    {
        private Color[,] campoGioco;
        private int sizeStampa;
        private frmMenu nomeChiamante;
        private int HeightCampoGioco, WidthCampoGioco;

        public frmSnake(frmMenu frmChiamante, int HeightCampoGioco, int WidthCampoGioco)
        {
            InitializeComponent();
            nomeChiamante = frmChiamante;
            this.HeightCampoGioco = HeightCampoGioco;
            this.WidthCampoGioco = WidthCampoGioco;
        }


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
            campoGioco = new Color[Width, Height];
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    campoGioco[i, j] = Color.Black;
                }
            }
            pnlCampoGioco.Size = new Size(GetHeigth() * sizeStampa, GetWidth() * sizeStampa);
        }

        private void StampaCampoGioco()
        {
            for (int i = 0; i < GetHeigth(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    Panel panel = new Panel();
                    panel.BackColor = Color.Black;
                    panel.BorderStyle = BorderStyle.Fixed3D;
                    panel.Location = new Point(i * sizeStampa, j * sizeStampa);
                    panel.Size = new Size(sizeStampa, sizeStampa);
                    panel.Visible = true;
                    pnlCampoGioco.Controls.Add(panel);
                }
            }
        }

        private int GetHeigth()
        {
            return campoGioco.GetLength(0);
        }

        private int GetWidth()
        {
            return campoGioco.GetLength(1);
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
}
