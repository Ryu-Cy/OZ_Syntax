namespace ConsoleApp_Day22
{   /***********************************************
    [LINQ]
    - Collection 데이터를 쉽게 검색, 정렬, 변환, 집계할 수 있는 기능
    - 코드가 간결해지고, 데이터 처리가 편리해진다.
    - 상황에 따라서 성능 저하가 있을 수 있다. (내부적으로 반복하고, GC 영향을 받을 수 있음.)
     ㄴ 특히 Unity의 Update에서는 지양해야 한다.
    - 너무 길게 작성하면 가독성에 좋지 안다.
    - 체이닝 가능
    
    [사용처]
    - 데이터 검색, 조건 필터링, 정렬, UI에 보여줄 목록

    [주의사항]
    - Unity에서 Update는 매 프레임 호출되기 때문에 Update안에서 사용하는 것은 피할 것.
    - GC를 줄여야 하는 상황, 모바일 최적화 등의 상황에서는 피하는 것이 좋다.
    - 코드는 짧아보이지만, 내부적으로는 데이터를 하나씩 확인하는 과정을 거침.
    - 체이닝이 가능하지만, 길어지면 디버깅이 어려워진다.

    [키워드]
    Any : 조건을 만족하는 데이터가 하나라도 있는지 검사. 결과는 bool
    Count : 조건을 만족하는 데이터 개수
    Where : 데이터 필터링
    Select : 데이터 변경
    OrderBy : 1차 정렬
    ThenBy : 2차 정렬

    ***********************************************/
    class Item
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Price { get; private set; }
        public int AttackPower { get; private set; }
        public Item (string name, string type, int price, int attackPower)
        {
            Name = name;
            Type = type;
            Price = price;
            AttackPower = attackPower;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} | {Type} | {Price} | {AttackPower}");
        }
    }
    internal class Program01
    {
        static void Main()
        {
            List<Item> inven = new List<Item>();
            inven.Add(new Item("체력 포션", "포션", 300, 0));
            inven.Add(new Item("마나 포션", "포션", 500, 0));
            inven.Add(new Item("목검", "무기", 700, 5));
            inven.Add(new Item("철검", "무기", 1200, 15));
            inven.Add(new Item("전설의 검", "무기", 5000, 50));
            //                         조건에 맞는 데이터 필터링             필터링 된 데이터를 List 형태로 바꾸어 weapons에 저장
            List<Item> weapons = inven.Where(item => item.Type == "무기").ToList();
            foreach (Item item in weapons)
            {
                item.PrintInfo();
            }
            Console.WriteLine("\n===========================================\n");
            //                              큰값 > 작은값 정렬
            List<Item> sortedAttack = inven.OrderByDescending(item => item.AttackPower).ToList();
            foreach (Item item in sortedAttack)
            {
                item.PrintInfo();
            }
            Console.WriteLine("\n===========================================\n");

            List<Item> expeniveItems = inven.Where(item => item.Price >= 1000).ToList();
            foreach (Item item in expeniveItems)
            {
                item.PrintInfo();
            }
            Console.WriteLine("\n===========================================\n");

            // 체이닝                          
            var resultItem = inven.Where(item => item.Type == "무기")    // 조건에 맞는 데이터 필터링  
                                  .OrderBy(item => item.Price)          // 조건에 맞게 데이터 1차 정렬
                                  .ThenBy(item => item.Type)            // 조건에 맞게 데이터 2차 정렬
                                  .Select(item => item.Name);           // 조건에 맞는 데이터 추출
            foreach (string item in resultItem)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n===========================================\n");

            int[] number = { 1, 2, 3, 4, 5, 6 };
            //                  원본 데이터를 변경해 저장
            var result = number.Select(number => { return number * 10; });
            foreach (int num in result)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("\n===========================================\n");
            
            int[] number1 = { 10, 20, 30, 40, 50, 60 };
            //                       조건에 맞는 첫 번쨰 값 반환, 없으면 기본값 반환
            int firstValue = number1.FirstOrDefault(number => { return number >= 25; });
            Console.WriteLine(firstValue);
        }
    }
}
