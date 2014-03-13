using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using Commons;
using Model;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace BLL
{
    public class UserBusi
    {

        #region 通过用户名得到用户信息
        public bool GetUserByUserName(ref UserEntity user)
        {
            bool isExist = false;
            string sql = "select * from `user` where user_id='" + user.user_name + "'";
            Common comm = new Common();
            DataTable dt = comm.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                user.user_id = Convert.ToInt32(dr["user_id"]);
                user.user_name = dr["user_name"].ToString();
                user.user_pwd = dr["user_pwd"].ToString();
                isExist = true;
            }
            return isExist;
        }
        #endregion

        #region 通过会话判断User是否存在，并填充User对象
        public bool IsExistSession(ref UserEntity user)
        {
            if (HttpContext.Current.Session["user"] != null)
                user.user_name = HttpContext.Current.Session["user"].ToString();
            else if (HttpContext.Current.Request.Cookies["user"] != null && HttpContext.Current.Request.Cookies["user"].Value != string.Empty)
                user.user_name = HttpContext.Current.Request.Cookies["user"].Value;
            else
                return false;

            GetUserByUserName(ref user);
            return true;
        }
        #endregion

        #region 用户登录验证
        public bool Login(ref UserEntity user)
        {
            string sql = "select * from user where user_name='{0}' and user_pwd='{1}'";
            sql = string.Format(sql, user.user_name, user.user_pwd);
            Common common = new Common();
            if (common.ExecuteScalar(sql,"") != "")
            {
                DataSet ds = common.GetDataSet(sql);
                DataRow dr = ds.Tables[0].Rows[0];
                user.user_id = Convert.ToInt32(dr["user_id"]);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断用户名是否存在
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="name">值</param>
        /// <param name="Table">表名</param>
        /// <param name="Field">字段名</param>
        /// <returns>是否存在</returns>
        public static bool ChecUser(string name, string Table, string Field)
        {
            Common comm = new Common();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + Table + " ");
            strSql.Append(" where " + Field + "=?" + Field + "");
            MySqlParameter[] parameters = {
					new MySqlParameter("?"+Field+"", MySqlDbType.VarChar,20)
                                          };
            parameters[0].Value = name;
            DataSet ds = comm.GetDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
