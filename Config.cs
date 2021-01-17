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
        
        public static Keys[] up = new Keys[2];
        public static Keys[] left = new Keys[2];
        public static Keys[] down = new Keys[2];
        public static Keys[] right = new Keys[2];
        public static Keys[] tongue = new Keys[2];
        

        public static int sizeQuadrato;

        public static void DefaultSettings()
        {
            
            up[0] = Keys.Up;
            left[0] = Keys.Left;
            down[0] = Keys.Down;
            right[0] = Keys.Right;
            tongue[0] = Keys.Space;
            



            sizeQuadrato = 16;
        }
    }
}
