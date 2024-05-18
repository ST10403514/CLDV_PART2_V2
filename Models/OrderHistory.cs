using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLDV_POE_PART2_V1.Models
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
