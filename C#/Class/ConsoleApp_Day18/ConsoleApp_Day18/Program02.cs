namespace ConsoleApp_Day18
{   /***********************************************
    [딕셔너리 예제 1]
    ***********************************************/
    internal class Program02
    {
        static void Main()
        {
            Dictionary<int, List<string>> inven = new Dictionary<int, List<string>>();
            inven.Add(1, new List<string>());
            inven[1].Add("Sword");
            inven[1].Add("Shield");
            inven[1].Add("Armor");

            inven.Add(2, new List<string>());
            inven[2].Add("Bow");
            inven[2].Add("Arrow");
            inven[2].Add("ShortBow");

            foreach (var player in inven)
            {
                Console.WriteLine($"{player.Key}");
                foreach (var item in player.Value)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }
    }
}
