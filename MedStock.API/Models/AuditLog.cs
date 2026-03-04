using System;

namespace MedStock.API.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public string Data { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}