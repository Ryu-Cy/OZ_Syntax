namespace ConsoleApp_Day10
{
    /**********************************************
    [문자열(string)]
    - 참조형
    - 내부적으로 System.String 클래스로 구현
    - 문자들의 집합으로 표현이 되고 내부적으로 인덱서를 구현해 문자 배열의 형태로 구현 > 읽기 전용이기에 수정은 불가능
    - 한 번 생성된 문자열은 수정할 수 없고, 변경되는 것 처럼 보일 때는 새로운 문자열 객체가 생성됨
    - string 변수에 string 변수를 저장하면 저장하는 변수가 참조하는 힙 메모리의 데이터를 같이 참조한다.

    [string의 불변성]
    - 기본 자료형과 같이 값형식을 구현하기 위해 string클래스의 처리를 값형식 처럼 동작하도록 구현
    - 이를 구현하기 위해 string간의 대입이 있을 경우 참조에 의한 주소값이 복사
    - 결과적으로 데이터 자체를 복사하는 값형식으로 사용하지만, 힙 영역을 사용하기 때문에 string이 설정되면

    [스트링 빌더(string builder)]
    - 문자열 수정 시 새로운 문자열을 만들지 않는다.
    - 반복적인 문자열 조작이 많을 경우 이점이 있다.
    - 스트링 빌더는 내부 버퍼를 사용하여 기존 데이터를 유지한 채 뒤에 덧붙이지만, string은 매변 새로운 메모리 공간을 할당한 후 복사
    **********************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "abcde";
            Console.WriteLine(str);
            Console.WriteLine(str[1]);
            
            string str1 = "Hello";
            string str2 = "World";
            string str3 = str1 + " " + str2;
            Console.WriteLine(str3);

            string str4 = "abc";
            string str5 = str4;
            Console.WriteLine(object.ReferenceEquals(str4, str5));

            string str6 = "Hello World Game";
            Console.WriteLine($"Game의 시작 위치: {str6.IndexOf("Game")}");  // 문자열 내에서 특정 문자/문자열이 처음 나타나는 인덱스 반환
            Console.WriteLine($"e의 시작 위치(역순): {str6.LastIndexOf('e')}");  // 위 방식에서 순서만 뒤에서부터로 변경
            Console.WriteLine($"World의 포함 여부: {str6.Contains("World")}");   // 문자열 내에서 특정 문자/문자열이 있는지 판단
            Console.WriteLine($"Hello로 시작?: {str6.StartsWith("Hello")}");  // 문자열 내에서 특정 문자/문자열로 시작하는지 판단
            Console.WriteLine($"Game으로 끝?: {str6.EndsWith("Game")}");  // 문자열 내에서 특정 문자/문자열로 끝나는지 판단
            Console.WriteLine($"문자열 변경: {str6.Replace("World", "C#")}");  // 특정 문자열 변경 > 스트링 빌더는 아니기에 새로 만들어짐
            Console.WriteLine($"문자열의 일부 출력: {str6.Substring(7, 5)}");  // 문자열의 특정 부분을 추출(시작 인덱스, 길이)

            string str7 = "  Space  ";
            Console.WriteLine($"{str7.Trim()}");    // 문자열의 공백(space, tap)을 지워준다.

            string str8 = "C# Java Python C++";
            string[] strArr = str8.Split(' ');      // 특정 문자를 기준으로 나눠 배열로 바꿔준다.
            foreach (string s in strArr)
                Console.WriteLine(s);


        }
    }
}
