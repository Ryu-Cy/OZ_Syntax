using System.Drawing;
using System.Net.WebSockets;
using System.Security;

namespace ConsoleApp_Day12
{   /*************************************************
    [속성(Property)]
    - 클래스 내부의 필드를 캡슐화했을 때 필드에 안전하게 접근 하도록 도와주는 기능
    - Getter(읽기)/Setter(쓰기)를 통해 내부 데이터를 보호하면서 필요할 때만 값을 읽거나 변경할 떄 사용
    - 외부에서는 필드에 직접 접근하지 못 하고 프로퍼티를 통해서만 접근 가능
    
    [사용 이유]
    - set블록에서 조건을 사용하여 잘못된 값이 들어오는 것을 차단할 수 있음
    ㄴ ex) 플레이어의 HP가 음수가 되는 것을 방지
    - get은 public, set은 private으로 설정하여 외부 읽기 전용 상태를 만들 수 있음
    - 필요에 따라 쓰기 전용(set만 존재)/읽기 전용(get만 존재) 프로퍼티도 만들 수 있음
    - 메서드의 형태(GetHp(), SetHp())호출 방식보다 대입 연산자를 사용하는 게 가시성이 좋다.
    - 자동 구현 프로퍼티를 통해 코드양을 어느 정도 줄일 수 있음
    *************************************************/
    class Circle
    {
        double pi = 3.14;   // 디폴트로 private 선언
        double GetArea(double radius)
        {
            return radius * pi;
        }
        public void Print(double value)
        {
            Console.WriteLine(GetArea(value));
        }
    }
    class Character
    {
        private string name;
        public string Name
        {
            get { return name; }    // getter : 값 읽기
            set { name = value; }   // setter : 값 설정
                                    // set 안에서의 value : 사용자가 프로퍼티에 값을 설정할 때 전달된 값(암시적 매개변수)
                                    //                    타입은 프로퍼티 타입과 항상 동일
        }
    }
    class Character1
    {   // get만 제공하고 set이 없으면 읽기 전용 프로퍼티
        // 객체의 데이터를 외부에서 변경하지 못 하도록 설정
        private int level = 1;
        public int Level
        {
            get { return level; }
        }
    }
    class Character2
    {   // set만 제공하고 get이 없으면 쓰기 전용 프로퍼티
        private string name;
        public string Name
        {
            set { name = value; }
        }
    }
    // [자동 구현 프로퍼티]
    // 직접 선언하지 않고도 자동으로 필드를 생성하는 프로퍼티 제공
    // 간단한 속성읠 정의할 때 유용
    class Character3
    {
        public string Name { get; set; }
    }
    // [프로퍼티에 로직 추가]
    // set에 유효성 검사를 통해 잘못된 값이 입력되지 않도록 보호 가능
    class Character4
    {
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("레벨은 1 이상이어야 한다.");
                    level = 1;
                }
                else
                {
                    level = value;
                }
            }
        }
    }
    // [private set]
    // 외부에서는 읽기만 가능(get), 값 설정은 내부에서만 가능(set)
    // 한 번 설정된 값이 외부에서 변경되지 않도록 보호할 때 사용
    // 생성자나 내부 메서드에서만 값을 변경할 수 있다.
    class Character5
    { 
        public string Name { get; private set; }
        public Character5(string name)
        {
            Name = name;    // 생성자 내부에서는 값 설정 가능
        }
    }
    // [private property]
    // 클래스 내부에서만 접근 허용 -> 외부에서 직접적으로 읽거나 변경 불가능
    // 객체의 내부 상태를 보호하고 특정 메서드를 통해서만 값을 변경하게 만들 때 유용
    class Game
    {
        private int Score { get; set; }
        public void IncreaseScore(int point)
        {
            Score += point;
            Console.WriteLine($"현재 점수: {score}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 기본 형태
            Character player = new Character();
            player.Name = "전사";
            Console.WriteLine(player.Name);

            // 읽기 전용
            Character1 player1 = new Character1();
            Console.WriteLine(player1.Level);
            //player1.Level = 1;    외부에서 값 수정 불가능

            // 쓰기 전용
            Character2 player2 = new Character2();
            player2.Name = "Secret";
            //Console.WriteLine(player2.Name);  외부에서 읽기 불가능

            // 자동 구현 프로퍼티
            Character3 player3 = new Character3();
            player3.Name = "기사";
            Console.WriteLine(player3.Name);

            // set에 유효성 검사
            Character4 player4 = new Character4();
            player4.Level = -1;
            Console.WriteLine(player4.Level);

            // private set
            // 객체를 초기화할 때만 수정이 가능하고 읽기만 가능
            Character5 player5 = new Character5("마법사");
            Console.WriteLine(player5.Name);
            //player5.Name = "전사";
        }
    }
}
