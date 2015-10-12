using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL2
{
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;
        public SQLHelper()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        private SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        #region 执行不带参数的增删改SQL语句或存储过程
        /// <summary>
        ///  执行不带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, CommandType ct)
        {
            int res;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }
        #endregion

        #region 执行带参数的增删改SQL语句或存储过程
        /// <summary>
        ///  执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int res;
            using (cmd = new SqlCommand(cmdText, GetConn()))
            {
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }
        #endregion

        #region 执行查询SQL语句或存储过程
        /// <summary>
        ///  执行查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion

        #region 执行带参数的查询SQL语句或存储过程
        /// <summary>
        ///  执行带参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion

        #region 操作SQL Server并返回一个string型量
        /// <summary>
        /// 对SQL服务器进行指定返回值的查询
        /// </summary>
        /// <param name="cmdText">SQL命令</param>
        /// <param name="ct">查询方式</param>
        /// <returns>字符串</returns>
        public string StringOpSQL(string cmdText, CommandType ct)
        {
            string res = null;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                res = cmd.ExecuteScalar().ToString();
                return res;
            }
            catch (Exception)
            {
                return res;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 含参操作SQL Server存储过程并返回一个string型量
        /// <summary>
        /// 使用带参数的SQL Store Procedure操作数据库，返回结果的第一行第一列值
        /// </summary>
        /// <param name="cmdText">存储过程</param>
        /// <param name="paras">参数</param>
        /// <param name="ct">操作类型</param>
        /// <returns>返回的string型量</returns>
        public string StringOpSQL(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            string res = null;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteScalar().ToString();
                return res;
            }
            catch (Exception)
            {
                return res;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 操作SQL Server并返回一个bool型量
        /// <summary>
        /// 对SQL服务器进行指定返回值的查询
        /// </summary>
        /// <param name="cmdText">SQL查询命令</param>
        /// <param name="ct">查询方式</param>
        /// <returns>布尔值</returns>
        public bool BoolOpSQL(string cmdText, CommandType ct)
        {
            string res;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                res = cmd.ExecuteScalar().ToString();
                if (res == "true" || res == "True" || res == "1" || res == "TRUE")
                    return true;
                else return false;
            }
            catch (Exception)
            {
                return true;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 含参操作SQL Server存储过程并返回一个bool型量
        public bool BoolOpSQL(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            string res = null;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteScalar().ToString();
                cmd.Parameters.Clear();
                if (res == "true" || res == "True" || res == "1" || res == "TRUE")
                    return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 含参操作SQL Server存储过程并返回一个int型量
        public int IntOpSQL(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            object res = null;
            try
            {
                cmd = new SqlCommand(cmdText, GetConn());
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteScalar();
                int i = Convert.ToInt32(res);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
