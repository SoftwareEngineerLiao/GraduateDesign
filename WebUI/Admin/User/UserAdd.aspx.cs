using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Commons;
using DAL;

namespace WebUI.Admin.User
{
    public partial class UserAdd : AdminBasePage
    {
        Help Help = new Help();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string GetRole()
        {
            try
            {
                StringBuilder s = new StringBuilder();
                Common com = new Common();
                DataSet ds = com.GetDataSet("select * from role");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        s.Append("<option value=\"" + ds.Tables[0].Rows[i]["role_id"] + "," + ds.Tables[0].Rows[i]["role_name"] + "\">" + ds.Tables[0].Rows[i]["role_name"] + "</option>");
                    }
                }
                return s.ToString();
            }
            catch (Exception e)
            {
                Help.SysWriteLog("UserAdd.aspx获取角色信息出错：" + e.Message, 0);
                return "";

            }
        }
    }
}
