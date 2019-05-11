using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;

namespace RPG.GameBoard
{
    public interface IGameBoardBuilder
    {
        void SetShape(int height, int width);

        void CreateWalls(ICollection<Wall> walls);

        void SetUnits(ICollection<IItem> units);

        void SetUnit(IItem unit);

        void Reset();

        GameBoard GetGameBoard();
    }
}
