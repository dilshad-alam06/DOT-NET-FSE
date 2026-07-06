using System;

namespace SingletonPattern
{
    /// <summary>
    /// Simple logger implementing the Singleton pattern.
    /// </summary>
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger() { }

        public static Logger GetInstance()
        {
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[Logger] {message}");
        }
    }
}
