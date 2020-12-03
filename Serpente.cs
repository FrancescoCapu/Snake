using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Serpente
    {
        private List <Point> lstSerpente = new List<Point>(4);

        public Serpente(int width, int height)
        {
            for(int i = 0; i < 4; i++)
            {
                    lstSerpente.Add(new Point((width / 3) - i, (height / 2)));
            }

        }

        public int getLength()
        {
            return lstSerpente.Count;
        }
        
        public void IncLength()
        {
            lstSerpente.Add(new Point(3,3));    
        }
       
       public void AggiornaSnake(int incx, int incy)
       {
            for (int i = lstSerpente.Count - 1; i > 0; i--)
            {
                lstSerpente[i] = new Point(lstSerpente[i - 1].X, lstSerpente[i-1].Y);
            }
            lstSerpente[0] = new Point(lstSerpente[0].X + incx, lstSerpente[0].Y + incy);
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