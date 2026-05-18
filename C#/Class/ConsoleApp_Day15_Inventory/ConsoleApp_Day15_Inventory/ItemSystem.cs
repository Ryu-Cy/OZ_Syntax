using Game.Enums;

namespace Game.ItemSystem
{
    interface IEquippable
    {
        void Equip();
        void UnEquip();
    }
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public bool IsEquipped { get; set; }
        public ItemType Type { get; protected set; }
        public Item (string name, int price, ItemType type)
        {
            Name = name;
            Price = price;
            Type = type;
            IsEquipped = false;
        }
        public abstract void ShowInfo();
        public virtual int GetAtkBonus() { return 0; }
        public virtual int GetDefBonus() { return 0; }
    }
    public class Weapon : Item, IEquippable
    {
        public int Atk { get; private set; }
        public Weapon(string name, int atk, int price)
            : base(name, price, ItemType.Weapon)
        {
            Atk = atk;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"[{Name}]\t공격력: {Atk}\t(가격: {Price}Gold)");
        }
        public override int GetAtkBonus()
        {
            return Atk;
        }
        public void Equip()
        {
            Console.WriteLine($"{Name}을 장착했습니다. 공격력 상승!!!");
        }
        public void UnEquip()
        {
            Console.WriteLine($"{Name}을 장착 해제 했습니다.");
        }
    }
    public class Armor : Item, IEquippable
    {
        public int Def { get; private set; }
        public Armor(string name, int def, int price)
            : base(name, price, ItemType.Armor)
        {
            Def = def;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"[{Name}]\t방어력: {Def}\t(가격: {Price}Gold)");
        }
        public override int GetDefBonus()
        {
            return Def;
        }
        public void Equip()
        {
            Console.WriteLine($"{Name}을 장착 했습니다. 방어력 상승!!!");
        }
        public void UnEquip()
        {
            Console.WriteLine($"{Name}을 장착 해제 했습니다.");
        }
    }
}
