using Microsoft.EntityFrameworkCore;
using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            context.Database.EnsureCreated();

            if (!context.ProductsInformation.Any())
            {
                context.ProductsInformation.AddRange(
                new ProductInformation()
                {
                   ProductId = 1,
                   Name = "Nike",
                   Description = "Jordans",
                   Price = 1000,
                   Quantity = 20,

                });
            }

        }
    }
}
