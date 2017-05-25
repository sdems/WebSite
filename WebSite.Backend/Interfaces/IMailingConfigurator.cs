namespace WebSite.Backend.Interfaces
{
    public interface IMailingConfigurator
    {
        string GetHost();
        string GetSenderName();
        string GetSenderMail();
        string GetSenderPassword();
        int GetPort();
    }
}
