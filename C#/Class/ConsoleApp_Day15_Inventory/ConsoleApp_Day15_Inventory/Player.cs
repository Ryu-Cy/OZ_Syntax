using Game.ItemSystem;

namespace Game.Player
{
    class Player
    {
        private int gold = 1000;
        private int baseAtk = 10;
        private int baseDef = 5;
        private int totalAtk;
        private int totalDef;
        public Item[] Inventory = new Item[10];

        public Player()
        {
            UpdateStatus();
        }
        public int Gold 
        {
            get { return gold; } 
            set 
            {
                if (value < 0)
                    gold = 0;
                else
                    gold = value;
            } 
        }
        public int TotalAtk { get { return totalAtk; } }
        public int TotalDef { get { return totalDef; } }
        public void UpdateStatus()
        {
            int atkBonus = 0;
            int defBonus = 0;
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] != null && Inventory[i].IsEquipped)
                {
                    atkBonus += Inventory[i].GetAtkBonus();
                    defBonus += Inventory[i].GetDefBonus();
                }
            }
            totalAtk = baseAtk + atkBonus;
            totalDef = baseDef + defBonus;
        }
        public int GetEmptySlot()
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
