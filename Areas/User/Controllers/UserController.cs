using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/{controller}/{action}")]
    public class UserController : Controller
    {
        #region ViewUsers
        public IActionResult ViewUsers()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewUsers();
            if (dt.Rows.Count == 0)
            {
                ViewBag.User = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteUsers
        public IActionResult DeleteUsers(int UserID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteUser(UserID);
            return RedirectToAction("ViewUsers");
        }
        #endregion
    }
}
