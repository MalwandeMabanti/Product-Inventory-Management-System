using Microsoft.EntityFrameworkCore;
using Product_Inventory_Management_System.Data;
using Product_Inventory_Management_System.Interface;
using Product_Inventory_Management_System.Models;
using System.Xml.Linq;

namespace Product_Inventory_Management_System.Service
{
    public class ProductInformationService : GenericService<ProductInformation>, IProductInformationService
    {
        public ProductInformationService(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
