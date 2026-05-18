using Game.Enums;
using Game.Player;
using Game.ItemSystem;

namespace Shop
{
    internal class MainGame
    {
        private Player player = new Player();
        private Item[] shopItems =
        {
            new Weapon("초보자 칼", 5, 100),
            new Weapon("전설의 검", 20, 500),
            new Armor("누더기 옷", 2, 50),
            new Armor("전설의 갑옷", 15, 300)
        };
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine($"\t[MainMenu] ({player.Gold})");
                Console.WriteLine("===========================================");
                Console.WriteLine("[1] 상점 이동" +
                                "\n[2] 인벤토리 관리" +
                                "\n[3] 캐릭터 상태" +
                                "\n[0] 종료");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    continue;
                }
                switch ((MenuOption)choice)
                {
                    case MenuOption.Exit:
                        isRunning = false;
                        break;
                    case MenuOption.Shop:
                        ShowShop();
                        break;
                    case MenuOption.Inventory:
                        ShowInventory();
                        break;
                    case MenuOption.Status:
                        ShowStatus();
                        break;
                    default:
                        break;
                }

            }
        }
        private void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("\t[상점]");
            Console.WriteLine("===========================================");
            for (int i = 0; i < shopItems.Length; i++)
            {
                Console.Write($"[{i + 1}]");
                shopItems[i].ShowInfo();
            }
            Console.WriteLine("[0]나가기");
            Console.WriteLine("-------------------------------------------");
            Console.Write("구매할 아이템 번호 입력: ");

            if (int.TryParse(Console.ReadLine(), out int idx)
                && idx > 0 && idx <= shopItems.Length)
            {
                BuyItem(shopItems[idx - 1]);
            }
            Console.WriteLine("\n엔터를 누르면 돌아간다.");
            Console.ReadLine();
        }
        public void BuyItem(Item item)
        {
            int slot = player.GetEmptySlot();
            if (slot == -1)
            {
                Console.WriteLine("\n가방이 가득 찼다.");
                return;
            }
            if (player.Gold < item.Price)
            {
                Console.WriteLine("골드가 부족하다.");
                return;
            }
            player.Gold -= item.Price;
            player.Inventory[slot] = item;
            Console.WriteLine($"\n{item.Name} 구매 성공!!");
        }
        private void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("\t[가방]");
            Console.WriteLine("===========================================");
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                Item item = player.Inventory[i];
                string info = "";
                if (item != null)
                {
                    if (item.IsEquipped)
                    {
                        info = "(E)" + item.Name;
                    }
                    else
                    {
                        info = item.Name;
                    }
                }
                else
                {
                    info = "[비었음]";
                }
                Console.WriteLine($"[{i + 1}]{info}");
            }
            Console.WriteLine("[0]나가기");
            Console.WriteLine("-------------------------------------------");
            
            Console.Write("아이템 번호 입력: ");
            if (int.TryParse(Console.ReadLine(), out int idx)
                && idx > 0 && idx <= player.Inventory.Length)
            {
                Item selected = player.Inventory[idx - 1];
                if (selected == null)
                {
                    Console.WriteLine("\n빈 슬롯이다.");
                }
                else
                {
                    Console.WriteLine($"\n선택한 아이템: {selected.Name}");
                    Console.WriteLine("(1). 장착 / 해제");
                    Console.WriteLine("(2). 판매");

                    Console.Write("선택: ");
                    string input = Console.ReadLine();
                    switch(input)
                    {
                        case "1":
                            HandleEquip(selected);
                            break;
                        case "2":
                            SellItem(idx - 1);
                            break;
                    }
                }
            }
            Console.WriteLine("\n엔터를 누르면 돌아간다.");
            Console.ReadLine();
        }
        private void HandleEquip(Item item)
        {
            item.IsEquipped = !item.IsEquipped;
            if (item is IEquippable equipItem)
            {
                if (item.IsEquipped)
                {
                    equipItem.Equip();
                }
                else
                {
                    equipItem.UnEquip();
                }
            }
            player.UpdateStatus();
        }
        private void SellItem(int slotIndex)
        {
            Item item = player.Inventory[slotIndex];
            int sellPrice = item.Price / 2;
            player.Gold += sellPrice;
            player.Inventory[slotIndex] = null;
            player.UpdateStatus();
            Console.WriteLine($"\n{item.Name} 판매 완료!(+{sellPrice} Gold)");
        }
        private void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("\t[캐릭터]");
            Console.WriteLine("===========================================");
            Console.WriteLine($"공격력: {player.TotalAtk}" +
                            $"\n방어력: {player.TotalDef}" +
                            $"\n골드: {player.Gold}");
            Console.WriteLine("===========================================");
            Console.WriteLine("\n엔터를 누르면 돌아간다.");
            Console.ReadLine();
        }
    }
}
