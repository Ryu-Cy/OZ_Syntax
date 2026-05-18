using System.Net.NetworkInformation;

namespace ConsoleApp_Day9
{
    /**********************************************
    [in]
    - 읽기 전용 참조 전달 방식
    - 매소드 내부에서 값을 읽을 수 있지만, 수정은 불가능하다.
    - 값 타입을 전달할 때(특히 덩치가 큰 구조체) 복사비용을 줄일 수 있다.
    - 값 변경을 막고싶을 때 사용
    **********************************************/
    internal class Program03
    {
        struct Player
        {
            public int hp;
            public int attackPower;

        }
        static void Main()
        {
            int number = 10;
            Print(number);
            Console.WriteLine();

            Player player = new Player();
            player.hp = 100;
            player.attackPower = 10;
            PrintPlayer(in player);
        }
        static void Print(in int num)
        {
            Console.WriteLine(num);
        }
        static void PrintPlayer(in Player player)
        {
            Console.WriteLine("Player Hp: " + player.hp);
            Console.WriteLine("Player AttackPowet: " + player.attackPower);
        }
    }
}
