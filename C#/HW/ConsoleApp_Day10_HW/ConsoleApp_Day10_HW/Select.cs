namespace ConsoleApp_Day10_HW
{
    /**********************************************
    [과제]
        선택 과제
    1. 몬스터 이름 길이 출력
    2. 전투 로그 단어 위치 찾기
    3. 채팅 욕설 필터(*처리)
    4. 문자열 뒤집기
    **********************************************/
    internal class Select
    {
        // 과제 4
        // ToCharArray() + Array.Reverse() 사용
        static string ReverseString(string input)
        {
            char[] tmp = input.ToCharArray();
            Array.Reverse(tmp);
            return new string(tmp);
        }
        // for loop 사용
        static string ReverseString_for(string input)
        {
            char[] tmp1 = input.ToCharArray();
            char[] tmp2 = new char[tmp1.Length];
            int j = 0;
            for (int i = tmp1.Length - 1; i >= 0; i--)
            {
                tmp2[j] = tmp1[i];
                j++;
            }
            return new string(tmp2);
        }
        static void Main()
        {
            // 과제 1
            Console.WriteLine("===== 과제 1 =====");
            Console.Write("몬스터 이름을 입력하세요: ");
            string inputEnemyName = Console.ReadLine();

            Console.WriteLine($"몬스터 이름 '{inputEnemyName}'은 {inputEnemyName.Length}글자입니다.");
            Console.WriteLine();

            // 과제 2
            Console.WriteLine("===== 과제 2 =====");
            string battleRogStr = "Player hits Orc for 10 damage";
            bool isCheck = false;
            Console.WriteLine(battleRogStr);

            while (!isCheck)
            {
                isCheck = true;
                Console.Write("찾을 단어를 입력하세요: ");
                string inputFindWord = Console.ReadLine();

                if (battleRogStr.IndexOf(inputFindWord) == -1)
                {
                    Console.WriteLine($"{inputFindWord}는 없는 단어입니다.");
                    isCheck = false;
                }
                else
                    Console.WriteLine($"{inputFindWord}는 {battleRogStr.IndexOf(inputFindWord)}번째 인덱스에서 시작합니다.");
            }
            Console.WriteLine();

            // 과제 3
            Console.WriteLine("===== 과제 3 =====");
            Console.Write("채팅을 입력하세요: ");
            string inputChat = Console.ReadLine();

            Console.WriteLine(inputChat.Replace("바보", "***"));
            Console.WriteLine();

            // 과제 4
            Console.WriteLine("===== 과제 4 =====");
            Console.Write("문자열을 입력하세요: ");
            string inputStr = Console.ReadLine();

            Console.WriteLine($"뒤집은 결과: {ReverseString(inputStr)}");
            Console.WriteLine($"뒤집은 결과: {ReverseString_for(inputStr)}");

        }
    }
}
