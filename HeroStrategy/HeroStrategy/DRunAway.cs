using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    class DRunAway : DefenseBehavior
    {
        public void Defense()
        {
            double savingDamage = 100;
            Console.WriteLine("---Сбежать от нападения:Сохраняет {0}% жизни", savingDamage);
        }
    }
}
