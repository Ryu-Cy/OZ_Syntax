using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Xml.Schema;

namespace ConsoleApp_Day17_HW
{   /************************************************
        [도전 과제]
    1. 최댓값 최솟값 제거하기
    2. 홀수만 골라 정렬하기
    3. 특정 점수 이상의 이름 찾기
    ************************************************/
    // 2-1
    class MathUtilsChallenge
    {
        public static List<int> DeleteMaxMin(List<int> numbers)
        {
            // 제한 사항
            // 3 <= List 길이
            if (numbers.Count < 3)
                return new List<int>();

            // 중복 값은 하나만 지우기 위해 for문 하나당 하나 지우고 빠져나오게 작성
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers.Max())
                {
                    numbers.Remove(numbers[i]);
                    break;
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers.Min())
                {
                    numbers.Remove(numbers[i]);
                    break;
                }
            }
            return numbers;
        }
        public static List<int> GetOddSort(List<int> numbers)
        {
            // 제한 사항
            // 1,000 <= List원소 값 <= 1,000     >>>>> 무슨 조건이지??
            // 1 <= List 길이 <= 1,000
            if (numbers.Count < 1 || numbers.Count > 1000)
                return new List<int>();

            List<int> result = new List<int>();
            for(int i = 0;i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    result.Add(numbers[i]);
                }
            }
            result.Sort();
            return result;
        }
        public static List<string> FindName(List<string> names, List<int> scores)
        {
            // 제한 사항
            // names.Count == scores.Count
            // 0 <= 점수 <= 100
            if (!(names.Count == scores.Count))
                return new List<string>();
            if (0 > scores.Min() || 100 < scores.Max())
                return new List<string>();

            List<string> result = new List<string>();
            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] >= 80)
                    result.Add(names[i]);
            }
            return result;
        }
    }
}
