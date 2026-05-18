namespace ConsoleApp_Day15
{   /************************************************
    [캐스팅]
    - 상속 관계에서는 객체를 다양한 타입으로 바라볼 수 있다.

    [업 캐스팅]
    - 자식 객체를 부모 타입으로 참조하는 것
    - 자식 -> 부모 방향으로 변환
    - 자동 변환 가능
    - 안전한 변환
    - 부모 클래스에 정의되어 있는 기능만 호출 가능

    [핵심]
    - 실제 객체는 자식 객체 그대로임
    - 단지, 부모 타입 관점으로 바라보는 것
    - virtual/override는 실제 객체(자식) 기준으로 동작
    ************************************************/
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 낸다.");
        }
        public virtual void Eat()
        {
            Console.WriteLine("밥을 먹는다.");
        }
    }
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍");
        }
        public override void Eat()
        {
            Console.WriteLine("개가 밥을 맛있게 먹는다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Animal animal = dog;
            animal.Speak();
            animal.Eat();       //실제 객체(자식)의 메서드 호출
            //animal.Bark();    //Bark 메서드가 사라진 것이 아니라 부모 클래스 타입으로 바라보고 있기 때문에 못 찾는 것.
        }
    }
}
