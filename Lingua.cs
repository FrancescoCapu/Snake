using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public abstract class Lingua
    {
        protected Point tonguePoint;
        protected int countToStop;

        public int CountToStop { get => countToStop; set => countToStop = value; }

        protected Lingua(int tongueX, int tongueY)
        {
            tonguePoint = new Point(tongueX, tongueY);
            CountToStop = 0;
        }

        protected void UpdateTonguePosition(int x, int y)
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

        public void IncCounterTongue()
        {
            CountToStop++;
        }
    }
}
