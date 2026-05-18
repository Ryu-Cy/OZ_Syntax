using Game.ElementEffiectiveness_;
using Game.Enums;
using Game.Item_;
using Game.Player_;
using System.Diagnostics;

namespace Game.Monster_
{
    // 몬스터가 가질 기본 정보들
    abstract class Monster
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        public int MaxHp { get; protected set; }
        public bool IsDead { get; protected set; } = false;
        public int Hp {  get; protected set; }
        public  int AtkPower { get; protected set; }
        public int DefPower { get; protected set; }
        public ElementType Type { get; protected set; }
        public bool IsEquiped { get; protected set; }
        public Item EquipedItem { get; protected set; }
        public Monster(string name)
        {
            Name = name;
            Level = 1;
            IsEquiped = false;
            EquipedItem = new Item();
        }
        public Monster(string name, int level)
        {
            Name = name;
            Level = level;
            IsEquiped = false;
        }
        public virtual void LevelUp()
        {
            Level++;
        }
        public void UpdateStatus(int baseHp, int baseAtk, int baseDef)
        {
            MaxHp = baseHp + (2 * Level);
            AtkPower = baseAtk + (2 * Level);
            DefPower = baseDef + (1 * Level);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"[{Name}]  |  Lv. {Level}  |  Hp: {Hp}");
        }
        public void Heal()
        {
            Hp = MaxHp;
        }
        public void Resurrection()
        {
            if (IsDead == true)
                IsDead = false;
        }
        public virtual void Attack(Monster monster)
        {

        }
        public virtual void SpecialAttack(Monster monster)
        {

        }
        public virtual void TakeDamage(int atk)
        {

        }
        public virtual void UseItem(Item item)
        {

        }
        public virtual void UnUseItem()
        {

        }
    }
    // 몬스터 종류별 클래스
    class Charmander : Monster
    {
        private int baseHp = 10;
        private int baseAtkPower = 2;
        private int baseDefPower = 1;
        private ElementType myType = ElementType.Fire;

        public Charmander(string name)
            : base(name)
        {
            MaxHp = baseHp;
            Hp = MaxHp;
            AtkPower = baseAtkPower;
            DefPower = baseDefPower;
            Type = myType;
        }
        public Charmander(string name, int level)
            : base(name, level)
        {
            Level = level;
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
            Hp = MaxHp;
            Type = myType;
        }
        public override void Attack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 일반 공격으로 공격했다!");
            monster.TakeDamage(this.AtkPower);
        }
        public override void SpecialAttack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 특수 공격으로 공격했다!");
            int result = ElementEffiectiveness.ElementCheck(this.Type, monster.Type);
            if (result == 0)
            {
                Console.WriteLine("효과가 크지는 않았다!");
                monster.TakeDamage(this.AtkPower);
            }
            else if (result == 1)
            {
                Console.WriteLine("효과가 굉장했다!");
                monster.TakeDamage(this.AtkPower * 2);
            }
            else if (result == -1)
            {
                Console.WriteLine("효과가 별로였다!");
                monster.TakeDamage(this.AtkPower / 2);
            }
        }
        public override void TakeDamage(int atk)
        {
            if (atk - DefPower < 0)
                atk = 0;
            Console.WriteLine($"대미지: {atk}");
            Hp -= atk;
            if (Hp < 0)
            {
                Hp = 0;
                IsDead = true;
            }
        }
        public override void LevelUp()
        {
            base.LevelUp();
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
        }
        public override void UseItem(Item item)
        {
            if (!IsEquiped)
            {
                if (item.Type == ItemType.AtkOrb)
                {
                    AtkPower += item.GetAtkBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 공격력이 {item.GetAtkBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.DefOrb)
                {
                    DefPower += item.GetDefBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 방어력이 {item.GetDefBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.MonsterBall)
                {
                    Console.WriteLine("장착 아이템이 아닙니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            Console.WriteLine("이미 장비를 장착 중입니다.");
            Thread.Sleep(1000);
            return;
        }
        public override void UnUseItem()
        {
            if (EquipedItem.Type == ItemType.AtkOrb)
            {
                AtkPower -= EquipedItem.GetAtkBonus();
                Console.WriteLine($"{Name}의 공격력이 {EquipedItem.GetAtkBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
            else if (EquipedItem.Type == ItemType.DefOrb)
            {
                DefPower -= EquipedItem.GetDefBonus();
                Console.WriteLine($"{Name}의 방어력이 {EquipedItem.GetDefBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
        }
    }
    class Squirtle : Monster
    {
        private int baseHp = 10;
        private int baseAtkPower = 2;
        private int baseDefPower = 1;
        private ElementType myType = ElementType.Water;

        public Squirtle(string name) 
            : base(name)
        {
            MaxHp = baseHp;
            Hp = MaxHp;
            AtkPower = baseAtkPower;
            DefPower = baseDefPower;
            Type = myType;
        }
        public Squirtle(string name, int level) 
            : base(name, level)
        {
            Level = level;
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
            Hp = MaxHp;
            Type = myType;
        }
        public override void Attack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 일반 공격으로 공격했다!");
            monster.TakeDamage(this.AtkPower);
        }
        public override void SpecialAttack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 특수 공격으로 공격했다!");
            int result = ElementEffiectiveness.ElementCheck(this.Type, monster.Type);
            if (result == 0)
            {
                Console.WriteLine("효과가 크지는 않았다!");
                monster.TakeDamage(this.AtkPower);
            }
            else if (result == 1)
            {
                Console.WriteLine("효과가 굉장했다!");
                monster.TakeDamage(this.AtkPower * 2);
            }
            else if (result == -1)
            {
                Console.WriteLine("효과가 별로였다!");
                monster.TakeDamage(this.AtkPower / 2);
            }
        }
        public override void TakeDamage(int atk)
        {
            if (atk - DefPower < 0)
                atk = 0;
            Console.WriteLine($"대미지: {atk}");
            Hp -= atk;
            if (Hp < 0)
            {
                Hp = 0;
                IsDead = true;
            }
        }
        public override void LevelUp()
        {
            base.LevelUp();
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
        }
        public override void UseItem(Item item)
        {
            if (!IsEquiped)
            {
                if (item.Type == ItemType.AtkOrb)
                {
                    AtkPower += item.GetAtkBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 공격력이 {item.GetAtkBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.DefOrb)
                {
                    DefPower += item.GetDefBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 방어력이 {item.GetDefBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.MonsterBall)
                {
                    Console.WriteLine("장착 아이템이 아닙니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            Console.WriteLine("이미 장비를 장착 중입니다.");
            return;
        }
        public override void UnUseItem()
        {
            if (EquipedItem.Type == ItemType.AtkOrb)
            {
                AtkPower -= EquipedItem.GetAtkBonus();
                Console.WriteLine($"{Name}의 공격력이 {EquipedItem.GetAtkBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
            else if (EquipedItem.Type == ItemType.DefOrb)
            {
                DefPower -= EquipedItem.GetDefBonus();
                Console.WriteLine($"{Name}의 방어력이 {EquipedItem.GetDefBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
        }
    }
    class Bulbasaur : Monster
    {
        private int baseHp = 10;
        private int baseAtkPower = 2;
        private int baseDefPower = 1;
        private ElementType myType = ElementType.Grass;

        public Bulbasaur(string name)
            : base(name)
        {
            MaxHp = baseHp;
            Hp = MaxHp;
            AtkPower = baseAtkPower;
            DefPower = baseDefPower;
            Type = myType;
        }
        public Bulbasaur(string name, int level)
            : base(name, level)
        {
            Level = level;
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
            Hp = MaxHp;
            Type = myType;
        }
        public override void Attack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 일반 공격으로 공격했다!");
            monster.TakeDamage(this.AtkPower);
        }
        public override void SpecialAttack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 특수 공격으로 공격했다!");
            int result = ElementEffiectiveness.ElementCheck(this.Type, monster.Type);
            if (result == 0)
            {
                Console.WriteLine("효과가 크지는 않았다!");
                monster.TakeDamage(this.AtkPower);
            }
            else if (result == 1)
            {
                Console.WriteLine("효과가 굉장했다!");
                monster.TakeDamage(this.AtkPower * 2);
            }
            else if (result == -1)
            {
                Console.WriteLine("효과가 별로였다!");
                monster.TakeDamage(this.AtkPower / 2);
            }
        }
        public override void TakeDamage(int atk)
        {
            if (atk - DefPower < 0)
                atk = 0;
            Console.WriteLine($"대미지: {atk}");
            Hp -= atk;
            if (Hp < 0)
            {
                Hp = 0;
                IsDead = true;
            }
        }
        public override void LevelUp()
        {
            base.LevelUp();
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
        }
        public override void UseItem(Item item)
        {
            if (!IsEquiped)
            {
                if (item.Type == ItemType.AtkOrb)
                {
                    AtkPower += item.GetAtkBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 공격력이 {item.GetAtkBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.DefOrb)
                {
                    DefPower += item.GetDefBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 방어력이 {item.GetDefBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.MonsterBall)
                {
                    Console.WriteLine("장착 아이템이 아닙니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            Console.WriteLine("이미 장비를 장착 중입니다.");
            return;
        }
        public override void UnUseItem()
        {
            if (EquipedItem.Type == ItemType.AtkOrb)
            {
                AtkPower -= EquipedItem.GetAtkBonus();
                Console.WriteLine($"{Name}의 공격력이 {EquipedItem.GetAtkBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
            else if (EquipedItem.Type == ItemType.DefOrb)
            {
                DefPower -= EquipedItem.GetDefBonus();
                Console.WriteLine($"{Name}의 방어력이 {EquipedItem.GetDefBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
        }
    }
    class Pikachu : Monster
    {
        private int baseHp = 10;
        private int baseAtkPower = 2;
        private int baseDefPower = 1;
        private ElementType myType = ElementType.Electric;

        public Pikachu(string name)
            : base(name)
        {
            MaxHp = baseHp;
            Hp = MaxHp;
            AtkPower = baseAtkPower;
            DefPower = baseDefPower;
            Type = myType;
        }
        public Pikachu(string name, int level)
            : base(name, level)
        {
            Level = level;
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
            Hp = MaxHp;
            Type = myType;
        }
        public override void Attack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 일반 공격으로 공격했다!");
            monster.TakeDamage(AtkPower);
        }
        public override void SpecialAttack(Monster monster)
        {
            Console.WriteLine($"{Name}이(가) {monster.Name}을(를) 특수 공격으로 공격했다!");
            int result = ElementEffiectiveness.ElementCheck(this.Type, monster.Type);
            if (result == 0)
            {
                Console.WriteLine("효과가 크지는 않았다!");
                monster.TakeDamage(this.AtkPower);
            }
            else if (result == 1)
            {
                Console.WriteLine("효과가 굉장했다!");
                monster.TakeDamage(this.AtkPower * 2);
            }
            else if (result == -1)
            {
                Console.WriteLine("효과가 별로였다!");
                monster.TakeDamage(this.AtkPower / 2);
            }
        }
        public override void TakeDamage(int atk)
        {
            if (atk - DefPower < 0)
                atk = 0;
            Console.WriteLine($"대미지: {atk}");
            Hp -= atk;
            if (Hp < 0)
            {
                Hp = 0;
                IsDead = true;
            }
        }
        public override void LevelUp()
        {
            base.LevelUp();
            UpdateStatus(baseHp, baseAtkPower, baseDefPower);
        }
        public override void UseItem(Item item)
        {
            if (!IsEquiped)
            {
                if (item.Type == ItemType.AtkOrb)
                {
                    AtkPower += item.GetAtkBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 공격력이 {item.GetAtkBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.DefOrb)
                {
                    DefPower += item.GetDefBonus();
                    if (item is IUsable usableItem)
                        usableItem.UseItem();
                    Console.WriteLine($"{Name}의 방어력이 {item.GetDefBonus()}만큼 증가했다!");
                    item.Equiped();
                    EquipedItem = item;
                    IsEquiped = true;
                    Thread.Sleep(1000);
                    return;
                }
                else if (item.Type == ItemType.MonsterBall)
                {
                    Console.WriteLine("장착 아이템이 아닙니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }
            Console.WriteLine("이미 장비를 장착 중입니다.");
            return;
        }
        public override void UnUseItem()
        {
            if (EquipedItem.Type == ItemType.AtkOrb)
            {
                AtkPower -= EquipedItem.GetAtkBonus();
                Console.WriteLine($"{Name}의 공격력이 {EquipedItem.GetAtkBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
            else if (EquipedItem.Type == ItemType.DefOrb)
            {
                DefPower -= EquipedItem.GetDefBonus();
                Console.WriteLine($"{Name}의 방어력이 {EquipedItem.GetDefBonus()}만큼 감소했다!");
                EquipedItem.Equiped();
                EquipedItem = null;
                IsEquiped = false;
                Thread.Sleep(1000);
                return;
            }
        }
    }
}
