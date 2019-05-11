using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public class LightGameBoardDirector : IGameBoardDirector
    {
        public LightGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
            _redPositions = new List<Tuple<int, int>>(){new Tuple<int, int>(2, 9), new Tuple<int, int>(8, 10), new Tuple<int, int>(10, 7)};
            _bluePositions = new List<Tuple<int, int>>(){new Tuple<int, int>(1, 2), new Tuple<int, int>(5, 2), new Tuple<int, int>(9, 1)};

            _lifePosition = new Tuple<int, int>(7, 7);
            _weaponPosition = new Tuple<int, int>(3, 5);
        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues, IItem life, IItem weapon)
        {
            _builder.SetShape(12, 12);
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

            _builder.SetUnits(reds);
            _builder.SetUnits(blues);
            _builder.SetUnit(life);
            _builder.SetUnit(weapon);
        }

        private Tuple<int, int> _lifePosition;
        private Tuple<int, int> _weaponPosition;
        
        private IList<Tuple<int, int>> _redPositions;
        private IList<Tuple<int, int>> _bluePositions;
        private IGameBoardBuilder _builder;
    }
}
