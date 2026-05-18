using System.ComponentModel;
using System.Net;

namespace ConsoleApp_Day18
{   /***********************************************
    [제네릭 제약]
    - 일반화 자료형을 선언할 때 제약 조건을 전언하여 사용 당시 쓸 수 있는 자료형을 제한
    - 불필요한 타입이 들어가는 것을 방지하고, 원하는 기능을 보장하는 데 유용
    - 제네릭 타입 제한 where T: 조건 형식으로 사용하며, 여러 개를 조합할 수도 있다.

    제네릭은 타입을 나중에 결정하는 문법인데, 아무 타입이나 들어오면 문제가 생길 수 있다.

    [구조 안전성]
    - 제약이 없으면 이상한 타입 사용, 잘못된 객체 전달, 런타임 오류 발생 가능성
    - 따라서 제약으로 사용 가능한 타입 범위를 제한
    ***********************************************/
    internal class Program
    {
        // 내가 만든 클래스만 가능이라는 뜻이 아니라 참조 타입 전체라는 뜻
        class ReferenceOnly<T> where T : class 
        {
            public T Data { get; set; }
            public ReferenceOnly(T data)
            {
                this.Data = data;
            }
        }
        // 값 타입만 허용하고, string, class 등 참조타입 불가
        class valueOnly<T> where T : struct  
        {
            public T Data { get; set; }
            public valueOnly(T data)
            {
                this.Data = data;
            }
        }
        // 매개변수가 없는 public 기본 생성자가 있는 타입만 가능
        class Factory<T> where T : new() 
        {
            public T CreateInstance()
            {
                return new T();
            }
        }
        class Player
        {
            public string Name { get; set; } = "홍길동";
        }
        // 상속받은 객체만 가능
        class Character
        {
            public string Name { get; set; }
        }
        class Warrior : Character
        {

        }
        class Mage
        {

        }
        class CharacterManager<T> where T : Character
        {
            public void PrintName(T character)
            {
                Console.WriteLine(character.Name);
            }
        }
        // GameObject, IDamageble 두 가지를 모두 상속받은 객체만 들어올 수 있다.
        class GameObject
        {

        }
        interface IDamageble
        { 
            void TakeDamage();
        }
        class Enemy : GameObject, IDamageble
        {
            public void TakeDamage()
            {
                Console.WriteLine("대미지 출력!");
            }
        }
        class DamageHandler<T> where T : GameObject, IDamageble
        {
            public void ApplyDamage(T obj)
            {
                obj.TakeDamage();
            }
        }
        // 클래스 상속은 안 하고 인터페이스만 상속 받았으면 가능
        interface IAttackable
        {
            void Attack();
        }
        class Monster : IAttackable
        { 
            public void Attack()
            {

            }
        }
        class Attacker<T> where T : IAttackable
        {
            public void Att(T att)
            {
                att.Attack();
            }
        }
        //
        class InsterfaceT<T> where T : IComparable
        {

        }

        static void Main(string[] args)
        {
            ReferenceOnly<string> refInstance = new ReferenceOnly<string>("Hello");
            valueOnly<int> valueInstance = new valueOnly<int>(100);

            Factory<Player> factory = new Factory<Player>();

            Player p = factory.CreateInstance();
            CharacterManager<Character> c1 = new CharacterManager<Character>();
            CharacterManager<Warrior> c2 = new CharacterManager<Warrior>();
            //CharacterManager<Mage> c3 = new CharacterManager<Mage>(); Mage는 Characger 상속x

            DamageHandler<Enemy> enemy = new DamageHandler<Enemy>();
            
            Attacker<Monster> monster = new Attacker<Monster>();

            InsterfaceT<int> insterfaceT = new InsterfaceT<int>();  // int는 IComparable 구현이 되어있어서 가능
        }
    }
}
