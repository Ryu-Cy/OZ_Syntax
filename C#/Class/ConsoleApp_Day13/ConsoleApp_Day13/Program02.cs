namespace ConsoleApp_Day13
{   /****************************************************
    [메서드 오버라이딩]
    - 상속받은 부모 클래스의 메서드를 자식 클래스에서 재정의 하는 기능
    - 부모 클래스의 메서드와 같은 이름, 같은 반환형, 같은 매개변수를 가지지만, 내부 동작을 다르게 구현
    - 부모 메서드에 virtual 키워드를, 자식 메서드에 override 키워드를 사용
     ㄴ virtual: 자식 클래스에서 오버라이딩 가능한 메서드로 선언하는 키워드
     ㄴ override: 부모 클레스에 virtual 메서드를 재정의 하기 위한 키워드
     ㄴ sealed: 자식 클래스에서 더 이상 오버라이딩을 허용하지 않기 위한 키워드

    [오버로딩 vs 오버라이딩]
    - 오버로딩
    - 오버라이딩
    ****************************************************/
    class Character
    {
        protected string Name { get; set; }
        public Character(string name)
        {
            Name = name;
        }
        public virtual void Attack()
        {
            Console.WriteLine($"{Name}(이)가 기본공격을 한다.");
        }
    }
    class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {

        }
        public sealed override void Attack() 
        {   
            Console.WriteLine($"{Name}(이)가 강한공격을 한다.");
        }
    }
    class Mage : Character
    {
        public Mage(string name) : base(name)
        {

        }
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine($"{Name}(이)가 마법 공격을 한다.");
        }
    }
    class AWarrior : Warrior
    {
        public AWarrior(string name) : base(name)
        { 

        }
        //public override void Attack() { }     부모 클래스에서 sealed를 사용해 재정의 불가
    }
    internal class Program02
    {
        static void Main()
        {
            // 동적 바인딩
            Character warrior = new Warrior("홍길동");
            Character mage = new Mage("홍길서");

            warrior.Attack();
            mage.Attack();
        }
    }
}
