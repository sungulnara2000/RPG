using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Units;

namespace RPG.GameBoard
{
    public interface IGameBoardDirector
    {
        void Create(ICollection<IItem> reds, ICollection<IItem> blues);
    }
}
