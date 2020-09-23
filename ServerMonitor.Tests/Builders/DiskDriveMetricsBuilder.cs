namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Domain;

    internal class DiskDriveMetricsBuilder : BaseBuilder<DiskDriveMetrics>
    {        
        public DiskDriveMetricsBuilder WithPath(string path)
        {
            this.Obj.Path = path;
            return this;
        }

        public DiskDriveMetricsBuilder WithIsReady(bool isReady)
        {
            this.Obj.IsReady = isReady;
            return this;
        }

        public DiskDriveMetricsBuilder WithTotal(long total)
        {
            this.Obj.Total = total;
            return this;
        }

        public DiskDriveMetricsBuilder WithFree(long free)
        {
            this.Obj.Free = free;
            return this;
        }
    }
}
