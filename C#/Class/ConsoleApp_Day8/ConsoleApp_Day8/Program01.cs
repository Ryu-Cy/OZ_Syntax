/*************************************
[C++때 배운 것들 C#에서 해보기]

=====================================

[Random Class]
- new라는 키워드를 통해 객체 생성
*************************************/

using System.Collections.Specialized;
using System.Data.Common;
using System.Formats.Tar;
using System.Xml.Schema;

namespace ConsoleApp_Day8
{
    internal class Program01
    {
        static void Main(string[] args)
        {
            /*
            int num = 1;
            switch (num)    // break 필수
            {
                case 0:
                    Console.WriteLine("첫 번째");
                    break;
                case 1:
                    Console.WriteLine("두 번째");
                    break;
            }
            */

            /*
            int power = 0;
            Console.WriteLine("=== 훈련소 입소 ===");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{i} 번째 목검 휘두르기");
                power += 10;

                if (i == 3)
                {
                    Console.WriteLine("스승님이 나타나 비법을 전수했다.");
                    power += 20;
                }
            }
            Console.WriteLine("\n 훈련이 끝났다. 배울 기술을 선택하시오.");
            Console.WriteLine("번호 입력 (1. 불, 2. 물, 3. 바람) : ");
            string input = Console.ReadLine();

            string skillName = "";

            switch (input)
            {
                case "1":
                    skillName = "화염참";
                    break;
                case "2":
                    skillName = "냉기참";
                    break;
                case "3":
                    skillName = "회오리";
                    break;
            default:
                    skillName = "기본 공격";
                    break;
            }

            Console.WriteLine("\n=== 최종 캐릭터 정보 ===");
            Console.WriteLine($"최종 공격력: {power}");
            Console.WriteLine($"배운 기술: {skillName}");
            */

            /*
            Random random = new Random();
            int num1 = random.Next();       // 0~int.MaxValue
            int num2 = random.Next(10);     // 0이상 10미만, 0~9
            int num3 = random.Next(5, 15);  // 5이상 15미만, 5~14
            Console.WriteLine($"num1: {num1}, num2: {num2}, num3: {num3}");
            */


            Random randDmg = new Random();
            Console.WriteLine("몬스터를 처치할 때까지 공격");
            int count = 0;
            bool isDead = false;

            while (isDead)
            {
                count++;
                int damage = randDmg.Next(1, 11);
                Console.WriteLine($"{count} 번째 공격! 대미지: {damage}");
                if (damage >= 8)
                {
                    Console.WriteLine("몬스터를 물리쳤다!");
                    isDead = true;
                }
            }
        }
    }
}
