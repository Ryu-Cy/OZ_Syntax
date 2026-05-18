namespace ConsoleApp_Day13
{   /****************************************************
    [캡슐화(EnCapsulation)]
    - 객체의 내부 데이터를 외부에서 직접 접근하지 못 하도록 보호하는 기법
    - 클래스 내부에서만 데이터를 관리하고 필요한 경우에만 외부에서 접근할 수 있도록 제한한다.
    - 중요한 데이터가 외부에서 직접 변경되지 않도록 해주는 것이 핵심
    - 접근 제한자를 잉요해 데이터 접근을 제어
    
    [기본원칙]
    - 필드를 private으로 선언하여 외부에서 직접 접근하지 못 하도록 한다.
    - 필요한 경우에는 public 메서드나 프로퍼티를 통해 접근
    - 클래스 내부에서만 데이터를 변경하거나 조작할 수 있도록 제한
    
    [장점]
    - private 필드를 사용하면 잘못된 데이터 변경을 방지해 데이터 보호
    - 특정 필드 변경 방식이 바뀌어도 외부 코드에 영향을 주지 않아 유지 보수에 용이
    - 프로퍼티를 조정해서 읽기/쓰기 권한을 세밀하게 조절할 수 있다.
    - set에서 유효성 검사를 통해 잘못된 값 방지

    [사용하는 상황]
    - 중요한 데이터를 보호해야 할 때
    - 외부에서 임의로 데이터를 수정하면 안 될 때
    - 클래스 내부에서 데이터의 변화를 안전하게 관리하고 싶을 때
    ****************************************************/
    class Character
    {
        private string name;
        private int health;
        public Character(string name, int health)
        {
            this.name = name;
            this.health = health;
        }
        public void ShowStatus()
        {
            Console.WriteLine($"이름: {name}, 체력: {health}");
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
    class Character1
    {
        private string name;
        private int health;
        public string Name
        {
            get { return name; }
        }
        public int Health
        {
            get { return health; } 
            private set 
            { 
                if (value < 0 ) value = 0; 
                else health = value; 
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
