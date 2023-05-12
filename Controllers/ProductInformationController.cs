using Microsoft.AspNetCore.Mvc;

namespace Product_Inventory_Management_System.Controllers
{
    public class ProductInformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
