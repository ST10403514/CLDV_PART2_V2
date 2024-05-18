using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLDV_POE_PART2_V1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
