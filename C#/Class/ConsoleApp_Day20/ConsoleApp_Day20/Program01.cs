using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Day20
{   /***********************************************
    [Delegate Chain]
    - 하나의 델리게이트 변수에 여러 메서드들을 연결하는 방식
    - 델리게이트를 한 번 호출하면 연결된 메서드들이 순서대로 실행됨.

    [키워드]
    += : 메서드 추가
    -= : 메서드 제거
    = : 기존 연결을 제거하고 새 메서드만 저장

    [사용처]
    - 이 특징을 통해 여러 행동을 순차적으로 실행하여 캐릭터의 행동 구현
    - 여러 이벤트 처리 메서드를 체인으로 연결하여 특정 게임 이벤트 발생 시 여러 로직을 순차적으로 처리할 때

    [주의]
    - 유니티에서는 이벤트를 +=로 등록을 했다면, 사용 후 -=로 해제해 주는 습관을 들이는 게 좋다.
     ㄴ 해제가 안 됐다면, 추가된 이벤트 메서드의 객체를 지워도 참조를 하고있기에 GC가 처리하지 않아 메모리 누수가 생길 수 있다.
    ***********************************************/
    internal class Program01
    {
        public delegate void GameEvent();
        public static void PlayDeadAnimation()
        {
            Console.WriteLine("사망 애니메이션 실행");
        }
        public static void PlayDeadSound()
        {
            Console.WriteLine("사망 효과음 재생");
        }
        public static void ShowGameOverUI()
        {
            Console.WriteLine("게임 오버 UI 출력");
        }
        public static void DecreaseExp()
        {
            Console.WriteLine("경험치 감소");
        }

        static void Main()
        {
            GameEvent OnPlayerDead = null;
            OnPlayerDead += PlayDeadAnimation;
            OnPlayerDead += PlayDeadSound;
            OnPlayerDead += ShowGameOverUI;
            OnPlayerDead += DecreaseExp;
            OnPlayerDead();
            Console.WriteLine();

            OnPlayerDead -= DecreaseExp;
            OnPlayerDead();
            Console.WriteLine();

            OnPlayerDead = ShowGameOverUI;
            OnPlayerDead?.Invoke();
        }
    }
}
