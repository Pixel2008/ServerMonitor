
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServerMonitor.Tests")]
namespace ServerMonitor.Config
{
    internal class SMTP
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }

        public string Debug => $"{GetType().Name}:" +
            $"{nameof(Server)}={Server}:{Port}," +
                    $"{nameof(Timeout)}={Timeout}seconds," +
                    $"{nameof(Username)}={Username}," +
                    $"{nameof(Password)}={Password?.Length ?? 0}chars";
    }
}