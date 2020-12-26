using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Serpente : Lingua
    {
        private List <Point> lstSerpente = new List<Point>(4);

        public Serpente(int width, int height) : base (width, height) 
        {
            for(int i = 0; i < lstSerpente.Capacity; i++)
            {
                    lstSerpente.Add(new Point(10-i,10));
            }
        }

        public int GetLength()
        {
            return lstSerpente.Count;
        }
        
        public void IncLength(Point p)
        {
            lstSerpente.Add(p);
        }
       
       public void AggiornaSnake(int incx, int incy)
       {
            for (int i = lstSerpente.Count - 1; i > 0; i--)
            {
                lstSerpente[i] = new Point(lstSerpente[i - 1].X, lstSerpente[i-1].Y);
            }
            lstSerpente[0] = new Point(lstSerpente[0].X + incx, lstSerpente[0].Y + incy);
            UpdateTonguePosition(lstSerpente[0].X, lstSerpente[0].Y);
       }

        public int GetX(int num)
        {
            return lstSerpente[num].X;
        }

        public int GetY(int num)
        {
            return lstSerpente[num].Y;
        }
    }

}