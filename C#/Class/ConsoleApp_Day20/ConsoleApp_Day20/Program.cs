namespace ConsoleApp_Day20
{   /***********************************************
    [대리자(Delegate)]
    - 메서드를 저장할 수 있는 타입.
     ㄴ 즉, 메서드를 담는 변수라고 생각하면 된다.
    - 반환형과 매개변수가 모두 같아야 받아올 수 있다.
    - 저장된 메서드 변경 가능
     ㄴ 상황에 따라 실행할 기능 변경 가능

    [사용처]
    - 여러 기능을 연결하고 싶을 때
    - 이벤트 시스템을 만들 때
    - UI 버튼 클릭, 아이템 획득 처리할 때

    ?.Invoke : 데이터 존재 여부, null체크 가능
    ***********************************************/
    internal class Program
    {
        // 반환형 float, 매개변수 (float x, float y)인 메서드만 저장 가능한 델리게이트
        public delegate float DelegateMethod1(float x, float y);
        public delegate void DelegateMethod2(string str);
        public static float Plus(float x, float y)
        {
            return x * y;
        }
        public static float Minus(float x, float y)
        {
            return x - y;
        }
        public static float Multi(float x, float y)
        {
            return x * y;
        }
        public static float Divide(float x, float y)
        {
            return x / y;
        }
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
        static void Main(string[] args)
        {
            DelegateMethod1 delegate1 = null;
            delegate1 = new DelegateMethod1(Plus);

            Console.WriteLine(delegate1(10, 20));
            Console.WriteLine(delegate1.Invoke(20, 30));
            delegate1?.Invoke(30, 40);

            DelegateMethod2 delegate2 = Message;

            delegate2("메세지");
            Message("메세지");

            delegate1 = Multi;
        }
    }
}
