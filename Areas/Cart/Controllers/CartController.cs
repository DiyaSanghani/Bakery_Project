using Bakery_Project.Areas.Cart.Models;
using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.Areas.User.Models;
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

        #region ProductDropDownList
        public void ProductDropDownList()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Product_DropDownList();
            List<ProductDropdownModel> productDropDownModelList = new List<ProductDropdownModel>();
            foreach (DataRow data in dt.Rows)
            {
                ProductDropdownModel productDropDownModel = new ProductDropdownModel();
                productDropDownModel.ProductID = Convert.ToInt32(data["ProductID"]);
                productDropDownModel.ProductName = data["ProductName"].ToString();
                productDropDownModelList.Add(productDropDownModel);
            }
            ViewBag.productDropDownModel = productDropDownModelList;
        }
        #endregion

        #region UserDropDownList
        public void UserDropDownList()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.User_DropDownList();
            List<UserDropdownModel> userDropDownModelList = new List<UserDropdownModel>();
            foreach (DataRow data in dt.Rows)
            {
                UserDropdownModel userDropDownModel = new UserDropdownModel();
                userDropDownModel.UserID = Convert.ToInt32(data["UserID"]);
                userDropDownModel.UserName = data["UserName"].ToString();
                userDropDownModelList.Add(userDropDownModel);
            }
            ViewBag.userDropDownModel = userDropDownModelList;
        }
        #endregion

        #region AddEditCart
        public IActionResult AddEditCart()
        {
            ProductDropDownList();
            UserDropDownList();
            return View();
        }
        #endregion

        #region AddEditCartData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditCartData(CartModel cartModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (cartModel.CartID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_Cart_Insert(cartModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_Cart_Update(cartModel);
                }
                return RedirectToAction("ViewCart");
            }
            else
            {
                ProductDropDownList();
                UserDropDownList();
                return View("AddEditCart");
            }
        }
        #endregion

        #region EditCart
        [HttpGet]
        public IActionResult EditCart(int CartID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_Cart_SelectByID(CartID);
            CartModel cartModel = new CartModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    cartModel.CartID = Convert.ToInt32(dataRow[0]);
                    cartModel.CartNumber = Convert.ToInt32(dataRow[1]);
                    cartModel.ProductID = Convert.ToInt32(dataRow[2]);
                    cartModel.UserID = Convert.ToInt32(dataRow[3]);
                    cartModel.TotalAmount = Convert.ToDecimal(dataRow[4]);
                    cartModel.CartQuantity = Convert.ToInt32(dataRow[5]);
                }
            }
            ViewBag.ID = CartID;
            ProductDropDownList();
            UserDropDownList();
            return View("AddEditCart", cartModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewCart");
        }
        #endregion
    }
}
