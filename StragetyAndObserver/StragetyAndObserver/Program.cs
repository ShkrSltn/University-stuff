using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Schedule sh = new Schedule();

            Teacher teacher=new Teacher(sh);
            Student st1 = new Student(sh,teacher);
            Student st2 = new Student(sh,teacher);
            Student st3 = new Student(sh,teacher);
            Student st4 = new Student(sh,teacher);

            sh.AddObserver(teacher);
            sh.AddObserver(st1);
            sh.AddObserver(st2);
            sh.AddObserver(st3);
            sh.AddObserver(st4);

           
          teacher.AddObserver(st2);
           teacher.Give("Make a makefile", 2);
           sh.Change("asd", 5);
           teacher.AddObserver(st1);

            sh.RemoveObserver(st1);
            

          
            

        }
    }
}
