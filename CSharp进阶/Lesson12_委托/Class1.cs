using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_委托
{

    abstract class People
    {
        public abstract void Eat();
    }

    class Mother : People
    {
        public Action beginEat;
        public override void Eat()
        {
            Console.WriteLine("妈妈吃饭");
        }
        public void Cook()
        {
            Console.WriteLine("妈妈做饭");

            Console.WriteLine("做好了");

            if (beginEat != null)
            {
                beginEat();
            }
        }
    }
    class Father : People
    {
        public override void Eat()
        {
            Console.WriteLine("爸爸吃饭");
        }
    }
    class Son : People
    {
        public override void Eat()
        {
            Console.WriteLine("孩子吃饭");
        }
    }

    class Monster
    {
        //怪物死亡把自己作为参数传出去
        public Action<Monster> deadDoSomething;
        //怪物价值
        public int money = 10;
        public void Dead()
        {
            if(deadDoSomething != null)
            {
                Console.WriteLine("怪物死亡");
                deadDoSomething(this);
            }
            deadDoSomething = null;
        }   
    }
    class Player
    {
        private int myMoney = 10;
        public void MonsterDeadDosomthing(Monster monster)
        {
            myMoney += monster.money;
            Console.WriteLine("现在有{0}元", myMoney);
        }
    }
    class Ui
    {
        private int nowShowMoney = 0;
        public void MonsterDeadDo(Monster monster)
        {
            nowShowMoney = monster.money;
            Console.WriteLine("当前面板显示+ {0}元", nowShowMoney);
        }
    }
    class cj
    {
        private int nowKillMonsterNum = 0;
        public void MonsterDeadDosomthing(Monster monster)
        {
            nowKillMonsterNum ++;
            Console.WriteLine("当前击杀了{0}个怪物", nowKillMonsterNum);
        }
    }

    internal class Class1
    {
        static void Question1()
        {
            Mother m = new Mother();
            Father f = new Father();
            Son son = new Son();
            m.beginEat += m.Eat;
            m.beginEat += f.Eat;
            m.beginEat += son.Eat;

            m.Cook();
        }

        static void Question2()
        {
            Monster monster = new Monster();
            Player player = new Player();
            Ui ui = new Ui();
            cj cj = new cj();

            monster.deadDoSomething += player.MonsterDeadDosomthing;
            monster.deadDoSomething += ui.MonsterDeadDo;
            monster.deadDoSomething += cj.MonsterDeadDosomthing;
            monster.Dead();
            monster.Dead();

            Monster monster2 = new Monster();
            monster2.deadDoSomething += player.MonsterDeadDosomthing;
            monster2.deadDoSomething += ui.MonsterDeadDo;
            monster2.deadDoSomething += cj.MonsterDeadDosomthing;

            monster2.Dead();
        }
        static void Main(string[] args)
        {
            Question1();
            Console.WriteLine("*******************");
            Question2();
        }
    }
}