using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Units
{
    public interface IActionable
    {
        void Act(GameBoard.GameBoard gameBoard);
    }
}
