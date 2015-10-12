using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL2
{
    public class docManage
    {
        private SQLHelper sqlhelper;
        public docManage()
        {
            sqlhelper = new SQLHelper();
        }
        public bool Delete(string id)
        {
            try
            {
                string cmdText = "docs_Delete";
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@docid",id)
                };
                return (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure)) > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
