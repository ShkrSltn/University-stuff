using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    class HeroIterator:IIterator
    {
        public readonly IGameCharacterMenuItem[] GameItems;
        private int index;

        public HeroIterator(IGameCharacterMenuItem[] gItems)
        {
            GameItems = gItems;
            index = 0;
        }

        public bool HasNext()
        {
            return index < GameItems.Length && GameItems[index] != null;
        }

        public object Next()
        {
            
            IGameCharacterMenuItem GameItem = GameItems[index];
            index++;
            return GameItem;
           
        }
        
    }
}
