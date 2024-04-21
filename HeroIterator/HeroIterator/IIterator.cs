using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    public interface IIterator
    {
        bool HasNext();
        object Next();

    }

    public interface CopyOfIIterator
    {
        bool HasNext();
        object Next();

    }
}
