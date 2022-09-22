namespace MySecrets.CrossCutting.Emails.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(IEmailMessage message);
    }
}
