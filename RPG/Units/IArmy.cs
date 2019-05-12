using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;

namespace RPG.Units
{
    public interface IArmy
    {
        void Initialize(int archers, int firemen, int icemen);

        void Add(Unit unit);

        void Remove(Unit unit);

        void Clear();

        bool IsAlive();

        int Count();

        int AliveCount();

        Archer Archer { get; }

        FireMan FireMan { get; }

        IceMan IceMan { get; }

        void ActWithout(GameBoard.GameBoard gameBoard, Unit unit);

        void Act(GameBoard.GameBoard gameBoard);

        void UpdateAliveUnits();

        ICollection<IItem> Units { get; }
    }
}
