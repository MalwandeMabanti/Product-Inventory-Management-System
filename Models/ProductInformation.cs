using System.Globalization;

namespace Product_Inventory_Management_System.Models
{
    public class ProductInformation
    {
        public string Name  { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
