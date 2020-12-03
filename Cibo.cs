using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Cibo
    {
        private static Random r = new Random();
        private Point food;

        public Cibo(int x, int y)
        {
            food.X = r.Next(x);
            food.Y = r.Next(y);

        }
        public int GetFoodX()
        {
            return food.X;
        }
        public int GetFoodY()
        { 
            return food.Y;
        }
    }
}