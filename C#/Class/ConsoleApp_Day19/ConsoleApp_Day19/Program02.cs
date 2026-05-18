namespace ConsoleApp_Day19
{   /***********************************************
    [Queue]
    - First in First Out : 선입선출 
    - 즉, 먼저 들어간 데이터가 먼저 나온다.
    - 동적 배열 기반 원형큐 구조를 사용한다.
    - 즉, 끝에 도달했다면 앞쪽 공간을 재사용한다.
    
    front
    - 큐에서 가장 먼저 제거될 데이터 위치
    - Dequeue : Front 위치 데이터 제거
    - Peek : Front 위치 데이터 확인

    Rear
    - 큐에서 다음 데이터가 저장될 위치
    - Enqueue : Rear 위치에 데이터를 추가하고 Rear는 다음 인덱스로 이동

    [ex]
    BFS, 메시지 큐, 버프/스킬 순차적 처리, 작업 대기열, 이벤트 처리, ...


    [키워드]
    Enqueue : Queue의 뒤쪽(Rear)에 데이터 추가
    Dequeue : Queue의 앞쪽(Front)의 데이터 제거 후 반환
    Peek : Front 데이터 확인 (제거x)
    Count : 현재 데이터 개수
    Contains : 특정 데이터 포함 여부 확인
    Clear : 모든 데이터 제거


    [Stack vs Queue]
    - 
    ***********************************************/
    internal class Program02
    {
        static void Main()
        {
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue("Player1");
            //queue.Enqueue("Player2");
            //queue.Enqueue("Player3");

            //Console.WriteLine(queue.Peek());
            //Console.WriteLine(queue.Count);
            //Console.WriteLine();

            //while (queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}
            //Console.WriteLine(queue.Count);

            Queue<string> turnQueue = new Queue<string>();
            turnQueue.Enqueue("A");
            turnQueue.Enqueue("B");
            turnQueue.Enqueue("C");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== 턴 순서 =====");
                foreach (string character in turnQueue)
                {
                    Console.WriteLine(character);
                }
                Console.WriteLine();

                string curCharacter = turnQueue.Peek();
                Console.WriteLine($"{curCharacter}의 차례");

                Console.WriteLine("아무 키나 눌러라");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = char.ToUpper(keyInfo.KeyChar);
                if (input == 'Q')
                    break;
                string finishCharacter = turnQueue.Dequeue();
                Console.WriteLine($"{finishCharacter}의 행동이 끝났다.");

                turnQueue.Enqueue(finishCharacter);
                Console.ReadKey(true);
            }
        }
    }
}
