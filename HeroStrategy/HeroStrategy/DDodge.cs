using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    public class DDodge : DefenseBehavior
    {
        public void Defense()
        {
            double savingDamage = 90;
            Console.WriteLine("---Уклонение от атаки:сохраняет {0}% жизни", savingDamage);

        }
    }
}
