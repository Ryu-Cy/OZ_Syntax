using System.Diagnostics;

namespace ConsoleApp_Day9
{
    /**********************************************
    [out]
    - 값을 반환하기 위한 참조 전달 방식
    - 변수의 값을 복사하지 않고 참조를 전달
    - 여러 개의 값을 반환할 때 주로 사용
    - 메소드 내부에서 반드시 값을 할당해야한다.
    - ref와는 다르게 변수를 초기화해두지 않아도 사용 가능
    **********************************************/
    internal class Program02
    {
        static void Main()
        {
            int result;
            GetNumber(out result);
            Console.WriteLine(result);
            Console.WriteLine();

            int remainder;
            Divide(10, 3, out result, out remainder);
            Console.WriteLine("몫: " + result);
            Console.WriteLine("나머지: " + remainder);
            Console.WriteLine();

            int number;
            bool success = TryParse("123", out number);
            if (success)
            {
                Console.WriteLine("변환 성공");
            }
            else if (!success)
            {
                Console.WriteLine("변환 실패");
            }
        }
        static void GetNumber(out int number)
        {
            number = 100;
        }
        static void Divide(int a, int b, out int result, out int remainder)
        {
            result = a / b;
            remainder = a % b;
        }
        static bool TryParse(string input, out int result)
        {
            result = 0;
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
                return false;
        }
    }
}
