using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndObserver
{
    class Teacher:IObserver,IObservable
    {
        Schedule schedule;
        public Teacher(Schedule s)
        { schedule = s; }
        
        public void Update()
        {
            Console.WriteLine(schedule.LastChange());

        }

        List<string> homeworks = new List<string>();
        List<int> timeToPass = new List<int>();

        List<IObserver> observers = new List<IObserver>();
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Update();
        }
        public void Give(string homework, int time)
        {
            homeworks.Add(homework);
            timeToPass.Add(time);
            this.NotifyObservers();
        }
        public int GetTime()
        {
            int var = 0;
            foreach (int t in timeToPass)
                if (t==1)
                {
                    var = 1;
                }
                    return var;

        }

        public string LastGive()
        {
            return String.Format("{0}, Время на сдачу: {1} - недели(я)", homeworks[homeworks.Count - 1], timeToPass[timeToPass.Count - 1]);
        }

    }
}
