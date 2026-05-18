
namespace ConsoleApp_Day9
{
    /**********************************************
    [배열(Array)]
    - 배열 이름(주소) > 스택, 배열 내용(실제 데이터) > 힙
    - Array 클래스를 통해 구현되어 있어 내부 기능 사용 가능

    [foreach]
    - C#에서 배열이나 컬렉션의 모든 요소를 처음부터 끝까지 하나씩 순회할 때 사용
    - 배열 안의 데이터 수정 불가능
    - 반복 횟수에 의한 오류 방지 가능
    **********************************************/
    internal class Program04
    {
        static void Main()
        {
            /*
            int[] scores = new int[5];
            scores[0] = 1;
            scores[1] = 2;
            scores[2] = 3;
            scores[3] = 4;
            scores[4] = 5;
            Console.WriteLine(scores.Length);
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
            foreach (int i in scores)
            {
                Console.WriteLine(i);
            }
            */

            /*
            // 배열 초기화 방식
            int[] arr1;
            arr1 = new int[5];
            int[] arr2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] arr3 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr4 = { 1, 2, 3, 4, 5 };
            */

            /*
            int[] array = { 1, 2, 3, 4, 5 };
            int length = array.Length;

            int max = array.Max();
            int min = array.Min();
            Console.WriteLine(max);

            Array.Sort(array);
            */


            int[,] map = new int[2, 3];
            map[0, 0] = 1;
            map[0, 1] = 2;
            map[0, 2] = 3;
            map[1, 0] = 4;
            map[1, 1] = 5;
            map[1, 2] = 6;

            for (int i = 0; i < map.GetLength(0); i++)  // 행의 길이
            {
                for (int j = 0; j < map.GetLength(1); j++)  // 열의 길이
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
