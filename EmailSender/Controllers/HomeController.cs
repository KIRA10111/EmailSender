using EmailSender.Busines.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmailSender.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILoggingRequestRepository _loggingRequestRepository;
        private readonly IEmailSenderService _emailSenderServices;
        public HomeController(ILoggingRequestRepository loggingRequestRepository, IEmailSenderService emailSenderServices)
        {
            _loggingRequestRepository = loggingRequestRepository;
            _emailSenderServices = emailSenderServices;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmailSender(string fromEmail, string toEmail, string subject, string body)
        {
            await _emailSenderServices.SendEmailAsync(fromEmail, toEmail, subject, body);
            return RedirectToAction("Archive");
        }
        public async Task<ActionResult> Archive()
        {
            var allEmails = await _loggingRequestRepository.GetAllEmailsAsync();
          
            return View(allEmails);
        }
       
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _loggingRequestRepository.DeleteEmailAsync(id);
            return RedirectToAction("Archive");
        }
    }
}