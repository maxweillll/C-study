using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_双向链表
{

    class LinkNode<T>
    {
        public T Value;
        public LinkNode<T> nextNode;
        public LinkNode<T> prevNode;

        public LinkNode(T Value)
        {
            this.Value = Value;
        }
    }

    class Link<T>
    {
        
        public LinkNode<T> head ;
        public LinkNode<T> last ;
        public void Add(T value)
        {
            LinkNode<T> node = new LinkNode<T>(value);

            if (head == null)
            {
                head = node;
                last = head;
            }
            else 
            {
                last.nextNode = node;
                node.prevNode = last;
                last=node;
            }
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            Link<int> link = new Link<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            LinkNode<int> node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }

            node = link.last; // 从尾部开始
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.prevNode; // 向前遍历
            }
        }
    }
}
