namespace ConsoleApp_Day19
{   /***********************************************
    [Stack]
    - Last In First Out : 후입선출
    - 즉, 마지막에 들어간 데이터가 먼저 나온다.

    [top]
    - Stack의 가장 위 위치
    - 가장 최근에 추가된 데이터

    [키워드]
    Push : 항상 top에 데이터 추가
    pop : 항상 top에서 데이터 제거
    peek : top 데이터를 제거하지 않고 확인
    contains : 특정 데이터 포함 여부 확인
    count : 현재 데이터 개수
    clear : 데이터 제거

    [ex]
    실행 취소(Undo), 뒤로가기, DFS, 역순처리
    ***********************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("첫 번째");
            stack.Push("두 번째");
            stack.Push("세 번째");
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);

            Stack<string> inventory = new Stack<string>();
            inventory.Push("포션");
            inventory.Push("방패");
            inventory.Push("검");
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
