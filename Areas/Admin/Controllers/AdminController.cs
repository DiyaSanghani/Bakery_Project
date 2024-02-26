using Bakery_Project.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_Project.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}")]
    [CheckAccess]
    [CheckAdmin]
    public class AdminController : Controller
    {

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult ViewProducts()
        {
            return View();
        }

        public IActionResult ViewOrderDetails()
        {
            return View();
        }
    }
}
