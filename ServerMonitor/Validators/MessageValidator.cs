using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Validators
{
    using ServerMonitor.Domain;
    using System;    
    using System.Threading.Tasks;

    internal class MessageValidator : IMessageValidator
    {
        public Task ValidateAsync(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (string.IsNullOrEmpty(message.Title))
            {
                throw new ArgumentNullException(nameof(message.Title));
            }

            if (string.IsNullOrEmpty(message.Content))
            {
                throw new ArgumentNullException(nameof(message.Content));
            }
            return Task.CompletedTask;
        }
    }
}
