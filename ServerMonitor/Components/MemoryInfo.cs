using ServerMonitor.Domain;
using ServerMonitor.Tools;
using System;
using System.Diagnostics;

namespace ServerMonitor.Components
{
    internal class MemoryInfo : IMemoryInfo
    {
        public MemoryMetrics GetMemoryMetrics()
        {
            if (OS.IsWindows())
                return WindowsMetrics();
            else if (OS.IsLinux())
                return LinuxMetrics();
            else
                throw new NotSupportedException("OS not supported!");
        }

        private MemoryMetrics WindowsMetrics()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "wmic",
                Arguments = "OS get FreePhysicalMemory, TotalVisibleMemorySize /Value",
                RedirectStandardOutput = true
            };

            using var process = Process.Start(processInfo);
            var output = process.StandardOutput.ReadToEnd();

            var lines = output.Trim().Split("\n");

            var metrics = new Domain.MemoryMetrics()
            {
                Free = double.Parse(lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries)[1])*1024,
                Total = double.Parse(lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries)[1])*1024                
            };

            return metrics;
        }

        private MemoryMetrics LinuxMetrics()
        {
            var processInfo = new ProcessStartInfo("free -m")
            {
                FileName = "/bin/bash",
                Arguments = "-c \"free -m\"",
                RedirectStandardOutput = true
            };

            using var process = Process.Start(processInfo);
            var output = process.StandardOutput.ReadToEnd();

            var lines = output.Split("\n");
            var memory = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var metrics = new Domain.MemoryMetrics()
            {
                Total = double.Parse(memory[1]),
                Free = double.Parse(memory[3])
            };

            return metrics;
        }
    }
}
