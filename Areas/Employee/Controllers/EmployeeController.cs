using Bakery_Project.Areas.Employee.Models;
using Bakery_Project.Areas.Product.Models;
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

        #region AddEditEmployees
        public IActionResult AddEditEmployees()
        {
            return View();
        }
        #endregion

        #region AddEditEmployeesData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditEmployeesData(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (employeeModel.EmployeeID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_Employee_Insert(employeeModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_Employee_Update(employeeModel);
                }
                return RedirectToAction("ViewEmployees");
            }
            else
            {
                return View("AddEditEmployees");
            }
        }
        #endregion

        #region EditEmployees
        [HttpGet]
        public IActionResult EditEmployees(int EmployeeID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_Employee_SelectByID(EmployeeID);
            EmployeeModel employeeModel = new EmployeeModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    employeeModel.EmployeeID = Convert.ToInt32(dataRow[0]);
                    employeeModel.EmployeeName = dataRow[1].ToString();
                    employeeModel.IsActive = Convert.ToBoolean(dataRow[3]);
                }
            }
            ViewBag.ID = EmployeeID;
            return View("AddEditEmployees", employeeModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewEmployees");
        }
        #endregion

    }
}
