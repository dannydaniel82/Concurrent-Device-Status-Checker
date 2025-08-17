// StatusChecker.cs
// Device Status Checker Using Async/Await pattern

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Manages Concurrent Status Checking of Multiple Devices
public class StatusChecker
{
    private readonly PingEmitter _pingEmitter;
    private readonly List<string> _deviceIps;

    // Initialize StatusCHecker with PingEmiiter and Deivce IPs
    public StatusChecker()
    {
        _pingEmitter = new PingEmitter();
        _deviceIps = DeviceRepository.GetDeviceIps();
    }

    // Check All Devices' Status Concurrently using Taks.WhenAll
    public async Task<Dictionary<string, bool>> CheckAllDevicesAsync()
    {
        Console.WriteLine("Check all devices' status . . .");

        // Create Concurrent Tasks for Each Device IP
        var checkTasks = _deviceIps
            .Select(async ip => new { IP = ip, IsOnline = await _pingEmitter.SendPingAsync(ip) })
            .ToList();

        // Wait for All Tasks to Complete Concurrently
        var results = await Task.WhenAll(checkTasks);

        Console.WriteLine("모든 장비 점검 완료");

        // Conver results to Dictionary Format
        return results.ToDictionary(res => res.IP, res => res.IsOnline);
    }
}