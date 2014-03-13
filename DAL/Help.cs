using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Data;
using System.Web;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.IO;
using System.Web.Caching;
using System.Web.UI.WebControls;
using Commons;
using DAL;
using Model;
using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace DAL
{
public class Help
    { 
        public Help()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        static int size = Convert.ToInt32(RXml("PageSize"));
        static string error = RXml("Error");
        public static int GetSize
        {
            set { size = value; }
            get { return size; }
        }
        public static string GetError
        {
            set { error = value; }
            get { return error; }
        }
 
        #region 分页显示
        /// <summary>
        /// 分页导航
        /// </summary>
        /// <param name="RecordCount">记录总数</param>
        /// <param name="NowPage">当前页</param>
        /// <param name="url">url地址</param>
        /// <param name="title">显示标题</param>
        /// <param name="id">选项卡ID</param>
        /// <param name="s">查询关键字</param>
        /// <returns>返回显示分页</returns>
        public static string Pager(int Count, int PageSize, int NowPage)
        {
            StringBuilder pager = new StringBuilder();
            pager.Append("<div class=\"panelBar\">");
            pager.Append("<div class=\"pages\">");
            pager.Append("<span>显示</span>");
            pager.Append("<select name=\"numPerPage\" onchange=\"navTabPageBreak({numPerPage:this.value})\">");
            switch (PageSize)
            {
                case 20:
                    pager.Append("<option value=\"20\" selected=\"selected\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 50:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\" selected=\"selected\">50</option>");
                    pager.Append("<option value=\"100\">100</option>");
                    break;
                case 100:
                    pager.Append("<option value=\"20\">20</option>");
                    pager.Append("<option value=\"50\">50</option>");
                    pager.Append("<option value=\"100\" selected=\"selected\">100</option>");
                    break;
            }
            pager.Append("</select>");
            pager.Append("<span>条，总共" + Count + "条，每页" + PageSize + "条，当前第" + NowPage + "页</span>");
            pager.Append("</div>");
            pager.Append("<div class=\"pagination\" targetType=\"navTab\" totalCount=\"" + Count + "\" numPerPage=\"" + PageSize + "\" pageNumShown=\"10\" currentPage=\"" + NowPage + "\"></div>");
            pager.Append("</div>");
            return pager.ToString();
        }
        #endregion

        #region 生成主键
        public static string GeneratedPrimaryKey()
        {
        

          return Guid.NewGuid().ToString();
         
    
        }
        #endregion

        #region 通用数据分页

        /// <summary>
        /// 通用mysql分页查询
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="tbFields">字段名</param>
        /// <param name="orderField">排序字段名</param>
        /// <param name="orderType">排序[1-asc,0-desc]</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageRecord">查询记录数</param>
        /// <returns></returns>
        public static DataSet PageList(string tbName, string tbFields, string orderField, int orderType, string strWhere, int pageSize, int pageIndex, out int pageRecord)
        {
            Common comm = new Common();
            MySqlParameter output = new MySqlParameter("?pageRecord", MySqlDbType.Int32);
            output.Direction = ParameterDirection.Output;
            MySqlParameter[] parameters = {
                    new MySqlParameter("?tbName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?tbFields", MySqlDbType.VarChar, 1000),
                    new MySqlParameter("?orderField", MySqlDbType.VarChar,255),
                    new MySqlParameter("?orderType", MySqlDbType.Int32),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1500),
                    new MySqlParameter("?pageSize", MySqlDbType.Int32),
                    new MySqlParameter("?pageIndex", MySqlDbType.Int32),                    
                    output};
            parameters[0].Value = tbName;
            parameters[1].Value = tbFields;
            parameters[2].Value = orderField;
            parameters[3].Value = orderType;
            parameters[4].Value = strWhere;
            parameters[5].Value = pageSize;
            parameters[6].Value = pageIndex;
            parameters[7].Value = 0;

            DataSet ds = comm.GetDataSet("PageList", parameters);
            //返回符合条件的记录数
            pageRecord = int.Parse(parameters[7].Value.ToString());
            return ds;
        }

        #endregion

        #region 通用读取方法
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="name">值</param>
        /// <param name="Table">表名</param>
        /// <param name="Field">字段名</param>
        /// <returns>是否存在</returns>
        public  bool ChecUser(string name, string Table, string Field)
        {
            Common comm = new Common();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + Table + " ");
            strSql.Append(" where " + Field + "=?" + Field + "");
            MySqlParameter[] parameters = {
					new MySqlParameter("?"+Field+"", MySqlDbType.VarChar,20)
                                          };
            parameters[0].Value = name;
            DataSet ds = comm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region 获取记录数计算
        /// <summary>
    /// 获取记录数计算
    /// </summary>
    /// <param name="Table">表名</param>
    /// <param name="Field"></param>
    /// <returns></returns>
    public  int GetCount(string Table)
    {
        Common comm = new Common();
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(*) from " + Table + " ");


        DataSet ds = comm.GetDataSet(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        else
        {
            return 0;
        }
    }

    #endregion

        #region 登录方法，前台重载
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public UserEntity CheckUser_GetModel(UserEntity user)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from user ");
        strSql.Append(" where user_name=?user_name and user_pwd=?user_pwd");
        MySqlParameter[] parameters = {
					new MySqlParameter("?user_name", MySqlDbType.VarChar,20),
                    new MySqlParameter("?user_pwd", MySqlDbType.VarChar,50)
                                          };
        parameters[0].Value = user.user_name;
        parameters[1].Value = user.user_pwd;
        UserEntity model = new UserEntity();
        Common com = new Common();
        DataSet ds = com.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            model.user_id = Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"]);
            model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
            model.real_name = ds.Tables[0].Rows[0]["real_name"].ToString();
            model.user_pwd = ds.Tables[0].Rows[0]["user_pwd"].ToString();
            model.role_id = Convert.ToInt32(ds.Tables[0].Rows[0]["role_id"].ToString());
            model.status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
            {
                model.user_id = Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"]);
            }
            if (ds.Tables[0].Rows[0]["status"].ToString() != "")
            {
                model.status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"]);
            }
            if (ds.Tables[0].Rows[0]["role_id"].ToString() != "")
            {
                model.role_id = Convert.ToInt32(ds.Tables[0].Rows[0]["role_id"].ToString());
            }
            
            return model;
        }
        else
        {
            return null;
        }
    }


    #endregion

        #region 系统错误日志写入
    /// <summary>
    /// 运营平台日志
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="type">分类0为系统错误日志，1为操作日志</param>
    public  void SysWriteLog(string txt, int type)
    {
        try
        {
            LogDAL log = new LogDAL();
            LogEntity model = new LogEntity();
            if (HttpContext.Current.Session["user"] != null)
            {
                UserEntity user = HttpContext.Current.Session["user"] as UserEntity;
                model.log_content = "[" + user.user_name + "] " + txt;
                model.write_time = DateTime.Now;
                model.log_type = type;
                log.InsertLogDAL(model);
            }  
        }
        catch (Exception)
        {
        }
    }
    #endregion

        #region 读取Excel
    public static DataSet ExcelToDS(string Path)
    {
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
        using (OleDbConnection conn = new OleDbConnection(strConn))
        {
            conn.Open(); string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet(); myCommand.Fill(ds, "table1");
            return ds;
        }
    }
    #endregion

        #region 上传文件
    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="Files">文件对象</param>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string[] UploadFiles(HttpPostedFile Files, string path)
    {
        string[] name = new string[2];
        name[0] = Files.FileName;
        name[1] = "";
        if (name[0].LastIndexOf("\\") > 0)
            name[0] = name[0].Substring(name[0].LastIndexOf("\\") + 1, name[0].Length - name[0].LastIndexOf("\\") - 1);

        //path += DateTime.Now.ToString("yyyyMMdd"); // 以时间为文件名
        string paths = HttpContext.Current.Server.MapPath(path);
        if (!Directory.Exists(paths))
        { 
            Directory.CreateDirectory(paths);
        }
        name[1] = path.Substring(0, path.Length) + name[0];
        //name[1] = path.Substring(2, path.Length - 2) + "/" + name[0];
        Files.SaveAs(paths + "\\" + name[0]);
        return name;
    }
    #endregion

        #region 上传文件通用返回显示
    public static string RString(string code, string message, string id, string url, string type)
    {
        StringBuilder s = new StringBuilder();
        s.Append("<script type=\"text/javascript\">");
        s.Append("var statusCode=\"" + code + "\"; ");
        s.Append("var message=\"" + message + "\"; ");
        s.Append("var navTabId=\"" + id + "\"; ");
        s.Append("var forwardUrl=\"" + url + "\"; ");
        s.Append("var callbackType=\"" + type + "\"; ");
        s.Append("var response = {statusCode:statusCode,");
        s.Append("message:message,");
        s.Append("navTabId:navTabId,");
        s.Append("forwardUrl:forwardUrl,");
        s.Append("callbackType:callbackType");
        s.Append("}; ");
        s.Append("if(window.parent.donecallback)window.parent.donecallback(response);");
        s.Append("</script>");
        return s.ToString();
    }
    #endregion

        #region Xml参数取值
        public static string RXml(string name)
        {
            XmlDataDocument doc = new XmlDataDocument();
            if (HttpContext.Current.Cache.Get("Parameters") != null)
            {
                doc = HttpContext.Current.Cache.Get("Parameters") as XmlDataDocument;
            }
            else
            {
                string xml = HttpContext.Current.Server.MapPath("~/Xml/Parameters.xml");
                doc.Load(xml);
                CacheDependency cd = new CacheDependency(xml);
                HttpContext.Current.Cache.Insert("Parameters", doc, cd);
            }

            if (doc != null)
            {
                XmlNodeList node = doc.SelectNodes("Parameter/" + name);
                return node[0].InnerText;
            }
            else
            {
                return "";
            }
        }
       #endregion

        #region 获取天气

    public static string GetWeather()
    {
        try
        {
            if (System.Web.HttpContext.Current.Cache["weather"] != null)
            {
                return HttpContext.Current.Cache["weather"].ToString();
            }
            else
            {
                string url = RXml("weather");
                XmlDataDocument doc = new XmlDataDocument();
                doc.Load(url);
                if (doc != null)
                {
                    XmlNodeList OneList = doc.SelectNodes("rss/channel");
                    StringBuilder s = new StringBuilder();
                    foreach (XmlNode listOne in OneList)
                    {
                        s.Append(listOne.SelectSingleNode("title").InnerText + " ");
                        XmlNodeList TwoList = listOne.SelectNodes("item");
                        foreach (XmlNode listTwo in TwoList)
                        {
                            s.Append(listTwo.SelectSingleNode("title").InnerText + " ");
                            s.Append(listTwo.SelectSingleNode("description").InnerText);
                        }
                    }
                    HttpContext.Current.Cache.Insert("weather", s.ToString(), null, DateTime.Now.AddHours(3), TimeSpan.Zero);
                    return s.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch 
        {
            //Help.SysWriteLog("读取天气预报出错：" + e.Message, 0);
            return "";
        }
    }
    #endregion

        #region 权限检查
    /// <summary>
    /// 
    /// </summary>
    /// <param name="page">page</param>
    /// <param name="code">权限代码</param>
    /// <param name="TabName">弹出页面ID</param>
    /// <param name="Url">地址</param>
    public void OACheck(System.Web.UI.Page page, string code)
    {
        try
        {
            // page.Response.Redirect("~/Error/OA"+Url);
            //return;
        }
        catch (Exception e)
        {
            SysWriteLog("help权限查询出错：" + e.Message, 0);
        }
    }




    /// <summary>
    /// 运营平台检查权限
    /// </summary>
    /// <returns></returns>
    public  void SysCheck(System.Web.UI.Page page, string code)
    {
        try
        {
            
            UserEntity userModel = HttpContext.Current.Session["user"] as UserEntity;
            if (userModel.user_name != "admin")
            {
                RoleDAL roleDal = new RoleDAL();
                RoleEntity roleModel = new RoleEntity();
                roleModel = roleDal.GetModel(userModel.role_id);
                if (roleModel != null && roleModel.rights_code.IndexOf(code) == -1)
                    page.Response.Redirect("~/Error/Error_p.aspx", false);
            }

        }
        catch (Exception e)
        {
            SysWriteLog("help权限查询出错：" + e.Message, 0);
        }
    }
    /// <summary>
    /// 显示权限检查
    /// </summary>
    /// <param name="page"></param>
    /// <param name="code"></param>
    public  bool SysCheck(string p, string code)
    {
        try
        {
            if (p.IndexOf(code) == -1)
                return false;
            else
                return true;

        }
        catch (Exception e)
        {
            SysWriteLog("help显示权限查询出错：" + e.Message, 0);
            return false;
        }
    }
   
     /// <summary>
    /// 权限显示通用检查
    /// </summary>
    /// <param name="code">s001,s002</param>
    /// <returns></returns>
    public  List<string> SysCheck(List<string> code)
    {
        List<string> list = new List<string>();
        try
        {
            list.Add("disabled=\"true\"");
            list.Add("disabled=\"true\"");
            list.Add("disabled=\"true\"");
            list.Add("disabled=\"true\"");
            list.Add("disabled=\"true\"");
            UserEntity userModel = HttpContext.Current.Session["user"] as UserEntity;
            
            if (code != null)
            {
                if (userModel.user_name != "admin")
                {
                    RoleDAL roleDAL = new RoleDAL();
                    RoleEntity roleModel = new RoleEntity();
                    //OA.Model.sys_role model = new OA.Model.sys_role();
                    roleModel = roleDAL.GetModel(userModel.role_id);
                    

                    for (int i = 0; i < code.Count; i++)
                    {
                        if (roleModel != null)
                        {
                            if (roleModel.rights_code.IndexOf(code[i]) != -1)
                                list[i] = "";
                            else
                                list[i] = "disabled=\"true\"";
                        }
                        else
                        {
                            list[i] = "disabled=\"true\"";
                        }
                    }
                    return list;
                }
                else
                {
                    for (int i = 0; i < code.Count; i++)
                    {
                        list[i] = "";
                    }
                    
                    return list;
                }
            }
            else
                return list;

        }
        catch (Exception e)
        {
            SysWriteLog("help权限查询出错：" + e.Message, 0);
            return list;
        }
    }
    
    #endregion
 }
}