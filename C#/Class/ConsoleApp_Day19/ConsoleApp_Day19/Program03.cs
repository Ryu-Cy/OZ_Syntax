namespace ConsoleApp_Day19
{   /***********************************************
    [HashSet]
    - 중복을 허용하지 않는다.
    - 내부적으로 해시 기반 구조를 사용
     ㄴ 검색이 빠름

    사용처
    - 중복 방지가 필요할 때
    - 빠른 검색이 필요할 때
    - 방문 체크
    - 길 찾기 알고리즘(A*)
    - 이미 먹은 아이템 체크, 이미 맞은 적 체크, 상태이상 중복 방지

    [키워드]
    - Add : 데이터 추가
    - Remove : 데이터 제거
    - Contains : 특정 데이터 확인
    - Count : 현재 데이터 개수
    - Clear : 데이터 전부 제거
    ***********************************************/
    internal class Program03
    {
        static void Main()
        {
            //HashSet<int> numbers = new HashSet<int>();
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(3); // 중복 저장x

            //foreach (int number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //Console.WriteLine($"{numbers.Contains(1)}");
            //Console.WriteLine($"{numbers.Contains(4)}");

            //numbers.Remove(1);

            int width = 10;
            int height = 10;

            int playerX = 0;
            int playerY = 0;

            HashSet<string> visitedTiles = new HashSet<string>();
            visitedTiles.Add($"{playerX},{playerY}");
            while ( true )
            {
                Console.Clear();
                DrawMap(width, height, playerX, playerY, visitedTiles);
                Console.WriteLine();

                Console.WriteLine("이동: W A S D\n");
                Console.WriteLine($"현재 위치: {playerX},{playerY}");
                Console.WriteLine($"방문한 칸 수: {visitedTiles.Count}");
                Console.WriteLine($"전체 칸 수: {width * height}\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = char.ToUpper(keyInfo.KeyChar);

                int prevX = playerX;
                int prevY = playerY;

                if (input == 'W') playerY--;
                else if (input == 'S') playerY++;
                else if (input == 'A') playerX--;
                else if (input == 'D') playerX++;
                else if (input == 'Q') break;
                else continue;

                if (playerX < 0 || playerX >= width ||
                    playerY < 0 || playerY >= height)
                {
                    playerX = prevX;
                    playerY = prevY;
                    continue;
                }

                string curPosition = $"{playerX},{playerY}";

                if (visitedTiles.Contains(curPosition))
                {
                    playerX = prevX;
                    playerY = prevY;
                    continue;
                }

                if (prevX != playerX || prevY != playerY)
                {
                    visitedTiles.Add(curPosition);
                }

                if (visitedTiles.Count == width * height)
                {
                    Console.Clear();
                    DrawMap(width, height, playerX, playerY, visitedTiles);
                    Console.WriteLine("모든 칸을 탐험했음");
                    break;
                }
            }
        }
        static void DrawMap(int width, int height, int playerX, int playerY, HashSet<string> visitedTiles)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string position = $"{x},{y}";
                    if (x == playerX &&  y == playerY)
                    {
                        Console.Write("P ");
                    }
                    else if (visitedTiles.Contains(position))
                    {
                        Console.Write("X ");
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
