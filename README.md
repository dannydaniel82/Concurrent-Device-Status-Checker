# Concurrent-Device-Status-Checker

## Purpose

A small .NET 9 console demo of concurrent asynchronous device checks, structured results, and Ctrl+C cancellation.

Checks are simulated: the program does not contact devices or send ICMP packets. See [REQUIREMENTS.md](REQUIREMENTS.md) for the project scope and acceptance criteria.

## Features

- Concurrent checks with Task.WhenAll
- Cancellation of in-flight simulated checks with Ctrl+C
- Structured results with address, online status, and simulated latency
- Alternate address lists can be supplied to StatusChecker

## Requirements

- .NET 9 SDK
- Windows, Linux, or macOS

## Run

From the project directory, run dotnet run.

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
