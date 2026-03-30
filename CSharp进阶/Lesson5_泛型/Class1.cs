using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_泛型
{

    class Type
    {
        public Type() { }

        public void IsType<T>(T t)
        {
            if (typeof(T) == typeof(int))
            {
                Console.WriteLine("int");
            }
            else if (typeof(T) == typeof(char))
            {
                Console.WriteLine("char");
            }
            else if (typeof(T) == typeof(float))
            {
                Console.WriteLine("float");
            }
            else if ((typeof(T) == typeof(string)))
            {
                Console.WriteLine("string");
            }
            else
            {
                Console.WriteLine("其他类型");
            }
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            Type t = new Type();

            t.IsType<int>(1);
            t.IsType<string>("1");
            t.IsType(1.2f);
            t.IsType('c');
            t.IsType(1.2);
        }
    }
}
