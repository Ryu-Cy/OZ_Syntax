namespace ConsoleApp_Day13
{   /****************************************************
    [포함]
    - 클래스가 다른 클래스를 소유하고 있는 관계
    - 하나의 클래스가 다른 클래스의 인스턴스를 멤버 변수로 포함하고 그 객체의 기능을 자신의 일부처럼 사용하는 방식
    - 포함된 객체는 포함하는 개체가 소멸될 때 함께 소멸
    - 포함된 객체는 필드 변수처럼 사용되고, 외부에서 접근하기 위해서는 공개된 메서드를 통해 접근

    [상속]
    - 상속 관계 : is-a 관계라고도 부른다.
     ㄴ ex) 기사는 플레이어다. 사과는 과일이다.
    - 상속은 한 클래스가 다른 클래스의 특성을 물려받는 관계
    - 기본 클래스(부모 클래스)의 기능을 확장하거나 변경해서 자식 클래스에서 사용
    - 자식 클래스는 부모 클래스의 모든 public, protected 멤버를 상속. private은 불가능
    - 자식 클래스는 부모 클래스의 기능을 재정의(오버라이딩)하거나 추가할 수 있다.
    - 다중 상속은 C#에서는 지원하지 않는다.
     ㄴ 인터페이스를 통해 다중 상속의 효과를 낼 수 있다.

    [두 방식의 차이점]
    - 관계
     ㄴ 포함: 한 클래스가 다른 클래스를 소유하고 포함
     ㄴ 상속: 자식 클래스는 부모 클래스의 확장
    - 확장성
     ㄴ 포함: 포함된 객체의 기능을 내부적으로 사용
     ㄴ 상속: 부모 클래스를 확장하거나 수정할 때 유용하지만, 자식 클래스와 부모 클래스간의 결합도가 높아질 수 있다.

    [사용하는 상황]
    - 포함
     ㄴ has-a 관계일 때
     ㄴ 기능을 조립해서 만들고싶을 때
     ㄴ Player -> Inventory, Item, etc...
    - 상속
     ㄴ is-a관계일 때
     ㄴ 공통 기능을 여러 클래스가 공유해야 할 때 (공통 기능이 명확할 때)
     ㄴ 다형성을 활용할 때
     ㄴ Character -> Warrior, Mage, Rogue, etc...

    단, 상속에서 깊은 상속은 지양(가급적이면 사용 x, 상속 관계는 간단하게)
    ****************************************************/
    // 포함
    class Engine
    {
        public string Type;
        public Engine(string type)
        {
            Type = type;
        }
        public void Start()
        {
            Console.WriteLine("엔진 가동");
        }
    }
    class Car
    {
        private Engine engine;
        public Car(string engineType)
        {
            engine = new Engine(engineType);
        }
        public void StartCar()
        {
            Console.WriteLine("시동이 걸렸다.");
            engine.Start();
        }
    }
    // 상속
    class Warrior
    {
        private string Name;
        private int Health;
        private int AttackPower;
        private int Defense;
        public Warrior(string name)
        {
            Name = name;
            Health = 120;
            AttackPower = 15;
            Defense = 5;
        }
        public void Attack()
        {
            Console.WriteLine($"{Name}이 기본공격을 사용했다. 공격력: {AttackPower}");
        }
        public void HeavyAttack()
        {
            Console.WriteLine($"{Name}이 강한공격을 사용했다. 공격력: {AttackPower * 2}");
        }
        public void TakeDamage(int dmg)
        {
            int reduceDamage = Math.Max(dmg - Defense, 0);
            Health = reduceDamage;
            Console.WriteLine($"{Name}이 {reduceDamage}만큼 피해를 입었다. 남은 체력: {Health}");
        }
        public void ShowStatus()
        {
            Console.WriteLine($"이름: {Name}, 체력: {Health}, 공격력: {AttackPower}, 방어력: {Defense}");
        }
    }
    class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }
        public Character(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }
        public void Attack()
        {
            Console.WriteLine($"{Name}(이)가 기본 공격을 한다. 공격력: {AttackPower}");
        }
        public void ShowStatus()
        {
            Console.WriteLine($"이름: {Name} 체력: {Health}, 공격력: {AttackPower}");
        }
    }
    class Rogue : Character
    {
        private int defense;
        public Rogue(string name) : base(name, 120, 15) // base: 부모 클래스 멤버에 접근할 때 사용
        {
            defense = 5;
        }
        public void HeavyAttack()
        {
            Console.WriteLine($"{Name}이 강한공격을 사용했다. 공격력: {AttackPower * 2}");
        }
        public void TakeDamage(int dmg)
        {
            int reduceDamage = Math.Max(dmg - defense, 0);
            Health = reduceDamage;
            Console.WriteLine($"{Name}이 {reduceDamage}만큼 피해를 입었다. 남은 체력: {Health}");
        }
    }
    internal class Program01
    {
        static void Main()
        {
            Car myCar = new Car("V8");
            myCar.StartCar();
            Console.WriteLine();

            //상속x
            Warrior warrior = new Warrior("홍길동");
            warrior.ShowStatus();
            warrior.Attack();
            warrior.HeavyAttack();
            warrior.TakeDamage(20);
            Console.WriteLine();

            //상속o
            Rogue rogue = new Rogue("홍길서");
            rogue.ShowStatus();     // 부모 클래스의 메서드
            rogue.Attack();         // 부모 클래스의 메서드
            rogue.HeavyAttack();
            rogue.TakeDamage(20);
        }
    }
}
