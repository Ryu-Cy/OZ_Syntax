using System.ComponentModel;

namespace ConsoleApp_Day10
{
    /**********************************************
    [열거형(enum)]
    - 관련된 상수들을 묶어서 관리할 수 있는 데이터 타입.
    - 가독성 향상
    - 각 상수는 0부터 시작하며 명시적으로 값을 지정할 수도 있다.

    ex) - 캐릭터의 상태(Idle, Jump, Run, ...) 등
        - UI요소의 상태(Enabled, Disabled, Hidden, ...) 등
    **********************************************/
    enum CharacterStatus
    {
        None = 0,
        Idle,
        Walking,
        Running,
        Attack
    }
    struct CharacterInfo
    {
        public string name;
        public CharacterStatus status;
    }

    enum ItemType { Weapon, Armor, Potion }
    struct Item
    {
        public string name;
        public ItemType type;
        public int value;

        public void Print()
        {
            Console.WriteLine($"[{type}] {name}(위력 / 방어: {value})");
        }
    }
    internal class Program02
    {
        enum GameState
        {
            None,       // 열거형 멤버에 정수값을 지정하지 않을 경우 0부터 시작
            Start,      // 위와 같은 이유로 1번
            Playing,    // 2
            Paused,     // 3
            Gameover = 20,   // 열거형 멤버에 정수값을 지정해주어 20번
            Length      // 이전 멤버가 20번이었으니 21번
        }
        enum Direction
        {
            Up, Down, Left, Right
        }
        enum Color
        {
            Red, Greem, Blue
        }
        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        static void Main()
        {
            Console.WriteLine(GameState.Start);
            Console.WriteLine((int)GameState.Playing);
            Console.WriteLine((int)GameState.Length);

            Direction dir = Direction.Up;
            switch (dir)
            {
                case Direction.Up:
                    Console.WriteLine("캐릭터가 위쪽으로 이동");
                    break;
                case Direction.Down:
                    Console.WriteLine("캐릭터가 아래쪽으로 이동");
                    break;
                case Direction.Left:
                    Console.WriteLine("캐릭터가 왼쪽으로 이동");
                    break;
                case Direction.Right:
                    Console.WriteLine("캐릭터가 오른쪽으로 이동");
                    break;
                default:
                    break;
            }

            Item mySword;
            mySword.name = "집행검";
            mySword.type = ItemType.Weapon;
            mySword.value = 10;
            mySword.Print();

            Item myPotion = new Item
            {
                name = "빨강물약",
                type = ItemType.Potion,
                value = 20
            };
            myPotion.Print();
        }
    }
}
