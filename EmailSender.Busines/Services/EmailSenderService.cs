using EmailSender.Busines.Interfaces;
using EmailSender.Data.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EmailSender.Busines.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly string apiKey = "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";
        private readonly ILoggingRequestRepository _loggingRequestRepository;
        public EmailSenderService(ILoggingRequestRepository loggingRequestRepository)
        {
            _loggingRequestRepository = loggingRequestRepository;
        }
        public async Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body)
        {
            
            var mailInformation = new LoggingRequest();
            try
            {                
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, null);
                var to = new EmailAddress(toEmail, null);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
                var response = await client.SendEmailAsync(msg);
                var statusCode = (int)response.StatusCode;
                if (statusCode == 200 || statusCode == 201 || statusCode == 202)
                {
                    mailInformation.Success = true;
                }
                else
                {
                    mailInformation.Success = false;
                }

                mailInformation.FromEmail = fromEmail;
                mailInformation.ToEmail = toEmail;
                mailInformation.Subject = subject;
                mailInformation.Body = body;
                mailInformation.SendingTime = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                mailInformation.Error = ex.Message;
            }
            await _loggingRequestRepository.AddEmailAsync(mailInformation);
            if (mailInformation.Success == true)
            {
                Logger.Debug("Message successfuly sending");
            }
            else
            {
                Logger.Debug("Message sending is fail");
            }
        }
    }
}
