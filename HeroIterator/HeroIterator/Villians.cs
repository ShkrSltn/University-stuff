using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class Villians : IGameMenu
    {
        public List<IGameCharacterMenuItem> GameItems;


        public Villians()
        {
            GameItems = new List<IGameCharacterMenuItem>();
            AddItem("Tanos", "Intelligence", 500, "Infinity glove");
            AddItem("gnrl.Shepherd", "Traitor", 20, "Deagle");
            AddItem("Overlord", "Control", 40, "Minions");
            AddItem("Mysterio", "Illusion", 24, "Drones");
            
        }

        public void AddItem(string name,string power,int damage,string weapon)
        {
            GameItems.Add(new IGameCharacterMenuItem(name, power, damage, weapon));

        }

        public IIterator CreateIterator()
        {
            return new VillianIterator(GameItems);
        }
    }
}
