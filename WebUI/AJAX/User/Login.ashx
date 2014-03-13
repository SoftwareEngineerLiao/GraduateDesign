<%@ WebHandler Language="C#" Class="Login" %>

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

public class Login : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
        string method = context.Request["method"];
        switch (method)
        {
            case "AdminLogin":
                AdminLogin(context);
                break;
        }
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    public void AdminLogin(HttpContext context)
    {
        string username = context.Request["username"].Trim();
        string pwd = DbTools.Md5(context.Request["pwd"].Trim());
        string role = "";
        Help help = new Help();
        
        if (username != "" && pwd != "")
        {
            UserEntity user = new UserEntity();
            user.user_name = username;
            user.user_pwd= pwd;
            user = help.CheckUser_GetModel(user);
            if (user != null)
            {
                if (user.status == 1)
                {
                    context.Session["user"] = user;
                    Common com = new Common();
                    string sql = "select role_name from role where role_id = '" + user.role_id + "'";
                    role = com.ExecuteScalar(sql,"");
                    context.Session["role_name"] = role;
                    help.SysWriteLog("登录系统", 1);
                    context.Response.Write("{result: \"ok\"}");
                }
                else
                    context.Response.Write("{result: \"您的帐号已被禁用，无法登录！\"}");
            }

            else
            {
                context.Response.Write("{result: \"您输入的帐号、密码错误，请重新输入！\"}");
            }

        }
        else
        {
            context.Response.Write("{result: \"帐号、密码不能为空！\"}");
        }
    }
    
    public bool IsReusable
    {
        get
        {
            return false;
        }

    }
}