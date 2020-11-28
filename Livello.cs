using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Livello
    {
        public int numLev;
        public IList<Muro> posMuri;

        public Livello()
        {
            posMuri = new List<Muro>();
        }
    }
}
