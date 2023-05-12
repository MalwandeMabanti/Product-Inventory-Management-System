using Microsoft.EntityFrameworkCore;
using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<ProductInformation> ProductsInformation { get; set; }
    }
}
