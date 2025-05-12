
using System;
class Box<T>
{
    public T Content { get; set; }
    public void Show() => Console.WriteLine($"Box contains: {Content}");
}
class Calculator<T> where T : struct
{
    public T Add(T a, T b)
    {
        dynamic x = a, y = b;
        return x + y;
    }
}
class GenericsExample
{
    static void Main()
    {
        var intBox = new Box<int> { Content = 100 };
        intBox.Show();
        var strBox = new Box<string> { Content = "Generics" };
        strBox.Show();
        var calc = new Calculator<double>();
        Console.WriteLine($"Sum: {calc.Add(2.5, 3.5)}");
    }
}