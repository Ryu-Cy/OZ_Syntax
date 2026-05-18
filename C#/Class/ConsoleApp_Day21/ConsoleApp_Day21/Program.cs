namespace ConsoleApp_Day21
{   /***********************************************
    [예외 처리(Exception Handling)]
    - 예외 사용 / 사용자 정의 예외 처리
    - 예외 : 의도하지 않은 상황, 예측할 수 없는 오류

    [예외 처리가 필요한 이유]
    - 네트워크 연결 실패
    - 리소스(파일) 관련 로드 오류
    - 하드웨어 문제
    - 사용자 입력 오류
    - ...

    위와 같은 이유들에 의해 돌발 상황이 발생했을 때, 프로그램이 비정상적으로 종료된다.
    이런 상황에 예외 처리를 통해 비정상적인 종료 대신 상황에 따른 방식들로 프로그램 지속

    [try - catch - finally]
    - try : 예외가 발생할 수 있는 가능성이 있는 코드 작성
    - catch : 예외 상황이 발생했을 때 실행되는 코드 작성 / 여러 개 작성 가능
    - finally : try에서 예외 발생 여부와 관계 없이 실행되는 코드 작성

    [catch에서 오류 잡는 키워드]
    FormatException : 형식에 따른 오류    - 입력 형식 미리 검사
    OverflowException : 변수 타입별 범위에 따른 오류    - 숫자 크기를 미리 검사
    IndexOutOfRangeException : 인덱스 범위에 따른 오류    - 인덱스 범위 미리 검사
    DivideByZeroException : 정수를 0으로 나누려할 때 나타나는 오류  - 나누려는 수가 0인지 미리 체크
    NullReferenceException : 값이 null이면 나타나는 오류    - 데이터가 null인지 미리 검사
    Exception : 모든 오류 형식들의 부모

    - 가능하면 조건문으로 처리하자.
     ㄴ 위 방법으로 체크하면 throw를 실행하는데 무거움.

    [알아두면 좋은 것]
    - Validation : 유효성 검사
    - Regex(Regular Expression) : 정규 표현식
    ***********************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
        }
        // Try Catch Finally 예제1
        static void Test1()
        {
            try
            {
                Console.Write("숫자를 입력하세요: ");
                string input = Console.ReadLine();

                int number = int.Parse(input);

                Console.WriteLine($"입력한 숫자는 {number} 입니다.");
            }
            catch (FormatException)
            {
                Console.WriteLine("입력 형식이 잘못 됐습니다.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("입력 범위를 벗어났습니다.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"오류가 발생했습니다. {ex.Message}");
            }
            finally
            {
                Console.WriteLine("프로그램 종료!");
            }
        }
        // Try Catch Finally 예제 2
        static void Test2()
        {
            try
            {
                Console.WriteLine("Try 실행");
                int number = int.Parse("ABC");
            }
            catch
            {
                Console.WriteLine("Catch 실행");
                return;
            }
            finally
            {
                Console.WriteLine("Finally 실행");
            }
            Console.WriteLine("Try - Catch - Finally 블록 밖 실행"); // catch에서 return 시 실행x
        }
        // Try Catch Finally 예제 3
    }
}
