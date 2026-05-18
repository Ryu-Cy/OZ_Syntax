using System.Globalization;
using System.Net.Security;

namespace ConsoleApp_Day12_HW
{   /*************************************
    [과제]
    1. 플레이어 체력 관리
    2. 간단한 인벤토리 만들기
    *************************************/
    internal class Program
    {
        // 과제 1
        class Player
        {
            private string name;
            private int hp;
            public string Name { get { return name; } set { name = value; } }
            public int Hp
            {
                get { return hp; }
                set
                {
                    if (value < 0)
                        hp = 0;
                    else if (value > 100)
                        hp = 100;
                    else
                        hp = value;
                }
            }
            public Player (string name, int hp)
            {
                Name = name;
                Hp = hp;
            }
            public void PrintInfo(Player p)
            {
                Console.WriteLine($"플레이어: {p.Name}, HP: {p.Hp}");
            }
        }
        class Enemy
        {
            private string name;
            private int atk;
            public string Name { get { return name; } set { name = value; } }
            public int Atk { get { return atk; } set { atk = value; } }
            public Enemy(string name, int atk)
            {
                Name = name;
                Atk = atk;
            }
            public void PrintInfo(Enemy e)
            {
                Console.WriteLine($"적 이름: {e.Name}, 공격력: {e.Atk}");
            }
        }
        static class Combat
        {
            private static Random randNum = new Random();
            private static int getRandNum;
            public static void DamageDealt(Player p, Enemy e)
            {
                getRandNum = randNum.Next(0, 10);
                if (getRandNum % 2 == 0)
                {
                    Console.WriteLine($"{p.Name}(이)가 {e.Name}에게 공격을 당했습니다.\t대미지: {e.Atk}");
                    p.Hp -= e.Atk;
                }
                else if (getRandNum % 2 == 1)
                {
                    Console.WriteLine($"{p.Name}(이)가 {e.Name}에게 치명적인 공격을 당했습니다.\t대미지: {e.Atk * 2}");
                    p.Hp -= e.Atk;
                }
            }
        }
        // 과제 2
        class Inventory
        {
            private int capacity = 3;
            //private int count;        -> 필요 없을듯?
            public int Capacity { get { return capacity; } }
            public int Count { get; private set; }
            //public Inventory() { }    -> 필요 없을듯?
            public void AddItem()
            {
                Count++;
                if (Count > Capacity)
                {
                    Console.WriteLine("더 이상 담을 수 없습니다.");
                    Count--;
                }
                else
                    Console.WriteLine($"아이템을 추가했습니다. (현재 {Count}/{Capacity})");
            }
            public void ShowInfo()
            {
                Console.WriteLine($"현재 아이템 수: {Count}/{Capacity}");
            }
        }
        static void Main(string[] args)
        {
            // 과제 1. 플레이어 체력 관리
            Console.WriteLine("===== 과제 1. 플레이어 체력 관리 =====");
            Player player = new Player("둘리", 100);
            player.PrintInfo(player);
            Enemy enemy = new Enemy("고블린", 10);
            enemy.PrintInfo(enemy);
            while (player.Hp > 0)
            {
                Combat.DamageDealt(player, enemy);
                player.PrintInfo(player);
            }
            Console.WriteLine($"{player.Name}(이)가 {enemy.Name}에 의해 쓰러졌습니다.\n");
            Console.WriteLine("===== 과제 1. 예외처리 테스트 =====");
            Player player1 = new Player("둘리", -20);
            player.PrintInfo(player1); 
            Player player2 = new Player("둘리", 120);
            player.PrintInfo(player2);
            Console.WriteLine();

            // 과제 2. 간단한 인벤토리 만들기
            Console.WriteLine("===== 과제 2. 간단한 인벤토리 만들기 =====");
            Inventory inventory = new Inventory();
            inventory.ShowInfo();
            inventory.AddItem();
            inventory.AddItem();
            inventory.AddItem();
            inventory.ShowInfo();
            inventory.AddItem();
        }
    }
}
