using Game.BattleManager_;
using Game.Enums;
using Game.Item_;
using Game.Map_;
using Game.Monster_;
using Game.Player_;
using Game.Shop_;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace Game.GameManager_
{
    class GameManager
    {
        Dictionary<int, Player> players = new Dictionary<int, Player>();
        Player player = new Player(1, "Player");
        Player enemy = new Player(2, "Wild");
        Player boss = new Player(3, "Red");
        Map map = new Map();
        BattleManager battleManager = new BattleManager();
        Shop shop = new Shop();
        bool isPlay = true;
        bool isTurnSet = false;


        public void Run()
        {

            SetPlayer();
            SetBoss();
            while (isPlay)
            {
                Console.Clear();
                if (battleManager.IsBattle)
                {
                    if (!battleManager.IsBoss)
                    {
                        if (!isTurnSet)
                        {
                            battleManager.SetTurn(player, enemy);
                            isTurnSet = true;
                        }
                        map.UpdateBattleField(map.Width, map.Height,
                            player.MonsterInventory.GetMonster(0), enemy.MonsterInventory.GetMonster(0));
                        battleManager.BattleSystem(player, enemy, map);
                    }
                    else
                    {
                        if (!isTurnSet)
                        {
                            battleManager.SetTurn(player, boss);
                            isTurnSet = true;
                        }
                        map.UpdateBattleField(map.Width, map.Height,
                            player.MonsterInventory.GetMonster(0), boss.MonsterInventory.GetMonster(0));
                        battleManager.BattleSystem(player, boss, map);
                    }
                }
                else
                {
                    isTurnSet = false;
                    map.UpdateField(map.Width, map.Height, player.myPosX, player.myPosY);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    char input = char.ToUpper(keyInfo.KeyChar);
                    if (input == 'Q')
                    {
                        isPlay = false;
                        break;
                    }
                    else if (input == 'I')
                    {
                        Console.Clear();
                        for (int y = 0; y < map.Width; y++)
                        {
                            for (int x = 0; x < map.Height; x++)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("  ");
                                Console.ResetColor();
                            }
                            Console.WriteLine();
                        }
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"========== [ {player.MonsterInventory.Count} / 6 ] ==========");
                        Console.SetCursorPosition(0, 2);
                        player.MonsterInventory.ShowMonster();
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine($"========== [ {player.Inventory.Count} / 10 ] ==========");
                        Console.SetCursorPosition(0, 10);
                        player.Inventory.ShowItem();
                        Console.SetCursorPosition(0, 20);
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"총 골드 : {player.Gold}");
                        Console.WriteLine("무엇을 하시겠습니까?\n1. 아이템 장착/해제\n2. 나가기");
                        string inputSelectTask = Console.ReadLine();
                        int selectNum = int.Parse(inputSelectTask);
                        if (selectNum == 1)
                        {
                            Console.Write("장비를 선택해주세요: ");
                            string inputItemName = Console.ReadLine();
                            if (player.Inventory.IsItem(inputItemName))
                            {
                                if (!player.Inventory.SelectItem(inputItemName).IsEquipped)
                                {
                                    Console.Write("장비를 장착할 몬스터 번호를 입력해주세요: ");
                                    if (int.TryParse(Console.ReadLine(), out int idx)
                                        && idx <= player.MonsterInventory.Count)
                                    {
                                        player.MonsterInventory.GetMonster(idx - 1).UseItem(player.Inventory.SelectItem(inputItemName));
                                    }
                                    else
                                    {
                                        Console.WriteLine("잘못 입력했습니다.");
                                        Thread.Sleep(1000);
                                    }
                                }
                                else
                                {
                                    Console.Write("장비를 해제하겠습니까?  (1. 예 / 2. 아니오) : ");
                                    if (int.TryParse(Console.ReadLine(), out int idx))
                                    {
                                        if (idx == 1)
                                        {
                                            Console.Write("장비를 해제할 몬스터를 선택해주세요: ");
                                            if (int.TryParse(Console.ReadLine(), out int idx_)
                                                && idx_ <= player.MonsterInventory.Count)
                                            {
                                                if (player.MonsterInventory.GetMonster(idx_ - 1).IsEquiped)
                                                {
                                                    player.MonsterInventory.GetMonster(idx_ - 1).UnUseItem();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("장비를 장착 중이지 않습니다.");
                                                    Thread.Sleep(1000);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("잘못 입력했습니다.");
                                                Thread.Sleep(1000);
                                            }
                                        }
                                        else if (idx == 2)
                                        {
                                            Console.WriteLine("장비를 해제하지 않습니다.");
                                            Thread.Sleep(1000);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("해당 장비가 없습니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        else if (selectNum == 2)
                            continue;
                        else
                        {
                            Console.WriteLine("잘못 입력했습니다. 메인 화면으로 돌아갑니다."); 
                            Thread.Sleep(1000);
                        }
                    }
                    player.Move(keyInfo.Key, map.Width, map.Height);
                    Encounter(player.myPosX, player.myPosY);
                }

            }
        }
        public void SetPlayer()
        {
            Console.Write("이름을 입력해주세요: ");
            string inputName = Console.ReadLine();
            player.SetPlayerName(inputName);
            players.Add(player.PlayerID, player);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== 몬스터를 선택하세요. ==");
                Console.WriteLine("1. Fire");
                Console.WriteLine("2. Water");
                Console.WriteLine("3. Grass");

                ConsoleKeyInfo consoleKey = Console.ReadKey();
                double inputNum = char.GetNumericValue(consoleKey.KeyChar);
                Console.WriteLine();

                if ((int)inputNum == 1)
                {
                    Console.WriteLine("Fire를 선택했습니다.");
                    player.MonsterInventory.AddMonster(new Charmander("Fire"));
                    Thread.Sleep(1000);
                    break;
                }
                else if ((int)inputNum == 2)
                {
                    Console.WriteLine("Water를 선택했습니다.");
                    player.MonsterInventory.AddMonster(new Squirtle("Water"));
                    Thread.Sleep(1000);
                    break;
                }
                else if ((int)inputNum == 3)
                {
                    Console.WriteLine("Grass를 선택했습니다.");
                    player.MonsterInventory.AddMonster(new Bulbasaur("Grass"));
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못 입력했습니다."); 
                    Thread.Sleep(1000);
                }
            }

            player.Inventory.AddItem(new Ball("몬스터 볼", 100));
            player.Inventory.AddItem(new Ball("몬스터 볼", 100));
            player.Inventory.AddItem(new Ball("몬스터 볼", 100));
            player.GetGold(5000);
        }
        public void Encounter(int playerX, int playerY)
        {
            if (map.mapArr[playerX, playerY] == FieldType.Grass)
            {
                battleManager.EnterGrass();
                Random randNum = new Random();
                int result = randNum.Next(0, 10);
                if (result % 10 > 7)
                {
                    result = randNum.Next(0, 10);
                    enemy.MonsterInventory.Reset();
                    player.MonsterInventory.AllHeal();
                    if (result % 3 == 0)
                        enemy.MonsterInventory.AddMonster(new Charmander("Fire"));
                    else if (result % 3 == 1)
                        enemy.MonsterInventory.AddMonster(new Squirtle("Water"));
                    else if (result % 3 == 2)
                        enemy.MonsterInventory.AddMonster(new Bulbasaur("Grass"));

                    battleManager.EnterBattle();
                }
            }
            else if (map.mapArr[playerX, playerY] == FieldType.Shop)
            {
                map.MapChange(3);
            }
            else if (map.mapArr[playerX, playerY] == FieldType.Portal)
            {
                map.MapChange();
            }
            else if (map.mapArr[playerX, playerY] == FieldType.Boss)
            {
                battleManager.EnterBoss();
                player.MonsterInventory.AllHeal();
                battleManager.EnterBattle();
            }
            else if (map.mapArr[playerX, playerY] == FieldType.Npc)
            {
                shop.OpenShop(map.Width, map.Height, player);
            }
        }
        public void SetBoss()
        {
            players.Add(boss.PlayerID, boss);
            boss.MonsterInventory.AddMonster(new Charmander("Fire", 10));
            boss.MonsterInventory.AddMonster(new Squirtle("Water", 10));
            boss.MonsterInventory.AddMonster(new Bulbasaur("Grass", 10));
            boss.MonsterInventory.AddMonster(new Pikachu("Electric", 10));
        }
    }
}
