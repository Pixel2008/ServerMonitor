namespace ServerMonitor.Components
{
    using ServerMonitor.Domain;
    using ServerMonitor.Extensions;
    using ServerMonitor.Tools;
    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;

    internal class MessageDecorator : IMessageDecorator
    {
        #region Methods
        public Task<Message> GetMessageAsync(Message message)
        {
            if (message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            var nl = "".NL();
            var m = new Message
            {
                Title = $"ServerMonitor - {Environment.MachineName} - {message.Title}",
                Content = $"{message.Content}{nl}{nl}" +
                $"{string.Join(nl, this.ContentSuffix())}{nl}{nl}" +
                $"--{nl}" +
                $"ServerMonitor {App.AppNameVersion()}"
            };
            return Task.FromResult(m);
        }
        private IList<string> ContentSuffix()
        {
            var result = new List<string>
            {
                $"Server: {Environment.MachineName}"
            };
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                result.Add($"Network Interface {netInterface.Name} ({netInterface.Description})");
                result.Add("Addresses: ");
                IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                {
                    result.Add($"   {addr.Address.ToString()}");
                }
            }
            return result;
        }
        #endregion
    }
}
