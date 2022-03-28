using System;
using System.IO;
using System.Collections.Generic;
interface ILogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception ex);

}
namespace ConsoleApp4

{
    class Entity
    {
        public int Id;
        public int ParentId;
        public string Name;
        
    }
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
            File.AppendAllText(Way, Environment.NewLine + "[Info]:" +Environment.NewLine + 
                $"[{GenericTypeName}]:{message}");
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(Way, Environment.NewLine + "[Warning]:" + Environment.NewLine + 
                $"[{GenericTypeName}]:{message}");
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(Way, Environment.NewLine + "[Error]:" +Environment.NewLine + 
                $"[{GenericTypeName}]:{message}. {ex.Message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Child0 = new Entity();
            var Child1 = new Entity();
            var Child2 = new Entity();
            var Child3 = new Entity();
            var Child4 = new Entity();
        
            Child0.Id = 1; Child0.Name = "Root entity";Child0.ParentId = 0;
            Child1.Id = 2;Child1.Name = "Child of 1 entity ";Child1.ParentId = 1;
            Child2.Id = 3;Child2.Name = "Child of 1 entity "; Child2.ParentId = 1;
            Child3.Id = 4; Child3.Name = "Child of 2 entity "; Child3.ParentId = 2;
            Child4.Id = 5; Child4.Name = "Child of 4 entity "; Child4.ParentId = 4;
            var ChildArray = new Entity[5];
            ChildArray[0] = Child0;
            ChildArray[1] = Child1;
            ChildArray[2] = Child2;
            ChildArray[3] = Child3;
            ChildArray[4] = Child4;
            
            var Diction = new Dictionary<int, List<int>>();
            for(int i=0; i < ChildArray.Length; i++) {
                var IdList = new List<int>();
                if (!Diction.ContainsKey(ChildArray[i].ParentId))
                {
                    IdList.Add(ChildArray[i].Id);
                    Diction.Add(ChildArray[i].ParentId, IdList);
                }
                else
                {
                    var _IdList = new List<int>();
                    Diction.TryGetValue(ChildArray[i].ParentId, out _IdList);
                    _IdList.Add(ChildArray[i].Id);
                    
                }
              
            }
            foreach (var entity in Diction)
            {
                foreach(var Entity in Diction.Values)
                {
                    Console.WriteLine($"key: {entity.Key}  value: {Entity}");
                }
                
            }

            /* string way = @"D:\1.txt";
             File.WriteAllText(way, string.Empty);
             var LoggerInt = new LocalFileLogger<int>(way);
             var LoggerStr = new LocalFileLogger<string>(way);
             var LoggerChar = new LocalFileLogger<char>(way);
             LoggerChar.LogInfo("Hello");
             LoggerChar.LogWarning("Hello");
             LoggerInt.LogInfo("Hi");
             LoggerInt.LogWarning("Hi");
             LoggerStr.LogInfo("How");
             LoggerStr.LogWarning("How");
             try
             {
                 throw new IndexOutOfRangeException();
             }
             catch (IndexOutOfRangeException e)
             {
                 LoggerChar.LogError("Bye", e);
                 LoggerStr.LogError("Bye", e);
                 LoggerInt.LogError("Bye", e);
             }
            */
        }
    }
}
