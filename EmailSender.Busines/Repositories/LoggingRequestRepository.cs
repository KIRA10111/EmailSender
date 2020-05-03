using EmailSender.Busines.Interfaces;
using EmailSender.Data;
using EmailSender.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EmailSender.Busines.Repositories
{
    public class LoggingRequestRepository : ILoggingRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public LoggingRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoggingRequest> AddEmailAsync(LoggingRequest entity)
        {
            try
            {
                var result = _context.LoggingRequest.Add(entity);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmailAsync(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                try
                {
                    _context.LoggingRequest.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            throw new NullReferenceException($"Result with id={id} not found");
        }

        public async Task<IEnumerable<LoggingRequest>> GetAllEmailAsync()
        {
            return await _context.LoggingRequest.ToListAsync();
        }

        public async Task<LoggingRequest> GetById(int id)
        {
            return await _context.LoggingRequest.FirstOrDefaultAsync(_ => _.Id == id);            
        }

    }
}
