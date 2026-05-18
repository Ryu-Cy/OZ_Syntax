using System.ComponentModel;
using System.Drawing;

namespace ConsoleApp_Day16
{   /************************************************
    [O(OCP: Open Closed Principle) - 개방 폐쇄 원칙]
    - 확장은 열려있고, 수정은 닫혀있어야 한다.
    ㄴ 새로운 기능 추가는 가능하지만, 기존 코드는 최대한 수정하지 않는다.
    ************************************************/
    // OCP 적용 전
    class Warrior
    {
        public void Attack()
        {
            Console.WriteLine("전사가 칼로 공격한다.");
        }
    }
    class Mage
    {
        public void Attack()
        {
            Console.WriteLine("마법사가 지팡이로 공격한다.");
        }
    }
    // ==========
    // OCP 적용
    interface ICharacter
    {
        void Attack();
    }
    class NewWarrior : ICharacter
    {
        public void Attack()
        {
            Console.WriteLine("전사가 칼로 공격한다.");
        }
    }
    class NewMage : ICharacter
    {
        public void Attack()
        {
            Console.WriteLine("마법사가 지팡이로 공격한다.");
        }
    }
    class NewArcher : ICharacter
    {
        public void Attack()
        {
            Console.WriteLine("궁수가 활로 공격한다.");
        }
    }
    // ==========
    class Circle
    {
        public double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
    }
    class Rectangle
    {
        public double width;
        public double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }
    
    // ==========
    interface IShape
    {
        double GetArea();
    }
    class NewCircle : IShape
    {
        public double radius {  get; set; }
        public NewCircle(double radius)
        {
            this.radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * this.radius * this.radius;
        }
    }
    class NewRectangle : IShape
    {
        public double width { get; set; }
        public double height { get; set; }
        public NewRectangle(double width, double height)
        {
            this.width = width;
            this.width = height;
        }
        public double GetArea()
        {
            return this.width * this.height;
        }
    }
    class NewTriagle : IShape
    {
        public double b {  get; set; }
        public double h {  get; set; }
        public NewTriagle(double b, double h)
        {
            this.b = b;
            this.h = h;
        }
        public double GetArea()
        {
            return (this.b * this.h) / 2;
        }
    }
    // ==========
    // OCP 적용 전
    class AreaCalculation
    {
        public double CalculateArea(object shape)
        {
            if (shape is Circle)
            {
                Circle circle = (Circle)shape;
                return Math.PI * circle.radius * circle.radius;
            }
            else if (shape is Rectangle)
            {
                Rectangle rectangle = (Rectangle)shape;
                return rectangle.width * rectangle.height;
            }
            return 0;
        }
    }
    // ==========
    // OCP 적용
    class NewAreaCalculation
    {
        public static void CalculateArea(List<IShape> shapes)
        {
            foreach (IShape shape in shapes)
            {
                double area = shape.GetArea();
                Console.WriteLine(area);
            }
        }
    }
    internal class OCP
    {
        // OCP 적용 전
        // 새로운 캐릭터가 추가될 때마다 if문을 수정해야 한다.
        static void CharacterAttack(object character)
        {
            if (character is Warrior)
                ((Warrior)character).Attack();
            else if ( character is Mage)
                ((Mage)character).Attack();
        }
        // OCP 적용
        static void NewCharacterAttack(ICharacter character)
        {
            character.Attack();
        }
    }
}
