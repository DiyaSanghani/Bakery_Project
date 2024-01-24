using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Route("Employee/{controller}/{action}")]
    public class EmployeeController : Controller
    {
        #region ViewEmployees
        public IActionResult ViewEmployees()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewEmployees();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Employee = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteEmployees
        public IActionResult DeleteEmployees(int EmployeeID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteEmployees(EmployeeID);
            return RedirectToAction("ViewEmployees");
        }
        #endregion
    }
}
