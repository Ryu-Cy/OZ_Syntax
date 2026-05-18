namespace ConsoleApp_Day12
{   /*************************************************
    [인스턴스 메서드]
    - 클래스의 인스턴스를 생성한 후에 호출할 수 있는 메서드
    - 해당 상태를 변경하거나 참조 가능

    [정적 메서드(static)]
    - 객체를 생성하지 않고 클래스 이름을 통해 호출
    - 인스턴스 클래스 내부에 선언했어도 선언한 클래스 내부의 변수와 인스턴스 메서드들에 접근 불가능

    [정적 클래스(static)]
    - 공통된 기능을 제공하거나 공유 데이터를 관리할 때 사용
    - 인스턴스를 생성 불가능
    - 상속 불가능
    - 정적 변수와 정적 메서드를 포함     -> 클래스 단위에서 공유됨. 프로그램 실행 중 하나의 메모리 공간만 할당
    - 공통적으로 사용되는 기능(유틸리티, 설정, 수학 등)
    - 각 개체마다 다른 값이 필요하지 않고 하나의 값만 공유하면 되는 경우
    - 객체 없이 전역적인 접근이 필요한 경우

    [정적 클레스(static class) 사용의 경우]
    - 정적일 필요가 있는가?
    - 오직 기능만 제공하는가?
    *************************************************/
    class Car
    {
        private int num;
        // 인스턴스 메서드
        public void Start()
        {
            num = 10;
            Console.WriteLine($"{num}");
        }
    }
    class Calculator
    {
        int a = 1;
        // 인스턴스 메서드
        public void Print() { }
        // 정적 메서드
        public static int Add( int a , int b) {  return a + b; }
    }
    class GameUtils
    {
        public static void PrintMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    static class MathUtils
    {
        //int = 1;  -> 인스턴스 변수 허용x
        //public void Print() { }   -> 인스턴스 메서드 허용x
        public static double Pi = 3.141592;
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static double CircleArea(double radius)
        {
            return Pi * radius * radius;
        }
    }
    internal class Program02
    {
        static void Main()
        {
            Console.WriteLine($"{MathUtils.Pi}");
            Console.WriteLine($"{MathUtils.Add(10, 20)}");
            Console.WriteLine($"{MathUtils.CircleArea(5)}");
        }
    }
}
