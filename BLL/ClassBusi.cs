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
    public class ClassBusi
    {
        #region 判断班级编号是否存在
        /// <summary>
        /// 判断学院编号是否存在
        /// </summary>
        /// <param name="name">值</param>
        /// <param name="Table">表名</param>
        /// <param name="Field">字段名</param>
        /// <returns>是否存在</returns>
        public bool ChecClass(string name, string Table, string Field)
        {
            Common comm = new Common();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + Table + " ");
            strSql.Append(" where " + Field + "=?" + Field + "");
            MySqlParameter[] parameters = {
					new MySqlParameter("?"+Field+"", MySqlDbType.VarChar,20)
                                          };
            parameters[0].Value = name;
            DataSet ds = comm.Query(strSql.ToString(), parameters);
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
