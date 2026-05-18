using Microsoft.VisualBasic;
using System.Diagnostics;

namespace ConsoleApp_Day10
{
    /**********************************************
    [구조체(struct)]
    - 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
    - 데이터를 저장(보관)하기 위한 단위 용도로 사용한다.
    - 클래스와 비슷하게 필드, 메서드, 프로퍼티, 생성자 등을 가질 수 있다.
    - 값 타입이기 때문에 스택에 저장되고 클래스와 다르게 상속 불가

    [구조체 vs 클래스]
    - 메모리 할당 방식이 다름
    ㄴ 구조체: stack에 할당
    ㄴ 클래스: heap에 할당
            클래스 안에 구조체를 생성하면 그 구조체도 heap에 할당

    **********************************************/
    public struct StudentInfo
    {
        public string name;
        public int math;
        public int english;
        public int science;
        public float Average()
        {
            return(math + english +  science) / 3.0f;
        }
    }
    public struct MyStruct
    {
        public int value1;
        public int value2;
    }
    public class ASD
    {
        public struct DSA
        {

        }
    }
    internal class Program01
    {
        static void Main()
        {
            // new를 통해 구조체 안의 내용을 초기화시켜줌.
            StudentInfo st = new StudentInfo
            {
                name = "Ryu",
                math = 10,
                english = 20,
                science = 30
            };
            Console.WriteLine(st.math);
            Console.WriteLine(st.english);
            Console.WriteLine(st.science);
            Console.WriteLine(st.Average());
            Console.WriteLine();

            MyStruct m;
            m.value1 = 1;
            m.value2 = 2;
            Console.WriteLine(m.value1);
            Console.WriteLine(m.value2);
            MyStruct s;
            s = m;
            Console.WriteLine(s.value1);
            Console.WriteLine(s.value2);
            // 구조체 m.value1의 값을 변경하더라도 구조체 s는 영향을 받지 않는다.(복사, 서로 독립)
            m.value1 = 10;
            Console.WriteLine(m.value1);
            Console.WriteLine(s.value1);
        }
    }
}
