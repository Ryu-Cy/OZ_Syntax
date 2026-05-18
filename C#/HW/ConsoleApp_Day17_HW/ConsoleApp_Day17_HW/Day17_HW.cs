using System.Threading.Tasks.Sources;

namespace ConsoleApp_Day17_HW
{
    internal class Day17_HW
    {
        static void PrintList(List<int> list)
        {
            Console.Write("[ ");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void PrintList(List<string> list)
        {
            Console.Write("[ ");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // 과제 1
            // 과제 1-1. 평균값 구하기
            Console.WriteLine("===== 1-1. 평균값 구하기 =====");
            List<int> numbers = new List<int>();
            double average = 0.0;
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i + 1);
            }
            PrintList(numbers);
            average = MathUtils.GetAverage(numbers);
            Console.WriteLine($"평균: {average.ToString("0.0")}");
            numbers.Clear();
            Console.WriteLine();

            for (int i = 0; i < 11; i++)
            {
                numbers.Add(i + 89);
            }
            PrintList(numbers);
            average = MathUtils.GetAverage(numbers);
            Console.WriteLine($"평균: {average.ToString("0.0")}");
            numbers.Clear();
            Console.WriteLine();

            // 과제 1-2. 배열 두 배 만들기
            Console.WriteLine("===== 1-2. 배열 두 배 만들기 =====");
            List<int> tmp = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                numbers.Add(i + 1);
            }
            tmp = MathUtils.GetDoubleList(numbers);
            PrintList(numbers);
            PrintList(tmp);
            numbers.Clear();
            tmp.Clear();
            Console.WriteLine();

            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(100);
            numbers.Add(-99);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            tmp = MathUtils.GetDoubleList(numbers);
            PrintList(numbers);
            PrintList(tmp);
            numbers.Clear();
            tmp.Clear();
            Console.WriteLine();

            // 1-3. 중복된 숫자 개수 구하기
            Console.WriteLine("===== 1-3. 중복된 숫자 개수 구하기 =====");
            int result = 0;
            numbers.Add(1);
            for (int i = 0; i < 5; i++)
            {
                numbers.Add(i + 1);
            }
            result = MathUtils.GetDuplicateCount(numbers, 1);
            PrintList(numbers);
            Console.WriteLine($"1 개수: {result}");
            numbers.Clear();
            Console.WriteLine();

            numbers.Add(0);
            for (int i = 0; i < 3; i++)
            {
                numbers.Add(i + 2);
            }
            PrintList(numbers);
            result = MathUtils.GetDuplicateCount(numbers, 1);
            Console.WriteLine($"1 개수: {result}");
            numbers.Clear();
            Console.WriteLine();

            Console.WriteLine("\n=================================================================\n");
            // 과제 2
            // 과제 2-1
            Console.WriteLine("===== 2-1. Max, Min값 지우기 =====");
            for (int i = 0; i < 5; i++)
            {
                numbers.Add(i + 1);
            }
            PrintList(numbers);
            PrintList(MathUtilsChallenge.DeleteMaxMin(numbers));
            numbers.Clear();
            Console.WriteLine();

            numbers.Add(10);
            numbers.Add(1);
            numbers.Add(10);
            numbers.Add(5);
            numbers.Add(2);
            PrintList(numbers);
            PrintList(MathUtilsChallenge.DeleteMaxMin(numbers));
            numbers.Clear();
            Console.WriteLine();

            // 과제 2-2
            Console.WriteLine("===== 2-2. 홀수만 골라 정렬 =====");
            numbers.Add(4);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(8);
            numbers.Add(5);
            numbers.Add(3);
            tmp = MathUtilsChallenge.GetOddSort(numbers);
            PrintList(numbers);
            PrintList(tmp);
            numbers.Clear();
            tmp.Clear();
            Console.WriteLine();

            numbers.Add(10);
            numbers.Add(2);
            numbers.Add(6);
            numbers.Add(4);
            tmp = MathUtilsChallenge.GetOddSort(numbers);
            PrintList(numbers);
            PrintList(tmp);
            numbers.Clear();
            tmp.Clear();
            Console.WriteLine();

            // 과제 2-3
            Console.WriteLine("===== 2-3. 특정 점수 이상의 이름 찾기 =====");
            List<string> names = new List<string>();
            List<string> resultNames = new List<string>();
            names.Add("민수"); numbers.Add(75);
            names.Add("철수"); numbers.Add(85);
            names.Add("영희"); numbers.Add(90);
            PrintList(names);
            PrintList(numbers);
            resultNames = MathUtilsChallenge.FindName(names, numbers);
            PrintList(resultNames);
            numbers.Clear();
            names.Clear();
            resultNames.Clear();
            Console.WriteLine();

            names.Add("A"); numbers.Add(10);
            names.Add("B"); numbers.Add(20);
            names.Add("C"); numbers.Add(30);
            PrintList(names);
            PrintList(numbers);
            resultNames = MathUtilsChallenge.FindName(names, numbers);
            PrintList(resultNames);
            numbers.Clear();
            names.Clear();
            resultNames.Clear();
        }
    }
}
