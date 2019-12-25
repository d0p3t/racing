using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class Logger
    {
        public static void Info(string message)
        {
            SendMessage(message, LogLevel.INFO);
        }

        public static void Exception(Exception e, string message = "")
        {
            SendMessage($"{e.Message} {message}", LogLevel.EXCEPTION);
        }

        private static void SendMessage(string message, LogLevel logLevel)
        {
            CitizenFX.Core.Debug.WriteLine($"[{logLevel}][{DateTime.UtcNow}] {message}");
        }

        private enum LogLevel
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR,
            EXCEPTION
        }
    }
}
