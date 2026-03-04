using Microsoft.EntityFrameworkCore;
using MedStock.API.Data;
using MedStock.API.Models;

namespace MedStock.API.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetLowStockAsync(int threshold)
        {
            return await _context.Products
                .Where(p => p.Stock <= threshold)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetExpiringAsync(int days)
        {
            var targetDate = DateTime.Now.AddDays(days);

            return await _context.Products
                .Where(p => p.ExpiryDate <= targetDate)
                .ToListAsync();
        }
    }
}