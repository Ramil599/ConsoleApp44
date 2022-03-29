using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp111

{
   
    
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
                    Diction.Remove(ChildArray[i].ParentId);
                    Diction.Add(ChildArray[i].ParentId, _IdList);
                }
                

            }
            foreach (var entity in Diction)
            {
                Console.WriteLine($"key: {entity.Key}  value: {entity.Value}");
            }
             string way = @"D:\1.txt";
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
            
        }
    }
}
