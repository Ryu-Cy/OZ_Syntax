namespace ConsoleApp_Day22
{   /***********************************************
    [확장 메서드]
    - 기존 클래스에 새로운 메서드를 추가한 것처럼 사용할 수 있는 문법
     ㄴ 실제로 기존 클래스를 수정하지는 않음

    - 확장 메서드는 반드시 static 클래스 안에 작성해야 한다.
    - 확장 메서드도 반드시 static 메서드여야 한다.
    - 첫 번째 매개변수 앞에 this 키워드를 붙인다.
    - this 뒤에 확장하고 싶은 타입을 작성    
    ***********************************************/
    public static class StringExtensions
    {
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            char[] array = str.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            //                   공백을 기준으로 문자열을 나눔, 연속된 공간으로 생기는 빈 문자열 제거
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        public static bool ISLonger(this string str, int length)
        {
            if (str == null) return false;
            return str.Length > length;
        }
    }
    public static class ListExtensions
    {
        public static void PrintAll<T>(this List<T> list)
        {
            if (list == null) return;
            if (list.Count == 0)
            {
                Console.WriteLine("리스트가 비어 있다.");
                return;
            }
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this int value)
        {
            return value % 2 == 1;
        }
    }
    internal class Program02
    {
        static void Main()
        {
            string original = "Hello World!";
            string reverseStr = original.ReverseString();
            Console.WriteLine(reverseStr);

            string text = "Hello World Extension Method";
            Console.WriteLine(text.WordCount());

            int number = 10;
            Console.WriteLine(number.IsEven());

            List<string> name = new List<string>()
            {
                "홍길동",
                "홍길서",
                "홍길남",
                "홍길북"
            };
            name.PrintAll();
        }
    }
}
