using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Web.Caching;
using System.Data;

using DAL;
using Model;
using System.Text;

namespace WebUI
{
    public partial class _Default : System.Web.UI.Page
    {
        StringBuilder LeftList = new StringBuilder();
        StringBuilder Announcement = new StringBuilder();
        DateTime time = DateTime.Now;
        StringBuilder Welcome = new StringBuilder();
        UserEntity user = new UserEntity();
        XmlDataDocument doc = new XmlDataDocument();
        Help help = new Help();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Check();
            }
        }

        /// <summary>
        /// 首页单独检查session
        /// </summary>
        public void Check()
        {

            if (Session["user"] == null)
            {

                Session.Abandon();
                Response.Write("<script language='javascript'>alert('您登录已超时，请重新登录！');top.location.href = 'Login.aspx';</script>");
                return;
            }
            else
            {
                user = Session["user"] as Model.UserEntity;
            }
        }

        /// <summary>
        /// 获取左侧便拦组
        /// </summary>
        protected string GetLeftList()
        {
            try
            {
                RoleDAL role = new RoleDAL();
                RoleEntity model = new RoleEntity();
                model = role.GetModel(user.role_id);
                if (Cache.Get("LeftMenuList") != null)
                {
                    doc = Cache.Get("LeftMenuList") as XmlDataDocument;
                }
                else
                {
                    string xml = Server.MapPath("~/XML/LeftMenuList.xml");
                    doc.Load(xml);
                    CacheDependency cd = new CacheDependency(xml);

                    Cache.Insert("LeftMenuList", doc, cd);
                }

                if (doc != null)
                {
                    XmlNodeList OneList = doc.SelectNodes("Permissions_Group/Group_List");
                    foreach (XmlNode listOne in OneList)
                    {
                        if (user.user_name == "admin" || help.SysCheck(model.rights_code, listOne.SelectSingleNode("pid").InnerText))
                        {
                            //*********************************************************信息管理开始-标题栏
                            LeftList.Append("<div class=\"accordionHeader\">");
                            LeftList.Append("<h2><span>Folder</span>" + listOne.SelectSingleNode("title").InnerText + "</h2>");

                            LeftList.Append("</div>");
                            //下拉开始
                            LeftList.Append("<div class=\"accordionContent\" style=\"display:block;\">");
                            //**************展示内容************
                            LeftList.Append("<ul class=\"tree treeFolder\">");
                            //*******循环内部******
                            XmlNodeList TwoList = listOne.SelectNodes("Group");
                            foreach (XmlNode ListTwo in TwoList)
                            {
                                if (user.user_name == "admin" || help.SysCheck(model.rights_code, ListTwo.SelectSingleNode("pid").InnerText))
                                {
                                    if (ListTwo.SelectSingleNode("type").InnerText == "0")
                                    {

                                        LeftList.Append("<li><a href=\"" + ListTwo.SelectSingleNode("url").InnerText + "\" target=\"navTab\" rel=\"" + ListTwo.SelectSingleNode("pid").InnerText + "\">" + ListTwo.SelectSingleNode("name").InnerText + "</a></li>");
                                    }
                                    else
                                    {

                                        LeftList.Append("<li><a>" + ListTwo.SelectSingleNode("name").InnerText + "</a>");
                                        LeftList.Append("<ul>");
                                        XmlNodeList ThreeList = ListTwo.SelectNodes("GroupOne");
                                        foreach (XmlNode ListThree in ThreeList)
                                        {
                                            if (user.user_name == "admin" || help.SysCheck(model.rights_code, ListThree.SelectSingleNode("pid").InnerText))
                                            {
                                                if (ListThree.SelectSingleNode("type").InnerText == "0")
                                                {

                                                    LeftList.Append("<li><a href=\"" + ListThree.SelectSingleNode("url").InnerText + "\" target=\"navTab\" rel=\"" + ListThree.SelectSingleNode("pid").InnerText + "\">" + ListThree.SelectSingleNode("name").InnerText + "</a></li>");
                                                }
                                                else if (ListThree.SelectSingleNode("type").InnerText == "2")
                                                {
                                                    LeftList.Append("<li><a href=\"" + ListThree.SelectSingleNode("url").InnerText + "\" target=\"dialog\" rel=\"" + ListThree.SelectSingleNode("pid").InnerText + "\" width=\"550\" height=\"400\" >" + ListThree.SelectSingleNode("name").InnerText + "</a></li>");
                                                }
                                                else
                                                {

                                                    LeftList.Append("<li><a>" + ListThree.SelectSingleNode("name").InnerText + "</a>");
                                                    LeftList.Append("<ul>");
                                                    XmlNodeList FourList = ListThree.SelectNodes("GroupTwo");
                                                    foreach (XmlNode ListFour in FourList)
                                                    {
                                                        if (user.user_name == "admin" || help.SysCheck(model.rights_code, ListFour.SelectSingleNode("pid").InnerText))
                                                        {
                                                            if (ListFour.SelectSingleNode("type").InnerText == "2")
                                                            {
                                                                LeftList.Append("<li><a href=\"" + ListFour.SelectSingleNode("url").InnerText + "\" target=\"dialog\" rel=\"" + ListFour.SelectSingleNode("pid").InnerText + "\" width=\"500\" height=\"400\" >" + ListFour.SelectSingleNode("name").InnerText + "</a></li>");
                                                            }
                                                            else
                                                            {
                                                                LeftList.Append("<li><a href=\"" + ListFour.SelectSingleNode("url").InnerText + "\" target=\"navTab\" rel=\"" + ListFour.SelectSingleNode("pid").InnerText + "\" >" + ListFour.SelectSingleNode("name").InnerText + "</a></li>");
                                                            }
                                                        }
                                                    }
                                                    LeftList.Append("</ul>");
                                                    LeftList.Append("</li>");
                                                }
                                            }
                                        }
                                        LeftList.Append("</ul>");
                                        LeftList.Append("</li>");
                                    }
                                }
                            }

                            //下拉结束
                            LeftList.Append("</ul>");


                            LeftList.Append("</div>");
                        }
                    }

                    return LeftList.ToString();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                help.SysWriteLog("读取左侧导航出错：" + e.Message, 0);
                return null;
            }
        }
    }
}
