using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.Cart.Controllers
{
    [Area("Cart")]
    [Route("Cart/{controller}/{action}")]
    public class CartController : Controller
    {
        #region ViewCart
        public IActionResult ViewCart()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewCart();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Product = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteCart
        public IActionResult DeleteCart(int CartID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteCart(CartID);
            return RedirectToAction("ViewCart");
        }
        #endregion
    }
}
