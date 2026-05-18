namespace ConsoleApp_Day14_HW
{   /**************************************************
    [과제]
    1. 추상 클래스
     1-1. 몬스터 전투 시스템
     1-2. 아이템 사용 시스템
    2. 인터페이스 과제
     2-1. 상호작용 오브젝트 만들기
     2-2. 추상 클래스와 인터페이스로 캐릭터 만들기
    **************************************************/
    internal class Day14_HW
    {
        static void Main(string[] args)
        {
            // 과제 1
            Console.WriteLine("===== 과제 1-1. 몬스터 전투 시스템 =====");
            Monster[] monsters = { new Goblin("고블린", 30), new Orc("오크", 50), new Dragon("드래곤", 200) };
            foreach (var monster in monsters)
            {
                monster.Print();
                monster.Attack();
                Console.WriteLine();
            }
            Console.WriteLine("===== 과제 1-2. 아이템 사용 시스템 =====");
            Item potion = new Potion("포션", 2);
            Item scroll = new Scroll("스크롤", 1);
            Item bomb = new Bomb("폭탄", 2);
            for (int i = 0; i < 3; i++)
            {
                potion.PrintInfo();
                potion.Use();
            } 
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                scroll.PrintInfo();
                scroll.Use();
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                bomb.PrintInfo();
                bomb.Use();
            }
            Console.WriteLine();

            // 과제 2
            Console.WriteLine("===== 과제 2-1. 상호작용 오브젝트 만들기 =====");
            IInteractable[] interactables = { new Chest(), new Door(), new Npc() };
            foreach (var interactable in interactables)
            {
                interactable.Interact();
            }
            Console.WriteLine();
            Console.WriteLine("===== 과제 2-2. 캐릭터 만들기 =====");
            Warrior warrior = new Warrior("아르곤", 150, 20);
            Mage mage = new Mage("메디브", 100, 15);
            warrior.ShowStatus();
            mage.ShowStatus();
            warrior.Attack();
            mage.TakeDamage(warrior.GetAttackPower());
            mage.Attack();
            warrior.TakeDamage(mage.GetAttackPower());
            mage.Heal();
        }
    }
}
