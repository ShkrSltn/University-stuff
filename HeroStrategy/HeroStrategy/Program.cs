using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            HeroWithSwordAndShield Ecx = new HeroWithSwordAndShield();

            Ecx.Display();
            Ecx.performAttack();
            Ecx.performDefense();
            Console.WriteLine("---------");
            Ecx.setAttackBehavior(new AttackWithBow());
            Ecx.performAttack();

            Console.WriteLine("-----------------------");
            HeroWithLightSaber jedi = new HeroWithLightSaber();
            jedi.Display();
            jedi.performAttack();
            jedi.performDefense();
        }
    }
}
