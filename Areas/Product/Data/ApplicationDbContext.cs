using Microsoft.AspNetCore.Mvc;

namespace Bakery_Project.Areas.Product.Data
{
    public class ApplicationDbContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
