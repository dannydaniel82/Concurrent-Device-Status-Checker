# Concurrent-Device-Status-Checker

## Overview
This program demonstrates concurrent device status checking using C#'s async/await pattern


## Features
- **Concurrent Processing** : Multiple device status checks simultaneously
- **Async/Await Pattern** : Non-blocking operations for better performance  
- **Simulated Network Operations** : Configurable latency and success rates
- **Real-time Status Display** : Live monitoring of device connectivity

## Requirements 

- .NET 9.0 or higher
- Any OS (Windows/Linux/macOS)

## Project Structure

```
├── Program.cs              # Main entry point
├── StatusChecker.cs        # Orchestrates concurrent checking
├── PingEmitter.cs          # Simulates ping operation
├── DeviceRepository.cs     # Device IP management
└── ConcurrentStatusChecker.csproj
```

## Sample Output / 실행 예시

```
## 장비 통신상태 동시점검 프로그램##
------------------------------
Check all devices' status . . .
 == [192.168.100.1] Ping Test start . . . 
 == [192.168.100.2] Ping Test start . . . 
 == [192.168.100.3] Ping Test start . . . 
 <- [192.168.100.1] Ping 응답 수신 (1203ms - 결과 : successed)
 <- [192.168.100.3] Ping 응답 수신 (1456ms - 결과 : failed)
모든 장비 점검 완료

--- 최종 점검 결과 ---
Device [192.168.100.1 ]: ONLINE 🟢
Device [192.168.100.2 ]: ONLINE 🟢
Device [192.168.100.3 ]: OFFLINE 🔴
Device [192.168.100.4 ]: ONLINE 🟢
Device [192.168.100.5 ]: ONLINE 🟢
------------------------------
프로그램 종료.
```

## Key Concepts

### Concurrent Execution
- Uses `Task.WhenAll()` to execute multiple ping operations simultaneously

### Async/Await Pattern
- Non-blocking operations for better performance and responsiveness

### Separation of Concerns 
- Clear separation between data, business logic, and presentation


## License

MIT License
