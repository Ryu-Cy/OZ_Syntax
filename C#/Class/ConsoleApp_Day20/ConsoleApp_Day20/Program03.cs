namespace ConsoleApp_Day20
{   /***********************************************
    [Func]
    - 반환값이 있는 메서드 즉, void를 제외한 메서드를 저장할 때 사용.


    ===============================================


    [Action vs Func]
    저장 대상
        Action : 리턴 값이 없는 메서드 (void)
        Func : 리턴 값이 있는 메서드 (void 제외)
    사용처
        Action : 
        Func : 
    ***********************************************/
    internal class Program03
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int CalculateDamage(int atk, int critical)
        {
            int damage = atk + critical;
            return damage;
        }
        public static string GetItemGrade(int level)
        {
            if (level >= 15)
                return "전설";
            else if (level >= 10)
                return "영웅";
            else
                return "일반";
        }
        static void Main()
        {
            Func<int, int, int> addFunc = Add;
            int result = addFunc(10, 20);
            Console.WriteLine(result);
            Console.WriteLine();

            Func<int, int, int> damage = CalculateDamage;
            int finalDamage = damage(20, 3);
            Console.WriteLine(finalDamage);
            Console.WriteLine();

            Func<int, string> itemGrade = GetItemGrade;
            itemGrade(10);
            Console.WriteLine(itemGrade);
        }
    }
}
