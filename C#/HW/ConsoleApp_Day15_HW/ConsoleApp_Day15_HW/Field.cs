using Game.Enums;
using System.Net.Sockets;

namespace Game.Field
{   /************************************************
    [Field]
    - 오목판 구현
    ************************************************/
    class Field
    {
        public int Row { get; set; }
        public int Col { get; set; }
        private string[,] gomokuArr = new string[15 + 1, 15 + 1];
        public StoneType[,] stoneArr = new StoneType[15 + 1, 15 + 1];
        // 필드 초기화
        public void StartField()
        {
            for (int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 16 ; j++)
                {
                    stoneArr[i, j] = StoneType.None;
                }
            }
        }
        // 필드 업데이트
        public void UpdateField()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (stoneArr[i, j] == StoneType.Black)
                        gomokuArr[i, j] = "●";
                    else if (stoneArr[i, j] == StoneType.White)
                        gomokuArr[i, j] = "○";
                    else if (stoneArr[i, j] == StoneType.None)
                        gomokuArr[i, j] = "▣";
                }
            }
            for (int i = 1; i < 16; i++)
            {
                gomokuArr[i, 0] = i.ToString();
            }
            for (int i = 1; i < 16; i++)
            {
                gomokuArr[0, i] = i.ToString();
            }
            gomokuArr[0, 0] = " ";
        }
        // 필드 출력
        public void ShowField()
        {
            Console.Clear();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (stoneArr[i, j] == StoneType.Black)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (stoneArr[i, j] == StoneType.White)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ResetColor();
                    Console.Write($"{gomokuArr[i, j], 2}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
