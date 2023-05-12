using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Product_Inventory_Management_System.Models
{
    public class ProductInformation
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name  { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}

//dotnet ef database update AuditUpdate --context ApplicationDbContext
