using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Commons;
using Model;
using DAL;

namespace DAL
{
    /// <summary>
    /// 数据访问类sys_log。
    /// </summary>
    public class LogDAL
    {
        public DataTable GetErrorLog(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  * from log where " + keyString + " and log_type='0' order by " + orderStr + "  ";
                DataTable dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetOperateLog(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select  * from log where " + keyString + " and log_type='1' order by " + orderStr + " ";
                DataTable dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region 插入LogDAL实体函数原型
        public bool InsertLogDAL(LogEntity log)
        {
            string sql = @"Insert Into log( 
                        log_content,
                        write_time,
                        log_type
                    )
                    Values(
                        ?log_content,
                        ?write_time,
                        ?log_type
                    )";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("log_content",log.log_content),
		        new MySqlParameter("write_time",log.write_time),
		        new MySqlParameter("log_type",log.log_type)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

        //-----------------------------------------------------------------
        // -- Date Created: 更新实体函数原型
        //-----------------------------------------------------------------

        #region 更新LogDAL实体函数原型
        public bool UpdateLogDAL(LogEntity log)
        {
            string sql = @"Update log Set 
                        log_content = ?log_content,
                        write_time = ?write_time,
                        log_type = ?log_type
                    Where 
                        `log_id` = ?log_id";
            MySqlParameter[] msp = new MySqlParameter[]
	        {
		        new MySqlParameter("log_id",log.log_id),
		        new MySqlParameter("log_content",log.log_content),
		        new MySqlParameter("write_time",log.write_time),
		        new MySqlParameter("log_type",log.log_type)
	        };
            Common comm = new Common();
            return (comm.ExecuteNonQuery(sql, 1, msp) > 0);
        }
        #endregion

    }
}
