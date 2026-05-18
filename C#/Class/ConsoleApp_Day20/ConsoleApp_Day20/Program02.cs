namespace ConsoleApp_Day20
{   /***********************************************
    [Action]
    - C#에서 미리 만들어둔 제네릭 델리게이트 타입.
    - 반환값이 없는 메서드 즉, void 메서드를 저장할 때 사용.
    - 직접 길게 delegate 선언을 하지 않아도 됨.
    ***********************************************/
    internal class Program02
    {
        public static void PrintMessage()
        {
            Console.WriteLine("기본 메세지 출력");
        }
        public static void ShowItemMessage(string itemName)
        {
            Console.WriteLine($"{itemName} 획득");
        }
        public static void ShowQuestReward(int gold, string itemName)
        {
            Console.WriteLine($"퀘스트 보상  | 골드: {gold}, 아이템: {itemName}");
        }
        public static void PlayStartSound()
        {
            Console.WriteLine("시작 사운드");
        }
        public static void ShowStartUI()
        {
            Console.WriteLine("게임 시작 UI");
        }
        public static void LoadScene(string sceneName, Action onComplete)
        {
            Console.WriteLine($"{sceneName}로딩 시작...");
            Console.WriteLine("로딩 중");
            Console.WriteLine($"{sceneName}로딩 완료");

            onComplete?.Invoke();
        }
        public static void Main(string[] args)
        {
            Action action1 = PrintMessage;
            action1();
            Console.WriteLine();

            Action<string> action2 = ShowItemMessage;
            action2("Potion");
            Console.WriteLine();

            Action<int, string> action3 = ShowQuestReward;
            action3(100, "Long Sword");
            Console.WriteLine();

            Action action4 = null;
            action4 += PlayStartSound;
            action4 += ShowStartUI;
            action4?.Invoke();
            Console.WriteLine();

            Action action5 = PrintMessage;
            action5 = ShowStartUI;
            action5?.Invoke();
            Console.WriteLine();

            LoadScene("StartVillage", action5);
        }
    }
}
