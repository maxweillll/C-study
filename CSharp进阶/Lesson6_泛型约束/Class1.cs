using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_泛型约束
{
    #region
    //单例模式基类，以后用单例模式直接继承
    class SingleBase<T> where T : new()
    {
        private static T instance = new T();
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        class Test : SingleBase<Test>
        {
            public Test() { }//小缺点，只能public，单例模式的类绝不能在其他地方new
        }
        #endregion
    }
    class ArrayList<K>
    {
        private K[] array;
        private int count;

        public ArrayList()
        {
            count = 0;
            array = new K[16];
        }

        public void Add(K value)
        {
            //判断是否要扩容
            if (count >= Capacity)
            {
                //搬家，每次扩容两倍
                K[] temp = new K[Capacity * 2];
                for (int i = 0; i < Capacity; i++)
                {
                    temp[i] = array[i];
                }
                //重新指向地址
                array = temp;
            }
            //不需要扩容
            array[count] = value;
            count++;
        }
        public void Remove(K value)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                //不能用==判断，因为不是所有类型都重载了运算符
                if (array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            //只要不为-1，那就是找到了，开始移除
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        public void RemoveAt(int index)
        {
            //判断索引合法吗
            if (index < 0 || index >= Count)
            {
                Console.WriteLine("索引不合法");
                return;
            }
            else
            {
                for (; index < Count - 1; index++)
                {
                    array[index] = array[index + 1];
                }
                //后面的往前放，最后一个设置伟默认值，相当于移除
                array[count - 1] = default(K);
                count--;
            }
        }

        //索引器，查和改
        public K this[int index]
        {
            get
            {
                //判断索引合法吗
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return default;
                }
                return array[index];
            }
            set
            {
                //判断索引合法吗
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }
                this[index] = value;
            }
        }
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
    }
    internal class Class1
    {
        static void Main(string[] args)
        {
            ArrayList<int> array = new ArrayList<int>();
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array[1]);
            array.RemoveAt(-1);
            Console.WriteLine(array[-1]);
            Console.WriteLine(array[3]);
        }
    }

}
