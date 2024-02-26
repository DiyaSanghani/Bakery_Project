using Bakery_Project.Areas.Cart.Models;
using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.OrderDetail.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

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
        public IActionResult DeleteOrderDetails(int OrderID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteOrderDetail(OrderID);
            return RedirectToAction("ViewOrderDetails");
        }
        #endregion

        #region CartDropDownList
        public void CartDropDownList()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Cart_DropDownList();
            List<CartDropdownModel> cartDropDownModelList = new List<CartDropdownModel>();
            foreach (DataRow data in dt.Rows)
            {
                CartDropdownModel cartDropDownModel = new CartDropdownModel();
                cartDropDownModel.CartID = Convert.ToInt32(data["CartID"]);
                cartDropDownModel.CartNumber = Convert.ToInt32(data["CartNumber"]);
                cartDropDownModelList.Add(cartDropDownModel);
            }
            ViewBag.cartDropDownModel = cartDropDownModelList;
        }
        #endregion

        #region AddEditOrderDetails
        public IActionResult AddEditOrderDetails()
        {
            CartDropDownList();
            return View();
        }
        #endregion

        #region AddEditOrderDetailsData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditOrderDetailsData(OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (orderDetailModel.OrderID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_OrderDetail_Insert(orderDetailModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_OrderDetail_Update(orderDetailModel);
                }
                return RedirectToAction("ViewOrderDetails");
            }
            else
            {
                CartDropDownList();
                return View("AddEditOrderDetails");
            }
        }
        #endregion

        #region EditOrderDetails
        [HttpGet]
        public IActionResult EditOrderDetails(int OrderID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_OrderDetail_SelectByID(OrderID);
            OrderDetailModel orderDetailModel = new OrderDetailModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    orderDetailModel.OrderID = Convert.ToInt32(dataRow[0]);
                    orderDetailModel.CartID = Convert.ToInt32(dataRow[1]);
                    orderDetailModel.OrderItemName = dataRow[2].ToString();
                    orderDetailModel.OrderQuantity = Convert.ToInt32(dataRow[3]);
                }
            }
            ViewBag.ID = OrderID;
            CartDropDownList();
            return View("AddEditOrderDetails", orderDetailModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewOrderDetails");
        }
        #endregion

    }
}
