using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public class ArcherFactory : Factory
    {
        public override Unit CreateUnit()
        {
            return new Archer()
            {
                Lives = new Life[] { new Life(), new Life(), new Life() },
                Weapons = new Weapon[] { new Arrow(), new Arrow(), new Arrow() }
            };
        }

        public override Weapon CreateWeapon()
        {
            return new Arrow();
        }
    }
}