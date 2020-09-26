namespace ServerMonitor.Validators
{
    using ServerMonitor.Config;
    using System.Threading.Tasks;

    internal interface ISMTPValidator
    {
        Task ValidateAsync(SMTP smtp);
    }
}