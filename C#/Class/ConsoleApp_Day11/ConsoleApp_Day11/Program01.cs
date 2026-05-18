namespace ConsoleApp_Day11
{   /******************************************************
    [값 타입 vs 참조 타입]
    ******************************************************/
    class MyClass
    {
        public int value1;
        public int value2;
    }
    struct ValueType
    {
        public int value;
    }
    class RefType
    {
        public int value;
    }
    class Weapon { public string name; }
    class Player { public string name; public Weapon weaopn; }
    internal class Program01
    {
        static void Swap(ValueType left, ValueType right)
        {   // 메서드 안에서만 유효한 복사본
            int tmp = left.value;
            left.value = right.value;
            right.value = tmp;
        }
        static void Swap(RefType left,  RefType right)
        {   // 주소를 따라가서 실제 값을 바꾸므로 원본이 바뀐다.
            int tmp = left.value;
            left.value = right.value;
            right.value = tmp;
        }
        static void Main(string[] args)
        {
            MyClass s = new MyClass();  // 메모리에 공간은 만들고 s에 주소를 할당
            s.value1 = 1;
            s.value2 = 2;

            MyClass t = s;
            t.value1 = 3;
            t.value2 = 4;
            // 같은 인스턴스를 참조하기 때문에 복사본(t) 변경 시 원본(s)도 변경
            Console.WriteLine(s.value1);
            Console.WriteLine(s.value2);
            Console.WriteLine(t.value1);
            Console.WriteLine(t.value2);

            Console.WriteLine();

            ValueType valueType = new ValueType { value = 10 };
            ValueType valueType2 = valueType;
            valueType2.value = 20;
            //  값이 복사되기 때문에 원본에는 영향이 없다.
            Console.WriteLine(valueType.value);

            RefType refType = new RefType { value = 10 };
            RefType refType2 = refType;
            refType2.value = 20;
            //  주소가 복사되기 때문에 원본에 영향을 준다.
            Console.WriteLine(refType.value);

            ValueType leftValue = new ValueType { value = 10 };
            ValueType rightValue = new ValueType { value = 20 };
            Swap(leftValue, rightValue);
            //  값이 복사되기 때문에 원본에는 영향이 없다.
            Console.WriteLine($"{leftValue.value}, {rightValue.value}");

            RefType leftRef = new RefType { value = 10 };
            RefType rightRef = new RefType { value = 20 };
            Swap(leftRef, rightRef);
            //  주소가 복사되기 때문에 원본에 영향을 준다.
            Console.WriteLine($"{leftRef.value}, {rightRef.value}");

            Console.WriteLine();

            RefType original = new RefType { value = 1 };
            RefType shallowCopy = original;
            //  새 객체를 만들고 처음 초기화할 때 복사한 것이기에 이후에는 원본을 수정해도 영향이 없다.
            RefType deepCopy = new RefType();
            deepCopy.value = original.value;

            Console.WriteLine(original.value);
            Console.WriteLine(shallowCopy.value);
            Console.WriteLine(deepCopy.value);

            original.value = 2;
            Console.WriteLine(original.value);
            Console.WriteLine(shallowCopy.value);
            Console.WriteLine(deepCopy.value);

            Console.WriteLine();

            Player playerOriginal = new Player();
            playerOriginal.name = "전서1";
            playerOriginal.weaopn = new Weapon { name = "집행검" };

            Player copyPlayer = new Player();
            copyPlayer.name = "전사2";
            copyPlayer.weaopn = playerOriginal.weaopn;

            copyPlayer.weaopn.name = "전설의 검";
            Console.WriteLine(playerOriginal.weaopn.name);

        }
    }
}
