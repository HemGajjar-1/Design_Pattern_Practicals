using Practical_22.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_22.Infrastructure.Logging
{
    public class LoggerService: ILoggerService
    {
        private static readonly LoggerService _instance = new LoggerService();
        private readonly string _filePath;
        private LoggerService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt");
        }
        public static LoggerService Instance
        {
            get { return _instance; }
        }
        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now} : {message}";
            File.AppendAllText(_filePath, logMessage + Environment.NewLine);
        }
    }
}
