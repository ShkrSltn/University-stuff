using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    public class HeroWithSwordAndShield:Hero
    {

 
        public HeroWithSwordAndShield()
        {
            attackBehaviour = new AttackWithSword();
            defenseBehaviour = new DWithShield();
        }

        public void Display()
        {
            Console.WriteLine("---Its hero with sword and shield");
        }
        
    }
}
