using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_List排序
{
    class Monster
    {
        private string Name;
        private int Id;
        private int Attack;
        private int Defend;
        private int Health;
        public Monster(string name, int id, int attack, int defend, int health)
        {
            this.Name = name;
            this.Id = id;
            this.Attack = attack;
            this.Defend = defend;
            this.Health = health;
        }
        public string GetName{get{return Name;}}
        public int GetId {get{return Id;}}
        public int GetAttack {get{return Attack;}}
        public int GetDefend{get{return Defend;}}
        public int GetHealth{get{return Health;}}

        public override string ToString()
        {
           return string.Format(
                        $"\t名称：{this.Name} | " +
                        $"\tID：{this.Id} | " +
                        $"\t攻击：{this.Attack} | " +
                        $"\t防御：{this.Defend} | " +
                        $"\t血量：{this.Health}"
                        );
        }
    }

    class Item
    {
        public int Type;
        public string Name;
        public int Quality;

        public Item(int type,int quality,string name)
        {
            this.Type = type;
            this.Quality = quality;
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("\t类型{0}  \t品质{1}  \t道具名称{2}", Type, Quality, Name);
        }
    }
    internal class Class1
    {
        static void Fun1()
        {
            List<Monster> list = new List<Monster>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Monster("哥布林", i, rand.Next(10, 21), rand.Next(5, 11), rand.Next(100, 201)));
            }


            while (true)
            {
                Console.WriteLine("当前怪物");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }
                Console.WriteLine("输入操作:");
                Console.WriteLine("1:攻击排序 2:防御排序 3:血量排序 4:反转");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    int index = input;
                    switch (input)
                    {
                        case 1:
                            list.Sort((a, b) => { return a.GetAttack > b.GetAttack ? 1 : -1; });
                            index = 1;
                            Console.Clear();
                            break;
                        case 2:
                            list.Sort((a, b) => { return a.GetDefend > b.GetDefend ? 1 : -1; });
                            index = 2;
                            Console.Clear();
                            break;
                        case 3:
                            list.Sort((a, b) => { return a.GetHealth > b.GetHealth ? 1 : -1; });
                            index = 3;
                            Console.Clear();
                            break;
                        case 4:
                            list.Reverse();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("输入超出范围");
                            Console.Clear();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("输入不正确");
                }
            }
        }

        static void Fun2()
        {
            List<Item> items = new List<Item>();
            Random random = new Random();
            Console.WriteLine("排序前");
            for(int i = 0; i < 10; i++)
            {
                items.Add(new Item(random.Next(1,5), random.Next(1,5), "item"+random.Next(1,201)));
                Console.WriteLine(items[i]);
            }
            Console.WriteLine("排序后");
            items.Sort((a,b) =>
            {
                //类型不同，按类型比
                if (a.Type != b.Type)
                {
                    return a.Type > b.Type ? 1 : -1;
                }
                //品质不同按品质
                else if (a.Quality!=b.Quality)
                {
                    return a.Quality > b.Quality ? 1 : -1;
                }
                //都相同按名字长度
                else
                {
                    return a.Name.Length>b.Name.Length ? 1 : -1;
                }
            });
            for(int i = 0;i < items.Count;i++)
            {
                Console.WriteLine(items[i]);
            }
        }
        static void Fun3()
        {
            Dictionary<int,string> dic = new Dictionary<int, string>();

            Random random = new Random();
            while (dic.Count < 10) // 直到够10个才停
            {
                int key = random.Next(1, 20); // 范围扩大，避免重复
                if (!dic.ContainsKey(key))    // 不存在才添加
                {
                    dic.Add(key, "dic" + random.Next(1, 20));
                }
            }
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>(dic);
            Console.WriteLine("字典排序前");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Key + "_"+list[i].Value);
            }
            Console.WriteLine("字典排序后");
            list.Sort((a, b) => {return a.Key > b.Key ? 1 : -1; });
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Key + "_" + list[i].Value);
            }
        }
        static void Main(string[] args)
        {
            Fun2();
            Fun3();
        }
    }
}
