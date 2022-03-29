using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp111
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
            File.AppendAllText(Way, Environment.NewLine + "[Info]:" + Environment.NewLine +
                $"[{GenericTypeName}]:{message}");
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(Way, Environment.NewLine + "[Warning]:" + Environment.NewLine +
                $"[{GenericTypeName}]:{message}");
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(Way, Environment.NewLine + "[Error]:" + Environment.NewLine +
                $"[{GenericTypeName}]:{message}. {ex.Message}");
        }
    }
}
