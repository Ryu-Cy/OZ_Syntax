using Game.Enums;
using Game.Player;
using Game.Field;
using System;
using System.Threading;

namespace Omok
{
    internal class MainGame
    {
        private Player playerB = new Player("Black", StoneType.Black);
        private Player playerW = new Player("White", StoneType.White);
        private Field field = new Field();
        private bool turn = true;
        private bool isPlayed = true;
        private int[] tempArr = new int[3] { 0, 0, 0};
        private int[] tempArr1 = new int[3] { 0, 0, 0 };
        private int[] tempArr2 = new int[3] { 0, 0, 0 };
        private int[] tempArr3 = new int[3] { 0, 0, 0 };

        public void Run()
        {
            field.StartField();
            while (isPlayed)
            {
                field.UpdateField();
                field.ShowField();

                if (turn)
                    SetStone(playerB);
                else
                    SetStone(playerW);
            }
        }

        public void SetStone(Player p)
        {
            bool isStoneSet = true;

            while (isStoneSet)
            {
                Console.SetCursorPosition(field.Row * 2 + 2, field.Col + 1);
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow: if (field.Col > 0) 
                            field.Col--; 
                        break;
                    case ConsoleKey.DownArrow: if (field.Col < 14) 
                            field.Col++; 
                        break;
                    case ConsoleKey.LeftArrow: if (field.Row > 0) 
                            field.Row--; 
                        break;
                    case ConsoleKey.RightArrow: if (field.Row < 14) 
                            field.Row++; 
                        break;

                    case ConsoleKey.Spacebar:
                        int y = field.Col + 1;      // 세로 인덱스
                        int x = field.Row + 1;      // 가로 인덱스

                        if (field.stoneArr[y, x] != StoneType.None)
                        {
                            Console.SetCursorPosition(0, 19);
                            Console.WriteLine($"이미 돌이 있습니다!");
                            break;
                        }

                        field.stoneArr[y, x] = p.Type;

                        if (CheckThreeStone(y, x, p))
                        {
                            field.stoneArr[y, x] = StoneType.None;
                            field.UpdateField();
                            field.ShowField();
                            Console.SetCursorPosition(0, 19);
                            Console.WriteLine($"3-3은 금지입니다!");
                            continue;
                        }
                        if (CheckStone(y, x, p))
                        {
                            field.UpdateField();
                            field.ShowField();
                            Console.SetCursorPosition(0, 19);
                            Console.WriteLine($"{p.Name} 승리!");
                            isPlayed = false;
                            isStoneSet = false;
                            return;
                        }

                        isStoneSet = false;
                        turn = !turn;
                        
                        break;
                }
            }
        }
        // 지난 번 빙고 과제에서 너무 무식하게 계산을 했던 기억과
        // 가위바위보에서 로직을 알면 줄을 획기적으로 줄일 수 있다는 것을 보고
        // 좋은 로직이 있는지 구글 검색을 해봤습니다.
        public bool CheckStone(int row, int col, Player p)
        {
            int[] dy = { 0, 1, 1, 1 };
            int[] dx = { 1, 0, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                int count = 1;
                count += CountStone(row, col, dy[i], dx[i], p);
                count += CountStone(row, col, -dy[i], -dx[i], p);

                if (count >= 5) return true;
            }
            return false;
        }
        public int CountStone(int row, int col, int dy, int dx, Player p)
        {
            int count = 0;
            int ny = row + dy;
            int nx = col + dx;

            // IsInside를 사용하여 인덱스 범위를 먼저 체크한 뒤 배열에 접근
            while (IsInside(ny, nx) && field.stoneArr[ny, nx] == p.Type)
            {
                count++;
                ny += dy;
                nx += dx;
            }
            return count;
        }
        public bool CheckThreeStone(int row, int col, Player p)
        {
            int[] dy = { 0, 1, 1, 1 };
            int[] dx = { 1, 0, 1, -1 };
            int three = 0;

            for (int i = 0; i < 4; i++)
            {
                int count = 1;
                count += CountStone(row, col, dy[i], dx[i], p);
                count += CountStone(row, col, -dy[i], -dx[i], p);

                if (count == 3)
                {
                    three++;
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[0], col + dx[0], dy[j], dx[j], p);
                        count1 += CountStone(row - dy[0], col - dx[0], -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[1], col + dx[1], dy[j], dx[j], p);
                        count1 += CountStone(row - dy[1], col - dx[1], -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[2], col + dx[2], dy[j], dx[j], p);
                        count1 += CountStone(row - dy[2], col - dx[2], -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[3], col + dx[3], dy[j], dx[j], p);
                        count1 += CountStone(row - dy[3], col - dx[3], -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[0]*2, col + dx[0]*2, dy[j], dx[j], p);
                        count1 += CountStone(row - dy[0]*2, col - dx[0]*2, -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[1]*2, col + dx[1]*2, dy[j], dx[j], p);
                        count1 += CountStone(row - dy[1]*2, col - dx[1]*2, -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[2]*2, col + dx[2]*2, dy[j], dx[j], p);
                        count1 += CountStone(row - dy[2]*2, col - dx[2]*2, -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int count1 = 1;
                        count1 += CountStone(row + dy[3]*2, col + dx[3]*2, dy[j], dx[j], p);
                        count1 += CountStone(row - dy[3]*2, col - dx[3]*2, -dy[j], -dx[j], p);
                        if (count1 >= 3)
                            three++;
                        if (three >= 2)
                            return true;
                    }
                }
            }
            return false;
        }
        // 그냥 위 카운트 메서드에 조건으로 내용 나열해도 됨.
        // 깔끔해보이기 위함.
        private bool IsInside(int row, int col)
        {
            // 배열 인덱스 1~15 범위 체크
            return row >= 1 && row <= 15 && col >= 1 && col <= 15;
        }
    }
}