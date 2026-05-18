using Game.Enums;

namespace Game.Player
{   /************************************************
    [Player]
    - 플레이어가 가지고 있어야 할 정보
    ************************************************/
    class Player
    {
        // 선언
        private string name;
        private StoneType type;    // 흑돌, 백돌
        // 프로퍼티
        public string Name { get { return name; } protected set { name = value; } }
        public StoneType Type { get { return type; } protected set { type = value; } }
        // 생성자
        public Player(string name, StoneType color)
        {
            Name = name;
            Type = color;
        }
    }
}
