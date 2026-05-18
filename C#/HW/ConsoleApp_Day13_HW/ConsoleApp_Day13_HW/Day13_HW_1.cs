namespace ConsoleApp_Day13_HW
{   /****************************************************
    [과제]
    1. 클래스 상속
     1-1. 캐릭터 직업 만들기
     1-2. 퀘스트 보상 시스템 만들기
    ****************************************************/
    // 과제 1
    // 1-1
    class Character
    {
        private string name;
        private int hp;
        private int attack;
        protected string Name { get { return name; } set { name = value; } }
        protected int Hp 
        { 
            get { return hp; } 
            set 
            { 
                if (value < 0)
                    hp = 0;
                else
                    hp = value; 
            } 
        }
        protected int Attack { get { return attack; } set { attack = value; } }
        public Character(string name, int hp, int atk)
        {
            Name = name;
            Hp = hp;
            Attack = atk;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"이름: {Name}, 체력: {Hp}, 공격력: {Attack}");
        }
        public virtual void Skill() { }
    }
    class Warrior : Character
    {
        public Warrior(string name) : base(name, 120, 15) { }
        public override void Skill()
        {
            Console.WriteLine("강력한 근접 공격!");
        }
    }
    class Mage : Character
    {
        public Mage(string name) : base(name, 80, 25) { }
        public override void Skill()
        {
            Console.WriteLine("화염 폭발!");
        }
    }
    class Thief : Character
    {
        public Thief(string name) : base(name, 90, 20) { }
        public override void Skill()
        {
            Console.WriteLine("은신술 발동!!");
        }
    }
    // 1-2
    class Reward
    {
        private string name;
        protected string Name { get { return name; } set { name = value; } }
        public Reward(string name)
        {
            Name = name;
        }
        public virtual void PrintInfo()
        {
            Console.Write("보상: ");
        }
    }
    class GoldReward : Reward
    {
        private int amount;
        public GoldReward(string name) : base(name)
        {
            amount = 100;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("골드 상자");
        }
        public void Give()
        {
            Console.WriteLine($"골드 {amount} 획득!");
        }
    }
    class ExpReward : Reward
    {
        private int exp;
        public ExpReward(string name) : base(name)
        {
            exp = 50;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("경험치 책");
        }
        public void Gain()
        {
            Console.WriteLine($"경험치 {exp} 획득!");
        }
    }
    internal class Day13_HW_1
    {
    }
}
