<%@ WebHandler Language="C#" Class="UserManage" %>

using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using DAL;
using Model;
using BLL;
using Commons;

public class UserManage : IHttpHandler, IRequiresSessionState
{
    Help help = new Help();
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
    
        string method = context.Request["method"];
        switch (method)
        {
            case "UserAdd":
                UserAdd(context);
                break;
            case "UserDelete":
                UserDelete(context);
                break;
            case "UserEdit":
                UserEdit(context);
                break;
            case "PersonalSettings":
                PersonalSettings(context);
                break;

        }
    }

    /// <summary>
    ///  创建
    /// </summary>
    public void UserAdd(HttpContext context)
    {
        Help help = new Help();
        try
        {
            UserEntity model = new UserEntity();
            model.user_name = context.Request.Form["user_name"];
            model.user_pwd = DbTools.Md5(context.Request.Form["pwd"]);
            string role1 = context.Request.Form["Role"];
            string[] role = role1.Split(',');
            // model.role_name = role[1]; 
            model.role_id = Convert.ToInt32(role[0]);
            model.status = 1;
            model.real_name = context.Request.Form["real_name"];
            if (help.ChecUser(model.user_name, "user", "user_id"))
            {
                context.Response.Write(failure("用户名重复，"));
                return;
            }

            UserDAL user = new UserDAL();
            user.InsertUserEntity(model);
            help.SysWriteLog("创建新用户：" + model.user_name, 1);
            context.Response.Write(success("用户创建", "M000"));
        }
        catch (Exception e)
        {
            help.SysWriteLog("创建用户出错" + e.Message, 0);
            context.Response.Write(failure("创建用户"));
        }
    }

    /// <summary>
    ///  删除
    /// </summary>
    public void UserDelete(HttpContext context)
    {
        try
        {
            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  user where user_id in (" + id + ") ");
            help.SysWriteLog("删除用户" , 1);
            context.Response.Write(success());
        }
        catch (Exception e)
        {
            help.SysWriteLog("删除用户出错" + e.Message, 0);
            context.Response.Write(failure());
        }
    }

    /// <summary>
    ///  修改
    /// </summary>
    public void UserEdit(HttpContext context)
    {
        try
        {
            Common comm = new Common();
            int role_id = 0;
            string pwd = context.Request.Form["UserPwd"].Trim();
            string ID = context.Request.Form["UID"].Trim();
            string userName = context.Request.Form["UserName"].Trim();
            string userRole = context.Request.Form["Role"].Trim();
            string realName = context.Request.Form["RealName"].Trim();
            if (!String.IsNullOrEmpty(context.Request.Form["NewUserPwd"].Trim()))
                pwd = DbTools.Md5(context.Request.Form["NewUserPwd"].Trim());
            string userState = context.Request.Form["State"].Trim();
            String time = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "select role_id from role where role_name='" + userRole + "'";
            role_id = comm.ExecuteScalar(sql1,0);
            string sql = " update user set user_name= '" + userName + "', real_name='" + realName + "',role_id= '" + role_id + "',user_pwd='" + pwd + "',status='" + userState + "' where user_id='" + ID + "' ";
            comm.ExecuteNonQuery(sql);
            help.SysWriteLog("修改用户信息：" + userName, 1);
            context.Response.Write(success("修改", "M000"));
        }
        catch (Exception e)
        {
            help.SysWriteLog("修改用户出错" + e.Message, 0);
            context.Response.Write(failure());
        }
    }

    /// <summary>
    ///  个人设置
    /// </summary>
    public void PersonalSettings(HttpContext context)
    {
        try
        {
            UserEntity user = new UserEntity();
            string ID = context.Request["ID"];
            Common comm = new Common();
            string pwd = "";

            if (!String.IsNullOrEmpty(context.Request.Form["NewUserPwd"]))
                pwd = context.Request.Form["NewUserPwd"];
            else
                pwd = context.Request.Form["UserPwd"];

            string sql = " update user set pwd= '" + pwd + "' where user_id='" + ID + "' ";
            comm.ExecuteNonQuery(sql);
            context.Response.Write(success("个人设置修改", "ps"));
        }
        catch
        {
            context.Response.Write(failure());
        }
    }



    /// <summary>
    /// 回复成功的json {"statusCode":"200", "message":"操作成功!"}"
    /// </summary>
    /// <returns></returns>
    public string success()
    {
        return "{\"statusCode\":\"200\", \"message\":\"删除成功!\"}";
    }
    /// <summary>
    /// 回复成功的json,并刷新名称为navTabId的Tab
    /// </summary>
    /// <param name="str">{"statusCode":"200", "message":"操作成功!{str的内容}"}"</param>
    /// <param name="navTabId">navTabId的名称</param>
    /// <returns></returns>
    public string success(string str, string navTabId)
    {
        return "{\"statusCode\":\"200\", \"message\":\"" + str + "成功!\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"closeCurrent\"}";
    }
    /// <summary>
    /// 失败的json {"statusCode":"300", "message":"操作失败!"}"
    /// </summary>
    /// <returns></returns>
    public string failure()
    {
        return "{\"statusCode\":\"300\", \"message\":\"操作失败,请稍后再试!\"}";
    }
    /// <summary>
    /// 失败的json {"statusCode":"300", "message":"操作失败!{str的内容}"}"
    /// </summary>
    /// <param name="str">{"statusCode":"300", "message":"操作失败!{str的内容}"}"</param>
    /// <returns></returns>
    public string failure(string str)
    {
        return "{\"statusCode\":\"300\", \"message\":\"" + str + "操作失败,请稍后再试!\"}";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }

    }
}
