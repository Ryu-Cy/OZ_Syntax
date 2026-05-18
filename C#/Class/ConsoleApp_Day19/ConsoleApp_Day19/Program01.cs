namespace ConsoleApp_Day19
{   /***********************************************
    [Stack 에시]
    - 뒤로 가기
    ***********************************************/
    internal class Program01
    {
        static void Main()
        {
            int width = 10;
            int height = 10;

            int playerX = 0;
            int playerY = 0;

            Stack<string> pathStack = new Stack<string>();

            pathStack.Push($"{playerX},{playerY}");

            while (true)
            {
                Console.Clear();
                DrawMap(width, height, playerX, playerY);
                Console.WriteLine();
                Console.WriteLine("이동: W A S D");
                Console.WriteLine("뒤로 가기: B");
                Console.WriteLine("종료: Q");

                Console.WriteLine($"현재 위치: {playerX}, {playerY}");
                Console.WriteLine($"이동 횟수: {pathStack.Count}");
                Console.WriteLine("==========최근 이동 기록==========");
                int showCount = 0;
                foreach (string path in pathStack)
                {
                    Console.WriteLine(path);
                    showCount++;

                    if (showCount >= 5)
                    {
                        break;
                    }
                }

                Console.WriteLine();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = char.ToUpper(keyInfo.KeyChar);
                int prevX = playerX;
                int prevY = playerY;
                if (input == 'W')
                {
                    playerY--;
                }
                else if (input == 'S')
                {
                    playerY++;
                }
                else if (input == 'D')
                {
                    playerX++;
                }
                else if (input == 'A')
                {
                    playerX--;
                }
                else if (input == 'B')
                {
                    if (pathStack.Count > 1)
                    {
                        pathStack.Pop();
                        string previous = pathStack.Peek();
                        string[] pos = previous.Split(',');
                        playerX = int.Parse(pos[0]);
                        playerY = int.Parse(pos[1]);
                    }
                }
                else if (input == 'Q')
                {
                    break;
                }

                if (playerX < 0)
                    playerX = 0;
                if (playerY < 0)
                    playerY = 0;
                if (playerX >= width)
                    playerX = width - 1;
                if (playerY >= height)
                    playerY = height - 1;

                if (prevX != playerX || prevY != playerY)
                    pathStack.Push($"{playerX},{playerY}");
            }

        }
        static void DrawMap(int width ,int height, int playerX, int playerY)
        {
            for (int y = 0; y <  height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
