namespace ConsoleApp_Day14
{   /**************************************************
    [추상 클래스]
    - 게임에 존재하지만 등장하지는 않는 것에 사용하기에 적합
     ㄴ ex) Item, Enemy 등 범주가 큰 것들
    - 상속이 강제되기에 남발하면 좋지 않다.
    **************************************************/
    abstract class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public void Show()
        {
            Console.WriteLine($"아이템: {Name}\n아이템 가격: {Price}");
        }
        public abstract void Use();
    }
    class Potion : Item
    {
        public int HealAbount {  get; private set; }
        public Potion(string name, int price, int healAmount)
            : base(name, price)
        {
            HealAbount = healAmount;
        }
        public override void Use()
        {
            Console.WriteLine($"{Name} 사용!!!!\n체력을 {HealAbount} 회복함!!!!");
        }
    }
    class Sword : Item
    {
        public int AttackPower { get; private set; }
        public Sword(string name, int price, int attackPower)
            : base(name, price)
        {
            AttackPower = attackPower;
        }
        public override void Use()
        {
            Console.WriteLine($"{Name} 장착!!!!\n공격력이 {AttackPower} 증가함!!!!");
        }
    }
    internal class Program01
    {
        static void Main()
        {
            Item potion = new Potion("포션", 10, 20);
            Item sword = new Sword("검", 30, 15);
            potion.Show();
            potion.Use();
            sword.Show();
            sword.Use();
        }
    }
}
