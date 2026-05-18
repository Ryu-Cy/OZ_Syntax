namespace ConsoleApp_Day18
{   /***********************************************
    [딕셔너리 예제 2]
    ***********************************************/
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Item(string name, int price)
        {
            Name = name; Price = price;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"[{Name}]\t가격: {Price} Gold");
        }
    }
    class Inventory
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
            items.Add(item);
            Console.WriteLine($"[{item.Name}]을(를) 추가했다.");
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
    }
    class Player
    {
        public int PlayerID { get; private set; }
        public string Name { get; private set; }
        public Inventory Inventory { get; private set; }
        public Player(int playerID, string name)
        {
            PlayerID = playerID;
            Name = name;
            Inventory = new Inventory();
        }
        public void ShowPlayerInfo()
        {
            Console.WriteLine($"Player ID: {PlayerID} / Name: {Name}");
        }
    }
    internal class Program03
    {
        static void Main()
        {
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            Player player1 = new Player(1001, "Warrior");
            Player player2 = new Player(1002, "Mage");

            players.Add(player1.PlayerID, player1);
            players.Add(player2.PlayerID, player2);

            Item sword = new Item("Long-Sword", 1000);
            Item shield = new Item("Wooden-Shield", 700);
            Item staff = new Item("Wand", 1200);

            players[1001].Inventory.AddItem(sword);
            players[1001].Inventory.AddItem(shield);

            players[1002].Inventory.AddItem(staff);

            players[1001].ShowPlayerInfo();
            players[1001].Inventory.ShowItem();

            players[1002].ShowPlayerInfo();
            players[1002].Inventory.ShowItem();
        }
    }
}
