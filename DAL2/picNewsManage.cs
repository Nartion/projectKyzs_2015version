using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL2
{
    public class picNewsManage
    {
        private SQLHelper sqlhelper;
        public picNewsManage()
        {
            sqlhelper = new SQLHelper();
        }
        public bool PostPicNews(string newstitle,string newstext,string picnewsfilename,bool ontop)
        {
            try
            {
                string cmdText = "picnews_PostPicNews";
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@title",newstitle),
                    new SqlParameter("@newstext",newstext),
                    new SqlParameter("@picnewsfilename",picnewsfilename),
                    new SqlParameter("ontop",ontop)
                };
                return (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure)) > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool EditPicNews(string newstitle, string newstext, bool ontop,string id)
        {
            try
            {
                string cmdText = "picnews_EditPicNews";
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@title",newstitle),
                    new SqlParameter("@newstext",newstext),
                    new SqlParameter("@ontop",ontop),
                    new SqlParameter("@id",id)
                };
                return (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure)) > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                string cmdText = "picnews_Delete";
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
