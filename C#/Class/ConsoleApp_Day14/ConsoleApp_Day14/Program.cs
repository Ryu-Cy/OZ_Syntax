namespace ConsoleApp_Day14
{   /**************************************************
    [추상 클래스(abstractClass)]
    - 객체를 직접 생성할 수 없고, 구체적인 내용이 일부 또는 전혀 없는 클래스
    - 공통 기능을 제공하면서 특정 기능은 자식이 반드시 구현하게 만드는 상속용 클래스
    - 공통적인 기능을 정의하고 자식 클래스가 이를 상속 받아 구현하도록 강제하는 역할
    - 자식 클래스가 반드시 구현해야 하는 메서드(추상 메서드)를 포함할 수 있음
    - 일반 메서드와 추상 메서드를 함께 가질 수 있다.
    - 객체의 일관성을 유지하면서 유연하게 확장 가능하다.
    - 공통된 기능을 한 곳에서 관리하므로 중복 코드를 줄이고 유지보수성을 높일 수 있다.

    [추상 메서드 vs 가상 메서드]
    - 추상 메서드: 반드시 자식에 구현해야함.
    - 가상 메서드: 선택적 재정의
    **************************************************/
    abstract class Animal
    {
        protected string Name { get; set; }

        public Animal(string name) { Name = name; }
        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 음식을 맛있게 먹는다");
        }
        public abstract void MakeSound();
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: 멍멍");
        }
    }
    class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: 야옹");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal("동물");     추상 클래스이기에 객체 생성 불가
            Animal dog = new Dog("개");
            Animal cat = new Cat("고양이");
            dog.Eat();
            dog.MakeSound();
            cat.Eat();
            cat.MakeSound();
        }
    }
}
