using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Hashtable
{

    class Monster
    {

        private static Monster instance = new Monster();

        private Monster()
        {

        }
        public static Monster Instance
        {
            get { return instance; }
        }

        int id;
        string name;
        Hashtable hashtable = new Hashtable();
        public Monster(string name)
        {
            this.id = 0;
            this.name=name;
        }

        public void creat(string name)
        {
            hashtable.Add(id,name);
            id++;
            Console.WriteLine("{0}已创建,id为{1}",name,id);
        }

        public void delete(int id)
        {
            object temp = hashtable[id];
            hashtable.Remove(id);
            Console.WriteLine("id为{0}的{1}已移除", id, temp);
        }
    }

    internal class Class1
    {

        static void Main(string[] args)
        {
            Monster.Instance.creat("僵尸");
            Monster.Instance.creat("僵尸");
            Monster.Instance.creat("僵尸");

            Monster.Instance.delete(1);

        }
    }
}
