using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson3_queue
{
    class Message
    {
        Queue queue = new Queue();
        public void input(string msg)
        {
            queue.Enqueue(msg);
        }

        public void show()
        {
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
                Thread.Sleep(1000);
            }
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            Message msg = new Message();
            msg.input("hello");
            msg.input("你好");
            msg.input("hola");
            msg.input("こんにちは");
            msg.input("你好");
            msg.input("hola");
            msg.input("こんにちは");
            msg.show();
        }
    }
}
