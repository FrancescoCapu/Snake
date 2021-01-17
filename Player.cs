using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class Player
    {
        public Keys up;
        public Keys left;
        public Keys down;
        public Keys right;
        public Keys tongue;

        public Player(int numPlayer = 1)
        {
            if (numPlayer == 1)
            {
                up = Keys.Up;
                left = Keys.Left;
                down = Keys.Down;
                right = Keys.Right;
                tongue = Keys.Space;
            }
            else if (numPlayer == 2)
            {
                up = Keys.W;
                left = Keys.A;
                down = Keys.S;
                right = Keys.D;
                tongue = Keys.X;
            }
        }
    }
}
