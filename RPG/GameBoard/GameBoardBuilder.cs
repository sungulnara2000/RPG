using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;

namespace RPG.GameBoard
{
    public class GameBoardBuilder : IGameBoardBuilder
    {
        public GameBoardBuilder()
        {
            Reset();
        }

        public void SetShape(int height, int width)
        {
            _gameBoard.GameBoardItems = new IItem[height][];
            for (int i = 0; i < height; i++)
            {
                _gameBoard.GameBoardItems[i] = new IItem[width];
                for (int j = 0; j < width; j++)
                {
                    _gameBoard.GameBoardItems[i][j] = new Ground(){X = j, Y = i};
                }
            }
        }
        
        public void CreateWalls(ICollection<Wall> walls)
        {
            foreach (var wall in walls)
            {
                _gameBoard.GameBoardItems[wall.Y][wall.X] = wall;
            }
        }

        public void SetStuff(IItem life, IItem weapon)
        {
            _gameBoard.GameBoardItems[life.Y][life.X] = life;
            _gameBoard.GameBoardItems[weapon.Y][weapon.X] = weapon;
        }

        public void SetUnits(ICollection<IItem> units)
        {
            foreach (var position in units)
            {
                _gameBoard.GameBoardItems[position.Y][position.X] = position;
            }
        }

        public void SetUnit(IItem unit)
        {
            _gameBoard.GameBoardItems[unit.Y][unit.X] = unit;
        }

        public void Reset()
        {
            _gameBoard = new GameBoard();
        }

        public GameBoard GetGameBoard()
        {
            var result = _gameBoard;
            Reset();
            return result;
        }

        private GameBoard _gameBoard;
    }
}
