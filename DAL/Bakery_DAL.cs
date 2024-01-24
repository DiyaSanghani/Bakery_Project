using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Bakery_Project.Areas.Product.Models;
using Bakery_Project.Areas.Cart.Models;

using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectByPKLOC_Country");
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
                Console.WriteLine("helloo");
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
                sqlDatabase.AddInParameter(cmd, "ProductDescription", SqlDbType.VarChar, productModel.ProductDescription.Trim());
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
                sqlDatabase.AddInParameter(cmd, "ProductID", SqlDbType.Int, productModel.ProductId);
                sqlDatabase.AddInParameter(cmd, "ProductName", SqlDbType.NVarChar, productModel.ProductName.Trim());
                sqlDatabase.AddInParameter(cmd, "CategoryID", SqlDbType.Int, productModel.CategoryID);
                sqlDatabase.AddInParameter(cmd, "FlavourID", SqlDbType.Int, productModel.FlavourID);
                sqlDatabase.AddInParameter(cmd, "Price", SqlDbType.Decimal, productModel.Price);
                sqlDatabase.AddInParameter(cmd, "ProductDescription", SqlDbType.NVarChar, productModel.ProductDescription);
                sqlDatabase.AddInParameter(cmd, "Created", SqlDbType.DateTime, productModel.Created);
                sqlDatabase.AddInParameter(cmd, "Modified", SqlDbType.DateTime, productModel.Modified);
                sqlDatabase.ExecuteNonQuery(cmd);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

    #endregion
}
}
