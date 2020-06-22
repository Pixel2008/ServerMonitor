using ServerMonitor.Domain;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Validators
{
    internal class MessageValidator : IMessageValidator
    {
        public void Validate(Message message)
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
        }
    }
}
