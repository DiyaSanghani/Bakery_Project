using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.Areas.Cart.Models;

using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Bakery_Project.Areas.User.Models;
using Bakery_Project.Areas.Flavour.Models;
using Bakery_Project.Areas.Category.Models;
using Bakery_Project.Areas.Employee.Models;
using Bakery_Project.Areas.OrderDetail.Models;

namespace Bakery_Project.DAL
{
    public class Bakery_DAL : Bakery_DALBase
    {
        #region SelectAll

        #region Bakery_Product_SelectAll
        public DataTable ViewProducts()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_SelectAll");
                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Cart_SelectAll
        public DataTable ViewCart()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_User_SelectAll
        public DataTable ViewUsers()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_User_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Flavour_SelectAll
        public DataTable ViewFlavours()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Flavour_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Category_SelectAll
        public DataTable ViewCategories()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Category_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Employee_SelectAll
        public DataTable ViewEmployees()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Employee_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_OrderDetail_SelectAll
        public DataTable ViewOrderDetails()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_OrderDetail_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region SelectByPK

        #region Bakery_Product_SelectByID
        public DataTable Bakery_Product_SelectByID(int? ProductID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_SelectByID");
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, ProductID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Cart_SelectByID
        public DataTable Bakery_Cart_SelectByID(int CartID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_SelectByID");
                sqlDatabase.AddInParameter(cmd, "CartID", SqlDbType.Int, CartID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                Console.WriteLine(dt.Rows.Count);
                //Console.WriteLine(dt;
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_User_SelectByID
        public DataTable Bakery_User_SelectByID(int? UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_User_SelectByID");
                sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Flavour_SelectByID
        public DataTable Bakery_Flavour_SelectByID(int? FlavourID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Flavour_SelectByID");
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, FlavourID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Category_SelectByID
        public DataTable Bakery_Category_SelectByID(int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Category_SelectByID");
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, CategoryID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_Employee_SelectByID
        public DataTable Bakery_Employee_SelectByID(int? EmployeeID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Employee_SelectByID");
                sqlDatabase.AddInParameter(cmd, "EmployeeID", SqlDbType.Int, EmployeeID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Bakery_OrderDetail_SelectByID
        public DataTable Bakery_OrderDetail_SelectByID(int? OrderID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_OrderDetail_SelectByID");
                sqlDatabase.AddInParameter(cmd, "OrderID", SqlDbType.Int, OrderID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Delete

        #region Bakery_Product_Delete
        public string DeleteProducts(int ProductID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_Delete");
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, ProductID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_Cart_Delete
        public string DeleteCart(int CartID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_Delete");
                sqlDatabase.AddInParameter(cmd, "CartID", SqlDbType.Int, CartID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_User_Delete
        public string DeleteUser(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_User_Delete");
                sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, UserID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_Flavour_Delete
        public string DeleteFlavour(int FlavourID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Flavour_Delete");
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, FlavourID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_Category_Delete
        public string DeleteCategory(int CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Category_Delete");
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_Employee_Delete
        public string DeleteEmployees(int EmployeeID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Employee_Delete");
                sqlDatabase.AddInParameter(cmd, "EmployeeID", SqlDbType.Int, EmployeeID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region Bakery_OrderDetail_Delete
        public string DeleteOrderDetail(int OrderID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_OrderDetail_Delete");
                sqlDatabase.AddInParameter(cmd, "OrderID", SqlDbType.Int, OrderID);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #endregion

        #region Add

        #region Bakery_Product_Insert

        public string Bakery_Product_Insert(ProductModel productModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_Insert");
                sqlDatabase.AddInParameter(cmd, "ProductName", SqlDbType.NVarChar, productModel.ProductName.Trim());
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, productModel.CategoryID);
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, productModel.FlavourID);
                sqlDatabase.AddInParameter(cmd, "Price", SqlDbType.Decimal, productModel.Price);
                //sqlDatabase.AddInParameter(cmd, "ProductDescription", SqlDbType.VarChar, productModel.ProductDescription.Trim());
                sqlDatabase.AddInParameter(cmd, "ProductDescription", SqlDbType.VarChar,"Dec");
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_Cart_Insert

        public string Bakery_Cart_Insert(CartModel cartModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_Insert");
                sqlDatabase.AddInParameter(cmd, "CartNumber", SqlDbType.Int, cartModel.CartNumber);
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, cartModel.ProductID);
                sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, cartModel.UserID);
                sqlDatabase.AddInParameter(cmd, "TotalAmount", SqlDbType.Decimal, cartModel.TotalAmount);
                sqlDatabase.AddInParameter(cmd, "CartQuantity", SqlDbType.Int, cartModel.CartQuantity);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_User_Insert

        public string Bakery_User_Insert(UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_User_Insert");
                sqlDatabase.AddInParameter(cmd, "UserName", SqlDbType.NVarChar, userModel.UserName.Trim());
                sqlDatabase.AddInParameter(cmd, "UserRole", SqlDbType.NVarChar, userModel.UserRole.Trim());
                sqlDatabase.AddInParameter(cmd, "Email", SqlDbType.NVarChar, userModel.Email.Trim());
                sqlDatabase.AddInParameter(cmd, "Mobile", SqlDbType.NVarChar, userModel.Mobile);
                sqlDatabase.AddInParameter(cmd, "Password", SqlDbType.NVarChar, userModel.Password);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_Flavour_Insert

        public string Bakery_Flavour_Insert(FlavourModel flavourModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Flavour_Insert");
                sqlDatabase.AddInParameter(cmd, "FlavourName", SqlDbType.NVarChar, flavourModel.FlavourName.Trim());
                sqlDatabase.AddInParameter(cmd, "FlavourDescription", SqlDbType.NVarChar, flavourModel.FlavourDescription.Trim());
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_Category_Insert

        public string Bakery_Category_Insert(CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Category_Insert");
                sqlDatabase.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, categoryModel.CategoryName.Trim());
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_Employee_Insert

        public string Bakery_Employee_Insert(EmployeeModel employeeModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Employee_Insert");
                sqlDatabase.AddInParameter(cmd, "EmployeeName", SqlDbType.NVarChar, employeeModel.EmployeeName.Trim());
                sqlDatabase.AddInParameter(cmd, "IsActive", SqlDbType.NVarChar, employeeModel.IsActive);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Bakery_OrderDetail_Insert

        public string Bakery_OrderDetail_Insert(OrderDetailModel orderDetailModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_OrderDetail_Insert");
                sqlDatabase.AddInParameter(cmd, "CartID", SqlDbType.Int, orderDetailModel.CartID);
                sqlDatabase.AddInParameter(cmd, "OrderItemName", SqlDbType.NVarChar, orderDetailModel.OrderItemName.Trim());
                sqlDatabase.AddInParameter(cmd, "OrderQuantity", SqlDbType.Int, orderDetailModel.OrderQuantity);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #endregion

        #region Edit

        #region Bakery_Product_Update
        public string Bakery_Product_Update(ProductModel productModel) {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_Update");
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, productModel.ProductID);
                sqlDatabase.AddInParameter(cmd, "ProductName", SqlDbType.NVarChar, productModel.ProductName.Trim());
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, productModel.CategoryID);
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, productModel.FlavourID);
                sqlDatabase.AddInParameter(cmd, "Price", SqlDbType.Decimal, productModel.Price);
                sqlDatabase.AddInParameter(cmd, "ProductDescription", SqlDbType.NVarChar, productModel.ProductDescription);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_Cart_Update
        public string Bakery_Cart_Update(CartModel cartModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_Update");
                sqlDatabase.AddInParameter(cmd, "CartID", SqlDbType.Int, cartModel.CartID);
                sqlDatabase.AddInParameter(cmd, "CartNumber", SqlDbType.Int, cartModel.CartNumber);
                sqlDatabase.AddInParameter(cmd, "TotalAmount", SqlDbType.Decimal, cartModel.TotalAmount);
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, cartModel.ProductID);
                sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, cartModel.UserID);
                sqlDatabase.AddInParameter(cmd, "CartQuantity", SqlDbType.Int, cartModel.CartQuantity);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_User_Update
        public string Bakery_User_Update(UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Cart_Update");
                sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, userModel.UserID);
                sqlDatabase.AddInParameter(cmd, "UserName", SqlDbType.NVarChar, userModel.UserName);
                sqlDatabase.AddInParameter(cmd, "UserRole", SqlDbType.NVarChar, userModel.UserRole);
                sqlDatabase.AddInParameter(cmd, "Email", SqlDbType.NVarChar, userModel.Email);
                sqlDatabase.AddInParameter(cmd, "Mobile", SqlDbType.NVarChar, userModel.Mobile);
                sqlDatabase.AddInParameter(cmd, "Password", SqlDbType.NVarChar, userModel.Password);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_Flavour_Update
        public string Bakery_Flavour_Update(FlavourModel flavourModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Flavour_Update");
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, flavourModel.FlavourID);
                sqlDatabase.AddInParameter(cmd, "FlavourName", SqlDbType.NVarChar, flavourModel.FlavourName);
                sqlDatabase.AddInParameter(cmd, "FlavourDescription", SqlDbType.NVarChar, flavourModel.FlavourDescription);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_Category_Update
        public string Bakery_Category_Update(CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Category_Update");
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, categoryModel.CategoryID);
                sqlDatabase.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, categoryModel.CategoryName);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_Employee_Update
        public string Bakery_Employee_Update(EmployeeModel employeeModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Employee_Update");
                sqlDatabase.AddInParameter(cmd, "EmployeeID", SqlDbType.Int, employeeModel.EmployeeID);
                sqlDatabase.AddInParameter(cmd, "EmployeeName", SqlDbType.NVarChar, employeeModel.EmployeeName);
                sqlDatabase.AddInParameter(cmd, "IsActive", SqlDbType.NVarChar, employeeModel.IsActive);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region Bakery_OrderDetail_Update
        public string Bakery_OrderDetail_Update(OrderDetailModel orderDetailModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_OrderDetail_Update");
                sqlDatabase.AddInParameter(cmd, "OrderID", SqlDbType.Int, orderDetailModel.OrderID);
                sqlDatabase.AddInParameter(cmd, "CartID", SqlDbType.Int, orderDetailModel.CartID);
                sqlDatabase.AddInParameter(cmd, "OrderItemName", SqlDbType.NVarChar, orderDetailModel.OrderItemName);
                sqlDatabase.AddInParameter(cmd, "OrderQuantity", SqlDbType.Int, orderDetailModel.OrderQuantity);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }   
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #endregion
    }
}
