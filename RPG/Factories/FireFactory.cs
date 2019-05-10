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
            return new FireMan()
            {
                Lives = new Life[] { new Life(), new Life(), new Life() },
                Weapons = new Weapon[] { new Fire(), new Fire(), new Fire() }
            };
        }

        public override Weapon CreateWeapon()
        {
            return new Fire();
        }
    }
}
