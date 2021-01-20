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
        int numPlayer;

        public Player(int numPlayer = 1)
        {
            this.numPlayer = numPlayer;
        }

        public void DefaultCommands()
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

        public bool ComparisonCommands(Player otherPlayer)
        {
            if (up == otherPlayer.up)
            {
                otherPlayer.up = Keys.None;
                return true;
            }
            else if (left == otherPlayer.left)
            {
                otherPlayer.left = Keys.None;
                return true;
            }
            else if (down == otherPlayer.down)
            {
                otherPlayer.down = Keys.None;
                return true;
            }
            else if (right == otherPlayer.right)
            {
                otherPlayer.right = Keys.None;
                return true;
            }
            else if (tongue == otherPlayer.tongue)
            {
                otherPlayer.tongue = Keys.None;
                return true;
            }
            else
                return false;
        }
    }
}
