using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public class HardGameBoardDirector : IGameBoardDirector
    {
        public HardGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
            _redPositions = new List<Tuple<int, int>>() { new Tuple<int, int>(1, 9), new Tuple<int, int>(2, 1), new Tuple<int, int>(4, 8)};

            _bluePositions = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 4), new Tuple<int, int>(0, 12), new Tuple<int, int>(3, 6)};
            _walls = new List<Wall>() { new Wall { X = 1, Y = 2 }, new Wall { X = 2, Y = 2 }, new Wall { X = 3, Y = 2 },
                                        new Wall { X = 3, Y = 1 }, new Wall { X = 7, Y = 3 }, new Wall { X = 8, Y = 5 },
                                        new Wall { X = 10, Y = 3 }, new Wall { X = 11, Y = 3 }, new Wall { X = 10, Y = 14 },
                                        new Wall { X = 5, Y = 15 }, new Wall { X = 6, Y = 15 }, new Wall { X = 6, Y = 16 },
                                        new Wall { X = 3, Y = 8 }, new Wall { X = 3, Y = 9 }, new Wall { X = 3, Y = 10 },
                                        new Wall { X = 3, Y = 11 }, new Wall { X = 3, Y = 12 }, new Wall { X = 3, Y = 13 },
                                        new Wall { X = 4, Y = 13 }, new Wall { X = 5, Y = 13 }, new Wall { X = 6, Y = 13 },
                                        new Wall { X = 7, Y = 13 } };
            _lifePosition = new Tuple<int, int>(7, 7);
            _weaponPosition = new Tuple<int, int>(3, 5);

        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues, IItem life, IItem weapon)
        {
            _builder.SetShape(18, 18);
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

            life = new Life { X = _lifePosition.Item1, Y = _lifePosition.Item2 };
            weapon = new Box { X = _weaponPosition.Item1, Y = _weaponPosition.Item2 };

            _builder.CreateWalls(_walls);
            _builder.SetUnits(reds);
            _builder.SetUnits(blues);
            _builder.SetUnit(life);
            _builder.SetUnit(weapon);
        }

        private Tuple<int, int> _lifePosition;
        private Tuple<int, int> _weaponPosition;

        private IList<Tuple<int, int>> _redPositions;
        private IList<Tuple<int, int>> _bluePositions;
        private IList<Wall> _walls;
        private IGameBoardBuilder _builder;
    }
}
