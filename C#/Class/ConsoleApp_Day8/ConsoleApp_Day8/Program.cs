/*************************************
[형변환(Casting)]
- 데이터를 선언한 자료형에 맞는 형태로 변환하는 작업
- 다른 자료형의 데이터를 저장하기 위해선 형변환 과정을 거쳐야 한다.
- 이 과정에서 보관할 수 없는 데이터는 버려진다(손실된다).
- 서로 다른 자료형끼린즌 바로 대입이 불가능하기 때문에 형변환이 필요하다.

[명시적 형변환]
- 변환할 데이터의 앞에 변환할 자료형을 괄호안에 넣어 형변환을 진행

[묵시적 형변환]
- 변수에 데이터를 넣는 과정에서 자료형이 더 큰 범위로 표현하는 경우 자동으로 형변환을 진행

[문자열 형변환]
- 단순형변환 불가
- 각 자료형 Parse, TryParse를 이용하여 문자열에서 자료형으로 변환
- Parse     : 변환이 실패할 경우 예외를 발생시킨다.
- TryParse  : 변환이 실패할 경우 false반환하고 예외를 발생시키지 않고, 성공할 경우 true를 반환하고 변환된 값을 out매개변수로 변환
- 변환이 실패할 가능성이 있다면 TyrParse를 사용하는 것이 권장

=====================================

[Convert Class]
- 다양한 자료형 간의 변환을 지원하는 클래스
- Convert.ToString  : 숫자 -> 문자열
- Convert.ToInt32   : 숫자 -> 정수
- Convert.ToDouble  : 숫자 -> 실수
- Convert.TpChar    : 문자열 -> 문자
*************************************/

//int, byte, long, unit, sbyte, short, ulong, float, double, decimal

//char, string

//bool

using System.Data.Common;
using System.Formats.Tar;

namespace ConsoleApp_Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int a = 1;
            float b = 2.5f;
            Console.WriteLine("Hello, World!");
            Console.WriteLine(a);

            // 명시적 형변환
            int intValue = (int)1.2;
            Console.WriteLine($"int 변수에 double형 변수 1.2를 형변환 해 나온 데이터는 {intValue}이다.");
            // 묵시적 형변환
            int num = 12342;
            long longValue = num;
            */

            /*
            int i = 1234;
            double d = 12.34;
            d = i;

            Console.WriteLine($"int {i}를 double로 묵시적 형변환한 결과는 {d}입니다.");
            d = 12.34;
            i = (int)d;
            Console.WriteLine($"double {d}를 int로 명시적 형변환한 결과는 {i}입니다.");

            string s = "";
            s = Convert.ToString(d);
            Console.WriteLine($"double {d}를 sring으로 변환한 결과는 {s}입니다.");
            */

            /*
            string numberStr = "123";
            int number = int.Parse(numberStr);
            Console.WriteLine(number);

            int value = int.Parse("142");
            Console.WriteLine(value);

            int testValue;
            bool fail = int.TryParse("abc", out testValue);
            Console.WriteLine($"변환 실패 시 \nfail = {fail}, value = {testValue}");
            bool success = int.TryParse("123", out testValue);
            Console.WriteLine($"변환 성공 시 \nfail = {success}, value = {testValue}");
            */

            Console.WriteLine("이름을 입력해주세요.");
            string? name = Console.ReadLine();
            Console.WriteLine("안녕하세요. " + name + "입니다.");

            Console.WriteLine("숫자를 입력해주세요.");
            string num = Console.ReadLine()!;
            int.Parse(num);
            Console.WriteLine(num);

            Console.WriteLine("숫자를 입력해주세요.");
            string num1 = Console.ReadLine()??"";
            int.TryParse(num1, out int num2);
            Console.WriteLine(num1 + num2);
        }
    }
}
