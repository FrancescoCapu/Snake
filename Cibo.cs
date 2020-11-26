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
        Random x = new Random(17);
        Random y = new Random(17);
        public bool flag;
        private Point cibo;
        public Cibo()
        {
            
            flag=false;

        }

        public void AggiornaCibo()
        {
           // if(flag==true)
                //cibo(x,y);        
        }

        /*public void AggiornaLengthSnake()
        {
             if(cibo()==lstSerpente[0])
             {
                lstSerpente.add;
                AggiornaCibo();
                flag=true;
             }
        }*/
    }
}