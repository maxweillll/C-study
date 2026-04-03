using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Linkedlist
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            Random random = new Random(25565);

            for(int i=0; i<10; i++)
            {
                list.AddLast(random.Next(0,100));
            }
            Console.WriteLine("迭代器正向遍历");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("反向遍历");
            LinkedListNode<int> node = list.Last;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;
            }
        }
    }
}
