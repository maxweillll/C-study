using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson13_事件
{

    class HotMachine
    {
        public int Hot(int tempre)
        { 
            Thread.Sleep(1);
            tempre++;
            return tempre;
        }
    }

    class Bell
    {
        public void Sound(int tempre)
        {
            if (tempre > 95)
            {
                Console.WriteLine("水开了，当前温度" + tempre);
            }
        }
    }

    class Display
    {
        public void Show(int tempre)
        {
            
            if (tempre > 95)
            {
                Console.WriteLine("水已经烧开了");
            }
        }
    }

    class HotWaterMachine
    {
        int tempre = 0;
        public event Action<int> Done;
        public void Start()
        {
            HotMachine hotMachine = new HotMachine();
            Bell bell = new Bell();
            Display display = new Display();
            Done += bell.Sound;
            Done += display.Show;
            while(true)
            {
                tempre = hotMachine.Hot(tempre);
                Console.WriteLine("当前的温度" + tempre);

                if (tempre >= 100)
                {
                    break;
                }
                else if (tempre>95)
                {
                    if (Done != null)
                    { 
                        Done(tempre);
                        Done = null;
                    } 
                }
            }
            
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            HotWaterMachine hotWaterMachine = new HotWaterMachine();
            hotWaterMachine.Start();
        }
    }
}
