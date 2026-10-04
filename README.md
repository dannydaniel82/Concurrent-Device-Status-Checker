# Concurrent-Device-Status-Checker

## Overview

A small .NET 9 console app that checks a fixed list of devices concurrently.
The current PingEmitter simulates network latency and success or failure; it does not send ICMP packets.

## Features

- Concurrent checks with Task.WhenAll
- Async cancellation with Ctrl+C
- Structured results with device address, status, and elapsed simulated latency
- Configurable device list through StatusChecker

## Requirements

- .NET 9 SDK
- Windows, Linux, or macOS

## Run

From the project directory, run `dotnet run`.

Press Ctrl+C to cancel an active check. The program stops pending delays and exits with a cancellation message.

## Project structure

```
├── Program.cs                  # Console entry point and result display
├── StatusChecker.cs            # Starts and awaits concurrent checks
├── PingEmitter.cs              # Simulates a ping operation
├── DeviceStatusResult.cs       # Result model for each device
├── DeviceRepository.cs         # Default device addresses
└── ConcurrentStatusChecker.csproj
```

## License

MIT License
