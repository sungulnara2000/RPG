using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;
using RPG.Goods;

namespace RPG.Units
{
    public class BlueArmy : IArmy
    {
        public BlueArmy()
        {
            _units = new List<Unit>();
        }

        public void Initialize(int archers, int firemen, int icemen)
        {
            for (int i = 0; i < archers; i++)
            {
                Add(new Archer()
                {
                    Army = this
                });
            }

            for (int i = 0; i < firemen; i++)
            {
                Add(new FireMan()
                {
                    Army = this
                });
            }

            for (int i = 0; i < icemen; i++)
            {
                Add(new IceMan()
                {
                    Army = this
                });
            }
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public void Remove(Unit unit)
        {
            _units.Remove(unit);
        }

        public void Clear()
        {
            _units.Clear();
        }

        public void Attack(GameBoard.GameBoard gameBoard)
        {
            foreach (var unit in _units)
            {
                unit.Attack(gameBoard);
            }
        }

        public ICollection<IItem> Units
        {
            get { return _units.Select(u => (IItem)u).ToList(); }
        }

        private ICollection<Unit> _units;
    }
}
