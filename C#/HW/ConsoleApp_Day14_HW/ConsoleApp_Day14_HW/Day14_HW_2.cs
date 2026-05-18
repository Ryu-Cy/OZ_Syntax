namespace ConsoleApp_Day14_HW
{   /**************************************************
    [과제]
    2. 인터페이스 과제
     2-1. 상호작용 오브젝트 만들기
     2-2. 추상 클래스와 인터페이스로 캐릭터 만들기
    **************************************************/
    // 2-1
    interface IInteractable
    {
        void Interact();
    }
    class Chest : IInteractable
    {
        public void Interact()
        {
            Console.WriteLine("상자를 열었다! 아이템 획득!");
        }
    }
    class Door : IInteractable
    {
        public void Interact()
        {
            Console.WriteLine("문을 열고 지나갔다!");
        }
    }
    class Npc : IInteractable
    {
        public void Interact()
        {
            Console.WriteLine("NPC와 대화를 시작했다!");
        }
    }
    // 2-2
    abstract class Character
    {
        private string name;
        private int hp;
        private int attackPower;
        protected string Name { get { return name; } private set { name = value; } }
        protected int Hp 
        { 
            get { return hp; } 
            private set
            {
                if (value < 0)
                    hp = 0;
                else
                    hp = value; 
            } 
        }
        protected int AttackPower 
        { 
            get { return attackPower; } 
            private set 
            { 
                if (value < 0)
                    attackPower = 0;
                else
                    attackPower = value; 
            } 
        }
        public Character(string name, int hp, int attackPower)
        {
            Name = name;
            Hp = hp;
            AttackPower = attackPower;
        }
        public void ShowStatus()
        {
            Console.WriteLine($"[ {Name} ], 체력: {Hp}, 공격력: {AttackPower}");
        }
        public void TakeDamage(int damage)
        {
            Hp -= damage * 2;
            Console.WriteLine($"{Name}이(가) {damage * 2} 피해를 입었습니다! (현재 체력: {Hp})");
        }
        public void Healed(int x)
        {
            Hp += x;
        }
        public int GetAttackPower()
        {
            return AttackPower;
        }
    }
    interface IAttackable
    {
        void Attack();
    }
    interface IHealable
    {
        void Heal();
    }
    class Warrior : Character, IAttackable
    {
        public Warrior(string name, int hp, int attackPower) : base(name, hp, attackPower)
        {

        }
        public void Attack()
        {
            Console.WriteLine($"{Name}이(가) 강력한 검 공격을 합니다! (공격력: {AttackPower})");
        }
    }
    class Mage : Character, IAttackable, IHealable
    {
        public Mage(string name, int hp, int attackPower) : base(name, hp, attackPower)
        {

        }
        public void Attack()
        {
            Console.WriteLine($"{Name}이(가) 파이어볼을 던졌습니다! (공격력: {AttackPower})");
        }
        public void Heal()
        {
            Healed(20);
            Console.WriteLine($"{Name}이(가) 체력을 회복했습니다! (현재 체력: {Hp})");
        }
    }
    internal class Day14_HW_2
    {
    }
}
