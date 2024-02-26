using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bakery_Project.Areas.Flavour.Controllers
{
    [Area("Flavour")]
    [Route("Flavour/{controller}/{action}")]
    public class FlavourController : Controller
    {
        #region ViewFlavours
        public IActionResult ViewFlavours()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewFlavours();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Flavour = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteFlavours
        public IActionResult DeleteFlavours(int FlavourID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteFlavour(FlavourID);
            return RedirectToAction("ViewFlavours");
        }
        #endregion

        #region AddEditFlavours
        public IActionResult AddEditFlavours()
        {
            return View();
        }
        #endregion

        #region AddEditFlavoursData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditFlavoursData(FlavourModel flavourModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (flavourModel.FlavourID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_Flavour_Insert(flavourModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_Flavour_Update(flavourModel);
                }
                return RedirectToAction("ViewFlavours");
            }
            else
            {
                return View("AddEditFlavours");
            }
        }
        #endregion

        #region EditFlavours
        [HttpGet]
        public IActionResult EditFlavours(int FlavourID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_Flavour_SelectByID(FlavourID);
            FlavourModel flavourModel = new FlavourModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    flavourModel.FlavourID = Convert.ToInt32(dataRow[0]);
                    flavourModel.FlavourName = dataRow[1].ToString();
                    flavourModel.FlavourDescription = dataRow[2].ToString();
                }
            }
            ViewBag.ID = FlavourID;
            return View("AddEditFlavour", flavourModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewFlavour");
        }
        #endregion
    }
}
