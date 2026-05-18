using Game.Enums;

namespace Game.ElementEffiectiveness_
{
    class ElementEffiectiveness
    {
        public static int ElementCheck(ElementType type1, ElementType type2)
        {
            if (type1 == ElementType.Fire && type2 == ElementType.Fire)
                return 0;
            else if (type1 == ElementType.Fire && type2 == ElementType.Water)
                return -1;
            else if (type1 == ElementType.Fire && type2 == ElementType.Grass)
                return 1;
            else if (type1 == ElementType.Fire && type2 == ElementType.Electric)
                return 0;

            if (type1 == ElementType.Water && type2 == ElementType.Fire)
                return 1;
            else if (type1 == ElementType.Water && type2 == ElementType.Water)
                return 0;
            else if (type1 == ElementType.Water && type2 == ElementType.Grass)
                return -1;
            else if (type1 == ElementType.Water && type2 == ElementType.Electric)
                return -1;

            if (type1 == ElementType.Grass && type2 == ElementType.Fire)
                return -1;
            else if (type1 == ElementType.Grass && type2 == ElementType.Water)
                return 1;
            else if (type1 == ElementType.Grass && type2 == ElementType.Grass)
                return 0;
            else if (type1 == ElementType.Grass && type2 == ElementType.Electric)
                return 0;

            if (type1 == ElementType.Electric && type2 == ElementType.Fire)
                return 0;
            else if (type1 == ElementType.Electric && type2 == ElementType.Water)
                return 1;
            else if (type1 == ElementType.Electric && type2 == ElementType.Grass)
                return 0;
            else if (type1 == ElementType.Electric && type2 == ElementType.Electric)
                return 0;


            return 0;
        }
    }
}
