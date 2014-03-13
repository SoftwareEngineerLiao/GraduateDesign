using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DAL;
using System.Collections.Generic;

namespace WebUI.Admin.Log
{
    public partial class ErrorLogManage : AdminBasePage
    {
         LogDAL logDAL = new LogDAL();
         Help help = new Help();
         protected List<string> p = new List<string>();

         public void Check()
         {

             p.Add("LC01");
             p = help.SysCheck(p);
         }
        #region 分页变量，与UI绑定
        private int numPerPage;
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int NumPerPage
        {
            get
            {
                int temp = Convert.ToInt32(Request.Form["numPerPage"]);
                return temp == 0 ? 20 : temp;
            }
            set { numPerPage = value; }
        }

        private int pageNumShown = 10;
        /// <summary>
        /// 页数导航的个数
        /// </summary>
        public int PageNumShown
        {
            get { return pageNumShown; }
            set { pageNumShown = value; }
        }

        private int pageNum;
        /// <summary>
        /// 当前显示的页数
        /// </summary>
        public int PageNum
        {
            get
            {
                int temp = Convert.ToInt32(Request.Form["pageNum"]);
                return temp == 0 ? 1 : temp;
            }
            set { pageNum = value; }
        }

        private int totalCount;
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        #endregion

        #region 排序关键字
        public string orderField;
        /// <summary>
        /// 排序关键字
        /// </summary>
        public string OrderField
        {
            get
            {
                string temp = Request.Form["orderField"];
                return temp;
            }
            set { orderField = value; }
        }

        #endregion

        #region 排序方式
        public string orderDirection;
        /// <summary>
        /// 排序方式
        /// </summary>
        public string OrderDirection
        {
            get
            {
                string temp = Request.Form["orderDirection"];
                return temp;
            }
            set { orderDirection = value; }
        }

        #endregion

        #region 查找关键字

        public string KeyString
        {
            get
            {
                string temp1 = Request.Form["KeyString"];
                return temp1;
            }
            set { KeyString = value; }
        }
        public string DateStart
        {
            get
            {
                string temp2 = Request.Form["DateStart"];
                return temp2;
            }
            set { DateStart = value; }
        }
        public string DateEnd
        {
            get
            {
                string temp3 = Request.Form["DateEnd"];
                return temp3;
            }
            set { DateEnd = value; }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                help.SysCheck(Page, "L002");
                Check();
            }
            DataTable dt;
            orderField = OrderField == null ? "write_time" : OrderField;
            orderDirection = OrderDirection == null ? "desc" : OrderDirection;
            string orderStr = " " + orderField + " " + orderDirection + " ";

            string sqlWhere = "1=1 ";

            if (!string.IsNullOrEmpty(KeyString)) // 排序
            {
                sqlWhere += "and log_content like '%" + KeyString + "%'  ";
            }
            else if ((!string.IsNullOrEmpty(DateStart)) && (DateEnd.Length == 0))
            {
                sqlWhere += "and write_time ='" + DateStart + "' ";
            }
            else if ((!string.IsNullOrEmpty(DateEnd)) && (DateStart.Length == 0))
            {
                sqlWhere += "and write_time ='" + DateEnd + "' ";
            }
            else if ((!string.IsNullOrEmpty(DateStart)) && (!string.IsNullOrEmpty(DateEnd))) // 排序
            {
                sqlWhere += "and write_time between '" + DateStart + "' and '" + DateEnd + "'  ";
            }
            dt = logDAL.GetErrorLog(orderStr, sqlWhere);
            totalCount = dt.Rows.Count;                 // 设置总条数
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = PageNum - 1;         // 当前页的索引
            pds.PageSize = NumPerPage;                  // 每页显示的记录数
            this.Repeater1.DataSource = pds;
            Repeater1.DataBind();
        }
        

    }
}
