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
        public override Unit CreateUnit(IArmy army)
        {
            var archer = new Archer {Army = army, Hit = 30, Health = 70, Weapons = 10};
            return archer;
        }

        public override Weapon CreateWeapon()
        {
            return new Arrow();
        }
    }
}