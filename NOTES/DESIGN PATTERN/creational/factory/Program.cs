using System;
namespace DesignPatterns
{
    // Product Interface
    public interface IShape
    {
        void Draw();
    }
    // Concrete Products
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square.");
        }
    }
    // Factory Class
    public class ShapeFactory
    {
        public IShape GetShape(string shapeType)
        {
            if (shapeType.Equals("Circle", StringComparison.OrdinalIgnoreCase))
                return new Circle();
            else if (shapeType.Equals("Square", StringComparison.OrdinalIgnoreCase))
                return new Square();
            else
                throw new ArgumentException("Invalid shape type");
        }
    }
    // Usage
    class FactoryExample
    {
        static void Main()
        {
            ShapeFactory factory = new ShapeFactory();
            IShape shape1 = factory.GetShape("Circle");
            shape1.Draw();
            IShape shape2 = factory.GetShape("Square");
            shape2.Draw();
        }
    }
}