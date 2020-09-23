namespace ServerMonitor.Tests.Builders
{
    using ServerMonitor.Config;

    internal class SMTPBuilder : BaseBuilder<SMTP>
    {
        public SMTPBuilder WithServer(string server)
        {
            this.Obj.Server = server;
            return this;
        }

        public SMTPBuilder WithPort(int port)
        {
            this.Obj.Port = port;
            return this;
        }

        public SMTPBuilder WithUsername(string username)
        {
            this.Obj.Username = username;
            return this;
        }

        public SMTPBuilder WithPassword(string password)
        {
            this.Obj.Password = password;
            return this;
        }

        public SMTPBuilder WithTimeout(int timeout)
        {
            this.Obj.Timeout = timeout;
            return this;
        } 
    }
}
