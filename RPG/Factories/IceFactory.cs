using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public class IceFactory : Factory
    {
        public override Unit CreateUnit()
        {
            return new IceMan()
            {
                Lives = new Life[] {new Life(), new Life(), new Life()},
                Weapons = new Weapon[] {new Ice(), new Ice(), new Ice()}
            };
        }

        public override Weapon CreateWeapon()
        {
            return new Ice();
        }
    }
}
