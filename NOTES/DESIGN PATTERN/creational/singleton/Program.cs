using System;
namespace DesignPatterns
{
    /// <summary>
    /// The Singleton class ensures that only one instance of the class exists
    /// and provides a global point of access to it.
    /// </summary>
    public sealed class Singleton
    {
        // Private static variable to hold the single instance of the class
        private static Singleton _instance = null;
        // Object used for locking to ensure thread safety
        private static readonly object _lock = new object();
        /// <summary>
        /// Private constructor ensures that the class cannot be instantiated from outside.
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton instance created.");
        }
        /// <summary>
        /// Public static method to provide access to the instance.
        /// Uses double-checked locking to ensure thread safety and performance.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                // First check without locking (for performance)
                if (_instance == null)
                {
                    // Lock only when the instance is null
                    lock (_lock)
                    {
                        // Double-check to ensure only one instance is created
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Example method to demonstrate the Singleton instance behavior.
        /// </summary>
        public void ShowMessage()
        {
            Console.WriteLine("Hello from the Singleton instance!");
        }
    }
    /// <summary>
    /// Example usage of the Singleton class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accessing Singleton instance...");
            // Access the Singleton instance for the first time
            Singleton singleton1 = Singleton.Instance;
            singleton1.ShowMessage();
            // Access the Singleton instance again
            Singleton singleton2 = Singleton.Instance;
            // Check if both instances are the same
            Console.WriteLine($"Are both instances equal? {object.ReferenceEquals(singleton1, singleton2)}");
        }
    }
}