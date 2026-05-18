namespace ConsoleApp_Day18
{   /***********************************************
    [Dictionary]
    - 'key' - 'value' 형태로 데이터를 저장하는 자료구조
    - key와 value가 한 쌍으로 저장된다.
    - key값은 중복을 허용하지 않는다.
    - key 값에 따른 정렬은 보장되지 않는다. 
     ㄴ 1, 3, 2 순서로 key값을 넣으면 1>2>3 순서가 아닌 1>3>2순서로 저장된다.(배열의 인덱스 순서와 다르다.)
    - 검색 속도가 빠르다.
    - 내부적으로 HashTable 기반 구현
     ㄴ HashTable도 key - value 형태로 데이터를 저장하는 자료구조
     ㄴ 그렇기에 HashTable 기반인 Dictionary도 key- value 형태를 가진다.
     ㄴ 특징 : 키를 해시함수를 통해 해시 코드로 변환해 데이터를 저장하고 검색하므로 빠른 검색 속도를 제공
     ㄴ Dictionary와의 차이점: HashTalbe - Object base, Dictionary - Generic base
     ㄴ HashTable은 Object 기반이기에 boxing/unboxing의 문제와 안전성의 문제가 있다.

    [해시 함수]
    - 키를 해시 코드로 변환해 인덱스를 계산, 빠른 데이터 접근을 가능하게 함.
    - 데이터를 저장할 주소 번호를 계산하는 함수.

    [해시 테이블 주의점]
    - 해시 함수가 서로 다른 입력값에 대해 동일한 해시 테이블 주소를 반환
    - 모든 입력값에 대해 고유한 해시 값을 만드는 것은 불가능하며, 충돌은 피할 수 없다.
    - 충돌을 해결하기 위해 체이닝, 개방주소법이 있다.

    [HashTable vs Dictionary]
    - 생성 방식
     ㄴ Dictionary : Dictionaty<키타입, 값타입> 이름
     ㄴ HashTable : 

    [키워드]
    Add : 데이터 추가
    TryAdd : 안전하게 데이터 추가
    ContainsKey : Key가 있는지 확인
    ContainsValue : Value가 있는지 확인
    TryGetValue : 안전하게 값 조회
    Ramove : 삭제
    Clear : 전체 삭제
    Count : 개수 확인
    Keys : 모든 키 가져오기
    Values : 모든 값 가져오기

    [Add indexer 차이]
    Add : 같은 키 추가 시 예외 발생
    
    [SortedDictionary]
    - 정렬을 보장해주는 딕셔너리.
     ㄴ 일반적인 딕셔너리보다는 느리다.
    - 내부적으로 균형이진탐색트리 기반 구현
    ***********************************************/
    internal class Program01
    {
        static void Main()
        {
            Dictionary<int, string> players = new Dictionary<int, string>();
            players.Add(1, "전사");
            players.Add(2, "마법사");
            players.Add(3, "도적");
            //players.Add(3, "ffff");   Add로 추가할 때 인덱스 값이 중복되면 예외 발생. -> 같은 key값은 허용하지 않는다.
            //                          바꾸고 싶으면 players[3] = "ffff"; 방식으로 해주어야 함.
            //                          players.TryAdd(3, "ffff"); 방식으로 예외 상황에 대한 안전성 보장을 할 수는 있다.
            //                          저장이 되는 것은 아님. 같은 key값이면 false 리턴으로 에러 발생만 막아줌.

            Console.WriteLine(players[1]);

            if (players.ContainsKey(2))
                Console.WriteLine($"{players[2]}가 있음.");
            players[3] = "궁수";
            Console.WriteLine(players[3]);
            // Add로 추가하지 않아도 자동으로 인덱스 추가
            players[4] = "기사";
            Console.WriteLine(players[4]);
            players.Remove(1);
            Console.WriteLine(players.Count);

            Console.WriteLine("\n============================전체출력============================");
            foreach (var player in players)
                Console.WriteLine($"{player.Key} : {player.Value}");

            Console.WriteLine();

            int searchKey = 4;
            if (players.TryGetValue(searchKey, out string value))
                Console.WriteLine($"{searchKey}번 플레이어: {value}");
            else
                Console.WriteLine($"{searchKey}번 플레이어가 없다.");

            players.Clear();

            //

        }
    }
}
