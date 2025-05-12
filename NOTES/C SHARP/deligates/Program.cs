using System;
class DelegateExample
{
    public delegate void GreetDelegate(string name);
    public delegate int MathOp(int x, int y);
    static void SayHello(string name) => Console.WriteLine($"Hello, {name}");
    static void SayGoodbye(string name) => Console.WriteLine($"Goodbye, {name}");
    static int Add(int x, int y) => x + y;
    static int Multiply(int x, int y) => x * y;
    static void Main()
    {
        // Single delegate
        GreetDelegate greet = SayHello;
        greet("Sophia");
        // Multicast delegate
        greet += SayGoodbye;
        greet("Sophia");
        // Anonymous method
        MathOp sub = delegate (int a, int b) { return a - b; };
        Console.WriteLine($"Sub: {sub(10, 5)}");
        // Lambda expression
        MathOp div = (a, b) => a / b;
        Console.WriteLine($"Div: {div(20, 4)}");
    }
}