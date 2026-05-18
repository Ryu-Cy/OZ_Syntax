using Game.Player_;
using Game.Item_;
using Game.Inventory_;

namespace Game.Shop_
{
    class Shop
    {
        public ItemInventory Inventory { get; private set; }

        public Shop()
        {
            Inventory = new ItemInventory();
            SetItems();
        }

        public void SetItems()
        {
            Inventory.AddItem(new AtkOrb("공격력 증가 구슬", 1000));
            Inventory.AddItem(new DefOrb("방어력 증가 구슬", 500));
            Inventory.AddItem(new Ball("몬스터 볼", 100));
        }
        public void OpenShop(int width, int height, Player player)
        {
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("=====================================");
            Console.SetCursorPosition(0, 2);
            Inventory.ShowItem();
            Console.WriteLine("=====================================");
            Console.WriteLine("구매할 아이템 이름을 입력해주세요.");
            string inputName = Console.ReadLine();
            if (Inventory.IsItem(inputName))
            {
                if (player.Gold >= Inventory.SelectItem(inputName).Price)
                {
                    player.Inventory.AddItem(Inventory.SelectItem(inputName));
                    player.PayPrice(Inventory.SelectItem(inputName).Price);
                    Console.WriteLine($"{Inventory.SelectItem(inputName).Name}을(를) 구매했습니다.!");
                    Console.WriteLine($"- {Inventory.SelectItem(inputName).Price}!");
                    Inventory.RemoveItem(inputName);
                    Thread.Sleep(1000);
                    return;
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            else
            {
                Console.WriteLine("해당 아이템이 없습니다.");
                return;
            }
        }
    }
}
