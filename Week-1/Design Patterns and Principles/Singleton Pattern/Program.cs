using System;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Obtain two references.
            var logger1 = Logger.GetInstance();
            var logger2 = Logger.GetInstance();

            // Verify both references point to the same object.
            bool sameInstance = ReferenceEquals(logger1, logger2);
            Console.WriteLine($"Both logger references are the same instance: {sameInstance}");

            // Demonstrate logging via both references.
            logger1.Log("First log message from logger1.");
            logger2.Log("Second log message from logger2.");
        }
    }
}

