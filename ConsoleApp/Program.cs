using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
         static async Task Main(string[] args)
        {
            do
            {
                AddLog("Ap is runnig");
                Console.WriteLine("Request Type (Sync = 0 Async = 1):");
                int requesType = int.Parse(Console.ReadLine());

                Console.WriteLine("How many request: ");
                int requestCount = int.Parse(Console.ReadLine());
                
                var sw = Stopwatch.StartNew();
                var task = requesType == 0 ?GetSyncTasks(requestCount): GetASyncTasks(requestCount);
                await Task.WhenAll(task);
                sw.Stop();
                AddLog($"Total Time : {sw.ElapsedMilliseconds} MS");
            } while (true);
            
            
        }

         public static IEnumerable<Task> GetSyncTasks(int howMany)
         {
             var result = new List<Task>();
             var client = new WebApiClient();
             for (int i = 0; i < howMany; i++)
             {
                 result.Add(client.CallSync());
             }

             return result;
         }
         public static IEnumerable<Task> GetASyncTasks(int howMany)
         {
             var result = new List<Task>();
             var client = new WebApiClient();
             for (int i = 0; i < howMany; i++)
             {
                 result.Add(client.CallAsync());
             }

             return result;
         }
        private static void AddLog(string logStr)
        {
            logStr = $"[{DateTime.Now:dd.MM.yyy HH:mm:ss}] {logStr}";
            Console.WriteLine(logStr);
        }
    }
}