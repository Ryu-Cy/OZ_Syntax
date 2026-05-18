using Game1;
using System.Net.Mail;
using GameCharacter = Game2.Characters.Warrior;

namespace ConsoleApp_Day14
{   /**************************************************
    [namespace]
    - 클래스, 인터페이스, 구조체, 열거형 등을 그룹화 해주는 역할
    - 이름 충돌 방지
    - 코드 가독성 향상
    - 프로젝트 구조 정리
    - 대규모 프로젝트 관리에 매우 중요
    **************************************************/
    internal class Program03
    {
        static void Main()
        {
            Game.Character player = new Game.Character();
            player.Name = "전사";
            player.Print();
            Game1.Character player1 = new Game1.Character();
            player1.Name = "기사";
            player1.Print();
            Game2.Characters.Warrior warrior = new Game2.Characters.Warrior();
            warrior.Attack();
            GameCharacter warrior1 = new GameCharacter();
            warrior1.Attack();
        }
    }
}
namespace Game
{
    class Character
    {
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine($"Game 캐릭터 이름: {Name}");
        }
    }
}
namespace Game1
{
    class Character
    {
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine($"Game1 캐릭터 이름: {Name}");
        }
    }
}
namespace Game2
{
    namespace Characters
    {
        class Warrior
        {
            public void Attack()
            {
                Console.WriteLine("공격");
            }
        }
    }
}
namespace Game.Player
{

}
namespace Game.Monster
{

}
namespace Game.Ui
{

}
namespace Game.Utils
{
    static class MathTool
    {
        public static int Add(in int x, in int y)
        { return x + y; }
        public static int Multiply(in int x, in int y)
        { return x * y; }
    }
    static class StringTool
    {
        public static string ToUpper(string str)
        { return str.ToUpper(); }
    }
}
namespace PlayerSystem
{
    enum State
    {
        Idle, Attack, AttackStart, AttackEnd
    }
}