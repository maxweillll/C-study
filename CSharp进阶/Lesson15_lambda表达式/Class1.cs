using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15_lambda表达式
{
    internal class Class1
    {
        static Action Fun()
        {
            Action action = null;
            for (int i = 1; i <= 10; i++)
            {
                int index = i;
                action += () => { Console.WriteLine(index); };
            }
            return action;
            
        }

        static void Main(string[] args)
        {
            Fun()();
        }
    }
}
