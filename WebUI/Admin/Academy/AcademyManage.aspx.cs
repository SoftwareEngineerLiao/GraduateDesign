using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using System.Data;

namespace WebUI.Admin.Academy
{
    public partial class AcademyManage : System.Web.UI.Page
    {
        protected int Count = 0;
        protected int NowPage = 1;
        protected int PageSize = Help.GetSize;
        protected List<string> p = new List<string>();
        public AcademyDAL academyDAL = new AcademyDAL();
        Help help = new Help();

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

        private string keyString;
        /// <summary>
        /// where子句,不加where与空格
        /// </summary>

        public string KeyString
        {
            get
            {
                string temp = Request.Form["keyString"];
                return temp;
            }
            set { keyString = value; }
        }

        #endregion

        public void Check()
        {
            p.Add("XX01");
            p.Add("XX02");
            p.Add("XX03");
            p = help.SysCheck(p);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                help.SysCheck(Page, "X000");
                Check();
            }
            DataTable dt;
            orderField = OrderField == null ? "academy_no" : OrderField;
            orderDirection = OrderDirection == null ? "asc" : OrderDirection;
            string orderStr = " " + orderField + " " + orderDirection + " ";

            string sqlWhere = "1=1 ";

            if (!string.IsNullOrEmpty(KeyString)) // 排序
            {
                sqlWhere += "and academy_name like '%" + KeyString + "%'  ";
                sqlWhere += "or academy_no like '%" + KeyString + "%'  ";
            }
            dt = academyDAL.GetAcademy(orderStr, sqlWhere);
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
