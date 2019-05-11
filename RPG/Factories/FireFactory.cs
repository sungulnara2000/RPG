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
            var fireMan = new FireMan();
            fireMan.Army = army;
            fireMan.Hit = 20;
            fireMan.Health = 80;
            return fireMan;
        }

        public override Weapon CreateWeapon()
        {
            return new Fire();
        }
    }
}
