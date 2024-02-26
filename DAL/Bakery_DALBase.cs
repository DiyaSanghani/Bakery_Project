using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Bakery_Project.DAL
{
    public class Bakery_DALBase : DAL_Helper
    {
        #region Flavour_DropDownList
        public DataTable Flavour_DropDownList()
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

        #region Product_DropDownList
        public DataTable Product_DropDownList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Bakery_Product_SelectAll");
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

        #region Cart_DropDownList
        public DataTable Cart_DropDownList()
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

        #region User_DropDownList
        public DataTable User_DropDownList()
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

    }
}
