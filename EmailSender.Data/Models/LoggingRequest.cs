using System;

namespace EmailSender.Data.Models
{
    public class LoggingRequest
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Success { get; set; } 
        public string Error { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
