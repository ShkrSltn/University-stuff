using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroStrategy
{
    public abstract class Hero
    {
        public void setAttackBehavior(AttackBehavior AB)
        {
            attackBehaviour = AB;
        }

        public void setDefenseBehavior(DefenseBehavior DB)
        {
            defenseBehaviour = DB;
        }

        public AttackBehavior attackBehaviour;
        public DefenseBehavior defenseBehaviour;
        
        

        public void performAttack()
        {
            attackBehaviour.Attack();
           
        }
        
        public void performDefense()
        {
            defenseBehaviour.Defense();
        }

    }
}
