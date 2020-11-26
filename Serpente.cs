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
        private List <Point> lstSerpente=new List<Point>(4);

        public Serpente(int Width, int Height)
        {
            for(int i=0;i<4;i++)
            {
                    lstSerpente.Add(new Point((Width / 3)-i,(Height / 2)));
            }

        }

        public int getLength()
        {
            return lstSerpente.Capacity;
        }
        
        public void IncLength()
        {
            lstSerpente.Add(new Point(3,3));    
        }
       
       public void AggiornaSnake(int incx, int incy)
       {
            for (int i = lstSerpente.Count-1;i > 1;i --)
            {
                lstSerpente[i] = new Point(lstSerpente[i - 1].X,lstSerpente[i-1].Y);
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