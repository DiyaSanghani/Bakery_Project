using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.Product.Controllers
{
    [Area("Product")]
    [Route("Product/{controller}/{action}")]
    public class ProductController : Controller
    {
        #region Viewproducts
        public IActionResult ViewProducts()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewProducts();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Product = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteProducts
        public IActionResult DeleteProducts(int ProductID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteProducts(ProductID);
            return RedirectToAction("ViewProducts");
        }
        #endregion

        #region FlavourDropDownList
        public void FlavourDropDownList()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Flavour_DropDownList();
            List<FlavourDropdownModel> flavourDropDownModelList = new List<FlavourDropdownModel>();
            foreach (DataRow data in dt.Rows)
            {
                FlavourDropdownModel flavourDropDownModel = new FlavourDropdownModel();
                flavourDropDownModel.FlavourID = Convert.ToInt32(data["FlavourID"]);
                flavourDropDownModel.FlavourName = data["FlavourName"].ToString();
                flavourDropDownModelList.Add(flavourDropDownModel);
            }
            ViewBag.flavourDropDownModel = flavourDropDownModelList;
        }
        #endregion

        #region AddEditProducts
        public IActionResult AddEditProducts()
        {
            FlavourDropDownList();
            return View();
        }
        #endregion

        #region AddEditProductsData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditProductsData(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (productModel.ProductId == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_Product_Insert(productModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_Product_Update(productModel);
                }
                return RedirectToAction("ViewProducts");
            }
            else
            {
                FlavourDropDownList();
                return View();
            }
        }
        #endregion

        #region EditProducts
        [HttpGet]
        public IActionResult EditProducts(int ProductID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_Product_SelectByID(ProductID);
            ProductModel productModel = new ProductModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    productModel.ProductId = Convert.ToInt32(dataRow[0]);
                    productModel.ProductName = dataRow[1].ToString();
                    productModel.CategoryID = Convert.ToInt32(dataRow[2]);
                    productModel.FlavourID = Convert.ToInt32(dataRow[3]);
                    productModel.Price = Convert.ToDecimal(dataRow[4]);
                    productModel.ProductDescription = dataRow[5].ToString();
                }
            }
            ViewBag.ID = ProductID;
            FlavourDropDownList();
            return View("AddEditProducts", productModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewProducts");
        }
        #endregion
    }
}
