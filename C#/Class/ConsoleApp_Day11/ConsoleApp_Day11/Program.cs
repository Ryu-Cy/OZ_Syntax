namespace ConsoleApp_Day11
{   /******************************************************
    [클래스(class)]
    - 데이터와 관련 기능을 캡슐화할 수 있는 참조형식
    - 객체지향 프로그래밍의 객체를 만들기 위한 설계도
    - 클래스는 개체를 만들기 위한 설계도이며, 만들어진 객체는 인스턴스라고 한다.
    - 만들어진 설계도를 기반드로 여러 객체를 만들 수 있다.
    - 참조 : 원본을 가리키고 있다. = 원본의 주소를 가지고 있다.

    [클래스 주요 구성 요소]
    - 필드(변수) 및 속성(프로퍼티)
    ㄴ 필드: 클래스 내부에서 데이터를 저장하는 변수.
            보통 외부에서 직접 접근하지 못 하도록 private으로 설정
    ㄴ 속성: 필드에 안전하게 접근하기 위한 통로.
            get, set을 사용하여 데이터의 유효성을 검사하거나, 읽기 전용으로 만들 수 있음
    - 메서드: 클래스가 수행할 수 있는 기능을 정의.
            함수와 유사하지만, 클래스 내부에 소속되어 있음
    - 생성자: 객체가 생성될 때 자동으로 호출되는 특수한 메서드
            클래스 이름과 동일하며 반환 타입이 없음. 주로 객체의 초기상태를 설정
    ******************************************************/
    public class Car
    {
        public string modelName;
        public string color;
        public int speed;

        public void Accel()
        {
            speed += 10;
            Console.WriteLine($"{modelName}이 가속한다. 현재 속도: {speed}");
        }
        public void Horn()
        {
            Console.WriteLine($"{modelName}: 빵빵 ~");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.modelName = "Tesla Model Y";
            myCar.color = "White";
            myCar.speed = 0;

            Car secondCar = new Car
            {
                modelName = "Morning",
                color = "red",
                speed = 0
            };

            myCar.Accel();
            myCar.Accel();
            myCar.Horn();
            Console.WriteLine();
            secondCar.Accel();
            secondCar.Horn();
        }
    }
}
