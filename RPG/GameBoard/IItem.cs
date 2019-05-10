using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public interface IItem
    {
        int X { get; set; }

        int Y { get; set; }
    }
}
