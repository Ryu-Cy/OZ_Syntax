using System.Diagnostics;

namespace ConsoleApp_Day9
{
    /**********************************************
    [ref]
    - 값을 변경할 수 있는 참조 전달 방식
    - 변수의 값을 복사하는 것이 아니라 메모리 주소를 전달
    - 메소드에서 값을 변경하면 호출한 곳에도 변경이 반영된다.
    - 메소드 내부에서 값을 읽고 수정할 수 있다.
    - 호출하는 쪽에서 반드시 초기화된 변수를 전달해야한다.
    - 원본 데이터를 직접 수정해야할 때 사용한다.
    **********************************************/
    internal class Program01
    {
        static void Main()
        {
            int playerHp = 100;
            Console.WriteLine("플레이어의 현재 체력: " + playerHp);
            TakeDamage(ref playerHp, 30);
            Console.WriteLine("플레이어의 현재 체력: " + playerHp);
            Console.WriteLine();

            int left = 10;
            int right = 20;
            Console.WriteLine("스왑 전");
            Console.WriteLine("Left: " + left + " Right: " + right);
            Swap(ref left, ref right);
            Console.WriteLine("스왑 후");
            Console.WriteLine("Left: " + left + " Right: " + right);

        }
        static void TakeDamage(ref int hp, int dmg)
        {
            hp -= dmg;
            if (hp < 0)
                hp = 0;
        }
        static void Swap(ref int left, ref int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }
    }
}
