using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Units;
using RPG.GameBoard;
using RPG.Goods;

namespace RPG.Action
{
    public interface IAction
    {
        bool Act(Unit unit, GameBoard.GameBoard gameBoard);
    }
}
