namespace ConsoleApp_Day15
{   /************************************************
    [다운 캐스팅]
    - 부모 타입으로 참조 주인 객체를 다시 자식 타입으로 변환
    - 부모 -> 자식으로 변환
    - 명시적 변환이 필요함.
    - 자식 클래스에 있는 기능 호출 가능
    - 불안전 변환

    [키워드]
    - is: 실패하면 false반환, 성공하면 변환
    - as: 실패하면 NULL 저장, 성공하면 주소값 저장
    ************************************************/
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 낸다.");
        }
    }
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍");
        }
    }
    internal class Program01
    {
        static void Main()
        {
            Animal animal = new Dog();  //Up
            Dog dog = (Dog)animal;      //Down
            dog.Bark();     //자식 객체의 기능 사용 가능
            dog.Speak();

            //is
            Animal animal1 = new Dog();
            if (animal1 is Dog dog1)
                dog1.Bark();

            //as
            Animal animal2 = new Dog();
            Dog dog2 = animal2 as Dog;
            if (dog2 != null)
                dog2.Bark();

            //잘못 된 다운 캐스팅
            Animal animal3 = new Animal();
            Dog dog3 = (Dog)animal3;
        }
    }
}
