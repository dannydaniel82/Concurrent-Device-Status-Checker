using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class PingEmitter
{
    public async Task<DeviceStatusResult> SendPingAsync(
        string ipAddress,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ipAddress);
        Console.WriteLine($" == [{ipAddress}] Ping Test start . . . ");

        var latencyMilliseconds = Random.Shared.Next(500, 1501);
        await Task.Delay(latencyMilliseconds, cancellationToken);

        var isOnline = Random.Shared.Next(100) >= 10;
        var resultMessage = isOnline ? "success" : "failed";
        Console.WriteLine(
            $" <- [{ipAddress}] Ping 응답 수신 ({latencyMilliseconds}ms - 결과 : {resultMessage})");

        return new DeviceStatusResult(
            ipAddress,
            isOnline,
            TimeSpan.FromMilliseconds(latencyMilliseconds));
    }
}
