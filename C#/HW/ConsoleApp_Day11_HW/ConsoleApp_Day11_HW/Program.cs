namespace ConsoleApp_Day11_HW
{   /******************************************************
    [과제]
    1. 캐릭터 정보 출력하기
    2. 은행 계좌 관리 (접근 제한 지정자 활용)
    ******************************************************/
    // 과제 1
    public class Character
    {
        private string name;
        private int level;
        private int health;
        private int atk;
        public void SetPlayer(string n, int l, int h, int a)
        {
            name = n;
            level = l;
            health = h;
            atk = a;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"이름: {name}, 레벨: {level}, HP:, {health}, 공격력: {atk}");
        }
    }
    // 과제 2
    public class BankAccount
    {
        private string owner;
        private int balance;
        public void setOwner(string o)
        {
            owner = o;
        }
        public void Deposit(int amount)
        {
            balance += amount;
        }
        public void Withdraw(int amount)
        {
            if (balance < amount)
                Console.WriteLine("잔액이 부족합니다.");
            else
                balance -= amount;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{owner}님의 현재 잔액은 {balance}원 입니다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 과제 1
            Console.WriteLine("===== 과제 1 =====");
            Character myCharacter = new Character();
            myCharacter.SetPlayer("홍길동", 3, 100, 20);
            myCharacter.PrintInfo();
            Console.WriteLine();
            // 과제 2
            Console.WriteLine("===== 과제 2 =====");
            BankAccount myBankAccoun = new BankAccount();
            bool isCheck = false;
            bool isIn = false;
            bool isOut = false;
            Console.Write("사용자 이름을 입력해주세요: ");
            string inputName = Console.ReadLine();
            myBankAccoun.setOwner(inputName);
            while (!isCheck)
            {
                Console.WriteLine("무엇을 하시겠습니까? (1. 입금, 2. 출금 0. 종료)");
                string inputCheck = Console.ReadLine();
                isCheck = true;
                if (int.Parse(inputCheck) == 0)
                    break;
                else if (int.Parse(inputCheck) == 1)
                    isIn = true;
                else if (int.Parse(inputCheck) == 2)
                    isOut = true;
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    isCheck = false;
                }
                while (isIn)
                {
                    Console.WriteLine("입금할 금액을 입력해주세요:  (종료 하시려면 0번을 입력해주세요.)");
                    string inputMoney = Console.ReadLine();
                    if (int.Parse(inputMoney) == 0)
                        break;
                    myBankAccoun.Deposit(int.Parse(inputMoney));
                    myBankAccoun.ShowInfo();
                    isIn = false;
                }
                while (isOut)
                {
                    Console.WriteLine("출금할 금액을 입력해주세요:  (종료 하시려면 0번을 입력해주세요.)");
                    string inputMoney = Console.ReadLine();
                    if (int.Parse(inputMoney) == 0)
                        break;
                    myBankAccoun.Withdraw(int.Parse(inputMoney));
                    myBankAccoun.ShowInfo();
                    isOut = false;
                }
                isCheck = false;
            }

            Console.WriteLine("종료합니다.");
        }
    }
}
