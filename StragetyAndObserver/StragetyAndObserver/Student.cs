using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndObserver
{
    class Student:IObserver
    {
        Schedule schedule;
        Teacher teacher;
        public Student(Schedule s, Teacher tch) { schedule = s; teacher = tch; }

        public void Update()
        {
            if (teacher.GetTime() == 1)
                Console.WriteLine("Почему так мало времени");

            if (schedule.LastPair() > 4)
                Console.WriteLine("Почему так много пар");
            
        }
    }
}
