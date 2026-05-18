namespace ConsoleApp_Day9_HW
{
    /**********************************************
        [도전 과제]
        숫자 야구 게임
    **********************************************/
    internal class Challenge
    {
        static int[] FisherYatesShuffle(int[] array)
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
            }

            return array;
        }
        static void Main()
        {
            int[] comArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bool isSet = false;
            bool isOut = false;
            int strike = 0;
            int ball = 0;
            int out_ = 0;
            int tmpOut = 0;

            while (true)
            {
                int[] inputArr = { 0, 0, 0 };

                // 컴퓨터 배열 체크
                if (!isSet)
                {
                    comArr = FisherYatesShuffle(comArr);
                    Console.WriteLine("컴퓨터가 낸 숫자: " + comArr[0] + ", " + comArr[1] + ", " + comArr[2]);
                    isSet = true;
                }
                // 플레이어 입력 체크
                for (int i = 0; i < inputArr.Length; i++)
                {
                    
                    Console.Write((i + 1) + " 번째 숫자를 입력하세요: ");
                    string tmp = Console.ReadLine();
                    inputArr[i] = int.Parse(tmp);
                    if (inputArr[i] > 0 && inputArr[i] < 10)
                    {
                        if (i != 0)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (inputArr[j] == inputArr[i])
                                {
                                    Console.WriteLine("중복된 숫자입니다.");
                                    i--;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력했습니다.");
                        i--;
                    }
                }
                // 결과 체크
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (inputArr[i] == comArr[i])
                        strike++;
                    else
                    {
                        for (int j = 0; j < inputArr.Length; j++)
                        {
                            if (comArr[i] == inputArr[j])
                            {
                                if (i != j)
                                    ball++;
                            }
                            else
                                tmpOut++;
                        }
                    }
                    if (tmpOut == 9)
                        isOut = true;
                }
                // 결과 출력
                if (isOut)
                {
                    out_++;
                    tmpOut = 0;
                    Console.WriteLine("아웃! 현재 아웃: " + out_);
                    if (out_ == 3)
                    {
                        Console.WriteLine("3아웃으로 게임 종료!");
                        break;
                    }
                    isOut = false;
                }
                else
                {
                    Console.WriteLine(ball + "볼, " + strike + "스트라이크");
                    if (strike == 3)
                        Console.WriteLine("\n삼진 아웃! 승리!");
                    break;
                }
            }
        }
    }
}
