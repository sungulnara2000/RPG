using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;

namespace RPG.Goods
{
    public abstract class Good : IItem
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}
