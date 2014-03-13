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
            string sql = "select * from class where class_id = '" + id + "' ";
            Common comm = new Common();
            ds = comm.GetDataSet(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取相应的学年、学期、年级的选项
        /// pjd
        /// 8/25
        /// </summary>
        /// <returns></returns>
        public string GetData(string strType)
        {
            try
            {
                string[] year = null;
                switch (strType)
                {
                    case "grade":
                        year = Help.RXml("Class").Split('|'); break;
                    case "SchoolYear":
                        year = Help.RXml("SchoolYear").Split('|'); break;
                }


                StringBuilder s = new StringBuilder();
                if ("grade".Equals(strType))
                {
                    for (int i = 0; i < year.Length; i++)
                    {
                        if (ds.Tables[0].Rows[0]["grade"].ToString() == year[i])
                            s.Append("<option value=\"" + year[i] + "\" selected=\"selected\">" + year[i] + "</option>");
                        else
                            s.Append("<option value=\"" + year[i] + "\">" + year[i] + "</option>");
                    }
                }
                else
                {
                    for (int i = 0; i < year.Length; i++)
                    {
                        if (ds.Tables[0].Rows[0]["CXuanNian"].ToString() == year[i])
                            s.Append("<option value=\"" + year[i] + "\" selected=\"selected\">" + year[i] + "</option>");
                        else
                            s.Append("<option value=\"" + year[i] + "\">" + year[i] + "</option>");
                    }
                }


                return s.ToString();

            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
