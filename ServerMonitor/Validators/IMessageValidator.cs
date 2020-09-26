using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Validators
{
    using ServerMonitor.Domain;
    using System.Threading.Tasks;

    internal interface IMessageValidator
    {
        Task ValidateAsync(Message message);
    }
}