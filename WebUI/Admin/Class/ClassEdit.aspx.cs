﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using Commons; // 工具类

namespace WebUI.Admin.Class
{
    public partial class ClassEdit1 : System.Web.UI.Page
    {  
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
            string sql = "select * from class where class_no = '" + id + "' ";
            Common comm = new Common();
            DataSet ds = comm.GetDataSet(sql);
            return ds.Tables[0];
        }
    }
}
