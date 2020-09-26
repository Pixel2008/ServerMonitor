namespace ServerMonitor.Components
{
    using ServerMonitor.Domain;
    using ServerMonitor.Tools;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    internal class MemoryInfo : IMemoryInfo
    {
        public Task<MemoryMetrics> GetMemoryMetricsAsync()
        {
            if (OS.IsWindows())
                return WindowsMetricsAsync();
            else if (OS.IsLinux())
                return LinuxMetricsAsync();
            else
                throw new NotSupportedException("OS not supported!");
        }

        private Task<MemoryMetrics> WindowsMetricsAsync()
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

            return Task.FromResult(metrics);
        }

        private Task<MemoryMetrics> LinuxMetricsAsync()
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

            return Task.FromResult(metrics);
        }
    }
}
