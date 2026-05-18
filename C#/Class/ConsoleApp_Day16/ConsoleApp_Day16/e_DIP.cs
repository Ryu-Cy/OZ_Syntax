namespace ConsoleApp_Day16
{   /************************************************
    [D(DIP: Dependency Inversion Principle) - 의존성 역전 원칙]
    - 구체적인 클래스가 아닌 추상적인 인터페이스에 의존해야 한다.
    - 상위 모듈이 하위 모듈에 의존하지 않고, 추상화 된 인터페이스에 의존하도록 해야한다.
    - 하위 모듈은 상위 모듈의 구현에 의존하지 않고, 두 모듈이 추상화 된 인터페이스를 통해 연결되어야 한다.
    - 구체적인 구현에 의존하지 않고, 추상화에 의존하여 모듈간의 결합도를 줄인다.

    -- 직접 만들고 직접 사용하지 말고 인터페이스를 통해 연결하자

    상위 모듈: 게임 로직을 사용하는 쪽
    하위 모듈: 시제 기능을 구현하는 쪽
    추상화: 인터페이스
    ************************************************/
    // DIP 적용 전
    class Warrior
    {
        private Sword sword = new Sword();
        public void Attack()
        {
            sword.Use();
        }
    }
    class Sword
    {
        public void Use()
        {
            Console.WriteLine("검으로 공격");
        }
    }
    // DIP 적용 후
    interface IWeapon
    {
        void Use();
    }
    class NewSword : IWeapon
    {
        public void Use()
        {
            Console.WriteLine("검으로 공격");
        }
    }
    class NewBow : IWeapon
    {
        public void Use()
        {
            Console.WriteLine("활로 공격");
        }
    }
    class NewWarrior
    {
        private IWeapon weapon;
        public NewWarrior(IWeapon weapon)
        {
            this.weapon = weapon;
        }
        public void Attack()
        {
            weapon.Use();
        }
    }
    internal class _5_DIP
    {
        static void Main()
        {
            NewWarrior warrior = new NewWarrior(new NewSword());
            warrior.Attack();
            NewWarrior bowWarrior = new NewWarrior(new NewBow());
            bowWarrior.Attack();
        }
    }
}
