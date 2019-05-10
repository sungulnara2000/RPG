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
        public override Unit CreateUnit()
        {
            return new FireMan();
        }

        public override Weapon CreateWeapon()
        {
            return new Fire();
        }
    }
}
