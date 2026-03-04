using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedStock.API.Data;
using MedStock.API.DTOs;

namespace MedStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<DashboardSummaryDto>> GetSummary()
        {
            var lowStockThreshold = 10;
            var expiryThresholdDays = 30;
            var expiryDate = DateTime.Now.AddDays(expiryThresholdDays);

            var totalProducts = await _context.Products.CountAsync();
            var totalStock = await _context.Products.SumAsync(p => p.Stock);
            var lowStockCount = await _context.Products
                .CountAsync(p => p.Stock <= lowStockThreshold);

            var expiringSoonCount = await _context.Products
                .CountAsync(p => p.ExpiryDate <= expiryDate);

            var summary = new DashboardSummaryDto
            {
                TotalProducts = totalProducts,
                TotalStock = totalStock,
                LowStockCount = lowStockCount,
                ExpiringSoonCount = expiringSoonCount
            };

            return Ok(summary);
        }
    }
}