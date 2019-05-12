using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public class FireFactory : Factory
    {
        public override Unit CreateUnit(IArmy army)
        {
            var fireMan = new FireMan {Army = army, Hit = 20, Health = 80, Weapons = 5};
            return fireMan;
        }

        public override Weapon CreateWeapon()
        {
            return new Fire();
        }
    }
}
