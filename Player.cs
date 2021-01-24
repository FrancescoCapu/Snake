using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    public class Player
    {
        public Keys up;
        public Keys left;
        public Keys down;
        public Keys right;
        public Keys tongue;

        private int numPlayer;
        private string name;
        private Color color;

        public int NumPlayer { get => numPlayer; set => numPlayer = value; }
        public string Name { get => name; set => name = value; }

        public Player(Color color, int numPlayer = 1, string name ="")
        {
            this.color = color;
            this.NumPlayer = numPlayer;
            this.Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeColor(Color color)
        {
            this.color = color;
        }

        public Color GetColor()
        {
            return color;
        }

        public void DefaultCommands()
        {
            if (NumPlayer == 1)
            {
                up = Keys.Up;
                left = Keys.Left;
                down = Keys.Down;
                right = Keys.Right;
                tongue = Keys.Space;
            }
            else if (NumPlayer == 2)
            {
                up = Keys.W;
                left = Keys.A;
                down = Keys.S;
                right = Keys.D;
                tongue = Keys.X;
            }
        }

        public bool ComparisonCommands(ref Player otherPlayer)
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
