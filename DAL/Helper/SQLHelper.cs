using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL.Helper
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    public class SQLHelper
    {
        //连接字符串
        static readonly string connstr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        #region 对数据库操作
        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="isProc">是否是存储过程</param>
        /// <returns></returns>
        public  int update(string sql,SqlParameter[] param,bool isProc){
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql,conn);
            if(isProc)
                cmd.CommandType=CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                writeLog("调用 public int update(string sql,SqlParameter[] param,bool isProc)时出错，错误信息：" + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 查询返回单一结果
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <param name="isProc">是否是存储过程</param>
        /// <returns></returns>
        public  object QuerySingle(string sql, SqlParameter[] param, bool isProc)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isProc)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                writeLog("调用public object QuerySingle(string sql, SqlParameter[] param, bool isProc)时出错，错误信息："+ex.Message);
                return "error";
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 查询结果集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <param name="isProc">是否是存储过程</param>
        /// <returns></returns>
        public  SqlDataReader QueryAll(string sql,SqlParameter[] param,bool isProc)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isProc)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                writeLog("调用public SqlDataReader QueryAll(string sql,SqlParameter[] param,bool isProc)时出错，错误信息：" + ex.Message);
                conn.Close();
                throw ex;
            }
        }

        #endregion

        #region 写入日志
        public  void writeLog(string message){
            FileStream fs = new FileStream("D:/ASP.NET文件/StudentManagerMVC_log/ProjectLog.log",FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString()+message);
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
