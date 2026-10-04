using System;

public sealed record DeviceStatusResult(
    string IpAddress,
    bool IsOnline,
    TimeSpan Latency);
