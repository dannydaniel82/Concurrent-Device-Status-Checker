using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class StatusChecker
{
    private readonly PingEmitter _pingEmitter;
    private readonly IReadOnlyList<string> _deviceIps;

    public StatusChecker()
        : this(DeviceRepository.GetDeviceIps())
    {
    }

    public StatusChecker(IReadOnlyList<string> deviceIps)
    {
        ArgumentNullException.ThrowIfNull(deviceIps);

        _pingEmitter = new PingEmitter();
        _deviceIps = deviceIps.ToArray();
    }

    public async Task<IReadOnlyList<DeviceStatusResult>> CheckAllDevicesAsync(
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Check all devices' status . . .");

        var checkTasks = _deviceIps
            .Select(ip => _pingEmitter.SendPingAsync(ip, cancellationToken));

        var results = await Task.WhenAll(checkTasks);

        Console.WriteLine("모든 장비 점검 완료");
        return results;
    }
}
