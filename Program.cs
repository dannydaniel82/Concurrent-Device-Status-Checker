// Program.cs
// Main Program Entry Point for Concurrent Device Status Monitoring
using System;
using System.Threading.Tasks;

class Program
{
    // Application Entry Point
    static async Task Main(string[] args)
    {
        Console.WriteLine("## 장비 통신상태 동시점검 프로그램##");
        Console.WriteLine("------------------------------");

        // Initialize Status Checkr
        var checker = new StatusChecker();
        // Start Async Checking and Wait for Results
        var results = await checker.CheckAllDevicesAsync();
    
        Console.WriteLine("\n--- 최종 점검 결과 ---");

        // Display Reuslts
        foreach (var result in results)
        {
            string ip = result.Key; // result 는 Dictionary 형태
            string status = result.Value ? "ONLINE 🟢" : "OFFLINE 🔴";
            Console.WriteLine($"Device [{ip.PadRight(15)}]: {status}");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("프로그램 종료.");
    }
}