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
    }
}
