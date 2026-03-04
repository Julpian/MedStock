using Microsoft.AspNetCore.Mvc;
using MedStock.API.Data;
using MedStock.API.Models;
using MedStock.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MedStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductService _productService;
        private readonly AuditService _auditService;

        public ProductsController(
            ApplicationDbContext context,
            ProductService productService,
            AuditService auditService)
        {
            _context = context;
            _productService = productService;
            _auditService = auditService;
        }

        // GET: api/products
        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }

        // POST: api/products
        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/products/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            var userEmail = User.Identity?.Name ?? "Unknown";

            await _auditService.LogAsync(
                userEmail,
                "DELETE",
                "Product",
                $"Deleted Product ID {id}"
            );

            return NoContent();
        }

        // LOW STOCK via Service
        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<Product>>> GetLowStockProducts([FromQuery] int threshold = 10)
        {
            var result = await _productService.GetLowStockAsync(threshold);
            return Ok(result);
        }

        // EXPIRING via Service
        [HttpGet("expiring")]
        public async Task<ActionResult<IEnumerable<Product>>> GetExpiringProducts([FromQuery] int days = 30)
        {
            var result = await _productService.GetExpiringAsync(days);
            return Ok(result);
        }
    }
}