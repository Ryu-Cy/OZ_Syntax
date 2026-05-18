using Game.Enums;
using Game.Inventory_;

namespace Game.Player_
{
    class Player
    {
        public int PlayerID { get; private set; }
        public string Name { get; private set; }
        public ItemInventory Inventory { get; private set; }
        public MonsterInventory MonsterInventory { get; private set; }
        public int myPosX = 0;
        public int myPosY = 0;
        public int Gold {  get; private set; }
        public Player(int playerID, string name)
        {
            PlayerID = playerID;
            Name = name;
            Gold = 1000;
            Inventory = new ItemInventory();
            MonsterInventory = new MonsterInventory();
        }
        public void SetPlayerName(string name)
        {
            Name = name;
        }
        public void ShowPlayerInfo()
        {
            Console.Write($"PlayerID: {PlayerID}  |  Name: {Name}");
            
        }
        public void ShowPlayerMonstersInfo()
        {
            Console.Write("Monster "); 
            for (int i = 0; i < MonsterInventory.Count; i++)
            {
                if (MonsterInventory.GetMonster(i).IsDead == false)
                    Console.Write("● ");
                else if (MonsterInventory.GetMonster(i).IsDead == true)
                    Console.Write("○ ");
            }
        }
        public void Move(ConsoleKey key, int width, int height)
        {
            //ConsoleKeyInfo consoleKey = Console.ReadKey(true);
            //int prevX = myPosX;
            //int prevY = myPosY;

            if (key == ConsoleKey.UpArrow) myPosY--;
            if (key == ConsoleKey.DownArrow) myPosY++;
            if (key == ConsoleKey.LeftArrow) myPosX--;
            if (key == ConsoleKey.RightArrow) myPosX++;

            if (myPosX < 0)
                myPosX = 0;
            if (myPosY < 0)
                myPosY = 0;
            if (myPosX >= width)
                myPosX = width - 1;
            if (myPosY >= height)
                myPosY = height - 1;
            return;
        }
        public void PlayerPosReset()
        {
            myPosX = 0;
            myPosY = 0;
        }
        public void GetGold(int gold)
        {
            Gold += gold;
        }
        public void PayPrice(int price)
        {
            Gold -= price;
        }
    }
}
