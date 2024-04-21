using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class Program
    {
        static void Main(string[] args)
        {
           Heroes heroes = new Heroes();
           Villians villians = new Villians();
           Locations locations = new Locations();

            DisplayButton display = new DisplayButton (heroes,villians,locations);
            
            display.DisplayMenu();
           // display.DisplayVillians();
            //display.DisplayLocations();
            

            
        } 
    }
}
