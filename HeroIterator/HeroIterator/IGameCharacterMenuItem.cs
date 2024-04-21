using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroIterator
{
    public class IGameCharacterMenuItem
    {
        public string Name { get; }
        public string Power { get; }
        public int Damage { get; }
        public string Weapon { get; }
        public string LocationName { get; }
        public int MaxCharacters { get; }
        public int Reward { get; }

        public IGameCharacterMenuItem(string name,string power,int damage,string weapon)
        {
            Name = name;
            Power = power;
            Damage = damage;
            Weapon = weapon;
        }

        public IGameCharacterMenuItem(string locationName,int maxCharacters,int reward)
        {
            LocationName =  locationName;
            MaxCharacters = maxCharacters;
            Reward = reward;
        }
   
    }
}
