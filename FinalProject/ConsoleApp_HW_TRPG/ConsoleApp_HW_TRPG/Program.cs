using Game.GameManager_;

namespace ConsoleApp_HW_TRPG
{   /**************************************************
    [문제점]
    1. 보스 사망 판단을 맵에서 하고 있음.
    2. 아이템으로 몬스터 볼이 있는데, 해당 아이템을 사용하는 방식이 아이템 사용 메서드가 아니라 몇 개 보유하고 있는지로 구현.
    3. 인벤토리 내부 로직이 아닌 실제 사용 구현을 메인 게임 로직 스크립트에서 작성.
    4. 중복된 코드들 다수 존재.
    5. 키 입력이 진행을 방해하지 않도록 'KeyAvailable' 기능을 사용했는데, 
        클릭 한 번에 실행이 되지 않고 꾹 누르고 있어야 실행이 되는 문제가 존재.
    6. while문 안에 키 입력 함수를 넣지 않고 메서드를 만들어 넣는 방식으로 진행하다보니
        오입력 시 continue를 할 수 없어 오입력에 대한 처리 실패.

    **************************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager mainGame = new GameManager();
            mainGame.Run();
        }
    }
}
