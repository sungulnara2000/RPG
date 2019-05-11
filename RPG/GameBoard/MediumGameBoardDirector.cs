using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public class MediumGameBoardDirector : IGameBoardDirector
    {
        public MediumGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
            _redPositions = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(2, 13), new Tuple<int, int>(4, 7)};

            _bluePositions = new List<Tuple<int, int>>() { new Tuple<int, int>(1, 1), new Tuple<int, int>(4, 11), new Tuple<int, int>(6, 4)};
            _walls = new List<Wall>() { new Wall { X = 3, Y = 3 }, new Wall { X = 3, Y = 4 }, new Wall { X = 3, Y = 5 },
                                        new Wall { X = 10, Y = 4 }, new Wall { X = 10, Y = 5 }, new Wall { X = 10, Y = 6 },
                                        new Wall { X = 10, Y = 7 }, new Wall { X = 9, Y = 7 }, new Wall { X = 8, Y = 7 },
                                        new Wall { X = 8, Y = 12 }, new Wall { X = 11, Y = 11 } };

        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues)
        {
            _builder.SetShape(15, 15);
            int i = 0;
            foreach (var red in reds)
            {
                red.X = _redPositions[i].Item1;
                red.Y = _redPositions[i].Item2;
                ++i;
            }

            i = 0;
            foreach (var blue in blues)
            {
                blue.X = _bluePositions[i].Item1;
                blue.Y = _bluePositions[i].Item2;
                ++i;
            }
            _builder.CreateWalls(_walls);
            _builder.SetUnits(reds);
            _builder.SetUnits(blues);
        }

        private IList<Tuple<int, int>> _redPositions;
        private IList<Tuple<int, int>> _bluePositions;
        private IList<Wall> _walls;
        private IGameBoardBuilder _builder;
    }
}
