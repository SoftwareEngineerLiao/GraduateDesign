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
    public class NoticeDAL
    {
        private DataTable dt;

        //查询所有用户分页信息
        public DataTable GetNoticeAll(int start, int limit, string orderStr)
        {
            try
            {
                Common comm = new Common();
                //string sql = "select top " + limit + " * from user where user_id not in(select top " + (limit * (start - 1)) + " user_id from user order by user_id asc) order by user_id asc";
                string sql = "select  * from notice  order by " + orderStr + "  limit  " + (limit * (start - 1)) + ", " + limit + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetNotice(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  * from notice where " + keyString + " order by " + orderStr + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //查询角色总数量
        public int GetNoticeCount()
        {
            try
            {
                Common comm = new Common();
                int count = comm.ExecuteScalar("select count(*) from notice", 0);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region 插入NoticeDAL实体函数原型
        public bool InsertNoticeDAL(NoticeEntity notice)
        {
            string sql = @"Insert Into notice( 
                        title,
                        content,
                        type,
                        time
                    )
                    Values(
                        ?title,
                        ?content,
                        ?type,
                        ?time
                    )";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("title",notice.title),
		        new MySqlParameter("content",notice.content),
                 new MySqlParameter("type",notice.type),
                 new MySqlParameter("time",notice.time)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        //-----------------------------------------------------------------
        // -- Date Created: 更新实体函数原型
        //-----------------------------------------------------------------

        #region 更新NoticeDAL实体函数原型
        public bool UpdateNoticeDAL(NoticeEntity notice)
        {
            string sql = @"Update notice Set 
                        title = ?title,
                        content = ?content,
                        type = ?type
                    Where 
                        `id` = ?id";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("title",notice.title),
		        new MySqlParameter("content",notice.content),
		        new MySqlParameter("type",notice.type),
                new MySqlParameter("time",notice.time)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        #region 删除NoticeDAL实体函数原型
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from notice ");
            strSql.Append(" where id=?RID ");
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
        public NoticeEntity GetModel(int RID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from notice ");
            strSql.Append(" where id=?RID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RID", MySqlDbType.Int32)};
            parameters[0].Value = RID;

            NoticeEntity notice = new NoticeEntity();
            Common comm = new Common();
            DataSet ds = comm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    notice.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                notice.title = ds.Tables[0].Rows[0]["title"].ToString();
                notice.content = ds.Tables[0].Rows[0]["content"].ToString();
                notice.time = (DateTime)ds.Tables[0].Rows[0]["time"];
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    notice.type = ds.Tables[0].Rows[0]["type"].ToString();
                }
                return  notice;
            }
            else
            {
                return null;
            }
        }
    }
}
