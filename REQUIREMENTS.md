# Project Purpose and Requirements

## Purpose

This project is a small .NET 9 console demo for coordinating multiple asynchronous device checks. It demonstrates concurrent task execution, structured results, and cancellation from Ctrl+C.

The current implementation simulates checks. It does not contact devices or send ICMP packets, so it must not be presented as a production network monitor.

## Functional requirements

- FR-1: Use the five addresses in DeviceRepository as the default input.
- FR-2: Allow callers to supply another address list through StatusChecker.
- FR-3: Start one simulated check per address and await all checks concurrently. Return one result per input entry in input order.
- FR-4: Simulate a latency from 500 to 1500 milliseconds and an online result with a 90% probability.
- FR-5: Return the address, online status, and simulated latency for each check.
- FR-6: Propagate a CancellationToken through StatusChecker to each simulated delay. Ctrl+C cancels pending checks, prints a cancellation message, and exits with code 130.
- FR-7: Reject a null, empty, or whitespace-only address before starting its simulated delay.

## Quality requirements

- Target .NET 9 and use only the .NET base libraries.
- Keep the check orchestration independent from the console result formatting.
- Use a thread-safe shared random source for concurrent simulations.
- Make the simulation boundary explicit in the README and console output.

## Out of scope

- Sending ICMP packets or making any other real network request.
- Reading device addresses from files, command-line arguments, or a live service.
- Retries, persistence, alerting, or long-running polling.

## Acceptance criteria

- Running the console app checks the default five addresses concurrently and displays one status and latency per address.
- A caller-provided list produces one result per entry in the same order.
- Cancelling during a simulated delay stops pending checks and the console app exits with code 130.
- A blank address is rejected without waiting for the simulated latency.
