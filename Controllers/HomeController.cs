namespace Product_Inventory_Management_System.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}