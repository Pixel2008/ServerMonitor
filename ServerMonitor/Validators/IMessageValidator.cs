using ServerMonitor.Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Validators
{
    internal interface IMessageValidator
    {
        void Validate(Message message);
    }
}