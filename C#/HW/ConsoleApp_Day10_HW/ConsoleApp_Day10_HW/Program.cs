namespace ConsoleApp_Day10_HW
{
    /**********************************************
    [과제]
        승급 과제(Silver)
    1. 열거형을 활용한 직업 선택 구현
    2. 구조체를 활용한 학생 점수 비교하기
    **********************************************/
    internal class Program
    {
        // 과제 1
        enum Jop { Warrior = 1, Mage, Rogue }
        static void SelectJop(int x, ref Jop j)
        {
            switch (x)
            {
                case 1:
                    j = Jop.Warrior;
                    break;
                case 2:
                    j = Jop.Mage;
                    break;
                case 3:
                    j = Jop.Rogue;
                    break;
                default:
                    break;
            }
        }
        // 과제 2
        struct Student { public string name; public int score; }
        static void CheckScore(Student student1, Student student2)
        {
            Student tmp = new Student();
            
            Console.WriteLine($"학생 1: {student1.name}, 점수: {student1.score}");
            Console.WriteLine($"학생 2: {student2.name}, 점수: {student2.score}");

            if (student1.score == student2.score)
                Console.WriteLine("두 학생의 점수가 같습니다.");
            else
            {
                if (student1.score > student2.score)
                    tmp = student1;
                else if (student1.score < student2.score)
                    tmp = student2;

                Console.WriteLine($"점수가 더 높은 학생은 {tmp.name}입니다!");
            }
        }
        static void Main(string[] args)
        {
            // 과제 1
            Console.WriteLine("===== 과제 1 =====");
            Jop jop = new Jop();
            bool isSelect = false;

            while (!isSelect)
            {
                Console.Write("직업을 선택하세요 (1: 전사, 2: 마법사, 3: 도적): ");
                string inputJop = Console.ReadLine();
                int inputNum = int.Parse(inputJop);
                SelectJop(inputNum, ref jop);
                isSelect = true;
                if (inputNum < 1 || inputNum > 3)
                {
                    Console.WriteLine("잘못 입력했습니다.");
                    isSelect = false;
                }
            }
            switch (jop)
            {
                case Jop.Warrior:
                    Console.WriteLine("당신은 전사를 선택했습니다!\n특징: 뛰어난 생존 능력을 가지고 있습니다.");
                    break;
                case Jop.Mage:
                    Console.WriteLine("당신은 마법사를 선택했습니다!\n특징: 강력한 마법으로 원거리 공격이 가능합니다.");
                    break;
                case Jop.Rogue:
                    Console.WriteLine("당신은 도적을 선택했습니다!\n특징: 강력한 근접 공격이 가능합니다.");
                    break;
                default:
                    break;
            }
            Console.WriteLine();

            // 과제 2
            Console.WriteLine("===== 과제 2 =====");
            Student student1 = new Student();
            Student student2 = new Student();
            string inputScore;

            Console.Write("첫 번째 학생 이름 입력: ");
            student1.name = Console.ReadLine();
            Console.Write("첫 번째 학생 점수 입력: ");
            inputScore = Console.ReadLine();
            student1.score = int.Parse(inputScore);

            Console.Write("두 번째 학생 이름 입력: ");
            student2.name = Console.ReadLine();
            Console.Write("두 번째 학생 점수 입력: ");
            inputScore = Console.ReadLine();
            student2.score = int.Parse(inputScore);

            CheckScore(student1, student2);
            Console.WriteLine();
        }
    }
}
