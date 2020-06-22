using ServerMonitor.Domain;
using ServerMonitor.Extensions;
using ServerMonitor.Tools;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace ServerMonitor.Components
{
    internal class MessageDecorator : IMessageDecorator
    {
        #region Methods
        public Message GetMessage(Message message)
        {
            var nl = "".NL();
            var m = new Message
            {
                Title = $"ServerMonitor - {Environment.MachineName} - {message.Title}",
                Content = $"{message.Content}{nl}{nl}" +
                $"{string.Join(nl, this.ContentSuffix())}{nl}{nl}" +
                $"--{nl}" +
                $"ServerMonitor {App.AppNameVersion()}"
            };
            return m;
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
