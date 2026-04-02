using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_List
{
    abstract class Monster
    {
        static public List<Monster> monsters = new List<Monster>();
        public Monster()
        {
            monsters.Add(this);
        }

        abstract public void Atk();
    }

    class Boss : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("Boss攻击");
        }
    }

    class Gablin : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("哥布林攻击");
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            #region
            List<int> list = new List<int>();
            for(int i=10; i>0; i--)
            {
                list.Add(i);
            }
            list.RemoveAt(4);
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
            #endregion

            Gablin g1 = new Gablin();
            Gablin g2 = new Gablin();
            Boss b1 = new Boss();
            Boss b2 = new Boss();
            for(int i=0; i<Monster.monsters.Count; i++)
            {
                Monster.monsters[i].Atk();
            }
        }
    }
}
