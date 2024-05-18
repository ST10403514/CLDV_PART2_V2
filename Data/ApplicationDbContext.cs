using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLDV_POE_PART2_V1.Models;

namespace CLDV_POE_PART2_V1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderHistory> OrderHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Handcrafted Vase", Price = 450.00, Category = "Crafts", Availability = true },
                new Product { ProductId = 2, Name = "Bronze Sculpture", Price = 700.00, Category = "Crafts", Availability = true },
                new Product { ProductId = 3, Name = "Ceramic Bowl", Price = 300.00, Category = "Crafts", Availability = true }
            );
        }

    }
}
