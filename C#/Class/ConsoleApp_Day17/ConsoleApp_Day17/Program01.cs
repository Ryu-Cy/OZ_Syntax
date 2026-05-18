using System.Collections;

namespace ConsoleApp_Day17
{   /************************************************
    [List]
    - 제네릭 기반의 동적 배열 클래스

    [특징]
    - 배열과 유사하지만, 크기가 자동으로 조절된다.
     ㄴ 내부적으로 배열을 사용하지만, 크기가 부족하면 새로운 배열을 생성하고 기존 요소를 복사
     ㄴ 새로운 배열을 생성할 때마다 기존 배열의 2배 크기의 배열을 생성한다.
    - 인덱스를 통해 빠른 접근이 가능하다.
    
    - 리스트는 순차적인 메모리 구조를 유지해야 하기 때문에 중간에 데이터를 건드리는 작업은 비용이 들어간다.
    - 삽입: 특정 인덱스에 데이터를 넣으려면 해당 위치 뒤에 있는 모든 데이터를 한 칸씩 뒤로 밀어야 함.
    - 삭제: 특정 데이터를 지우면 뒤에 있는 데이터들을 앞으로 한 칸씩 당겨야 함.

    [리스트를 효율적으로 쓰고싶다면]
    - 리스트를 비워라
    - 클리어를 호출하면 size는 0이 되지만 capacity는 해제되지 않고 유지된다.
     ㄴ 생성되어 있는 리스트 재활용 가능
    - 리스트 사이즈를 지정해라

    [GC영향]
    - 완전히 자유롭지는 않다.
    - boxing/unboxing으로 인해서 발생하는 불필요한 GC 부하를 줄여주는 것.

    [키워드]
    - _items: 실제 데이터 주소
    - size: 실제 데이터가 들어있는 크기
    - capacity: 현재 배열 전체 크기

    [메서드]
    - Add: 리스트 맨 끝에 요소 추가
    - Insert: 특정 위치에 요소를 삽입
    - Remove: 특정 요소 제거
    - Clear: 모든 요소 제거
    - Contains: 특정 요소가 있는지 확인
    - IndexOf: 특정 요소의 인덱스 반환, 없으면 -1리턴
    - Sort: 정렬
    - TrimExcess: 사용하지 않는 빈 공간 제거

    [속성]
    Count: 현재 리스트의 요소 개수 반환
    Capacity: 리스트가 내부적으로 사용할 수 있는 용량 반환

    [ArrayList vs List]
    - 저장할 때 값 타입이 boxing 없이 저장되기 때문에 GC 부하가 없음

    ================================================

    [Array]
    - 배열 크기 이상의 공간이 필요하면 새로운 배열을 만들거나 Resize를 해줘야 함.

    ================================================

    [ArrayList]
    - 배열 크기 선언 없이 저장 가능
    - object 타입으로 저장하기 때문에 어떤 타입이든 들어간다.
    - 때문에 안전성을 보장받지 못 함.
    - boxing/unboxing을 통한 object(참조)와 int, ...(값)간의 타입 변환이 일어남
     ㄴ ArrayList에 값 저장 시 boxing이 일어나 값 형식의 데이터를 참조 형식으로 변환해 힙 영역에 할당 -> GC의 영향을 받음
     ㄴ ArrayList에서 값을 꺼낼 시 unboxing이 일어나 참조 형식의 데이터를 값 형식으로 변환해 스택 영역에 할당
     ㄴ boxing/unboxind을 줄이기 위한 좋은 방법: 제네릭 타입 사용 -> List가 ArrayList보다 좋은 이유
    ************************************************/
    internal class Program01
    {
        static void Main()
        {
            // Array
            int[] scores = new int[3];
            scores[0] = 10;
            scores[1] = 20;
            scores[2] = 30;
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = i;
            }
            //배열 크기 초과
            //scores[3] = 40;
            int[] newScores = new int[4];
            for (int i = 0;i < scores.Length; i++)
            {
                newScores[i] = scores[i];
            }
            newScores[3] = 40;
            scores = newScores;

            //=================================================
            
            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add("1234");
            foreach (object obj in list)
            {
                try
                {
                    int score = (int)obj;
                    Console.WriteLine($"점수: {score}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"에러 발생: {e.Message}");
                }
            }

            //=================================================

            // List
            List<string> items = new List<string>();
            items.Add("Sword");
            items.Add("Shield");
            items.Add("Armor");
            items.Add("Potion");
            items.Add("Bow");

            items.Insert(5, "MpPotion");
            items.Remove("Bow");
            PrintList(items);
            if (items.Contains("Shield"))
            {
                Console.WriteLine("있다.");
            }
            items.Clear();
            PrintList(items);
            items.TrimExcess();
            PrintList(items);
        }
        static void PrintList(List<string> list)
        {
            foreach (string item in list)
            {
                Console.Write($"{item} -> ");
            }
            Console.WriteLine($"\n요소 개수: {list.Count}, 용량: {list.Capacity}");
        }
    }
}
