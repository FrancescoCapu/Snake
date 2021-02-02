using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    //Valutare l'eventuale implementazione di una classe Giocatore con i settaggi di ogni giocatore
    static class Config
    {
        /*
        public static Keys up;
        public static Keys left;
        public static Keys down;
        public static Keys right;
        public static Keys tongue;
        */

        public static int sizeQuadrato;

        public static void DefaultSettings()
        {
            /*
            up = Keys.Up;
            left = Keys.Left;
            down = Keys.Down;
            right = Keys.Right;
            tongue = Keys.Space;
            */

            sizeQuadrato = 24;
        }
    }
}
