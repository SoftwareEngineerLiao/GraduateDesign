using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons;
using System.Data;
using Model;

using MySql.Data.MySqlClient;

namespace DAL
{
    /// <summary>
    /// 数据访问类。
    /// </summary>
    public class AcademyDAL
    {
        private DataTable dt;

        //查询所有用户分页信息
        public DataTable GetAcademyeAll(int start, int limit, string orderStr)
        {
            try
            {
                Common comm = new Common();
                //string sql = "select top " + limit + " * from user where user_id not in(select top " + (limit * (start - 1)) + " user_id from user order by user_id asc) order by user_id asc";
                string sql = "select  * from academy  order by " + orderStr + "  limit  " + (limit * (start - 1)) + ", " + limit + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAcademy(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  * from academy where " + keyString + " order by " + orderStr + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //查询角色总数量
        public int GetAcademyCount()
        {
            try
            {
                Common comm = new Common();
                int count = comm.ExecuteScalar("select count(*) from academy", 0);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region 插入AcademyDAL实体函数原型
        public bool InsertAcademyDAL(AcademyEntity academy)
        {
            string sql = @"Insert Into academy(
                        academy_no,
                        academy_name
                      
                    )
                    Values(
                        ?academy_no,
                        ?academy_name
                      
                    )";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
                 new MySqlParameter("academy_no",academy.academy_no),
		        new MySqlParameter("academy_name",academy.academy_name)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        //-----------------------------------------------------------------
        // -- Date Created: 更新实体函数原型
        //-----------------------------------------------------------------

        #region 更新AcademyDAL实体函数原型
        public bool UpdateAcademyDAL(AcademyEntity academy)
        {
            string sql = @"Update academy Set 
                        academy_name = ?academy_name,
                        academy_no = ?academy_no
                    Where 
                        `academy_no` = ?academy_no";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("academy_name",academy.academy_name),
                new MySqlParameter("academy_no",academy.academy_no)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        #region 删除AcademyDAL实体函数原型
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from academy ");
            strSql.Append(" where academy_no=?RID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RID", MySqlDbType.Int32)};
            parameters[0].Value = RID;
            Common comm = new Common();
            comm.ExecuteNonQuery(strSql.ToString(), 1, parameters);
        }
        #endregion

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AcademyEntity GetModel(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from academy ");
            strSql.Append(" where academy_no=?RID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RID", MySqlDbType.Int32)};
            parameters[0].Value = RID;

            AcademyEntity academy = new AcademyEntity();
            Common comm = new Common();
            DataSet ds = comm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                academy.academy_name = ds.Tables[0].Rows[0]["academy_name"].ToString();
                return academy;
            }
            else
            {
                return null;
            }
        }
    }
}
