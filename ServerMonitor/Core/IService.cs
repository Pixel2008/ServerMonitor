namespace ServerMonitor.Core
{
    internal interface IService
    {
        bool Enabled { get; }
        double Interval { get; }
        double Delay { get; }        
        void DoWork();
        void Validate();
    }
}
