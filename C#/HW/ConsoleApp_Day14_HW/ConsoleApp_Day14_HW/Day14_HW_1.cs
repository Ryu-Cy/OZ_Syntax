namespace ConsoleApp_Day14_HW
{   /**************************************************
    [과제]
    1. 추상 클래스
     1-1. 몬스터 전투 시스템
     1-2. 아이템 사용 시스템
    **************************************************/
    // 1-1
    abstract class Monster
    {
        protected string Name { get; private set; }
        protected int Hp { get; private set; }
        public Monster(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }
        public abstract void Attack();
        public void Print()
        {
            Console.WriteLine($"이름: {Name}, HP: {Hp}");
        }
    }
    class Goblin : Monster
    {
        public Goblin(string name, int hp) : base(name, hp) { }
        public override void Attack()
        {
            Console.WriteLine("고블린이 칼로 공격했다!");
        }
    }
    class Orc : Monster
    {
        public Orc(string name, int hp) : base(name, hp) { }
        public override void Attack()
        {
            Console.WriteLine("오크가 도끼로 공격했다!");
        }
    }
    class Dragon : Monster
    {
        public Dragon(string name, int hp) : base(name, hp) { }
        public override void Attack()
        {
            Console.WriteLine("드래곤이 불을 내뿜었다!");
        }
    }
    // 1-2
    abstract class Item
    {
        private int charges;
        protected string Name { get; private set; }
        protected int Charges 
        {
            get { return charges; }
            private set 
            {
                if (value < 0)
                    charges = 0;
                else
                    charges = value;
            } 
        }
        public Item(string name, int charges)
        {
            Name = name;
            Charges = charges;
        }
        public abstract void Use();
        public void Used()
        {
            Charges--;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"아이템: {Name}, 남은 사용 횟수: {Charges}");
        }
        public bool CanUse(int charges)
        {
            if (charges > 0)
                return true;
            else
                return false;
        }
    }
    class Potion : Item
    {
        public Potion(string name, int charges) : base(name, charges)
        {

        }
        public override void Use()
        {
            if (Charges > 0)
                Console.WriteLine("포션을 사용했다! 체력이 회복된다.");
            else
                Console.WriteLine("더 이상 사용할 수 없습니다.");
            if (CanUse(Charges))
                Used();
        }
    }
    class Scroll : Item
    {
        public Scroll(string name, int charges) : base(name, charges)
        {

        }
        public override void Use()
        {
            if (Charges > 0)
                Console.WriteLine("스크롤을 사용했다! 마법이 발동된다.");
            else
                Console.WriteLine("더 이상 사용할 수 없습니다.");
            if (CanUse(Charges))
                Used();
        }
    }
    class Bomb : Item
    {
        public Bomb(string name, int charges) : base(name, charges)
        {

        }
        public override void Use()
        {
            if (Charges > 0)
                Console.WriteLine("폭탄을 사용했다! 큰 피해를 입혔다.");
            else
                Console.WriteLine("더 이상 사용할 수 없습니다.");
            if (CanUse(Charges))
                Used();
        }
    }
    internal class Day14_HW_1
    {
    }
}
