using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    public class LocationIterator:IIterator
    {
        
        private List<IGameCharacterMenuItem> LocationItems;
        private int index;

        public LocationIterator(List<IGameCharacterMenuItem> locationItems)
        {
            LocationItems = locationItems;
            index = 0;
        }

        public bool HasNext()
        {
            return index + 1 <= LocationItems.Count();
        }

        public object Next()
        {

            IGameCharacterMenuItem LocItem = LocationItems[index];
            index++;
            return LocItem;
        }


    }

    public class CopyOfLocationIterator : IIterator
    {

        private List<IGameCharacterMenuItem> LocationItems;
        private int index;

        public CopyOfLocationIterator(List<IGameCharacterMenuItem> locationItems)
        {
            LocationItems = locationItems;
            index = 0;
        }

        public bool HasNext()
        {
            return index + 1 <= LocationItems.Count();
        }

        public object Next()
        {

            IGameCharacterMenuItem LocItem = LocationItems[index];
            index++;
            return LocItem;
        }


    }
}
