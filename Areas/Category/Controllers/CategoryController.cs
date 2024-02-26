using Bakery_Project.Areas.Category.Models;
using Bakery_Project.Areas.Product.Models;
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
            TempData["message"] = bakery_DAL.DeleteCategory(CategoryID);
            return RedirectToAction("ViewCategories");
        }
        #endregion

        #region AddEditCategories
        public IActionResult AddEditCategories()
        {
            return View();
        }
        #endregion

        #region AddEditCategoriesData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditCategoriesData(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (categoryModel.CategoryID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_Category_Insert(categoryModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_Category_Update(categoryModel);
                }
                return RedirectToAction("ViewCategories");
            }
            else
            {
                return View("AddEditCategories");
            }
        }
        #endregion

        #region EditCategories
        [HttpGet]
        public IActionResult EditCategories(int CategoryID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_Category_SelectByID(CategoryID);
            CategoryModel categoryModel = new CategoryModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    categoryModel.CategoryID = Convert.ToInt32(dataRow[0]);
                    categoryModel.CategoryName = dataRow[1].ToString();
                }
            }
            ViewBag.ID = CategoryID;
            return View("AddEditCategories", categoryModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewCategories");
        }
        #endregion

    }
}
