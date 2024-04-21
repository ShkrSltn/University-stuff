using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    class DWithShield : DefenseBehavior
    {
        public void Defense()
        {
            double savingDamage = 50;
            Console.WriteLine("---Защититься щитом: сохраняет {0}% жизни", savingDamage);
        }
    }
}
