

using System;

using System.Collections;

using System.Collections.Generic;

class CollectionsExample

{

    static void Main()

    {

        // ArrayList (non-generic)

        ArrayList mixed = new ArrayList { 1, "Two", 3.0 };

        Console.WriteLine("ArrayList:");

        foreach (var item in mixed) Console.WriteLine(item);

        // List<T>

        List<string> names = new List<string> { "Alice", "Bob" };

        names.Add("Charlie");

        Console.WriteLine("\nList<string>:");

        foreach (var name in names) Console.WriteLine(name);

        // Dictionary<TKey, TValue>

        Dictionary<string, int> scores = new Dictionary<string, int>

        {

            { "Alice", 90 },

            { "Bob", 85 }

        };

        Console.WriteLine("\nDictionary:");

        foreach (var kvp in scores) Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        // Stack<T>

        Stack<int> stack = new Stack<int>();

        stack.Push(1); stack.Push(2);

        Console.WriteLine($"\nStack Pop: {stack.Pop()}");

        // Queue<T>

        Queue<string> queue = new Queue<string>();

        queue.Enqueue("First");

        queue.Enqueue("Second");

        Console.WriteLine($"Queue Dequeue: {queue.Dequeue()}");

    }

}
