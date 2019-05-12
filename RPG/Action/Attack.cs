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
    public class Attack : IAction
    {
        public bool Act(Unit unit, GameBoard.GameBoard gameBoard)
        {
            if (unit.Weapons == 0) return false;
            var x = unit.X;
            var y = unit.Y;
            var res = false;
            if (x - 1 >= 0 && gameBoard.GameBoardItems[y][x - 1] is Unit &&
                ((Unit) gameBoard.GameBoardItems[y][x - 1]).Army != unit.Army)
            {
                ((Unit) gameBoard.GameBoardItems[y][x - 1]).Health -= unit.Hit;
                if (((Unit) gameBoard.GameBoardItems[y][x - 1]).Health <= 0)
                {
                    gameBoard.GameBoardItems[y][x - 1] = new Ground {X = x - 1, Y = y};
                }
                unit.Weapons -= 1;
                res = true;
            }
            if (y - 1 >= 0 && gameBoard.GameBoardItems[y - 1][x] is Unit &&
                ((Unit) gameBoard.GameBoardItems[y - 1][x]).Army != unit.Army)
            {
                ((Unit) gameBoard.GameBoardItems[y - 1][x]).Health -= unit.Hit;
                if (((Unit)gameBoard.GameBoardItems[y - 1][x]).Health <= 0)
                {
                    gameBoard.GameBoardItems[y - 1][x] = new Ground { X = x, Y = y - 1 };
                }
                unit.Weapons -= 1;
                res = true;
            }
            if (x + 1 < gameBoard.Width && gameBoard.GameBoardItems[y][x + 1] is Unit &&
                ((Unit) gameBoard.GameBoardItems[y][x + 1]).Army != unit.Army)
            {
                ((Unit) gameBoard.GameBoardItems[y][x + 1]).Health -= unit.Hit;
                if (((Unit)gameBoard.GameBoardItems[y][x + 1]).Health <= 0)
                {
                    gameBoard.GameBoardItems[y][x + 1] = new Ground { X = x + 1, Y = y };
                }
                unit.Weapons -= 1;
                res = true;
            }
            if (y + 1 < gameBoard.Height && gameBoard.GameBoardItems[y + 1][x] is Unit &&
                ((Unit) gameBoard.GameBoardItems[y + 1][x]).Army != unit.Army)
            {
                ((Unit) gameBoard.GameBoardItems[y + 1][x]).Health -= unit.Hit;
                if (((Unit)gameBoard.GameBoardItems[y + 1][x]).Health <= 0)
                {
                    gameBoard.GameBoardItems[y + 1][x] = new Ground { X = x, Y = y + 1 };
                }
                unit.Weapons -= 1;
                res = true;
            }
            return res;
        }
    }
}
