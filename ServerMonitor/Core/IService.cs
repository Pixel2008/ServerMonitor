using System.Threading.Tasks;

namespace ServerMonitor.Core
{
    internal interface IService
    {
        bool Enabled { get; }
        double Interval { get; }
        double Delay { get; }        
        Task DoWorkAsync();
        Task ValidateAsync();
    }
}
