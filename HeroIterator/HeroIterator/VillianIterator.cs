using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class VillianIterator : IIterator
    {
        private  List<IGameCharacterMenuItem> GameItems;
        private int index;

        public VillianIterator(List<IGameCharacterMenuItem> gameItems)
        {
            GameItems = gameItems;
            index = 0;
        }
        
        public bool HasNext()
        {
            return index + 1 <= GameItems.Count();
        }

        public object Next()
        {
            IGameCharacterMenuItem GameItem = GameItems[index];
            index++;
            return GameItem;
        }
    }
}
