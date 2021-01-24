using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SaveViewConfig
    {
        public int sizeQuadrato;

        public SaveViewConfig(int sizeQuadrato = 16)
        {
            this.sizeQuadrato = sizeQuadrato;
        }
    }
}
