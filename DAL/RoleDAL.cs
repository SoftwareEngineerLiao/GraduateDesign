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
    public class RoleDAL
    {
        private DataTable dt;

        //查询所有用户分页信息
        public DataTable GetRoleAll(int start, int limit, string orderStr)
        {
            try
            {
                Common comm = new Common();
                //string sql = "select top " + limit + " * from user where user_id not in(select top " + (limit * (start - 1)) + " user_id from user order by user_id asc) order by user_id asc";
                string sql = "select  * from role  order by " + orderStr + "  limit  " + (limit * (start - 1)) + ", " + limit + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRole(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  * from role where " + keyString + " order by " + orderStr + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //查询角色总数量
        public int GetRoleCount()
        {
            try
            {
                Common comm = new Common();
                int count = comm.ExecuteScalar("select count(*) from role", 0);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region 插入RoleDAL实体函数原型
        public bool InsertRoleDAL(RoleEntity role)
        {
            string sql = @"Insert Into role( 
                        role_name,
                        rights_code,
                        role_time
                    )
                    Values(
                        ?role_name,
                        ?rights_code,
                        ?role_time
                    )";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("role_name",role.role_name),
		        new MySqlParameter("rights_code",role.rights_code),
		        new MySqlParameter("role_time",role.role_time)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        //-----------------------------------------------------------------
        // -- Date Created: 更新实体函数原型
        //-----------------------------------------------------------------

        #region 更新RoleDAL实体函数原型
        public bool UpdateRoleDAL(RoleEntity role)
        {
            string sql = @"Update role Set 
                        role_name = ?role_name,
                        rights_code = ?rights_code,
                        role_time = ?role_time
                    Where 
                        `role_id` = ?role_id";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("role_id",role.role_id),
		        new MySqlParameter("role_name",role.role_name),
		        new MySqlParameter("rights_code",role.rights_code),
		        new MySqlParameter("role_time",role.role_time)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        #region 删除RoleDAL实体函数原型
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from role ");
            strSql.Append(" where role_id=?RID ");
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
        public RoleEntity GetModel(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from role ");
            strSql.Append(" where role_id=?RID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RID", MySqlDbType.Int32)};
            parameters[0].Value = RID;

            RoleEntity  role = new RoleEntity();
            Common comm = new Common();
            DataSet ds = comm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["role_id"].ToString() != "")
                {
                    role.role_id = int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
                }
                role.role_name = ds.Tables[0].Rows[0]["role_name"].ToString();
                role.rights_code = ds.Tables[0].Rows[0]["rights_code"].ToString();
                if (ds.Tables[0].Rows[0]["role_time"].ToString() != "")
                {
                    role.role_time = DateTime.Parse(ds.Tables[0].Rows[0]["role_time"].ToString());
                }
                return role;
            }
            else
            {
                return null;
            }
        }

    }
}
