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

        private int _numPlayer;
        private string _name;
        private Color _color;

        public int NumPlayer { get => _numPlayer; set => _numPlayer = value; }
        public string Name { get => _name; set => _name = value; }
        public Color Color { get => _color; set => _color = value; }

        public Player(Color color, int numPlayer = 1, string name ="")
        {
            this.Color = color;
            this.NumPlayer = numPlayer;
            this.Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeColor(Color color)
        {
            this.Color = color;
        }

        public Color GetColor()
        {
            return Color;
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

        public bool ComparisonCommands(ref Player otherPlayer, Keys temp)
        {
            if (up == otherPlayer.up)
            {
                otherPlayer.up = temp;
                return true;
            }
            else if (left == otherPlayer.left)
            {
                otherPlayer.left = temp;
                return true;
            }
            else if (down == otherPlayer.down)
            {
                otherPlayer.down = temp;
                return true;
            }
            else if (right == otherPlayer.right)
            {
                otherPlayer.right = temp;
                return true;
            }
            else if (tongue == otherPlayer.tongue)
            {
                otherPlayer.tongue = temp;
                return true;
            }
            else
                return false;
        }
    }
}
