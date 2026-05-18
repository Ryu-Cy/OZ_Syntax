namespace ConsoleApp_Day16
{   /************************************************
    [S(SRP: Single Resonsibility Principle) - 단일 책임 원칙]
    - 하나의 클래스는 하나의 책임만 가져야 한다.
    ㄴ 클래스를 변경해야 하는 이유는 하나여야 한다.
    ㄴ 클래스를 잘게 나눈다고 SRP 원칙을 지킨 것은 아니다. -> 오히려 복잡해질 수 있다
    ************************************************/
    // Player가 가질 필요 없는 정보들까지 작성되어있는 경우
    class BadPlayer
    {
        public string name = "기사";
        public int hp = 100;
        public void Move()
        {

        }
        public void Attack()
        {

        }
        public void ShowUI()
        {

        }
        public void Save()
        {

        }
    }
    // 비슷한 기능을 하는 것들은 자연스럽게 묶는 것이 좋다.
    // ex) Attack(Attack, CriAttack), Move(Left, Right, ...) 등
    class PlayerAttack()
    {
        public void Attack()
        {
            
        }
        public void CriAttack()
        {

        }
    }
}
