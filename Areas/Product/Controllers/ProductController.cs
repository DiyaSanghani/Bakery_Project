using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.DAL;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace Bakery_Project.Areas.Product.Controllers
{
    [Area("Product")]
    [Route("Product/{controller}/{action}")]
    public class ProductController : Controller
    {
        

        #region Configuration

        private IConfiguration Configuration;
        

        public ProductController(IConfiguration _configuration)
        {
            this.Configuration = _configuration;
        }

        #endregion

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
        //[ValidateAntiForgeryToken]
        public IActionResult AddEditProductsData(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                Bakery_DAL bakery_DAL = new Bakery_DAL();
                if (productModel.ProductID == null)
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
                return View("AddEditProducts");
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
                    productModel.ProductID = Convert.ToInt32(dataRow[0]);
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

        #region Get All Records

        public List<ProductModel> GetProductModels()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            string myconnStr = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(myconnStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Bakery_ExportProductsToExcel_SelectAll";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductModel productModel = new ProductModel
                    {
                        ProductName = reader["ProductName"].ToString(),
                        CategoryID = (int)reader["CategoryID"],
                        FlavourID = (int)reader["FlavourID"],
                        Price = Convert.ToDecimal(reader["Price"]),
                        ProductDescription = reader["ProductDescription"].ToString(),
                        Created = Convert.ToDateTime(reader["Created"]),
                        Modified = Convert.ToDateTime(reader["Modified"])
                    };
                    productModels.Add(productModel);
                }
                return productModels;
            }
        }

        #endregion

        #region Export Table

        public IActionResult ExportProductsToExcel()
        {

            List<ProductModel> productModel = GetProductModels();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Products");
                // Add headers
                int row = 1;
                worksheet.Cell(row, 1).Value = "Product Name";
                worksheet.Cell(row, 2).Value = "CategoryID";
                worksheet.Cell(row, 3).Value = "FlavourID";
                worksheet.Cell(row, 4).Value = "Price";
                worksheet.Cell(row, 5).Value = "Product Description";
                worksheet.Cell(row, 6).Value = "Created";
                worksheet.Cell(row, 7).Value = "Modified";
                // Add data
                row = 2;
                foreach (var prodModel in productModel)
                {
                    worksheet.Cell(row, 1).Value = prodModel.ProductName;
                    worksheet.Cell(row, 2).Value = prodModel.CategoryID;
                    worksheet.Cell(row, 3).Value = prodModel.FlavourID;
                    worksheet.Cell(row, 4).Value = prodModel.Price;
                    worksheet.Cell(row, 5).Value = prodModel.ProductDescription;
                    worksheet.Cell(row, 6).Value = prodModel.Created;
                    worksheet.Cell(row, 7).Value = prodModel.Modified;
                    // Add other properties...
                    row++;
                }
                // Set content type and filename
                var contentType = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
                var fileName = "ProductData.xlsx";
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
        }

        #endregion

    }
}
