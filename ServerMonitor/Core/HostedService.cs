using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServerMonitor.Config;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerMonitor.Core
{
    internal class HostedService<T> : IHostedService, IDisposable where T : IService
    {
        #region Members
        private readonly T service;
        private readonly IOptions<AppConfig> config;
        private readonly ILogger<T> logger;
        private Timer timer;
        #endregion

        #region .ctor
        public HostedService(T service, IOptions<AppConfig> config, ILogger<T> logger) : base()
        {
            this.service = service;
            this.config = config;
            this.logger = logger;
        }
        #endregion

        #region Methods
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                this.service.Validate();

                var enabled = this.service.Enabled;
                var test = this.config.Value.Test;
                var testMode = this.service is ITestMode;
                var interval = this.service.Interval;
                var delay = this.service.Delay;

                if (test)
                {
                    interval = testMode ? 5 : 0;
                    delay = testMode ? 5 : 2;
                }

                this.logger.LogInformation($"Start Enabled={enabled.ToString()} Delay={delay}sec. Interval={interval}min.");

                if (enabled)
                {
                    this.timer = new Timer(DoWork, null, TimeSpan.FromSeconds(delay), TimeSpan.FromSeconds(interval));
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error while starting service!");
            }
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            this.logger.LogDebug($"Working");
            try
            {
                this.service.DoWork();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"An error occured!");
            }
            finally
            {
                this.logger.LogDebug("Done");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);
            this.logger.LogInformation("Stop");

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            this.timer?.Dispose();
        }
        #endregion
    }
}
