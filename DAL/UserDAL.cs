using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Commons;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class UserDAL
    {
        private DataTable dt;

        //查询所有用户分页信息
        public DataTable GetUserAll(int start, int limit, string orderStr)
        {
            try
            {
                Common comm = new Common();
                //string sql = "select top " + limit + " * from user where user_id not in(select top " + (limit * (start - 1)) + " user_id from user order by user_id asc) order by user_id asc";
                string sql = "select  * from user  order by " + orderStr + "  limit  " + (limit * (start - 1)) + ", " + limit + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUser(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  user.*, role.* from user,role where " + keyString + " order by " + orderStr + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //查询用户总数量
        public int GetUserCount()
        {
            try
            {
                Common comm = new Common();
                int count = comm.ExecuteScalar("select count(*) from user",0);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //-----------------------------------------------------------------
        // -- Date Created: 插入实体函数原型
        // -- Created By:   dxw
        //-----------------------------------------------------------------

        #region 插入UserEntity实体函数原型
        public bool InsertUserEntity(UserEntity user)
        {
            string sql = @"Insert Into user( 
                        user_name,
                        user_pwd,
                        real_name,
                        role_id,
                        status
                    )
                    Values(
                        ?user_name,
                        ?user_pwd,
                        ?real_name,
                        ?role_id,
                        ?status
                    )";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("user_name",user.user_name),
		        new MySqlParameter("user_pwd",user.user_pwd),
		        new MySqlParameter("real_name",user.real_name),
		        new MySqlParameter("role_id",user.role_id),
		        new MySqlParameter("status",user.status)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        //-----------------------------------------------------------------
        // -- Date Created: 更新实体函数原型
        // -- Created By:   dxw
        //-----------------------------------------------------------------

        #region 更新UserEntity实体函数原型
        public bool UpdateUserEntity(UserEntity user)
        {
            string sql = @"Update user Set 
                        user_name = ?user_name,
                        pwd = ?pwd,
                        real_name = ?real_name,
                        role_id = ?role_id,
                        status = ?status
                    Where 
                        `user_id` = ?user_id";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("user_id",user.user_id),
		        new MySqlParameter("user_name",user.user_name),
		        new MySqlParameter("pwd",user.user_pwd),
		        new MySqlParameter("real_name",user.real_name),
		        new MySqlParameter("role_id",user.role_id),
		        new MySqlParameter("status",user.status)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        #region 删除userDAL实体函数原型
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user ");
            strSql.Append(" where user_id=?RID ");
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
        public UserEntity GetModel(int uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user ");
            strSql.Append(" where user_id =?uid ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?uid", MySqlDbType.Int32)};
            parameters[0].Value = uid;

            UserEntity user = new UserEntity();
            Common comm = new Common();
            DataSet ds = comm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    user.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                user.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                user.user_pwd = ds.Tables[0].Rows[0]["user_pwd"].ToString();
                user.real_name = ds.Tables[0].Rows[0]["real_name"].ToString();
                user.role_id = Convert.ToInt32((ds.Tables[0].Rows[0]["role_id"].ToString()));
                user.status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
