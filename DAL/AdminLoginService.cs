using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdminLoginService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns>返回Admins</returns>
        public Admins Login(Admins user)
        {
            string sql = "Select AdminName from Admins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@LoginId",user.LoginId),
                new SqlParameter("@LoginPwd",user.LoginPwd)
            };
            try
            {
                SqlDataReader result = new Helper.SQLHelper().QueryAll(sql, param, false);
                while (result.Read())
                {
                    user.LoginName = result["AdminName"].ToString();
                    if (user.LoginName == null)
                        user = null;
                }
                result.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("系统异常！"+ex.Message);
            }
            return user;
        }
    }
}
