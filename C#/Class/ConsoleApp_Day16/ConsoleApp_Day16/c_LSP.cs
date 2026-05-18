namespace ConsoleApp_Day16
{   /************************************************
    [L(LSP: Liskov Substitution Principle) - 리스코프 치환 원칙]
    - 자식 클래스는 부모 클래스를 대체할 수 있어야 한다.
    ㄴ 부모 타입이 사용되는 곳에 자식 객체를 넣어도 프로그램의 논리가 깨지면 안 된다.
    ㄴ 부모 클래스가 약속한 행동을 자식 클래스도 반드시 지켜야 한다.
    ************************************************/
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("새가 훨훨 날아간다.");
        }
    }
    class Eagle : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("독수리가 높이 날아간다.");
        }
    }
    class Penguin : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("펭귄은 날 수가 없다.");
        }
    }
    class BirdManager
    {
        public static void BirdFly(Bird bird)
        {
            bird.Fly();
        }
    }
    // ==========
    abstract class Character
    {
        public abstract void Move();
        public abstract void Attack();
    }
    class Warrior : Character
    {
        public override void Move()
        {
            Console.WriteLine("전사가 뛰어서 움직인다.");
        }
        public override void Attack()
        {
            Console.WriteLine("전사가 검으로 공격한다.");
        }
    }
    class Mage : Character
    {
        public override void Move()
        {
            Console.WriteLine("마법사가 순간이동을 한다.");
        }
        public override void Attack()
        {
            Console.WriteLine("마법사가 마법으로 공격한다.");
        }
    }
    class Battle
    {
        public static void Execute(Character character)
        {
            character.Move();
            character.Attack();
        }
    }
}
