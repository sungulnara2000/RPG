using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public abstract class Factory
    {
        public abstract Unit CreateUnit();

        public abstract Weapon CreateWeapon();

    }
}
