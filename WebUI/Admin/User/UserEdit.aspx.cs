using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Commons;
using System.Data;
using System.Text;
using DAL;
using Model;

namespace WebUI.Admin.User
{
    public partial class UserEdit : AdminBasePage
    {
        Help help = new Help();
        string uid = HttpContext.Current.Request.QueryString["id"];
        protected UserEntity model = new UserEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }
        }

        public void getData()
        {
            try
            {
                UserDAL users = new UserDAL();
                model = users.GetModel(Convert.ToInt32(uid));
            }
            catch (Exception e)
            {
                help.SysWriteLog("UserEdit.aspx获取用户信息出错：" + e.Message, 0);

            }
        }

        public string GetRole()
        {
            try
            {
                StringBuilder s = new StringBuilder();
                Common comm = new Common();
                DataSet ds = comm.GetDataSet("select * from role");
                DataSet roleds = comm.GetDataSet("select role_id from user where user_id = '" + uid + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(roleds.Tables[0].Rows[0]["role_id"]) == Convert.ToInt32(ds.Tables[0].Rows[i]["role_id"]))
                            s.Append("<option value=\" " + ds.Tables[0].Rows[i]["role_name"] + "\" selected=\"selected\">" + ds.Tables[0].Rows[i]["role_name"] + "</option>");
                        else
                            s.Append("<option value=\"" + ds.Tables[0].Rows[i]["role_name"] + "\">" + ds.Tables[0].Rows[i]["role_name"] + "</option>");
                    }
                }
                return s.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
