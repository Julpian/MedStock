using MedStock.API.Data;
using MedStock.API.Models;

namespace MedStock.API.Services
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;

        public AuditService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(string userEmail, string action, string entity, string data)
        {
            var log = new AuditLog
            {
                UserEmail = userEmail,
                Action = action,
                EntityName = entity,
                Data = data
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}