using Game.Enums;
using Game.Item_;
using Game.Monster_;
using System.Data;

namespace Game.Inventory_
{
    class ItemInventory
    {
        private List<Item> items = new List<Item>();
        public int Count
        {
            get { return items.Count; }
        }
        public void AddItem(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("아이템이 없다.");
                return;
            }
            if (items.Count > 10)
            {
                Console.WriteLine("가방이 가득 찼다.");
                return;
            }
            items.Add(item);
            //Console.WriteLine($"[{item.Name}]을(를) 추가했다.");
        }
        public void RemoveItem(string itemName)
        {
            Item foundItem = null;
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    foundItem = item;
                    break;
                }
            }
            if (foundItem == null)
            {
                Console.WriteLine($"[{itemName}]이 없다.");
                return;
            }
            items.Remove(foundItem);
            Console.WriteLine($"[{itemName}]을(를) 제거했다.");
        }
        public void ShowItem()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있다.");
                return;
            }
            foreach (Item item in items)
            {
                item.PrintInfo();
            }
        }

        public bool IsItem(string itemName)
        {
            Item foundItem = null;
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    foundItem = item;
                    break;
                }
            }
            if (foundItem == null)
            {
                return false;
            }
            return true;
        }
        public Item SelectItem(string itemName)
        {
            Item foundItem = null;
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    foundItem = item;
                    break;
                }
            }
            return foundItem;
        }
        public int CountItem(ItemType type)
        {
            int count = 0;
            foreach (Item item in items)
            {
                if (item.Type == type)
                {
                    count++;
                }
            }
            return count;
        }
    }
    class MonsterInventory
    {
        private List<Monster> monsters = new List<Monster>();
        public int Count
        {
            get { return monsters.Count; }
        }
        public void AddMonster(Monster monster)
        {
            if (monster == null)
            {
                Console.WriteLine("몬스터가 없다.");
                return;
            }
            if (monsters.Count > 6)
            {
                Console.WriteLine("몬스터 가방이 가득 찼다.");
                return;
            }
            monsters.Add(monster);
            //Console.WriteLine($"[{monster.Name}]을(를) 추가했다.");
        }
        public void RemoveMonster(string monsterName)
        {
            Monster foundMonster = null;
            foreach (Monster monster in monsters)
            {
                if (monster.Name == monsterName)
                {
                    foundMonster = monster;
                    break;
                }
            }
            if (foundMonster == null)
            {
                Console.WriteLine($"[{monsterName}]이 없다.");
                return;
            }
            monsters.Remove(foundMonster);
            Console.WriteLine($"[{monsterName}]을(를) 제거했다.");
        }
        public void ShowMonster()
        {
            if (monsters.Count == 0)
            {
                Console.WriteLine("몬스터 인벤토리가 비어있다.");
                return;
            }
            foreach (Monster monster in monsters)
            {
                monster.PrintInfo();
            }
        }
        public Monster GetMonster(int x)
        {
            return monsters[x];
        }
        public void Reset()
        {
            monsters.Clear();
        }
        public void AllLevelUp()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].LevelUp();
            }
        }
        public void AllHeal()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Resurrection();
                monsters[i].Heal();
            }
        }
        public void ChangeMonster()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead == false)
                {
                    Monster tmpMon = monsters[0];
                    monsters[0] = monsters[i];
                    monsters[i] = tmpMon;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine($"{tmpMon.Name}이(가) 쓰러졌다!");
                    Console.WriteLine($"{monsters[0].Name}로 교대한다!");
                    return;
                }
            }
        }
        public void ChangeSelectMonster(int num)
        {
            if (monsters[num].IsDead == true)
            {
                Console.WriteLine("해당 몬스터는 쓰러져있습니다.");
                Thread.Sleep(1000);
                return;
            }
            if (num == 0)
            {
                Console.WriteLine("이미 나와있는 몬스터입니다.");
                Thread.Sleep(1000);
                return;
            }
            Monster tmp = monsters[0];
            monsters[0] = monsters[num];
            monsters[num] = tmp;
        }
        public int IsAliveCheck()
        {
            int count = 0;
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead == false)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
