using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class Locations : IGameMenu
    {

      
        public List<IGameCharacterMenuItem> LocationItems;

        public Locations()
        {
            LocationItems = new List<IGameCharacterMenuItem>();
            AddItem("The Bridge", 3, 200);
            AddItem("Arena", 2, 500);
            AddItem("Coliseum", 6, 1200);
            AddItem("Dark room", 2, 400);
            AddItem("Forest", 3, 500);
            
            
        }

        public void AddItem(string locationName,int maxCharacters,int reward)
        {
        
            LocationItems.Add(new IGameCharacterMenuItem(locationName, maxCharacters, reward));

        }

        public IIterator CreateIterator()
        {
            return new LocationIterator(LocationItems);
        }
    }
}
    
