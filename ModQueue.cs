using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public class ModQueue : Queue<Panel>
    {
        public ModQueue() : base()
        {

        }

        public void InserisciInTesta(Panel panel)
        {
            Enqueue(panel);
            for (int i = 0; i < Count - 1; i++)
            {
                Enqueue(Dequeue());
            }
        }
    }
}
