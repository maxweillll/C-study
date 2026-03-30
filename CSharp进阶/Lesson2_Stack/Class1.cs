using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Stack
{

    class Byte
    {
        Stack stack = new Stack();
        public void convert(int num)
        {
            Console.Write("{0}二进制是", num);
            while (true)
            {
                stack.Push(num % 2);
                num /= 2;
                if (num == 1)
                {
                    stack.Push(num);
                    break;
                }
            }

            
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

    }

    internal class Class1
    {
       static void Main(string[] args)
        {
            Byte @byte = new Byte();

            @byte.convert(4);

            @byte.convert(8);

        }
    }
}
