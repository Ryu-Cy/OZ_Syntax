namespace ConsoleApp_Day13
{   /****************************************************
    []
    - 
    ****************************************************/
    //class Warrior
    //{
    //    public string Name;
    //    public void Swing()
    //    {
    //        Console.WriteLine($"{Name}이 도끼를 휘두른다.");
    //    }
    //}
    //class Mage
    //{
    //    public string Name;
    //    public void FireBall()
    //    {
    //        Console.WriteLine($"{Name}이 파이어볼을 사용한다.");
    //    }
    //}
    class Character
    {
        public string Name;
        public virtual void Attack()
        {
            Console.WriteLine("기본 공격");
        }
    }
    class Warrior : Character
    {
        public override void Attack()
        {
            //base.Attack();
            Console.WriteLine($"{Name}이 도끼를 휘두른다.");
        }
    }
    class Mage : Character
    {
        public override void Attack()
        {
            //base.Attack();
            Console.WriteLine($"{Name}이 지팡이를 휘두른다.");
        }
    }
    internal class Program03
    {
        static void Main()
        {
            Character[] c = new Character[]
            {
                new Warrior{Name = "홍길동"},
                new Mage{Name ="홍길서"}
            };
            foreach(Character unit in c)
            {
                unit.Attack();  // 다형성에 의해 각자 재정의된 메서드 실행
            }
        }
    }
}
