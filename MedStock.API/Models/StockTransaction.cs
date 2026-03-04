using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedStock.API.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; } // IN or OUT

        public string? Notes { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}