namespace ConsoleApp_Day13_HW
{   /****************************************************
    [과제]
    2. 클래스 다형성 (오버라이딩)
     2-1. 스킬 사용 시스템 만들기
     2-2. 플레이어 스킬 사용 시스템 만들기
    ****************************************************/
    // 과제 2
    // 2-1
    class Skill
    {
        public virtual void Use()
        {
            Console.WriteLine("스킬을 사용한다.");
        }
    }
    class FireBall : Skill
    {
        public FireBall() : base() { }
        public override void Use()
        {
            Console.WriteLine("불덩이를 발사했다!");
        }
    }
    class Heal : Skill
    {
        public Heal() : base() { }
        public override void Use()
        {
            Console.WriteLine("체력을 회복했다!");
        }
    }
    class Stealth : Skill
    {
        public Stealth() : base() { }
        public override void Use()
        {
            Console.WriteLine("은신 상태에 들어갔다!");
        }
    }
    // 2-2
    class Player
    {
        private string name;
        protected string Name { get { return name; } set { name = value; } }
        public Player(string name) 
        {
            Name = name;
        }
        public void UseSkill(Skill skill)
        {
            Console.WriteLine($"{Name}이(가) 스킬을 사용했다.");
            skill.Use();
        }
    }
    internal class Day13_HW_2
    {
    }
}
