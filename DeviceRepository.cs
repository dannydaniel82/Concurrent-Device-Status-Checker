// DeviceRepository.cs
// Device IP Address Repostiory / 장비 IP 주소 저장소
using System.Collections.Generic;
public static class DeviceRepository
{
    public static List<string> GetDeviceIps()
    {
        // Returns List of Device IP Addresses to Check
        return new List<string>
        {
            "192.168.100.1",    // Device#1
            "192.168.100.2",    // Device#2
            "192.168.100.3",    // Device#3
            "192.168.100.4",    // Device#4
            "192.168.100.5"     // Device#5
        };
    }
}

