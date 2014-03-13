using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Commons;
using System.Data;

namespace DAL
{
    public class ClassDAL
    {
        private DataTable dt;
        public DataTable GetClass(string orderStr, string keyString)
        {
            try
            {
                Common comm = new Common();
                string sql = "select * from class where " + keyString + " order by " + orderStr + " ";
                dt = comm.GetDataTable(sql);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //查询用户总数量
        public int GetClassCount()
        {
            try
            {
                Common comm = new Common();
                int count = comm.ExecuteScalar("select count(*) from class", 0);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
