using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class SaveConfigPlayer
    {
        public Keys up;
        public Keys left;
        public Keys down;
        public Keys right;
        public Keys tongue;

        public SaveConfigPlayer(Player player)
        {
            up = player.up;
            left = player.left;
            down = player.down;
            right = player.right;
            tongue = player.tongue;
        }
    }
}
