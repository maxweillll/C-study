using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Dictionary
{

    class D1
    {
        Dictionary<int,string> hans = new Dictionary<int, string>();
        public D1()
        {
            hans.Add(0, "零");
            hans.Add(1, "壹");
            hans.Add(2, "贰");
            hans.Add(3, "叁");
            hans.Add(4, "肆");
            hans.Add(5, "伍");
            hans.Add(6, "陆");
            hans.Add(7, "柒");
            hans.Add(8, "捌");
            hans.Add(9, "玖");
            hans.Add(10, "拾");
        }
        public void Change()
        {
            Console.WriteLine("输入一个不超过三位数的数");
            try
            {
                int tempNum = int.Parse(Console.ReadLine());
                if (tempNum > 999) { return; }
                string str = "";
                int[] num = new int[3];
                num[0] = tempNum / 100;
                if (num[0] != 0)
                {
                    str += hans[num[0]];
                }
                num[1] = tempNum / 10 - num[0] * 10;
                if (num[1] != 0||str!="")
                {
                    str += hans[num[1]];
                }
                num[2] = tempNum - num[0] * 100 - num[1] * 10;
                if (num[2] != 0||str!="")
                {
                    str += hans[num[2]];
                }
                Console.WriteLine(str);
            }
            catch
            {
                Console.WriteLine("请输入数字");
            }
            
        }
    }

    class D2
    {
        
        public void CountWorlds()
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            string str = "Wellcome to Unity Wrold";
            str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (count.ContainsKey(str[i]))
                {
                    count[str[i]]++;
                }
                else
                {
                    count.Add(str[i],1);
                }
            }
            Console.WriteLine(str);
            foreach(char c in count.Keys)
            {
                Console.WriteLine("字母{0}出现了{1}次", c, count[c]);
            }
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            D1 d1 = new D1();
            d1.Change();
            D2 d2 = new D2();
            d2.CountWorlds();
        }
    }
}
