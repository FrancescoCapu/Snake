using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    abstract class Lingua
    {
        protected Point tonguePoint;

        public Lingua(int tongueX, int tongueY)
        {
            tonguePoint = new Point(tongueX, tongueY);
        }

        public void UpdateTonguePosition(int x, int y)
        {
            tonguePoint = new Point(x, y);
        }

        public void SetTonguePosition(int x, int y)
        {
            tonguePoint = new Point(x, y);
        }

        public int GetTongueX()
        {
            return tonguePoint.X;
        }

        public int GetTongueY()
        {
            return tonguePoint.Y;
        }
    }
}
