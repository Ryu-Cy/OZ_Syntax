namespace ConsoleApp_Day9_HW
{
    /**********************************************
        [과제]
    1. 메서드 구현
        1-1. 캐릭터 스탯 강화
        1-2. 공격 대미지 계산기
    2.  ref/out 메서드 구현
        2-1. 플레이어 체력 회복 시스템 (ref)
        2-2. 아이템 획득 결과 반환 (out)
        2-3. 전투 결과 계산 (ref + out)
    **********************************************/
    internal class Program
    {
        // 과제 1-1
        static string UpgradeStats(int hp, int atk, int hpIncrease = 10, int atkIncrease = 2)
        {
            hp += hpIncrease;
            atk += atkIncrease;

            return "강화 후: hp = " + hp + ", atk = " + atk;
        }
        // 과제 1-2
        static int CalculateDamage(int atk, int def)
        {
            return atk - def;
        }
        static int CalculateDamage(int atk, int def, bool isCritical)
        {
            if (isCritical)
            {
                double tmp = (atk - def) * 1.5;
                return (int)tmp;
            }
            else
                return atk - def;
        }
        static int CalculateDamage(int atk, int def, int bonusDamage)
        {
            return atk - def + bonusDamage;
        }

        // 과제 2-1
        static void HealPlayer(ref int hp, int healAmount)
        {
            hp += healAmount;
            if (hp > 100)
                hp = 100;
        }
        // 과제 2-2
        static void GetRandomItem(out string itemName, out int itemCount)
        {
            itemName = "포션";
            itemCount = 3;
        }
        // 과제 2-3
        static void AttackMonster(ref int monsterHp, int playerAtk, out bool isDead)
        {
            monsterHp -= playerAtk;
            if (monsterHp < 0)
                monsterHp = 0;

            if (monsterHp <= 0)
                isDead = true;
            else
                isDead = false;
            
        }
        static void Main(string[] args)
        {
            // 과제 1
            // 과제 1-1. 캐릭터 스탯 강화
            Console.WriteLine("===== 과제 1-1. 캐릭터 스탯 강화 메서드 구현 =====\n");

            int hp = 100;
            int atk = 20;

            Console.WriteLine($"강화 전: hp = {hp}, atk = {atk}");
            Console.WriteLine(UpgradeStats(hp, atk));

            hp = 110;
            atk = 22;

            Console.WriteLine($"강화 전: hp = {hp}, atk = {atk}");
            Console.WriteLine(UpgradeStats(hp, atk));
            Console.WriteLine();

            // 과제 1-2. 공격 대미지 계산기 메서드 구현 (메서드 오버로딩)
            Console.WriteLine("===== 과제 1-2. 공격 대미지 계산기 메서드 구현 =====\n");

            Console.WriteLine("기본 공격: " + CalculateDamage(50, 25));
            Console.WriteLine("치명타 공격: " + CalculateDamage(50, 25, true));
            Console.WriteLine("보너스 포함 공격: " + CalculateDamage(50, 25, 5));
            Console.WriteLine();

            // 과제 2
            // 과제 2-1. 플레이어 회복 시스템 (ref)
            Console.WriteLine("===== 과제 2-1. 플레이어 회복 시스템 =====\n");

            int hp1 = 70;

            Console.WriteLine($"회복 전 HP: {hp1}");
            HealPlayer(ref hp1, 20);
            Console.WriteLine($"회복 후 HP: {hp1}");
            Console.WriteLine();

            // 과제 2-2. 아이템 획득 결과 반환 (out)
            Console.WriteLine("===== 과제 2-2. 아이템 획득 결과 반환 =====\n");

            string itemName;
            int itemCount;

            GetRandomItem(out itemName, out itemCount);
            Console.WriteLine($"획득 아이템: {itemName}");
            Console.WriteLine($"획득 개수: {itemCount}");
            Console.WriteLine();

            // 과제 2-3. 전투 결과 계산
            Console.WriteLine("===== 과제 2-3. 전투 결과 계산 =====\n");

            int monsterHp = 30;
            int playerAtk = 15;
            bool isDead;

            Console.WriteLine($"공격 전 몬스터 HP: {monsterHp}");
            AttackMonster(ref monsterHp, playerAtk, out isDead);
            Console.WriteLine($"공격 후 몬스터 HP: {monsterHp}");
            Console.WriteLine($"몬스터 사망 여부: {isDead}");
        }
    }
}
