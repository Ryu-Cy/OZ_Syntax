namespace ConsoleApp_Day11_HW
{   /******************************************************
    [선택 과제]
    1. 월남뽕 게임 만들기
    ******************************************************/
    internal class Select
    {
        static void FisherYatesShuffle(int[] array, bool[] check)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                // i까지의 범위에서 무작위 인덱스를 선택
                int j = random.Next(0, i + 1);

                // 현재 요소와 무작위 요소를 교환
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                bool tempb = check[i];
                check[i] = check[j];
                check[j] = tempb;
            }
            for (int i = 0; i < 3; i++)
            {
                if (check[i] == true)
                {
                    for (int j = array.Length - 1; j > 0; j--)
                    {
                        if (check[j] == false)
                        {
                            int tmp;
                            tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                            bool tmpb;
                            tmpb = check[i];
                            check[i] = check[j];
                            check[j] = tmpb;
                        }
                    }
                }
            }

            //return array;
        }
        static void Main(string[] args)
        {
            int[] deckArr = new int[52];
            bool[] deckArrCheck = Enumerable.Repeat(false, 52).ToArray();
            int[] deckArrOpen = new int[3];
            int useCard = 0;
            int myMoney = 10000;
            bool isBetCheck = false;
            string inputBetting = "";
            // 덱 세팅
            for (int i = 0; i < deckArr.Length; i++)
            {
                deckArr[i] = i + 1;
            }
            while (true)
            {
                // 덱 셔플
                FisherYatesShuffle(deckArr, deckArrCheck);
                // 사용한 카드 체크
                for (int i = 0; i < 3; i++)
                {
                    deckArrCheck[i] = true;
                }
                // 사용한 카드 수 체크
                useCard = 0;
                for (int i = 0; i < deckArrCheck.Length; i++)
                {
                    if (deckArrCheck[i] == true)
                    {
                        useCard += 1;
                    }
                }
                // 카드 3장 출력 // 베팅 전
                for (int i = 0; i < deckArrOpen.Length - 1; i++)
                {
                    if (deckArr[i] >= 1 && deckArr[i] <= 13)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♠A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♠J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♠Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♠K\t");
                        else
                            Console.Write($"♠{deckArrOpen[i]}\t");
                    }
                    else if (deckArr[i] > 13 && deckArr[i] <= 26)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♣A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♣J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♣Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♣K\t");
                        else
                            Console.Write($"♣{deckArrOpen[i]}\t");

                    }
                    else if (deckArr[i] > 26 && deckArr[i] <= 39)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"◆A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"◆J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"◆Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"◆K\t");
                        else
                            Console.Write($"◆{deckArrOpen[i]}\t");

                    }
                    else if (deckArr[i] > 39 && deckArr[i] <= 52)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♥A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♥J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♥Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♥K\t");
                        else
                            Console.Write($"♥{deckArrOpen[i]}\t");

                    }

                }
                Console.Write("#\n");
                // 베팅
                while (!isBetCheck)
                {
                    Console.WriteLine($"내가 가진 시드머니: {myMoney}");
                    Console.Write("배팅액을 입력하시오! (베팅 최소금액: 1000): ");
                    inputBetting = Console.ReadLine();
                    isBetCheck = true;
                    if (!int.TryParse(inputBetting, out int typeCheck))
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                        isBetCheck = false;
                    }
                    else if (int.Parse(inputBetting) < 1000)
                    {
                        Console.WriteLine("베팅 최소 금액이 모자랍니다.");
                        isBetCheck = false;
                    }
                }

                Console.Clear();

                // 베팅 후
                for (int i = 0; i < deckArrOpen.Length; i++)
                {
                    if (deckArr[i] >= 1 && deckArr[i] <= 13)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♠A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♠J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♠Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♠K\t");
                        else
                            Console.Write($"♠{deckArrOpen[i]}\t");
                    }
                    else if (deckArr[i] > 13 && deckArr[i] <= 26)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♣A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♣J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♣Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♣K\t");
                        else
                            Console.Write($"♣{deckArrOpen[i]}\t");

                    }
                    else if (deckArr[i] > 26 && deckArr[i] <= 39)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"◆A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"◆J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"◆Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"◆K\t");
                        else
                            Console.Write($"◆{deckArrOpen[i]}\t");

                    }
                    else if (deckArr[i] > 39 && deckArr[i] <= 52)
                    {
                        deckArrOpen[i] = deckArr[i] % 13;
                        if (deckArrOpen[i] == 0)
                            deckArrOpen[i] = 13;
                        if (deckArrOpen[i] == 1)
                            Console.Write($"♥A\t");
                        else if (deckArrOpen[i] == 11)
                            Console.Write($"♥J\t");
                        else if (deckArrOpen[i] == 12)
                            Console.Write($"♥Q\t");
                        else if (deckArrOpen[i] == 13)
                            Console.Write($"♥K\t");
                        else
                            Console.Write($"♥{deckArrOpen[i]}\t");

                    }

                }
                Console.WriteLine($"\n내가 가진 시드머니: {myMoney}");
                Console.WriteLine($"배팅액: {int.Parse(inputBetting)}");
                // 승패 판단
                if ((deckArrOpen[0] < deckArrOpen[1] && deckArrOpen[1] < deckArrOpen[2])
                    || (deckArrOpen[0] > deckArrOpen[1] && deckArrOpen[1] > deckArrOpen[2]))
                {   // win
                    myMoney += int.Parse(inputBetting);
                    Console.WriteLine($"{int.Parse(inputBetting)}원을 획득했다.");
                }
                else
                {   // lose
                    myMoney -= int.Parse(inputBetting);
                    if (myMoney < 0)
                        myMoney = 0;
                    Console.WriteLine($"{int.Parse(inputBetting)}원을 잃었다.");
                }
                // 남은 카드 수 출력
                Console.WriteLine($"현재까지 사용한 카드 수: {useCard}\n");
                if (myMoney < 1000)
                    break;
                if (deckArr.Length - useCard < 3)
                    break;
                isBetCheck = false;
            }
            if (myMoney < 1000)
                Console.WriteLine($"소지 금액이 모자라 게임이 종료되었습니다.\n남은 소지금액: {myMoney}");
            if (deckArr.Length - useCard < 3)
                Console.WriteLine($"남은 카드가 모자라 게임이 종료되었습니다.\n남은 소지금액: {myMoney}, 남은 카드 수: {deckArr.Length - useCard}");
        }
    }
}
