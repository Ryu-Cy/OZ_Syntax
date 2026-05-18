namespace ConsoleApp_Day11
{   /******************************************************
    [접근 제한자 (접근 제한 지정자)]
    - 클래스, 필드, 메서드, 프로퍼티 등에 접근할 수 있는 범위를 결정하는 키워드
    - 접근 제한자를 적절히 사용한 캡슐화(Encapsulation)를 통해 데이터를 보호하고, 필요한 부분만 공개
    - 클래스 내부의 변수에 접근 제한자를 선언하지 않으면 디폴트로 private 지정이 된다.
    
    [자주 사용되는 접근 제한자]
    - public: 어디서든 접근 허용    -    외부에 공개해야 하는 기능을 만들 때 사용 ex)생성자, 메서드 선언
    - private: 클래스 내부에서만 접근 허용    -    ㅁㄴㅇ
    - protected: 현재 클래스 + 상속 받은 클래스에서 접근 허용    -    ㅁㄴㅇ
    
    [그 외 접근 제한자]
    - internal: 같은 프로젝트에서만 접근 허용
    - protected internal: 같은 프로젝트 + 모든 프로젝트 내에서 상속 받은 클래스에서 접근 허용
    - private protected: 같은 클래스 + 같은 프로젝트 내에서 상속받은 클래스에서 접근 허용


    * 헷갈리면 변수는 private, 메서드는 public을 사용
    ******************************************************/
    class Character
    {
        public string name = "홍길동";
        private int level = 1;
        protected int health = 100;
        public void SetLevel(int newLevel)
        {
            if (newLevel > 0)
            {
                level = newLevel;
            }
        }
        public void ShowLevel()
        {
            Console.WriteLine($"현재 레벨: {level}");
        }
    }
    class Warrior : Character   // Warrior(자식) 클래스에 Character(부모) 클래스 상속
    {
        public void TakeDamage()
        {
            health -= 10;   // 상속 받은 자식 클래스이기에 protected 변수 접근 가능
            Console.WriteLine($"남은 체력: {health}");
        }
    }
    internal class Program02
    {
        static void Main()
        {
            Character player = new Character();
            Console.WriteLine(player.name);
            // player.level = 10;   Character 클래스 안의 level 변수는 private 지정을 해주었기에 접근 불가능
            player.SetLevel(10);    // Character 클래스 안의 public 메서드이기에 접근 가능하고, 내부 메서드이기에 level 변수에 접근 가능
            player.ShowLevel();
            Warrior warrior = new Warrior();
            // warrior.health = 100;    // protected 지정해둔 변수이기에 상속 받은 클래스 내부에서만 접근이 가능하므로 접근 불가능
            warrior.TakeDamage();
        }
    }
}
