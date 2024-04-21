using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndObserver
{
    class Schedule: IObservable
    {
        List<string> subjects = new List<string>();
        List<int> pairs = new List<int>();
        List<IObserver> observers=new List<IObserver>();
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
        public void Change(string subject, int pair)
        {
            subjects.Add(subject);
            pairs.Add(pair);
            this.NotifyObservers();
        }
        public int LastPair()
        {
            int max = -1;
            foreach (int p in pairs)
                if (p > max) max = p;
            return max;
        }

       
        public string LastChange()
        {
            return String.Format("{0}:{1}", subjects[subjects.Count - 1], pairs[pairs.Count - 1]);
        }
    }
}
