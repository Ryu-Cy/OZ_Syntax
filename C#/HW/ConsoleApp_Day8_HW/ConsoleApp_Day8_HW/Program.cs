/*************************************
    == 과제 ==
    가위바위보 게임 만들기
*************************************/

using System.Data;

namespace ConsoleApp_Day8_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerWin = 0;
            int enemyWin = 0;
            int draw = 0;

            bool setMaxMoney = false;
            bool isBet = false;
            int myMoney = 0;
            int getBet = 0;

            // 소지금 체크
            while (!setMaxMoney)
            {
                Console.WriteLine("소지 금액을 입력하시오. (최소 100원)");
                string inputMoney = Console.ReadLine();
                myMoney = int.Parse(inputMoney);
                setMaxMoney = true;
                if (myMoney < 100)
                {
                    Console.WriteLine("금액이 모자랍니다.");
                    setMaxMoney = false;
                }
            }
            Console.WriteLine("");

            // 가위바위보 게임
            for (int i = 0; i < 5; i++)
            {
                // GameOver
                if (myMoney < 100)
                {
                    Console.WriteLine("\n소지금이 최소 베팅금보다 모자랍니다.");
                    break;
                }

                Console.WriteLine($"{i + 1} 번째 경기");

                // 베팅금 체크
                while (!isBet)
                {
                    Console.WriteLine("베팅할 금액을 입력해주세요. (베팅 최소 금액: 100원)");
                    string inputBet = Console.ReadLine();
                    getBet = int.Parse(inputBet);
                    isBet = true;
                    if (getBet < 100)
                    {
                        Console.WriteLine("베팅 금액이 모자랍니다.");
                        isBet = false;
                    }
                    else if (getBet > myMoney)
                    {
                        Console.WriteLine("소지 금액이 모자랍니다.");
                        isBet = false;
                    }
                }
                isBet = false;
                myMoney -= getBet;
                Console.WriteLine($"현재 소지금: {myMoney}, 베팅금: {getBet}");
                Console.WriteLine("무엇을 낼지 선택하시오. (1. 가위, 2. 바위, 3. 보)");
                string input = Console.ReadLine()!;
                int getNum = int.Parse(input);

                Random Enemy = new Random();
                int getEnemyNum = Enemy.Next(3);

                //  게임 로직
                if (getNum == 1)        // P가위
                {
                    Console.WriteLine("Player: 가위");
                    if (getEnemyNum == 0)       // E가위
                    {
                        Console.WriteLine("Enemy: 가위");
                        Console.WriteLine("무승부");
                        myMoney += getBet;
                        draw++;
                    }
                    else if (getEnemyNum == 1)  // E바위
                    {
                        Console.WriteLine("Enemy: 바위");
                        Console.WriteLine("EnemyWin");
                        enemyWin++;
                    }
                    else if (getEnemyNum == 2)  // E보
                    {
                        Console.WriteLine("Enemy: 보");
                        Console.WriteLine("PlayerWin");
                        myMoney += getBet * 2;
                        playerWin++;
                    }
                }
                else if (getNum == 2)   // P바위
                {
                    Console.WriteLine("Player: 바위");
                    if (getEnemyNum == 0)       // E가위
                    {
                        Console.WriteLine("Enemy: 가위");
                        Console.WriteLine("PlayerWin");
                        myMoney += getBet * 2;
                        playerWin++;
                    }
                    else if (getEnemyNum == 1)  // E바위
                    {
                        Console.WriteLine("Enemy: 바위");
                        Console.WriteLine("무승부");
                        myMoney += getBet;
                        draw++;
                    }
                    else if (getEnemyNum == 2)  // E보
                    {
                        Console.WriteLine("Enemy: 보");
                        Console.WriteLine("EnemyWin");
                        enemyWin++;
                    }
                }
                else if (getNum == 3)   // P보
                {
                    Console.WriteLine("Player: 보");
                    if (getEnemyNum == 0)       // E가위
                    {
                        Console.WriteLine("Enemy: 가위");
                        Console.WriteLine("EnemyWin");
                        enemyWin++;
                    }
                    else if (getEnemyNum == 1)  // E바위
                    {
                        Console.WriteLine("Enemy: 바위");
                        Console.WriteLine("PlayerWin");
                        myMoney += getBet * 2;
                        playerWin++;
                    }
                    else if (getEnemyNum == 2)  // E보
                    {
                        Console.WriteLine("Enemy: 보");
                        Console.WriteLine("무승부");
                        myMoney += getBet;
                        draw++;
                    }

                }
                else
                {
                    i--;
                    myMoney += getBet;
                    Console.WriteLine("잘못 입력하셨습니다.");
                }
                if (myMoney < 0)
                    myMoney = 0;
                Console.WriteLine($"현재 소지금: {myMoney}\n");
            }
            Console.WriteLine("\n=== 최종 결과 ===");
            Console.WriteLine($"플레이어: {playerWin}승, 적: {enemyWin}승, 무승부: {draw}회, 소지금: {myMoney}");
        }
    }
}
