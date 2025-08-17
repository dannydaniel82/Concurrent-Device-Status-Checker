// PingEmitter.cs
// Ping Test Simulator

using System;
using System.Threading.Tasks;

// Simulates Ping Operations to Test Device Connectivity
public class PingEmitter
{
    private static readonly Random _random = new Random();

    // Sends a Simulated Ping to the Specified IP Address
    public async Task<bool> SendPingAsync(string ip)
    {
        Console.WriteLine($" == [{ip}] Ping Test start . . . ");

        // Simulate Network Latency : 500ms ~ 1500ms
        int latency = new Random().Next(500, 1501);
        await Task.Delay(latency);

        // Simulate Success/Failure (90% success rate)
        bool isSuccess = _random.Next(0, 10) != 0;

        string resultMessage = isSuccess ? "successed" : "failed";
        Console.WriteLine($" <- [{ip}] Ping 응답 수신 ({latency}ms - 결과 : {resultMessage})");

        return isSuccess;
    }
}