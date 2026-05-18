using System.Diagnostics;

namespace ConsoleApp_Day9
{
    /**********************************************
    [메소드(Method)]
    - 형태 : [접근제한자][반환형(리턴타입)][메소드 이름](매개변수)
    - 같은 클래스 안에 있는 static 메소드는 이름으로 호출 가능
    - default값을 준 매개변수는 반드시 모든 일반 매개변수보다 뒤에 와야 한다.
    **********************************************/
    internal class Program
    {
        static void Print()
        {
            Console.WriteLine("Hi ~");
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void PrintInfo(string name = "NULL", int age = 0)
        {
            Console.WriteLine($"name: {name}, age: {age}");
        }
        static void PrintEnemyInfo(string name, int level = 1)
        {
            Console.WriteLine($"Enemy {name}, Level: {level}");
        }
        // static void PrintInfoTest(string name = "NULL", int age = 0, int number) { }
        static void Main(string[] args)
        {
            // 접근제한자 없이 함수 호출
            // Program p = new Program();
            // p.Print();            
            Print();    
            PrintMessage(Add(1, 2).ToString());
            PrintInfo();    // 메소드에 매개변수를 입력해두었기에 오류 x
            PrintEnemyInfo("Slime");   // 메소드에 level은 입력해두었기에 오류 x
            PrintEnemyInfo("Dragon", 99);
        }
    }
}
