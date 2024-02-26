using Bakery_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_Project.Areas.Z_Front_Index.Controllers
{
    public class Z_Front_IndexController : Controller
    {
        #region ViewFrontIndex
        public IActionResult ViewFrontIndex()
        {
            return View("C:\\Users\\hp\\source\\repos\\Bakery_Project\\Areas\\Z_Front_Index\\Views\\View_Z_Front_Index.cshtml");
        }
        #endregion
    }
}
