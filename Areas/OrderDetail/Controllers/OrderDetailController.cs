using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.OrderDetail.Controllers
{
    [Area("OrderDetail")]
    [Route("OrderDetail/{controller}/{action}")]
    public class OrderDetailController : Controller
    {
        #region ViewOrderDetails
        public IActionResult ViewOrderDetails()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewOrderDetails();
            if (dt.Rows.Count == 0)
            {
                ViewBag.OrderDetail = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteOrderDetails
        public IActionResult DeleteOrderDetails(int OrderDetailID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteOrderDetail(OrderDetailID);
            return RedirectToAction("ViewOrderDetails");
        }
        #endregion
    }
}
