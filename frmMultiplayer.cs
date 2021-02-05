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
    public partial class frmMultiplayer : frmSnake
    {
        protected Player player2;
        protected Serpente serpente2;
        protected ModQueue modQueueSerpente2 = new ModQueue();
        protected Panel pnlLingua2;
        protected Tasto tasto2 = Tasto.fermo;
        protected Tasto tastoPrec2 = Tasto.destra;
        protected Point posLastPrec2;
        public frmMultiplayer(frmMenu frmChiamante, int heightCampoGioco, int widthCampoGioco, int timerInterval, Player player1, Player player2, int numLivello = 0)
            : base(frmChiamante, heightCampoGioco, widthCampoGioco, timerInterval, player1, numLivello)
        {
            InitializeComponent();
            this.player2 = player2;
        }

        private void frmMultiplayer_Load(object sender, EventArgs e)
        {
            serpente2 = new Serpente(GetWidth() - livello.head.X, GetHeigth() - livello.head.Y, true, false);
            StampaSerpente(ref serpente2, ref player2, ref pnlElementiDinamici, ref modQueueSerpente2, true);
            PrintTongue(ref serpente2, ref pnlElementiDinamici, ref pnlLingua2);
            recordutente.NomePlayer = recordutente.NomePlayer + ", " + player2.Name;
            tmr.Enabled = false;
            tmrMulti.Interval = tmr.Interval;
            tmrMulti.Enabled = true;
        }

        protected override void frmSnake_KeyDown(object sender, KeyEventArgs e)
        {
            base.frmSnake_KeyDown(sender, e);
            if (e.KeyCode == player2.up || e.KeyCode == player2.left || e.KeyCode == player2.down || e.KeyCode == player2.right || e.KeyCode == player2.tongue)
                TastoScelto(ref serpente2, ref e, player2, ref tasto2);
        }

        protected override void tmr_Tick(object sender, EventArgs e)
        {
            base.tmr_Tick(sender, e);
            LogicaGioco(ref serpente2, ref player2, ref cibo, ref pnlElementiDinamici, ref modQueueSerpente2, ref pnlLingua2, ref lstPanelCibo, ref tasto2, ref tastoPrec2, ref posLastPrec2, ref tmrMulti, serpente2, SerpToSerpCollision(serpente, serpente2));
            if (base.tasto != Tasto.fermo && tasto2 == Tasto.fermo)
            {
                Tasto tastoTemp = Tasto.destra;
                LogicaGioco(ref serpente2, ref player2, ref cibo, ref pnlElementiDinamici, ref modQueueSerpente2, ref pnlLingua2, ref lstPanelCibo, ref tastoTemp, ref tastoPrec2, ref posLastPrec2, ref tmrMulti, serpente2, SerpToSerpCollision(serpente, serpente2));
            }
            else if (base.tasto == Tasto.fermo && tasto2 != Tasto.fermo)
            {
                Tasto tastoTemp = Tasto.destra;
                LogicaGioco(ref serpente, ref player1, ref cibo, ref pnlElementiDinamici, ref modQueueSerpente, ref pnlLingua, ref lstPanelCibo, ref tastoTemp, ref tastoPrec, ref posLastPrec, ref tmr);
            }
        }

        private bool SerpToSerpCollision(Serpente s1, Serpente s2)
        {
            
            for (int i = 0; i < s1.GetLength(); i++)
            {
                if (s2.GetX(0) == s1.GetX(i) && s2.GetY(0) == s1.GetY(i))
                {
                    Console.WriteLine("Alessandro Pallini");
                    Console.WriteLine("i == " + i);
                    Console.WriteLine("s2.GetX(0) == " + s2.GetX(0) + "s1.GetX(i) == " + s1.GetX(i) +
                        "\ns2.GetX(0) == " + s2.GetX(0) + "s1.GetY(i) == " + s1.GetX(i));
                    return true;
                }
            }
            for (int i = 0; i < s2.GetLength(); i++)
            {
                if (s1.GetX(0) == s2.GetX(i) && s1.GetY(0) == s2.GetY(i))
                {
                    Console.WriteLine("Giovanni Urganti");
                    return true;
                }
            }
            return false;
        }
    }
}
