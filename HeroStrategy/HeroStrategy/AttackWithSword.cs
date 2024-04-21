using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    public class AttackWithSword : AttackBehavior
    {
        public double Attack()
        {
            double enemyHealthE = 100;
            double damage = 80;
            Console.WriteLine("---Enemy health:{0}", enemyHealthE);
            enemyHealthE -= damage;
            Console.WriteLine("---Attack on Enemy -{0}\n---Enemy Health:{1}",damage,enemyHealthE);
            return enemyHealthE;
        }

    }
}

