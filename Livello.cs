using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class Livello
    {
        public int numLev;
        public DimensioniCampoGioco dimensioneCampo;
        public Point head;
        public IList<Muro> posMuri;

        public Livello()
        {
            posMuri = new List<Muro>();
        }
    }
}