using System.Net.Http.Headers;

namespace ConsoleApp_Day17_HW
{   /************************************************
        [과제 - List]
    1. 평균값 구하기
    2. 배열 두 배 만들기
    3. 중복된 숫자 개수 구하기
    ************************************************/
    class MathUtils
    {
        // 1-1
        public static double GetAverage(List<int> numbers)
        {
            // 제한 사항
            // 0 <= List원소 값 <= 1,000
            // 1 <= List 길이 <= 100
            if (numbers.Max() > 1000 || numbers.Min() < 0)
                return 0;
            if (numbers.Count < 1 || numbers.Count > 100)
                return 0;

            double sum = 0;
            double ave = 0.0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            ave = sum / numbers.Count;
            if (ave - (int)ave == 0.5 
                || ave - (int)ave == 0.0)
            {
                return ave;
            }
            return 0;
        }
        // 1-2
        public static List<int> GetDoubleList(List<int> numbers)
        {
            // 제한 사항
            // 10,000 <= List원소 값 <= 10,000     >>>>> 무슨 조건이지??
            // 1 <= List 길이 <= 1,000
            if (numbers.Count < 1 || numbers.Count > 1000)
                return new List<int>();

            List<int> result = new List<int>(numbers.Count);
            for (int i = 0;i < numbers.Count;i++)
            {
                result.Add(numbers[i] * 2);
            }
            return result;
        }
        // 1-3
        public static int GetDuplicateCount(List<int> arr, int n)
        {
            // 제한 사항
            // 0 <= List원소 값 <= 1000
            // 1 <= List 길이 <= 100
            // 0 <= n <= 1,000
            if (arr.Max() > 1000 || arr.Min() < 0)
                return 0;
            if (arr.Count < 1 || arr.Count > 100)
                return 0;
            if (n < 0 || n > 1000)
                return 0;

            int count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == n)
                    count++;
            }
            return count;
        }
    }
}
