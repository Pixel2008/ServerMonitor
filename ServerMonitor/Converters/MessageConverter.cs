using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Converters
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServerMonitor.Config;
    using ServerMonitor.Domain;
    using ServerMonitor.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class MessageConverter : IMessageConverter
    {
        private readonly IOptions<AppConfig> config;
        private readonly ILogger<MessageConverter> logger;

        public MessageConverter(IOptions<AppConfig> config, ILogger<MessageConverter> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public Task<Message> GetAsync(DiskDriveMetrics diskDriveMetrics)
        {
            if (diskDriveMetrics == null)
            {
                throw new NullReferenceException(nameof(diskDriveMetrics));
            }

            var test = this.config.Value.Test;
            var config = this.config.Value.DiskDrive;

            this.logger.LogDebug($"{diskDriveMetrics.Debug}");

            var isReady = diskDriveMetrics.IsReady;
            var usage = Math.Round(System.Convert.ToDouble(100 * diskDriveMetrics.Used) / diskDriveMetrics.Total);

            var warning = !isReady || (usage > config.Partitions.FirstOrDefault(x => x.Path == diskDriveMetrics.Path).MaxPercentageUsage);
            var send = config.ReportMode || warning || test;

            Message message = null;

            if (send)
            {
                var path = diskDriveMetrics.Path;
                var title = (warning ? "Warning - " : "") + $"DiskDrive - {path}";
                string content;
                if (isReady)
                {
                    var nl = "".NL();
                    var lines = new List<string>();

                    if (warning)
                    {
                        lines.Add($"Critical drive {path} {usage}% usage!{nl}{nl}");
                    }

                    lines.Add($"Capacity: {diskDriveMetrics.Total.BytesToString()}");
                    lines.Add($"Free space: {diskDriveMetrics.Free.BytesToString()}");
                    content = string.Join(nl, lines);
                }
                else
                {
                    content = $"Drive {path} is not ready!";
                }
                message = new Message { Title = title, Content = content };
            }
            return Task.FromResult(message);
        }

        public Task<Message> GetAsync(MemoryMetrics memoryMetrics)
        {
            if(memoryMetrics == null)
            {
                throw new NullReferenceException(nameof(memoryMetrics));
            }

            var test = this.config.Value.Test;
            var config = this.config.Value.Memory;

            this.logger.LogDebug($"Test={test} {config.Debug} {memoryMetrics.Debug}");

            var usage = Math.Round(100 * memoryMetrics.Used / memoryMetrics.Total);
            var maxPercentageUsage = config.MaxPercentageUsage;
            var warning = usage > maxPercentageUsage;
            var send = config.ReportMode || warning || test;

            Message message = null;
            if (send)
            {
                var title = (warning ? "Warning - " : "") + "RAM Memory";
                var nl = "".NL();
                var lines = new List<string>();

                if (warning)
                {
                    lines.Add($"RAM memory {usage}% consumed!{nl}{nl}");
                }

                lines.Add($"Total: {memoryMetrics.Total.BytesToString()}");
                lines.Add($"Used: {memoryMetrics.Used.BytesToString()}");
                lines.Add($"Free: {memoryMetrics.Free.BytesToString()}");
                message = new Message { Title = title, Content = string.Join(nl, lines) };
            }
            return Task.FromResult(message);
        }
    }
}
