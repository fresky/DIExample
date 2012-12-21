using System;

namespace DIExample
{
    class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            Console.WriteLine("Creating Console Logger!");
        }
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}