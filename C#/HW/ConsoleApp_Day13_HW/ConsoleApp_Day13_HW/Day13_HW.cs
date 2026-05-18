namespace ConsoleApp_Day13_HW
{   /****************************************************
    [과제]
    1. 클래스 상속
     1-1. 캐릭터 직업 만들기
     1-2. 퀘스트 보상 시스템 만들기
    2. 클래스 다형성 (오버라이딩)
     2-1. 스킬 사용 시스템 만들기
     2-2. 플레이어 스킬 사용 시스템 만들기
    ****************************************************/
    internal class Day13_HW
    {
        static void Main(string[] args)
        {
            // 과제 1
            // 1-1. 캐릭터 직업 만들기
            Console.WriteLine("===== 과제 1-1. 캐릭터 직업 만들기 =====");
            Character[] character = new Character[]
            {
                new Warrior("전사"),
                new Mage("마법사"),
                new Thief("도적")
            };
            Character warrior = new Warrior("전사");
            foreach (Character unit in character)
            {
                unit.PrintInfo();
                unit.Skill();
            }
            Console.WriteLine();
            // 1-2. 퀘스트 보상 시스템 만들기
            Console.WriteLine("===== 과제 1-2. 퀘스트 보상 시스템 만들기 =====");
            GoldReward gold = new GoldReward("골드");
            ExpReward exp = new ExpReward("경험치");
            gold.PrintInfo();
            gold.Give();
            exp.PrintInfo();
            exp.Gain();
            Console.WriteLine();

            // 과제 2
            // 2-1. 스킬 사용 시스템 만들기
            Console.WriteLine("===== 과제 2-1. 스킬 사용 시스템 만들기 =====");
            Skill[] skills = new Skill[]
            {
                new FireBall(),
                new Heal(),
                new Stealth()
            };
            foreach (Skill skill in skills)
            {
                skill.Use();
            }
            Console.WriteLine();
            // 2-2. 플레이어 스킬 사용 시스템 만들기
            Console.WriteLine("===== 과제 2-2. 플레이어 스킬 사용 시스템 만들기 =====");
            Player player = new Player("플레이어");
            bool isPlay = true;
            string inputSkillNum = "";
            while (isPlay)
            {
                bool isinputCheck = true;
                bool isCorrectNum = false;
                while (isinputCheck)
                {
                    if (!isCorrectNum)
                    {
                        Console.WriteLine("사용할 스킬을 선택하세요. (1: FireBall, 2: Heal, 3: Stealth, 0: Quit)");
                        inputSkillNum = Console.ReadLine();
                        if (!int.TryParse(inputSkillNum, out int typeCheck) ||
                            int.Parse(inputSkillNum) < 0 || int.Parse(inputSkillNum) > 3)
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                        }
                        else
                        {
                            isCorrectNum = true;
                            isinputCheck = false;
                        }
                    }
                }
                switch (int.Parse(inputSkillNum))
                {
                    case 0:
                        Console.WriteLine("종료합니다.");
                        isPlay = false;
                        break;
                    case 1:
                        player.UseSkill(new FireBall());
                        break;
                    case 2:
                        player.UseSkill(new Heal());
                        break;
                    case 3:
                        player.UseSkill(new Stealth());
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
