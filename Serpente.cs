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
        private List <Point> lstSerpente=new List<Point>(4); //color
        public Serpente()
        {
            PosHead=new Point();
            PosHead.X = Height/2;
            PosHead.Y = Width/3;
        }

        public int getLength()
        {
            return Length;
        }
        public void IncLength()
        {
            lstSerpente.Add();    
        }
        public void AggiornaSnakeX(int Inc)
        {
            lstSerpente[0].X +=Inc;
            for(int i=1;i<lstSerpente.Count;i++)
            {
                lstSerpente[i].X=lstSerpente[i-1].X;
            }
        }
        public void AggiornaSnakeY(int Inc)
        {
            lstSerpente[0].Y +=Inc;
            for(int i=1;i<lstSerpente.Count;i++)
            {
                lstSerpente[i].Y=lstSerpente[i-1].Y;
            }
        }
    }

}