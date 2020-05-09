using System.Threading.Tasks;

namespace EmailSender.Busines.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}
