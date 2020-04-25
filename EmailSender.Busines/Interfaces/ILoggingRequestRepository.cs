using EmailSender.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Busines.Interfaces
{
    public interface ILoggingRequestRepository
    {
        Task<LoggingRequest> AddEmailAsync(LoggingRequest entity);
        Task<IEnumerable<LoggingRequest>> GetAllEmailAsync();
        Task<bool> DeleteEmailAsync(int id);
        Task<LoggingRequest> GetById(int id);

    }
}
