using Microsoft.VisualBasic;

namespace ConsoleApp_Day20
{   /***********************************************
    [Event]
    - 특정 사건이 발생했다는 사실을 다른 객체들에게 알려주는 기능.
    - 디자인 패턴 중 하나인 관찰자 패턴(Observer Pattern)을 구현할 때 자주 사용.
    - event 키워드가 붙으면 +=/-=만 가능. =는 불가

    ===============================================

    [Delegate vs Event]
    Delegate
     - 메서드를 변수처럼 저장/실행
     - 메서드를 전달하거나 나중에 실행 가능
     - 여러 메서드 연결 가능
     - 어떤 기능을 실행할 것인가? 를 다룬다.

    Event
     - Delegate 기반으로 구현한 알림 전용
     - 외부에서 함부로 Invoke 불가능.
     - 상태 변화/사건 발생을 외부에 알릴 때 사용

    ***********************************************/
    internal class Program04
    {
        public class Player
        {
            private int coin;
            public event Action<int> OnCoinCollected;
            public void GetCoin()
            {
                coin++;
                Console.WriteLine($"플레이어가 코인을 획득.\t{coin}");

                OnCoinCollected?.Invoke(coin);
            }
        }
        public class UI
        {
            public void UpdateUI(int coin)
            {
                Console.WriteLine($"UI에 코인 수 갱신: {coin}");
            }
        }
        public class SFX
        {
            public void GetCoinSound(int coin)
            {
                Console.WriteLine($"{coin} 효과음 재생");
            }
        }
        public class VFX
        {
            public void GetCoinEffect(int coin)
            {
                Console.WriteLine($"{coin} 획득 이펙트 재생");
            }
        }
        public class EventSender
        {
            public Action OnDelegate;
            public event Action OnEvent;

            public void DelegateCall()
            {
                OnDelegate?.Invoke();
            }
            public void EventCall()
            {
                OnEvent?.Invoke();
            }
        }
        public class EventListener
        {
            public void ReAction()
            {
                Console.WriteLine("반응 실행");
            }
        }
        public static void Main2()
        {
            EventSender sender = new EventSender();
            EventListener listener1 = new EventListener();
            EventListener listener2 = new EventListener();
            EventListener listener3 = new EventListener();

            sender.OnDelegate += listener1.ReAction;
            sender.OnDelegate += listener2.ReAction;
            sender.OnDelegate = listener3.ReAction;
            sender.OnDelegate?.Invoke();
            Console.WriteLine();
            sender.DelegateCall();
            Console.WriteLine();

            sender.OnEvent += listener1.ReAction;
            sender.OnEvent += listener2.ReAction;
            //sender.OnEvent = listener3.ReAction;
            //sender.OnEvent?.Invoke();
            sender.EventCall();
            Console.WriteLine();
        }
        public static void Main1()
        {
            Player player = new Player();
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();

            player.OnCoinCollected += ui.UpdateUI;
            player.OnCoinCollected += sfx.GetCoinSound;
            player.OnCoinCollected += vfx.GetCoinEffect;

            player.GetCoin();
            player.GetCoin();
            Console.WriteLine();
        }
        static void Main()
        {
            //Main1();
            Main2();
        }
    }
}
