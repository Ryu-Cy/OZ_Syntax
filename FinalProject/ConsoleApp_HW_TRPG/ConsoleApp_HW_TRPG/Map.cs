using Game.Enums;
using Game.Monster_;
using Game.Player_;
using System.ComponentModel;

namespace Game.Map_
{
    class Map
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public FieldType[,] mapArr { get; protected set; } = new FieldType[25, 25];
        public int MapNum { get; protected set; }
        public bool IsBossAlive { get; protected set; }
        public Map()
        {
            Width = 25;
            Height = 25;
            StartMap(Width, Height);
            MapNum = 1;
            IsBossAlive = true;
        }
        // 필드 초기화
        public void StartMap(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    mapArr[x, y] = FieldType.Ground;
                    if (y <= 5 && x >= 15)
                        mapArr[x, y] = FieldType.Grass;
                    if (y >= 10 && y <= 12
                        && x == 24)
                        mapArr[x, y] = FieldType.Portal;
                    if (y >= 18 && y <= 20
                        && x >= 5 && x <= 8)
                        mapArr[x, y] = FieldType.Shop;
                }
            }
        }
        public void BossMap(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    mapArr[x, y] = FieldType.Ground;
                    if (y >= 10 && y <= 12
                        && x == 0)
                        mapArr[x, y] = FieldType.Portal;
                }
            }
            if (IsBossAlive)
            {
                mapArr[15, 15] = FieldType.Boss;
            }
        }
        public void ShopMap(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    mapArr[x, y] = FieldType.Ground;
                    if (y >= 10 && y <= 12
                        && x == 0)
                        mapArr[x, y] = FieldType.Portal;
                }
            }
            mapArr[10, 10] = FieldType.Npc;
        }
        // 필드 업데이트
        public void UpdateField(int width, int height, int playerX, int playerY)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{"P "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Ground)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{"  "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Grass)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write($"{"  "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Shop)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write($"{"  "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Portal)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write($"{"  "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Boss)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write($"{"B "}");
                        Console.ResetColor();
                    }
                    else if (mapArr[x, y] == FieldType.Npc)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"{"N "}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("=========================");
            Console.WriteLine("I. 인벤토리 확인");
            Console.WriteLine("Q. 종료");
        }
        public void UpdateBattleField(int width, int height, Monster my, Monster enemy)
        {
            for (int y = 0; y < height - 5; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{"  "}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("어떤 행동을 하겠습니까?");
            Console.WriteLine("1. 일반 공격");
            Console.WriteLine("2. 특수 공격");
            Console.WriteLine("3. 포획하기");
            Console.WriteLine("4. 몬스터 변경");
            Console.WriteLine("5. 도망치기");

        }
        public void MapChange()
        {
            if (MapNum == 1)
            {
                BossMap(Width, Height);
                MapNum = 2;
            }
            else if (MapNum == 2)
            {
                StartMap(Width, Height);
                MapNum = 1;
            }
            else if (MapNum == 3)
            {
                StartMap(Width, Height);
                MapNum = 1;
            }
        }
        public void MapChange(int num)
        {
            if (num == 1)
            {
                StartMap(Width, Height);
            }
            else if (num == 2)
            {
                BossMap(Width, Height);
            }
            else if (num == 3)
            {
                ShopMap(Width, Height);
            }
            MapNum = num;
        }
        // 이 메서드와 변수는 Map에 들어올 내용이 아닌 것 같은데
        public void IsBossDead()
        {
            IsBossAlive = false;
        }
    }
}
