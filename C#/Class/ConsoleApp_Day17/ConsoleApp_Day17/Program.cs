namespace ConsoleApp_Day17
{   /************************************************
    [제네릭(Generic)]
    - 클래스, 메서드, 인터페이스 등에서 사용할 자료형을 미리 정하지 않고, 나중에 결정하는 것.

    - 재사용성: 하나의 코드로 다양한 자료형을 처리할 수 있음.
    - 타입 안전성: Object 타입을 쓰면 아무거나 다 들어올 수 있음. 꺼낼 때마다 형변환을 해야하고 실수하면 런타임 오류가 발생
                제네릭은 컴파일 단계에서 타입을 체크하므로 잘못된 타입이 들어오는 것을 미리 막아줌

    [제네릭 메서드]
    - 클래스는 일반 클래스인데, 특정 메서드 하나만 다양한 타입을 처리하고 싶을 때 사용하는 방식
    - 클래스 전체가 제네릭일 필요는 없지만, 특정 기능을 수행할 때만 타입을 유연하게 받고 싶을 때 유용

    [제네릭 클래스]
    - 클래스 전체에서 사용할 타입을 설계 시점에 정하지 않고, 객체를 생성할 때 결정하는 방식
    - 클래스 내부의 필드, 프로퍼티, 매개변수 등 여러 곳에서 해당 타입을 공유할 때 사용

    [제네릭 인터페이스]
    - 인터페이스가 다룰 데이터 타입을 확정하지 않고, 이를 구현하는 클래스에서 결정하도록 비워둔 약속
    - 무엇을 저장하고 꺼내는 규칙은 정해두되 그 무엇이 무엇인지는 나중에 정하겠다.
    - 비슷한 역할을 하고 다루는 데이터만 다를 때마다 비슷한 인터페이스를 계속 만드는 것 방지
    ************************************************/
    internal class Program
    {
        // 제네릭 메서드
        class Utils
        {
            public static void Swap<T>(ref T x, ref T y)
            {
                T tmp = x;
                x = y;
                y = tmp;
            }
            public static void ArrayCopy<T>(T[] source, T[] output)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    output[i] = source[i];
                }
            }
        }
        // 제네릭 클래스
        class Box<T>
        {
            private T item;
            public void SetItem(T item)
            {
                this.item = item;
            }
            public T GetItem()
            {
                return this.item;
            }
        }
        // 제네릭 인터페이스
        interface IRepository<T>
        {
            void Add(T item);
            T Get(int id);
        }
        class UserRepository : IRepository<string>
        {
            private string[] users = new string[10];
            private int count = 0;
            public void Add(string item)
            {
                if (count < users.Length)
                {
                    users[count] = item;
                    count++;
                }
                else
                {
                    Console.WriteLine("가득 찼다.");
                }
            }
            public string Get(int id)
            {
                if (id < 0 || id >= count)
                {
                    return "찾을 수 없다.";
                }
                return users[id];
            }
        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            Utils.Swap(ref x, ref y);

            Box<int> intBox = new Box<int>();
            intBox.SetItem(100);
            Console.WriteLine(intBox.GetItem());
            Box<string> strBox = new Box<string>();
            strBox.SetItem("100");
            Console.WriteLine(intBox.GetItem());

            IRepository<string> repo = new UserRepository();
            repo.Add("홍길동");
            repo.Add("홍길서");
            repo.Add("홍길남");
            repo.Add("홍길북");
            string user0 = repo.Get(0);
            Console.WriteLine(user0);
        }
    }
}
