using System;
using System.ComponentModel.DataAnnotations;

namespace MedStock.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public int Stock { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
