using System;

namespace СК_циклический_список
{
    class Program
    {
        static void Main(string[] args)
        {
            
            object[] names = new string[] 
            {
                "Вася", "Петя", "Оля", "Даша", "Саша", "Глаша",
                "Паша", "Юра", "Наташа", "Юля","Женя","Ваня"
            };
            CircularList cl = new CircularList();
            foreach (string str in names)
            {
                cl.Add(str, null);
            }
            foreach(string str in names)
            {
                Console.Write("{0} ",str);
            }

            Console.WriteLine();

            if (cl.Contains("or"))
            {
                for(int i=0;i<cl.Count-1;i++)
                {
                    if ((string)cl.CurrentData()=="or")
                        cl.RemoveCurrent();
                    cl.MoveNext();

                }
                
                for(int i=0;i<cl.Count+2;i++)
                {
                    if ((string)cl.CurrentData() == "or")
                        cl.RemoveCurrent();
                    cl.MoveNext();
                }

            }
            else
            {
                for (int i = 0; i < cl.Count; i++)
                {
                    if (i<cl.Count-1 && i % 2 < 1)
                        cl.Add("or", cl.CurrentData());
                    cl.MoveNext();
                }
            }

            for (int i = 0; i < cl.Count+1; i++)
            {
                Console.Write("{0} ", cl.CurrentData());
                cl.MoveNext();
            }

        }
    }
}
