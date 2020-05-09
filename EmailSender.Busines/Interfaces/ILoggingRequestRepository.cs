using EmailSender.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Busines.Interfaces
{
    public interface ILoggingRequestRepository
    {
        Task<LoggingRequest> AddEmailAsync(LoggingRequest entity);
        Task<IEnumerable<LoggingRequest>> GetAllEmailsAsync();
        Task<bool> DeleteEmailAsync(int id);
        Task<LoggingRequest> GetById(int id);
    }
}
