using Game.Enums;

namespace Game.Item_
{
    // 아이템이 가질 기본 정보들
    interface IUsable
    {
        void UseItem();
    }
    class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public bool IsEquipped { get; private set; }
        public ItemType Type { get; private set; }
        public Item()
        {

        }
        public Item(string name, int price, ItemType type)
        {
            Name = name;
            Price = price;
            Type = type;
            IsEquipped = false;
        }
        public void PrintInfo()
        {
            if (IsEquipped)
                Console.WriteLine($"[{Name}]\t(E)");
            else
                Console.WriteLine($"[{Name}]");
        }
        public virtual int GetAtkBonus() { return 0; }
        public virtual int GetDefBonus() { return 0; }
        public void Equiped()
        {
            IsEquipped = !IsEquipped;
        }
    }
    // 아이템 종류별 클래스
    class AtkOrb : Item, IUsable
    {
        public int Atk { get; private set; }
        public AtkOrb(string name, int price)
            : base(name, price, ItemType.AtkOrb)
        {
            Atk = 2;
        }
        public void UseItem()
        {
            Console.WriteLine($"[{Name}] 사용");
        }
        public override int GetAtkBonus()
        {
            return Atk;
        }
    }
    class DefOrb : Item, IUsable
    {
        public int Def { get; private set; }
        public ItemType Type { get; private set; }
        public DefOrb(string name, int price)
            : base(name, price, ItemType.DefOrb)
        {
            Def = 1;
        }
        public void UseItem()
        {
            Console.WriteLine($"[{Name}] 사용");
        }
        public override int GetDefBonus()
        {
            return Def;
        }
    }
    class Ball : Item, IUsable
    {
        public ItemType Type { get; private set; }
        public Ball(string name, int price)
           : base(name, price, ItemType.MonsterBall)
        {

        }
        public void UseItem()
        {
            Console.WriteLine($"[{Name}] 사용");
        }
    }
}
