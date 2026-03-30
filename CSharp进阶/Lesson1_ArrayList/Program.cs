using System;
using System.Collections;
using System.Text;

namespace Lesson1_ArrayList
{
    public class Bag
    {
        public string Item { get; set; }
        public int Pay { get; set; }

        // 主构造函数
        public Bag(string item, int pay)
        {
            this.Item = item;
            this.Pay = pay;
        }

        // 调用主构造函数的重载
        public Bag(string name) : this(name, 0) { }

        public void showThisItem()
        {
            Console.WriteLine($"物品：{this.Item}，价值：{this.Pay}");
        }
    }

    internal class Program
    {
        // 商店物品列表
        ArrayList items = new ArrayList();
        // 我的背包物品列表
        ArrayList myItems = new ArrayList();
        // 我的余额
        int money;

        // 添加商店物品
        public void addItem(string item, int money)
        {
            items.Add(new Bag(item, money));
        }

        // 显示商店所有物品
        public void showAllItems()
        {
            Console.WriteLine("\n===== 商店物品列表 =====");
            if (items.Count == 0)
            {
                Console.WriteLine("商店暂无物品");
                return;
            }
            for (int i = 0; i < items.Count; i++)
            {
                Bag thisItem = (Bag)items[i];
                Console.WriteLine($"[{i + 1}] {thisItem.Item} - 价格：{thisItem.Pay} 金币");
            }
        }

        // 显示我的背包物品
        public void showMyItems()
        {
            Console.WriteLine("\n===== 我的背包 =====");
            if (myItems.Count == 0)
            {
                Console.WriteLine("背包为空");
                return;
            }
            for (int i = 0; i < myItems.Count; i++)
            {
                Bag thisItem = (Bag)myItems[i];
                Console.WriteLine($"[{i + 1}] {thisItem.Item} - 价值：{thisItem.Pay} 金币");
            }
        }

        // 删除商店物品（带边界检查）
        public void deleteItem(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                Console.WriteLine($"❌ 删除失败：索引 {index + 1} 超出范围！");
                return;
            }
            Bag deletedItem = (Bag)items[index];
            items.RemoveAt(index);
            Console.WriteLine($"✅ 已删除商店物品：{deletedItem.Item}");
        }

        // 初始化商店和余额
        void init()
        {
            addItem("泥土", 5);
            addItem("铁锭", 30);
            addItem("钻石", 64);
            money = 256;
            Console.WriteLine($"🔧 初始化完成！初始余额：{money} 金币");
        }

        // 买入物品（优化：忽略大小写，更友好）
        void buy(string name)
        {
            // 去除首尾空格 + 统一小写，避免用户输入"钻石"/"钻石 "/“ZuanShi”都能匹配
            string targetName = name.Trim().ToLower();
            bool found = false;
            Bag targetItem = null;

            for (int i = 0; i < items.Count; i++)
            {
                Bag thisItem = (Bag)items[i];
                if (thisItem.Item.ToLower() == targetName)
                {
                    found = true;
                    targetItem = thisItem;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"❌ 买入失败：商店没有「{name}」这个物品！");
                return;
            }

            if (money < targetItem.Pay)
            {
                Console.WriteLine($"❌ 买入失败：余额不足！需要 {targetItem.Pay} 金币，当前只有 {money} 金币");
                return;
            }

            money -= targetItem.Pay;
            myItems.Add(targetItem);
            Console.WriteLine($"✅ 买入成功！已购买「{targetItem.Item}」，花费 {targetItem.Pay} 金币，剩余余额：{money} 金币");
        }

        // 卖出物品（优化：忽略大小写）
        void sell(string name)
        {
            string targetName = name.Trim().ToLower();
            bool found = false;
            int targetIndex = -1;
            Bag targetItem = null;

            for (int i = 0; i < myItems.Count; i++)
            {
                Bag thisItem = (Bag)myItems[i];
                if (thisItem.Item.ToLower() == targetName)
                {
                    found = true;
                    targetIndex = i;
                    targetItem = thisItem;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"❌ 卖出失败：背包里没有「{name}」这个物品！");
                return;
            }

            int sellMoney = targetItem.Pay * 90 / 100;
            money += sellMoney;
            myItems.RemoveAt(targetIndex);
            Console.WriteLine($"✅ 卖出成功！「{targetItem.Item}」卖出价 {sellMoney} 金币，当前余额：{money} 金币");
        }

        // 显示余额
        void showMoney()
        {
            Console.WriteLine($"\n💰 当前余额：{money} 金币");
        }

        // 显示操作菜单（提取为独立方法，减少重复代码）
        static void ShowMenu()
        {
            Console.WriteLine("\n===== 操作菜单 =====");
            Console.WriteLine("1. 卖出物品");
            Console.WriteLine("2. 买入物品");
            Console.WriteLine("3. 查看余额");
            Console.WriteLine("4. 查看我的背包");
            Console.WriteLine("5. 查看商店物品");
            Console.WriteLine("6. 退出程序");
            Console.Write("请输入要执行的操作编号：");
        }

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;  // 输入编码（读取用户输入的 UTF-8 字符）
            Console.OutputEncoding = Encoding.UTF8; // 输出编码（打印 UTF-8 字符到控制台）
            Program program = new Program();
            program.init();
            program.showAllItems();

            while (true)
            {
                try
                {
                    ShowMenu(); // 调用独立的菜单方法
                    int choice = int.Parse(Console.ReadLine());

                    // 先清屏，再执行操作（优化体验：避免菜单和结果混在一起）
                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("===== 卖出物品 =====");
                            Console.Write("请输入要卖出的物品名称：");
                            string sellName = Console.ReadLine();
                            program.sell(sellName);
                            break;
                        case 2:
                            Console.WriteLine("===== 买入物品 =====");
                            // 买入前先显示商店物品，方便用户查看
                            program.showAllItems();
                            Console.Write("\n请输入要买入的物品名称：");
                            string buyName = Console.ReadLine();
                            program.buy(buyName);
                            break;
                        case 3:
                            program.showMoney();
                            break;
                        case 4:
                            program.showMyItems();
                            break;
                        case 5:
                            program.showAllItems();
                            break;
                        case 6:
                            Console.WriteLine("👋 程序已退出！");
                            return;
                        default:
                            Console.WriteLine("❌ 输入错误！请输入 1-6 之间的数字");
                            break;
                    }

                    // 操作完成后暂停，让用户看完结果再继续（按任意键返回菜单）
                    Console.WriteLine("\n按任意键返回菜单...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("❌ 输入格式错误！请输入数字");
                    Console.WriteLine("\n按任意键返回菜单...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"❌ 操作出错：{ex.Message}");
                    Console.WriteLine("\n按任意键返回菜单...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}