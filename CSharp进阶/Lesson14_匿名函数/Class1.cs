using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14_匿名函数
{



    internal class Class1
    {
        static void Main(string[] args)
        {
            Action ac = delegate ()
            {
                Console.WriteLine(GetFun(8)(4)); 
            };
            ac();
        }

        static Func<int,int> GetFun(int v)
        {
            //这样会改变v的生命周期
            return delegate (int i)
            {
                return i * v;
            };
        }
    }
}
