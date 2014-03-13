using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;

namespace WebUI.Admin.User
{
    public partial class UserManage : AdminBasePage
    {
        UserDAL dal = new UserDAL();

        Help help = new Help();

        protected List<string> p = new List<string>();

        public void Check()
        {

            p.Add("MM01");
            p.Add("MM02");
            p.Add("MM03");
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

        private string keyString;
        /// <summary>
        /// where语句，不加where与空格
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                help.SysCheck(Page, "M000");
                Check();
            }
             try
            {
            DataTable dt;
            orderField = OrderField == null ? "user_name" : OrderField;
            orderDirection = OrderDirection == null ? "asc" : OrderDirection;
            string orderStr = " " + orderField + " " + orderDirection + " ";

            string sqlWhere = "1=1 and user.role_id=role.role_id";

            if (!string.IsNullOrEmpty(KeyString)) // 查找语句
            {
                sqlWhere += " and user_name like '%" + KeyString + "%' or role_name like '%" + KeyString + "%'";
            }
            dt = dal.GetUser(orderStr, sqlWhere);
            totalCount = dt.Rows.Count;                 //设置总条数
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = PageNum - 1;         //当前页的索引
            pds.PageSize = NumPerPage;                  //每页显示的记录数
            this.Repeater1.DataSource = pds;
            Repeater1.DataBind();
            }
             catch (System.Exception ex)
             {
                 help.SysWriteLog("UserManage.aspx获取平台角色信息出错：" + ex.Message, 0);
             }
        }
    }
}
