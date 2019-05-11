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
        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues)
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
            _builder.SetUnits(reds);
            _builder.SetUnits(blues);
        }


        private IList<Tuple<int, int>> _redPositions;
        private IList<Tuple<int, int>> _bluePositions;
        private IGameBoardBuilder _builder;
    }
}
