namespace ConsoleApp_Day22
{   /***********************************************
    [람다식 (Lamda Expression)]
    - 메서드를 짧게 작성할 수 있음
    - 델리게이트 기반으로 동작
    - Func, Action, Predicate, Event, LINQ 등과 함께 사용된다.
    - 한 줄이면 {}와 return을 생략할 수 있다.
     ㄴ 반대로 여러 줄이면 {}와 return이 필요하다.
    - Unity에서도 자주 볼 수 있다.

    [주의사항/특징]
    - 너무 긴 코드는 람다식으로 만들지 않는 것이 좋다.
    - 재사용을 해야한다면 메서드가 더 좋다.
    - 짧은 조건식, 계산식, 이벤트 처리에는 람다식이 편하다.
    - LINQ와 함꼐 쓰면 데이터 검색, 필터, 정렬 코드가 잛아진다.
    ***********************************************/
    internal class Program
    {
        static bool isEven(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {
            Func<int, int, int> add = (x, y) => x + y;
            int result = 0;

            Func<int, int> doubleValue = x => x * 2;

            Func<int, int, int> add1 = (x, y) =>
            {
                Console.WriteLine("숫자를 더한다");
                int result = 0;
                return result;
            };

            Action<string> print = message =>
            {
                Console.WriteLine(message);
            };
            print("안녕하세요");
            Action<string> print2 = message => Console.WriteLine(message);

            Action attack = () =>
            {
                Console.WriteLine("공격");
            };


            Predicate<int> isEven = number => number % 2 == 0;
            Console.WriteLine("10은 짝수냐? " + isEven(10));
            Console.WriteLine("7은 짝수냐? " + isEven(7));



        }
    }
}
