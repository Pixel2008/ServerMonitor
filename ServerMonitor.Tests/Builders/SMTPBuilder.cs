using ServerMonitor.Config;

namespace ServerMonitor.Tests.Builders
{
    internal class SMTPBuilder
    {
        private readonly SMTP smtp;

        public SMTPBuilder()
        {
            this.smtp = new SMTP();
        }

        public SMTPBuilder WithServer(string server)
        {
            this.smtp.Server = server;
            return this;
        }

        public SMTPBuilder WithPort(int port)
        {
            this.smtp.Port = port;
            return this;
        }

        public SMTPBuilder WithUsername(string username)
        {
            this.smtp.Username = username;
            return this;
        }

        public SMTPBuilder WithPassword(string password)
        {
            this.smtp.Password = password;
            return this;
        }

        public SMTPBuilder WithTimeout(int timeout)
        {
            this.smtp.Timeout = timeout;
            return this;
        }

        public SMTP Build()
        {
            return this.smtp;
        }
    }
}
