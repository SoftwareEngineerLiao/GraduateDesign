using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using System.Text;

namespace WebUI.Admin.Class
{
    public partial class ClassAdd : System.Web.UI.Page
    {
        protected DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    case "Class":
                        year = Help.RXml("Class").Split('|'); break;
                    case "SchoolYear":
                        year = Help.RXml("SchoolYear").Split('|'); break;
                }


                StringBuilder s = new StringBuilder();
                for (int i = 0; i < year.Length; i++)
                {
                    s.Append("<option value=\"" + year[i] + "\">" + year[i] + "</option>");
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
