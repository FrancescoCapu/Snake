using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class SaveConfig
    {
        public Keys up;
        public Keys left;
        public Keys down;
        public Keys right;
        public Keys tongue;
        public int sizeQuadrato;

        public SaveConfig(Keys up, Keys left, Keys down, Keys right, Keys tongue, int sizeQuadrato = 16)
        {
            this.up = up;
            this.left = left;
            this.down = down;
            this.right = right;
            this.tongue = tongue;
            this.sizeQuadrato = sizeQuadrato;
        }
    }
}
