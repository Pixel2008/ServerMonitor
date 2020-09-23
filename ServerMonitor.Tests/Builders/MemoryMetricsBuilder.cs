namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Domain;

    internal class MemoryMetricsBuilder : BaseBuilder<MemoryMetrics>
    {    
        public MemoryMetricsBuilder WithTotal(double total)
        {
            this.Obj.Total = total;
            return this;
        }

        public MemoryMetricsBuilder WithFree(double free)
        {
            this.Obj.Free = free;
            return this;
        }
    }
}
