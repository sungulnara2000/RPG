using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.Units;
using RPG.GameBoard;
using RPG.Goods;

namespace RPG.Action
{
    public class Move : IAction
    {
        public Move(Direction direction)
        {
            _direction = direction;
        }

        public void PickUp(Unit unit, IItem temp, GameBoard.GameBoard gameBoard)
        {
            if (temp is Box)
            {
                unit.Weapons += 1;
                temp = new Ground {X = temp.X, Y = temp.Y};
                gameBoard.GameBoardItems[temp.Y][temp.X] = temp;
            }
            if (temp is Life)
            {
                unit.Health += 10;
                temp = new Ground { X = temp.X, Y = temp.Y };
                gameBoard.GameBoardItems[temp.Y][temp.X] = temp;
            }
        }

        public bool Act(Unit unit, GameBoard.GameBoard gameBoard)
        {
            var x = unit.X;
            var y = unit.Y;
            IItem temp;
            switch (_direction)
            {
                case Direction.LEFT:
                    if (x - 1 < 0 || gameBoard.GameBoardItems[y][x - 1] is Wall || gameBoard.GameBoardItems[y][x - 1] is Unit) break;
                    temp = gameBoard.GameBoardItems[y][x - 1];
                    PickUp(unit, temp, gameBoard);
                    if (!(temp is Unit)) temp = new Ground() { X = temp.X, Y = temp.Y };
                    gameBoard.GameBoardItems[y][x - 1] = unit;
                    gameBoard.GameBoardItems[y][x] = temp;
                    unit.X -= 1;
                    temp.X += 1;
                    break;
                case Direction.UP:
                    if (y - 1 < 0 || gameBoard.GameBoardItems[y-1][x] is Wall || gameBoard.GameBoardItems[y-1][x] is Unit) break;
                    temp = gameBoard.GameBoardItems[y - 1][x];
                    PickUp(unit, temp, gameBoard);
                    if (!(temp is Unit)) temp = new Ground() { X = temp.X, Y = temp.Y };
                    gameBoard.GameBoardItems[y - 1][x] = unit;
                    gameBoard.GameBoardItems[y][x] = temp;
                    unit.Y -= 1;
                    temp.Y += 1;
                    break;
                case Direction.RIGHT:
                    if (x + 1 >= gameBoard.Width || gameBoard.GameBoardItems[y][x + 1] is Wall || gameBoard.GameBoardItems[y][x + 1] is Unit) break;
                    temp = gameBoard.GameBoardItems[y][x + 1];
                    PickUp(unit, temp, gameBoard);
                    if (!(temp is Unit)) temp = new Ground() {X = temp.X, Y = temp.Y};
                    gameBoard.GameBoardItems[y][x + 1] = unit;
                    gameBoard.GameBoardItems[y][x] = temp;
                    unit.X += 1;
                    temp.X -= 1;
                    break;
                case Direction.DOWN:
                    if (y + 1 >= gameBoard.Height || gameBoard.GameBoardItems[y+1][x] is Wall || gameBoard.GameBoardItems[y+1][x] is Unit) break;
                    temp = gameBoard.GameBoardItems[y + 1][x];
                    PickUp(unit, temp, gameBoard);
                    if (!(temp is Unit)) temp = new Ground() { X = temp.X, Y = temp.Y };
                    gameBoard.GameBoardItems[y + 1][x] = unit;
                    gameBoard.GameBoardItems[y][x] = temp;
                    unit.Y += 1;
                    temp.Y -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        private readonly Direction _direction;
    }
}
