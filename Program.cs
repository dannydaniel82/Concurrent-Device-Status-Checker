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
            Console.WriteLine("## 장비 상태 점검 시뮬레이터 ##");
            Console.WriteLine("실제 네트워크에 연결하지 않습니다.");
            Console.WriteLine("------------------------------");

            var checker = new StatusChecker();
            var results = await checker.CheckAllDevicesAsync(
                cancellationTokenSource.Token);

            Console.WriteLine("\n--- 최종 점검 결과 (시뮬레이션) ---");
            foreach (var result in results)
            {
                var status = result.IsOnline ? "ONLINE 🟢" : "OFFLINE 🔴";
                Console.WriteLine(
                    $"Device [{result.IpAddress.PadRight(15)}]: {status} ({result.Latency.TotalMilliseconds:F0}ms)");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("시뮬레이션 종료.");
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
