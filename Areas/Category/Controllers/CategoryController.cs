using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.Category.Controllers
{
    [Area("Category")]
    [Route("Category/{controller}/{action}")]
    public class CategoryController : Controller
    {
        #region ViewCategories
        public IActionResult ViewCategories()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewCategories();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Category = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteCategories
        public IActionResult DeleteCategories(int CategoryID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteCart(CategoryID);
            return RedirectToAction("ViewCategories");
        }
        #endregion
    }
}
