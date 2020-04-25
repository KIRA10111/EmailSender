using EmailSender.Busines.Interfaces;
using EmailSender.Data.Models;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmailSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggingRequestRepository _loggingRequestRepository;
        public HomeController(ILoggingRequestRepository loggingRequestRepository)
        {
            _loggingRequestRepository = loggingRequestRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmailSender(string fromEmail, string toEmail, string subject, string body)
        {
            var result = new LoggingRequest();
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, null);
                var to = new EmailAddress(toEmail, null);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
                var response = await client.SendEmailAsync(msg);
                var statusCode = (int)response.StatusCode;
                if (statusCode == 200 || statusCode == 201 || statusCode == 202)
                {
                   result.Success = true;                   
                    //ViewBag.Message = "Your mail was sended!";
                }
                else
                {
                    result.Success = false;
                    //ViewBag.Message = "Oops! Something went wrong :( Unable to send mail from {} to {}";
                }

                result.FromEmail = fromEmail;
                result.ToEmail = toEmail;
                result.Subject = subject;
                result.Body = body;
                result.SendingTime = DateTime.UtcNow;                  
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            await _loggingRequestRepository.AddEmailAsync(result);
            return RedirectToAction("Archive");
        }
        public async Task<ActionResult> Archive()
        {
            var results = await _loggingRequestRepository.GetAllEmailAsync();

            return View(results);
        }
       
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _loggingRequestRepository.DeleteEmailAsync(id);
            return RedirectToAction("Archive");

        }
    }
}