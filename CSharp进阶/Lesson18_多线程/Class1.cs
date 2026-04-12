using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson18_多线程
{
    enum E_MoveDir
    {
        up, down, left, right
    }

    class Icon
    {
        public E_MoveDir dir = E_MoveDir.right;
        public int x;
        public int y;

        public Icon(int x, int y, E_MoveDir dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
        }

        public void Move()
        {
            switch (dir)
            {
                case E_MoveDir.up:
                    y--;
                    if(y< 0) { y=Console.WindowHeight-1; break; }
                    break;
                case E_MoveDir.down:
                    y++;
                    if (y > Console.WindowHeight - 1) { y = 0; break; }
                    break;
                case E_MoveDir.left:
                    x--;
                    if (x < 0) { x = Console.WindowWidth - 1; break; }
                    break;
                case E_MoveDir.right:
                    x++;
                    if (x > Console.WindowWidth - 1) { x = 0; break; }
                    break;
            }
        }
        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.Write("■");
        }
        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }
        public void ChangeDir(E_MoveDir dir)
        {
            this.dir = dir;
        }
    }

    internal class Class1
    {
        static Icon icon= new Icon(10, 5, E_MoveDir.right);
        static void Main(string[] args)
        {
            Thread t = new Thread(NewThreadLogic);
            t.IsBackground = true;
            t.Start();

            icon.Draw();
            while (true)
            {
                Thread.Sleep(200);
                icon.Clear();
                icon.Move();
                icon.Draw();
            }
        }
        static void NewThreadLogic()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        icon.ChangeDir(E_MoveDir.up);
                        break;
                    case ConsoleKey.A:
                        icon.ChangeDir(E_MoveDir.left);
                        break;
                    case ConsoleKey.S:
                        icon.ChangeDir(E_MoveDir.down);
                        break;
                    case ConsoleKey.D:
                        icon.ChangeDir(E_MoveDir.right);
                        break;
                }
            }
        }
    }
}
