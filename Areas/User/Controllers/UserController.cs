using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.Areas.User.Models;
using Bakery_Project.Controllers;
using Bakery_Project.DAL;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Bakery_Project.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/{controller}/{action}")]
    public class UserController : Controller
    {
        private IConfiguration configuration;
        public UserController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }



        #region ViewUsers
        public IActionResult ViewUsers()
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.ViewUsers();
            if (dt.Rows.Count == 0)
            {
                ViewBag.User = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region DeleteUsers
        public IActionResult DeleteUsers(int UserID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            TempData["message"] = bakery_DAL.DeleteUser(UserID);
            return RedirectToAction("ViewUsers");
        }
        #endregion

        #region AddEditUsers
        public IActionResult AddEditUsers()
        {
            return View();
        }
        #endregion

        #region AddEditUsersData
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditUsersData(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (userModel.UserID == null)
                {
                    TempData["message"] = bakery_DAL.Bakery_User_Insert(userModel);
                }
                else
                {
                    TempData["message"] = bakery_DAL.Bakery_User_Update(userModel);
                }
                return RedirectToAction("ViewUsers");
            }
            else
            {
                return View("AddEditUsers");
            }
        }
        #endregion

        #region EditUsers
        [HttpGet]
        public IActionResult EditUsers(int UserID)
        {
            Bakery_DAL bakery_DAL = new Bakery_DAL();
            DataTable dt = bakery_DAL.Bakery_User_SelectByID(UserID);
            UserModel userModel = new UserModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    userModel.UserID = Convert.ToInt32(dataRow[0]);
                    userModel.UserName = dataRow[1].ToString();
                    userModel.UserRole = dataRow[2].ToString();
                    userModel.Email = dataRow[3].ToString();
                    userModel.Mobile = dataRow[4].ToString();
					userModel.Password = dataRow[5].ToString();
				}
            }
            ViewBag.ID = UserID;
            
            return View("AddEditUsers", userModel);
        }
        #endregion

        #region Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("ViewUsers");
        }
        #endregion

        #region User_Login
        [HttpPost]
        public IActionResult Login(string email ,string password)
        {
            UserModel user = null;
            SqlConnection conn = new
            SqlConnection(this.configuration.GetConnectionString("myConnectionString"));
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = System.Data.CommandType.StoredProcedure;
            objCmd.CommandText = "Bakery_User_Login";
            objCmd.Parameters.AddWithValue("@Email", email);
            using (SqlDataReader reader = objCmd.ExecuteReader())
            {
                    
                       
                
                if (reader.Read())
                 {
                        user = new UserModel
                        {
                            UserID = reader["UserID"] as int?,
                            UserName = reader["UserName"].ToString(),
                            UserRole = reader["UserRole"].ToString(),
                            Email = reader["Email"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                }
                else{
                    TempData["Message"] = "Email Not Found";
                    return RedirectToAction("Login", "Home");
                }

            }
                if(user != null && password.Equals(user.Password))
                {
                    HttpContext.Session.SetString("UserID",user.UserID.ToString());
                    HttpContext.Session.SetString("UserName",user.UserName.ToString());
                    HttpContext.Session.SetString("MobileNo", user.Mobile.ToString());
                    HttpContext.Session.SetString("Email", user.Email.ToString());
                    HttpContext.Session.SetString("UserRole", user.UserRole.ToString());
                    TempData["Message"] = "Logged in Successfuly!";
                    return RedirectToAction("AdminIndex", "Admin", new { area = "Admin" });
                }

            

            else
            {
                TempData["Message"] = "Wrong Password";
                return RedirectToAction("Login", "Home");

            }
            // Check if Data Reader has Rows or not
            // if row(s) does not exists that means either username or password or both are invalid.

        }
        #endregion

        #region User_Logout
    
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");

        }
        #endregion
    }
}
