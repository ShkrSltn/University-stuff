using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    class HeroWithLightSaber:Hero
    {
        public void Display()
        {
            Console.WriteLine("I am jedi");
        }

        public HeroWithLightSaber()
        {
            attackBehaviour = new AttackWithLightSaber();
            defenseBehaviour = new DDodge();
        }
    }
}
