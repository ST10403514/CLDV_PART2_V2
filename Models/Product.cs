using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLDV_POE_PART2_V1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string? Category { get; set; }

        public bool Availability { get; set; }

        // Navigation property
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

