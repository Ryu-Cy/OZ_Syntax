namespace ConsoleApp_Day14
{   /**************************************************
    [인터페이스]
    - 클래스가 구현해야 하는 메서드의 규약을 정의하는 것
    - 어떤 동작을 수행해야 하는지 정의만 하고 실제 구현은 하지 않음
    - 클래스가 특정 기능을 반드시 구현하도록 강제
    - 기능 단위로 나눠서 정의

    [특징]
    - 메서드의 구현이 없음
    - 메서드를 반드시 구현해야 한다는 규칙만 정의
    - 직접적인 코드가 없고, 자식 클래스에서 반드시 구현해야 함
    - 다중 상속이 가능하다.

    [사용]
    - 객체의 행동을 정의하는 것에 사용
    - 이 객체가 무엇을 할 수 있는가를 정의

    [인터페이스 vs 추상 클래스]
    특정 기능만 강제: 인터페이스
    공통된 기능을 제공하면서 일부 기능만 강제: 추상 클래스
    **************************************************/
    interface IAttackble
    {
        void Attack();
    }
    interface IDamageble
    {
        void TakeDamage(int damage);
    }
    class Warrior : IAttackble, IDamageble
    {
        public Warrior() { }
        public void Attack()
        {
            Console.WriteLine("기사가 강력한 공격을 한다.");
        }
        public void TakeDamage(int damage)
        {
            Console.WriteLine($"기사가 {damage}만큼 피해를 입었다.");
        }
    }
    internal class Program02
    {
        static void Main()
        {
            Warrior warrior = new Warrior();
            IAttackble warrior1 = new Warrior();
            warrior.Attack();
            warrior.TakeDamage(100);
            warrior1.Attack();
            //warrior1.TakeDamage(100);
            
            IAttackble[] attacker = new IAttackble[3];
            attacker[0] = new Warrior();
            attacker[1] = new Warrior();
            attacker[2] = new Warrior();
            for (int i = 0; i < attacker.Length; i++)
                attacker[i].Attack();
        }
    }
}
