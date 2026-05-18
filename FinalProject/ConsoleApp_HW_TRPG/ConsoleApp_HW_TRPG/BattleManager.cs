using Game.Enums;
using Game.Item_;
using Game.Monster_;
using Game.Player_;
using System.Reflection.Metadata.Ecma335;

namespace Game.BattleManager_
{
    class BattleManager
    {
        public bool IsBattle { get; protected set; } = false;
        public bool IsBoss { get; protected set; } = false;
        public bool IsMyTurn { get; protected set; } = true;
        Queue<Player> turnQueue = new Queue<Player>();

        public void BattleSystem(Player player, Player enemy, Map_.Map map)
        {
            int count = 0;
            if (player.MonsterInventory.GetMonster(0).Hp <= 0 && player.MonsterInventory.Count > 1)
                player.MonsterInventory.ChangeMonster();
            for (int i = 0; i < player.MonsterInventory.Count; i++)
            {
                if (player.MonsterInventory.GetMonster(i).IsDead == true)
                    count++;
                if (count == player.MonsterInventory.Count)
                {
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("우리가 졌다...");
                    Thread.Sleep(1000);
                    map.MapChange();
                    player.PlayerPosReset();
                    QuitBattle();
                }
            }
            count = 0; 
            if (enemy.MonsterInventory.GetMonster(0).Hp <= 0 && enemy.MonsterInventory.Count > 1)
                enemy.MonsterInventory.ChangeMonster();
            for (int i = 0; i < enemy.MonsterInventory.Count; i++)
            {
                if (enemy.MonsterInventory.GetMonster(i).IsDead == true)
                    count++;
                if (count == enemy.MonsterInventory.Count)
                {
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("우리가 이겼다!");
                    Console.WriteLine("LevelUp!\n+100 Gold");
                    Thread.Sleep(1000);
                    if (enemy.PlayerID == 3)
                        map.IsBossDead();
                    player.GetGold(100);
                    player.MonsterInventory.AllLevelUp();
                    QuitBattle();
                }
            }
            if (enemy.MonsterInventory.GetMonster(0).Type == ElementType.Fire)
            {
                for (int y = 2; y < 5; y++)
                {
                    Console.SetCursorPosition(39, y);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (enemy.MonsterInventory.GetMonster(0).Type == ElementType.Water)
            {
                for (int y = 2; y < 5; y++)
                {
                    Console.SetCursorPosition(39, y);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (enemy.MonsterInventory.GetMonster(0).Type == ElementType.Grass)
            {
                for (int y = 2; y < 5; y++)
                {
                    Console.SetCursorPosition(39, y);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (enemy.MonsterInventory.GetMonster(0).Type == ElementType.Electric)
            {
                for (int y = 2; y < 5; y++)
                {
                    Console.SetCursorPosition(39, y);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(15, 6);
            Console.Write($"{enemy.Name}의 ");
            enemy.MonsterInventory.GetMonster(0).PrintInfo();
            Console.SetCursorPosition(15, 7);
            enemy.ShowPlayerMonstersInfo();

            if (player.MonsterInventory.GetMonster(0).Type == ElementType.Fire)
            {
                for (int y = 13; y < 16; y++)
                {
                    Console.SetCursorPosition(5, y);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (player.MonsterInventory.GetMonster(0).Type == ElementType.Water)
            {
                for (int y = 13; y < 16; y++)
                {
                    Console.SetCursorPosition(5, y);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (player.MonsterInventory.GetMonster(0).Type == ElementType.Grass)
            {
                for (int y = 13; y < 16; y++)
                {
                    Console.SetCursorPosition(5, y);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            else if (player.MonsterInventory.GetMonster(0).Type == ElementType.Electric)
            {
                for (int y = 13; y < 16; y++)
                {
                    Console.SetCursorPosition(5, y);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write("      ");
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(2, 17);
            Console.Write($"{player.Name}의 ");
            player.MonsterInventory.GetMonster(0).PrintInfo();
            Console.SetCursorPosition(2, 18);
            player.ShowPlayerMonstersInfo();

            if (turnQueue.Peek().PlayerID == player.PlayerID)
            {
                while (true)
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                    double inputNum = char.GetNumericValue(consoleKey.KeyChar);
                    Console.SetCursorPosition(0, 26);

                    if (player.MonsterInventory.GetMonster(0).Hp > 0)
                    {
                        if ((int)inputNum == 1)
                        {
                            player.MonsterInventory.GetMonster(0).Attack(enemy.MonsterInventory.GetMonster(0));
                            Thread.Sleep(1000);
                            TurnEnd();
                            break;
                        }
                        else if ((int)inputNum == 2)
                        {
                            player.MonsterInventory.GetMonster(0).SpecialAttack(enemy.MonsterInventory.GetMonster(0));
                            Thread.Sleep(1000);
                            TurnEnd();
                            break;
                        }
                        else if ((int)inputNum == 3)
                        {
                            if (player.Inventory.CountItem(ItemType.MonsterBall) > 0)
                            {
                                if (enemy.MonsterInventory.GetMonster(0).Hp > enemy.MonsterInventory.GetMonster(0).MaxHp / 2)
                                {
                                    if (player.Inventory.SelectItem("몬스터 볼") is IUsable usableItem)
                                        usableItem.UseItem();
                                    Console.WriteLine("적의 체력이 너무 많다!\t 실패");
                                    Thread.Sleep(1000);
                                    TurnEnd();
                                    break;
                                }

                                else
                                {
                                    if (player.Inventory.SelectItem("몬스터 볼") is IUsable usableItem)
                                        usableItem.UseItem();
                                    player.MonsterInventory.AddMonster(enemy.MonsterInventory.GetMonster(0));
                                    Console.WriteLine($"{enemy.MonsterInventory.GetMonster(0).Name}을(를) 포획했다!");
                                    player.Inventory.RemoveItem("몬스터 볼");
                                    QuitBattle();
                                    Thread.Sleep(1000);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("몬스터 볼이 부족하다!\t 실패");
                                Thread.Sleep(1000);
                                TurnEnd();
                                break;
                            }
                        }
                        else if ((int)inputNum == 4)
                        {
                            player.MonsterInventory.ShowMonster();
                            Console.Write("바꿀 몬스터 번호를 입력해주세요: ");
                            if (int.TryParse(Console.ReadLine(), out int idx_))
                            {
                                if (idx_ <= player.MonsterInventory.Count)
                                    player.MonsterInventory.ChangeSelectMonster(idx_ - 1);
                                else
                                {
                                    Console.WriteLine("해당 번호의 몬스터가 없습니다.");
                                    Thread.Sleep(1000);
                                }
                            }
                            TurnEnd();
                            break;
                        }
                        else if ((int)inputNum == 5)
                        {
                            Console.WriteLine("도망쳤다!");
                            Thread.Sleep(1000);
                            QuitBattle();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Thread.Sleep(1000);
                        }
                    }
                }
                turnQueue.Enqueue(player);
                turnQueue.Dequeue();
                
            }
            else
            {
                Console.SetCursorPosition(0, 26);
                if (enemy.MonsterInventory.GetMonster(0).Hp > 0)
                {
                    Random randNum = new Random();
                    int result = randNum.Next(0, 10);
                    if (result % 3 == 0)
                    {
                        enemy.MonsterInventory.GetMonster(0).Attack(player.MonsterInventory.GetMonster(0));
                        Thread.Sleep(1000);
                        TurnEnd();
                    }
                    else if (result % 3 == 1)
                    {
                        enemy.MonsterInventory.GetMonster(0).Attack(player.MonsterInventory.GetMonster(0));
                        Thread.Sleep(1000);
                        TurnEnd();
                    }
                    else
                    {
                        Console.WriteLine($"{enemy.MonsterInventory.GetMonster(0).Name}이(가) 한 턴 쉬었다!");
                        Thread.Sleep(1000);
                        TurnEnd();
                    }
                }

                turnQueue.Enqueue(enemy);
                turnQueue.Dequeue();
            }
            
        }
        public void SetTurn(Player player, Player enemy)
        {
            turnQueue.Clear();
            turnQueue.Enqueue(player);
            turnQueue.Enqueue(enemy);
        }
        public void EnterBattle()
        {
            IsBattle = true;
            IsMyTurn = true;
        }
        public void QuitBattle()
        {
            IsBattle = false;
        }
        public void TurnEnd()
        {
            IsMyTurn = !IsMyTurn;
        }
        public void EnterBoss()
        {
            IsBoss = true;
        }
        public void EnterGrass()
        {
            IsBoss = false;
        }
    }
}
