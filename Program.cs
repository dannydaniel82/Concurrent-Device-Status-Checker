using System;
using System.Threading;
using System.Threading.Tasks;

internal static class Program
{
    private static async Task<int> Main()
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        ConsoleCancelEventHandler cancelHandler = (_, eventArgs) =>
        {
            eventArgs.Cancel = true;
            cancellationTokenSource.Cancel();
        };

        Console.CancelKeyPress += cancelHandler;

        try
        {
            Console.WriteLine("## 장비 통신상태 동시점검 프로그램 ##");
            Console.WriteLine("------------------------------");

            var checker = new StatusChecker();
            var results = await checker.CheckAllDevicesAsync(
                cancellationTokenSource.Token);

            Console.WriteLine("\n--- 최종 점검 결과 ---");
            foreach (var result in results)
            {
                var status = result.IsOnline ? "ONLINE 🟢" : "OFFLINE 🔴";
                Console.WriteLine(
                    $"Device [{result.IpAddress.PadRight(15)}]: {status} ({result.Latency.TotalMilliseconds:F0}ms)");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("프로그램 종료.");
            return 0;
        }
        catch (OperationCanceledException) when (cancellationTokenSource.IsCancellationRequested)
        {
            Console.WriteLine("\n점검이 취소되었습니다.");
            return 130;
        }
        finally
        {
            Console.CancelKeyPress -= cancelHandler;
        }
    }
}
