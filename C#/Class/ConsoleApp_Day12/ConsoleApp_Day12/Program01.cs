namespace ConsoleApp_Day12
{   /*************************************************
    [생성자(Constructor)]
    - 객체를 생성할 때 자동으로 호출되는 메서드
    - 객체의 초기 상태를 설정하는 역할
    - 클래스 이름과 동일하고 반환형이 없다.
    - 사용자 정의 생성자가 없으면 디폴트 생성자 호출
    *************************************************/
    class Character
    {
        private string name;
        private int level;
        public Character()
        {   // 생성자는 항상 public 지정
            name = "초보자"; level = 1;
            Console.WriteLine($"캐릭터가 생성되었습니다.");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Level { get { return level; } set { level = value; } }
    }
    // 생성자 오버로딩
    class Character1
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Character1()
        {
            Name = "초보자"; Level = 1;
            Console.WriteLine("기본 캐릭터가 생성되었다.");
        }
        public Character1(string name)
        {
            Name = name; Level = 1;
            Console.WriteLine($"이름이 {Name}인 캐릭터가 생성되었다.");
        }
        public Character1(string name, int level)
        {
            Name = name; Level = level;
            Console.WriteLine($"이름이 {Name}이고 레벨이{Level}인 캐릭터가 생성되었다.");
        }
    }
    /*
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Player(string name, int lavel)
        {
            Name = name; Level = lavel;
        }
        public Player(string name)
        {
            Name= name; Level = 1;
        }
    }
    */
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Player(string name, int lavel)
        {
            Name = name; Level = lavel;
        }
        public Player(string name) : this (name, 1)
        {
            Console.WriteLine("good");
        }

    }
    internal class Program01
    {
        static void Main()
        {
            Character player = new Character();
            Console.WriteLine($"이름: {player.Name}, 레벨: {player.Level}");
            // 생성자 없이 값을 하나씩 할당하는 방식
            // 값 수정마다 할당
            player.Name = "중급자";
            player.Level = 10;
            Console.WriteLine($"이름: {player.Name}, 레벨: {player.Level}");
            

            Character1 player1 = new Character1();
            Character1 player2 = new Character1("중급자");
            Character1 player3 = new Character1("상급자", 50);


            Player p = new Player("홍길동");
        }
    }
}
