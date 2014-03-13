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
using System.Text;
using System.Xml;
using System.Web.Caching;

using DAL;
using Model;



namespace WebUI.Admin.Role
{
    public partial class RoleShow : AdminBasePage
    {
        StringBuilder ListRole = new StringBuilder();
        XmlDataDocument doc = new XmlDataDocument();
        Help help = new Help();
        protected RoleEntity roleEntity = new RoleEntity();
        protected string role_id = HttpContext.Current.Request.QueryString["id"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                help.SysCheck(Page, "RR04");
                GetData();
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        public void GetData()
        {
            try
            {
                RoleDAL roleDAL = new RoleDAL();

                roleEntity = roleDAL.GetModel(Convert.ToInt32(role_id));
            }
            catch (Exception e)
            {
               help.SysWriteLog("RoleShow.aspx获取角色信息出错：" + e.Message, 0);

            }
        }

        /// <summary>
        /// 获取左侧便拦组
        /// </summary>
        protected string GetListRole()
        {
            try
            {
                if (Cache.Get("Permissions") != null)
                {
                    doc = Cache.Get("Permissions") as XmlDataDocument;
                }
                else
                {
                    string xml = Server.MapPath("~/XML/Permissions.xml");
                    doc.Load(xml);
                    CacheDependency cd = new CacheDependency(xml);

                    Cache.Insert("Permissions", doc, cd);
                }

                if (doc != null)
                {
                    XmlNodeList OneList = doc.SelectNodes("Permissions_Group/Group_List");
                    foreach (XmlNode listOne in OneList)
                    {

                        if (roleEntity.rights_code.IndexOf(listOne.SelectSingleNode("pid").InnerText) == -1)
                            ListRole.Append("<div class=\"unit\"><h1><input type=\"checkbox\" name=\"pid\" value=\"" + listOne.SelectSingleNode("pid").InnerText + "\"  />" + listOne.SelectSingleNode("title").InnerText + "</h1></div>");
                        else
                            ListRole.Append("<div class=\"unit\"><h1><input type=\"checkbox\" name=\"pid\" value=\"" + listOne.SelectSingleNode("pid").InnerText + "\" checked=\"checked\"  />" + listOne.SelectSingleNode("title").InnerText + "</h1></div>");

                        XmlNodeList TwoList = listOne.SelectNodes("Group");

                        foreach (XmlNode ListTwo in TwoList)
                        {
                            if (roleEntity.rights_code.IndexOf(ListTwo.SelectSingleNode("pid").InnerText) == -1)
                                ListRole.Append("<div class=\"unit\"><input type=\"checkbox\" name=\"pid\" value=\"" + ListTwo.SelectSingleNode("pid").InnerText + "\"  />" + ListTwo.SelectSingleNode("name").InnerText + "</div>");
                            else
                                ListRole.Append("<div class=\"unit\"><input type=\"checkbox\" name=\"pid\" value=\"" + ListTwo.SelectSingleNode("pid").InnerText + "\" checked=\"checked\" />" + ListTwo.SelectSingleNode("name").InnerText + "</div>");

                            XmlNodeList ThreeList = ListTwo.SelectNodes("GroupOne");
                            ListRole.Append("<div class=\"unit\">");
                            foreach (XmlNode ListThree in ThreeList)
                            {
                                if (ListThree.SelectSingleNode("pid").InnerText == "S001")
                                {
                                    if (roleEntity.rights_code.IndexOf(ListThree.SelectSingleNode("pid").InnerText) == -1)
                                        ListRole.Append("<div class=\"unit\"><label><input type=\"checkbox\" name=\"pid\" value=\"" + ListThree.SelectSingleNode("pid").InnerText + "\" />" + ListThree.SelectSingleNode("name").InnerText + "</label></div>");
                                    else
                                        ListRole.Append("<div class=\"unit\"><label><input type=\"checkbox\" name=\"pid\" value=\"" + ListThree.SelectSingleNode("pid").InnerText + "\" checked=\"checked\" />" + ListThree.SelectSingleNode("name").InnerText + "</label></div>");
                                }
                                else
                                {
                                    if (roleEntity.rights_code.IndexOf(ListThree.SelectSingleNode("pid").InnerText) == -1)
                                        ListRole.Append("<label><input type=\"checkbox\" name=\"pid\" value=\"" + ListThree.SelectSingleNode("pid").InnerText + "\" />" + ListThree.SelectSingleNode("name").InnerText + "</label>");
                                    else
                                        ListRole.Append("<label><input type=\"checkbox\" name=\"pid\" value=\"" + ListThree.SelectSingleNode("pid").InnerText + "\" checked=\"checked\" />" + ListThree.SelectSingleNode("name").InnerText + "</label>");
                                }

                                XmlNodeList FourList = ListThree.SelectNodes("GroupTwo");
                                if (FourList.Count > 0)
                                {
                                    ListRole.Append("<div class=\"unit\">");
                                    foreach (XmlNode ListFour in FourList)
                                    {
                                        if (roleEntity.rights_code.IndexOf(ListFour.SelectSingleNode("pid").InnerText) == -1)
                                            ListRole.Append("<label><input type=\"checkbox\" name=\"pid\" value=\"" + ListFour.SelectSingleNode("pid").InnerText + "\" />" + ListFour.SelectSingleNode("name").InnerText + "</label>");
                                        else
                                            ListRole.Append("<label><input type=\"checkbox\" name=\"pid\" value=\"" + ListFour.SelectSingleNode("pid").InnerText + "\" checked=\"checked\" />" + ListFour.SelectSingleNode("name").InnerText + "</label>");

                                    }
                                    ListRole.Append("</div>");
                                }
                            }
                            ListRole.Append("</div>");

                        }

                        ListRole.Append("<div class=\"divider\"></div>");
                    }

                    return ListRole.ToString();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                help.SysWriteLog("RoleShow.aspx获取权限列表出错：" + e.Message, 0);
                return null;
            }
        }
    }
}
