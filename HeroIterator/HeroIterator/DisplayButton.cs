using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class DisplayButton
    {
        private IGameMenu Heroes;
        private IGameMenu Villians;
        private IGameMenu Locations;

        public DisplayButton(IGameMenu heroes,IGameMenu villians, IGameMenu locations)
        {
            Heroes = heroes;
            Villians = villians;
            Locations = locations;
            
        }
        

        public void DisplayMenu()
        {
            IIterator heroIterator = Heroes.CreateIterator();
            IIterator villianIterator = Villians.CreateIterator();
            IIterator locationIterator = Locations.CreateIterator();

            Console.WriteLine("-----------------------------------Heroes:--------------------------");
            DisplayMenu(heroIterator);
            Console.WriteLine("----------------------------------Villians:-------------------------");
            DisplayMenu(villianIterator);
            Console.WriteLine("----------------------------------locations:-------------------------");
            DisplayLocations(locationIterator);



        }

        
        public static void DisplayMenu(IIterator iterator)
        {
            
            while (iterator.HasNext())
            {
                
                    IGameCharacterMenuItem gameItem = (IGameCharacterMenuItem)iterator.Next();

                    Console.WriteLine("Name:{0}\nPower:{1}\nDamage:{2}\nWeapon:{3}", gameItem.Name, gameItem.Power, gameItem.Damage, gameItem.Weapon);
                    Console.WriteLine("-------------||--------------");

            }
        }

       
        public void DisplayLocations(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                IGameCharacterMenuItem gameItem = (IGameCharacterMenuItem)iterator.Next();

                Console.WriteLine("LocationName:{0}\nMaxCharacters:{1}\nReward:{2}\n", gameItem.LocationName, gameItem.MaxCharacters, gameItem.Reward);
                Console.WriteLine("-------------||--------------");
            }
        }

        public void DisplayLocations()
        {
            IIterator locationIterator = Locations.CreateIterator();
            Console.WriteLine("----------------------------------Locations:-------------------------");
            DisplayLocations(locationIterator);
        }
        



        public void DisplayVillians()
        {
            IIterator villianIterator = Villians.CreateIterator();
            Console.WriteLine("----------------------------------Villians:-------------------------");
            DisplayMenu(villianIterator);

        }

        public void DisplayHeroes()
        {
            IIterator heroIterator = Heroes.CreateIterator();
            Console.WriteLine("-----------------------------------Heroes:--------------------------");
            DisplayMenu(heroIterator);

        }

       
        


    }
}
