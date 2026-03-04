using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedStock.API.Data;
using MedStock.API.Models;

namespace MedStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(StockTransaction transaction)
        {
            var product = await _context.Products.FindAsync(transaction.ProductId);

            if (product == null)
                return NotFound("Product not found");

            if (transaction.Type == "OUT" && product.Stock < transaction.Quantity)
                return BadRequest("Insufficient stock");

            // Update stock
            if (transaction.Type == "IN")
                product.Stock += transaction.Quantity;
            else if (transaction.Type == "OUT")
                product.Stock -= transaction.Quantity;
            else
                return BadRequest("Type must be IN or OUT");

            _context.StockTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTransaction>>> GetTransactions()
        {
            return await _context.StockTransactions
                .Include(t => t.Product)
                .ToListAsync();
        }
    }
}