using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class Heroes:IGameMenu
    {
        public  int  MaxItems=8;
        private int countOfItems;
        private IGameCharacterMenuItem[] gameItems;

        public Heroes()
        {
            countOfItems = 0;
            gameItems = new IGameCharacterMenuItem[MaxItems];
            AddItem("Jedi", "Force", 99, "Lightsaber");
            AddItem("Hitman", "Assasinate", 50, "Pistols");
            AddItem("Wolverine", "Fury", 120, "Adamantium claws");
            AddItem("War", "Fury", 230, "Sword");
           

        }

        public void AddItem(string name,string power,int damage,string weapon)
        {
           IGameCharacterMenuItem GameItem = new IGameCharacterMenuItem(name, power, damage, weapon);
            if(countOfItems>=MaxItems)
            {
                Console.WriteLine("Game menu is not able to show another hero");

            }
            gameItems[countOfItems] = GameItem;
            countOfItems++;
        }

        public IIterator CreateIterator()
        {
            return new HeroIterator(gameItems);
        }
    }
}
