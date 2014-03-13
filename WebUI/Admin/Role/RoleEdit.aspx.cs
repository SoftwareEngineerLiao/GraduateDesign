using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Commons;
using DAL;
using System.Data;
using System.Text;

namespace WebUI.Admin.Role
{
    public partial class RoleEdit : AdminBasePage
    {
        string role_id = HttpContext.Current.Request.QueryString["id"];
        Help help = new Help();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                help.SysCheck(Page, "RR02");
                getData();
            }
        }

        public DataTable getData()
        {
            string sql = "select * from role where role_id = '" + role_id + "' ";
            Common comm = new Common();
            DataSet ds = comm.GetDataSet(sql);
            return ds.Tables[0];
        }
    }
}
