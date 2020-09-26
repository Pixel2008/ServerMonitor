using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServerMonitor.Config;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerMonitor.Core
{
    internal class HostedService<T> : BackgroundService where T : IService
    {
        #region Members
        private readonly T service;
        private readonly IOptions<AppConfig> config;
        private readonly ILogger<T> logger;
        private bool enabled;
        private double interval;
        private double delay;
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
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await this.service.ValidateAsync();

                var test = this.config.Value.Test;
                var testMode = this.service is ITestMode;

                this.enabled = this.service.Enabled;
                this.interval = this.service.Interval;
                this.delay = this.service.Delay;

                if (test)
                {
                    this.interval = testMode ? 5 : 0;
                    this.delay = testMode ? 5 : 2;
                }

                this.logger.LogInformation($"Start Enabled={this.enabled.ToString()} Delay={this.delay}sec. Interval={this.interval}sec.");
                await base.StartAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error while starting service!");
            }            
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Stop");
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(this.delay));

            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogDebug($"Working");

                try
                {
                    await this.service.DoWorkAsync();

                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"An error occured!");
                }
                finally
                {
                    this.logger.LogDebug("Done");
                }

                if(this.interval == 0)
                {
                    await Task.CompletedTask;
                    return;
                }
                await Task.Delay(TimeSpan.FromSeconds(this.interval), stoppingToken);
            }
        }
        #endregion
    }
}
