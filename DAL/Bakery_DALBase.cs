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
    }
}
