using System;
using System.Windows;

namespace DIExample
{
    class MessageBoxLogger : ILogger
    {
        public MessageBoxLogger()
        {
            Console.WriteLine("Creating MessageBox Logger!");
        }
        public void LogMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}