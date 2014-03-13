using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using BLL;
using DAL;
using Commons;
using System.Text;
using System.Data;

namespace WebUI.Admin.User
{ 
    public partial class PersonalSetting : AdminBasePage
    {
        Help help = new Help();
        protected UserEntity user = new UserEntity();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        public void GetData()
        {
            try
            {
                UserDAL uDAL = new UserDAL();
                user = uDAL.GetModel((Session["user"] as  Model.UserEntity).user_id);
            }
            catch (Exception e)
            {
                help.SysWriteLog("PersonalSetting.aspx获取用户信息出错：" + e.Message, 0);
            }
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        public String GetRole()
        {
            try
            {
                string role = "";
                role = Session["role_name"].ToString();
                return role;
            }
            catch (Exception e)
            {
                help.SysWriteLog("PersonalSetting.aspx获取用户信息出错：" + e.Message, 0);
                return null;
            }
        }
    }
}
