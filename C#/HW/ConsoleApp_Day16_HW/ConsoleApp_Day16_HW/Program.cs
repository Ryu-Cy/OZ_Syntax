using System;

namespace ConsoleApp_Day16_HW
{   /************************************************
    [과제]
    - 해당 코드의 문제점을 SOLID 원칙을 바탕으로 찾아내고 고치기
    ㄴ Inventory 클래스가 너무 많은 일을 하고 있다. -> SRP
    ㄴ 아이템 추가마다 기존 코드의 수정을 요구함 -> OCP
    ************************************************/
    // ===========================================
    enum ItemType
    {
        Potion, Weapon, Armor
    }
    interface IItem
    {
        public void Use();
    }
    class Potion : Item, IItem
    {
        private string Name { get; set; }
        private ItemType Type { get; set; }
        private int Price { get; set; }
        public Potion(string name, ItemType type, int price) : base(name, type, price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public void Use()
        {
            Console.WriteLine(Name + " 사용! 체력을 회복합니다.");
        }
    }
    class Weapon : Item, IItem
    {
        private string Name { get; set; }
        private ItemType Type { get; set; }
        private int Price { get; set; }
        public Weapon(string name, ItemType type, int price) : base(name, type, price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
        public void Use()
        {
            Console.WriteLine(Name + " 장착! 공격력이 증가합니다.");
        }
    }
    class Armor : Item, IItem
    {
        private string Name { get; set; }
        private ItemType Type { get; set; }
        private int Price { get; set; }
        public Armor(string name, ItemType type, int price) : base(name, type, price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
        public void Use()
        {
            Console.WriteLine(Name + " 장착! 방어력이 증가합니다.");
        }
    }
    class ItemUseSystem
    {
        public static void UseItem(IItem item)
        {
            item.Use();
        }
    }
    class ShopSystem
    {
        public static void SellItem(Inventory inventory, string name)
        {
            for (int i = 0; i < inventory.GetCount(); i++)
            {
                if (inventory.GetItems()[i].Name == name)
                {
                    inventory.AddGold(inventory.GetItems()[i].Price);
                    Console.WriteLine(inventory.GetItems()[i].Name + " 아이템 판매 완료\n" +
                                                                     $"+ {inventory.GetGold()} Gold");
                    
                    for (int j = i; j < inventory.GetCount() - 1; j++)
                    {
                        inventory.GetItems()[j] = inventory.GetItems()[j + 1];
                    }

                    inventory.GetItems()[inventory.GetCount() - 1] = null;
                    inventory.SubCount();

                    return;
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다.");
        }
    }
    class DataManager
    {
        public static void SaveInventory(Inventory inventory)
        {
            Console.WriteLine("인벤토리 저장 완료" +
                            "\n저장 데이터를 뽑지 않는데 무슨 내용이 들어가야하지?");
        }
    }
    // ===========================================
    abstract class Item
    {
        public string Name;
        public ItemType Type;
        public int Price;
        public Item(string name, ItemType type, int price) 
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }
    class Inventory
    {
        protected Item[] items = new Item[10];
        private int count = 0;
        private int gold = 0;

        public void AddItem(Item item)
        {
            if (count >= items.Length)
            {
                //Console.WriteLine("인벤토리가 가득 찼습니다.");
                //return;
                Array.Resize(ref items, count + 10);
                Console.WriteLine("\n인벤토리가 가득 찼습니다." +
                                "\n인벤토리 공간을 10칸 추가합니다.\n");
            }

            items[count] = item;
            count++;

            Console.WriteLine(item.Name + " 아이템 추가 완료");
        }

        public void RemoveItem(string itemName)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Name == itemName)
                {
                    Console.WriteLine(items[i].Name + " 아이템 삭제 완료");

                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }

                    items[count - 1] = null;
                    count--;

                    return;
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다.");
        }

        public void PrintItems()
        {
            Console.WriteLine("===== 인벤토리 목록 =====");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{items[i].Name} / {items[i].Type} / {items[i].Price}G");
            }
            Console.WriteLine($"\n현재 골드: {gold} Gold");
        }

        //public void UseItem(string itemName)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (items[i].Name == itemName)
        //        {
        //            if (items[i].Type == "Potion")
        //            {
        //                Console.WriteLine(items[i].Name + " 사용! 체력을 회복합니다.");
        //            }
        //            else if (items[i].Type == "Weapon")
        //            {
        //                Console.WriteLine(items[i].Name + " 장착! 공격력이 증가합니다.");
        //            }
        //            else if (items[i].Type == "Armor")
        //            {
        //                Console.WriteLine(items[i].Name + " 장착! 방어력이 증가합니다.");
        //            }

        //            return;
        //        }
        //    }

        //    Console.WriteLine("아이템을 찾을 수 없습니다.");
        //}

        //public void SaveInventory()
        //{
        //    Console.WriteLine("인벤토리 저장 완료");
        //}

        public Item[] GetItems()
        {
            return items;
        }
        public int GetCount()
        {
            return count;
        }
        public int SubCount()
        {
            return count--;
        }
        public int GetGold()
        {
            return gold;
        }
        public void AddGold(int x)
        {
            this.gold += x;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("===== 과제1. SOLID 관점 리펙토링 - 인벤토리 =====");
            Inventory inventory = new Inventory();

            //inventory.AddItem(new Item { Name = "체력 포션", Type = "Potion", Price = 50 });
            //inventory.AddItem(new Item { Name = "초보자 검", Type = "Weapon", Price = 100 });
            //inventory.AddItem(new Item { Name = "가죽 갑옷", Type = "Armor", Price = 150 });

            inventory.AddItem(new Potion("체력 포션", ItemType.Potion, 50));
            inventory.AddItem(new Weapon("초보자 검", ItemType.Weapon, 100));
            inventory.AddItem(new Armor("가죽 갑옷", ItemType.Armor, 150));
            inventory.AddItem(new Armor("중급자 장갑", ItemType.Armor, 150));

            inventory.AddItem(new Potion("체력 포션", ItemType.Potion, 50));
            inventory.AddItem(new Weapon("초보자 검", ItemType.Weapon, 100));
            inventory.AddItem(new Armor("가죽 갑옷", ItemType.Armor, 150));
            inventory.AddItem(new Armor("중급자 장갑", ItemType.Armor, 150));

            inventory.AddItem(new Potion("체력 포션", ItemType.Potion, 50));
            inventory.AddItem(new Weapon("초보자 검", ItemType.Weapon, 100));
            inventory.AddItem(new Armor("가죽 갑옷", ItemType.Armor, 150));
            inventory.AddItem(new Armor("중급자 장갑", ItemType.Armor, 150));
            Console.WriteLine("\n");

            inventory.PrintItems();
            Console.WriteLine("\n");

            // 기본 방식
            //inventory.UseItem("체력 포션");

            // 인벤토리 내부 중 하나를 인덱스로 출력하는 방식
            //ItemUseSystem.UseItem((IItem)inventory.GetItems()[0]);

            // 인벤토리 내부 인벤토리가 차있는 만큼의 인덱스를 출력하는 방식
            Console.WriteLine("===== 인벤토리 안 아이템 모두 사용 =====");
            for (int i = 0; i < inventory.GetCount(); i++)
            {
                ItemUseSystem.UseItem((IItem)inventory.GetItems()[i]);
            }
            Console.WriteLine("\n");

            inventory.RemoveItem("중급자 장갑");
            Console.WriteLine("\n");

            ShopSystem.SellItem(inventory, "중급자 장갑");

            Console.WriteLine("\n");

            // 기본 방식
            //inventory.SaveInventory();
            DataManager.SaveInventory(inventory);
            Console.WriteLine("\n");

            inventory.PrintItems();
        }
    }
}
