using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commons;
using System.Data;
using DAL;
using System.Text;

namespace WebUI.Admin.Class
{
    public partial class ClassEdit : System.Web.UI.Page
    {
        protected DataSet ds;
        string id = HttpContext.Current.Request.QueryString["id"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }
        }

        public DataTable getData()
        {
            string sql = "select * from notice where id = '" + id + "' ";
            Common comm = new Common();
            ds = comm.GetDataSet(sql);
            return ds.Tables[0];
        }

       
    }
}
