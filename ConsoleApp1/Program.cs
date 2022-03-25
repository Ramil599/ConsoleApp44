using System;
using System.IO;
interface ILogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception ex);

}
namespace ConsoleApp4

{
    class LocalFileLogger<T> : ILogger
    {

        public string GenericTypeName = typeof(T).Name;
        private string Way;
        public LocalFileLogger(string way)
        {
            Way = way;
        }
        public void LogInfo(string message)
        {
            File.AppendAllText(Way, $"[Info]:\n [{GenericTypeName}]:{message}\n");
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(Way, $"[Warning]:\n [{GenericTypeName}]:{message}\n");
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(Way, $"[Error]:\n [{GenericTypeName}]:{message}. {ex.Message}\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string way = "1.txt";
            var LoggerInt = new LocalFileLogger<int>(way);
            var LoggerStr = new LocalFileLogger<string>(way);
            var LoggerChar = new LocalFileLogger<char>(way);
            try
            {
                LoggerChar.LogInfo("Hello");
                LoggerChar.LogWarning("Hello");
                LoggerInt.LogInfo("Hi");
                LoggerInt.LogWarning("Hi");
                LoggerStr.LogInfo("How");
                LoggerStr.LogWarning("How");
                throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException e)
            {
                LoggerChar.LogError("Bye", e);
                LoggerStr.LogError("Bye", e);
                LoggerInt.LogError("Bye", e);
            }
        }
    }
}
