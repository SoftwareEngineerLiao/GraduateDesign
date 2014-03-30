<%@ WebHandler Language="C#"  Class="NoticeManage" %>

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

public class NoticeManage : IHttpHandler, IRequiresSessionState
{
    Help help = new Help();

 public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";

        string method = context.Request["method"];
        switch (method)
        {
            case "Add":
                Add(context);
                break;
            case "Delete":
                Delete(context);
                break;
            case "Edit":
                Edit(context);
                break;
        }
    }

 /// <summary>
 ///  添加公告
 /// </summary>
 public void Add(HttpContext context)
 {
     try
     {
         string title = context.Request.Form["title"];
         string content = context.Request.Form["content"];
         string type = context.Request.Form["type"];
         String time = DateTime.Now.ToString("yyyy-MM-dd");
         string sql = "insert into notice(title, content, type,time) values('" + title + "', '" + content + "', '" + type + "','" + time + "')";
         Common comm = new Common();
         comm.ExecuteNonQuery(sql);
         context.Response.Write(success("添加", "C001"));
     }
     catch
     {
         context.Response.Write(failure());
     }
 }

 /// <summary>
 ///  修改公告
 /// </summary>
 public void Edit(HttpContext context)
 {
     try
     {
         string ID = context.Request["ID"];
         string title = context.Request.Form["title"];
         string content = context.Request.Form["content"];
         string type = context.Request.Form["type"];
         string sql = " update notice set  title= '" + title + "', content= '" + content + "', type='" + type + "' where id='" + ID + "' ";
         Common comm = new Common();
         comm.ExecuteNonQuery(sql);
         context.Response.Write(success("修改", "C001"));
     }
     catch
     {
         context.Response.Write(failure());
     }
 }

 /// <summary>
 ///  删除
 /// </summary>
 public void Delete(HttpContext context)
 {
     try
     {

         string id = context.Request["ID"];
         Common comm = new Common();
         int count = comm.ExecuteNonQuery("delete from  notice where id in (" + id + ") ");
         context.Response.Write(success());
     }
     catch
     {
         context.Response.Write(failure());
     }
 }

    /// <summary>
    /// 返回成功的json {"statusCode":"200", "message":"操作成功!"}"
    /// </summary>
    /// <returns></returns>
    public string success()
    {
        return "{\"statusCode\":\"200\", \"message\":\"操作成功!\"}";
    }
    /// <summary>
    /// 返回成功的json,并刷新名为navTabId的Tab
    /// </summary>
    /// <param name="str">{"statusCode":"200", "message":"操作成功!{"str的内容"}"</param>
    /// <param name="navTabId">navTabId的名称</param>
    /// <returns></returns>
    public string success(string str, string navTabId)
    {
        return "{\"statusCode\":\"200\", \"message\":\"" + str + "成功!\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"closeCurrent\"}";
    }
    /// <summary>
    /// 返回失败的json {"statusCode":"300", "message":"操作失败!"}"
    /// </summary>
    /// <returns></returns>
    public string failure()
    {
        return "{\"statusCode\":\"300\", \"message\":\"操作失败\"}";
    }
    /// <summary>
    /// 返回失败的json {"statusCode":"300", "message":"操作失败!{"str的内容"}"
    /// </summary>
    /// <param name="str">{"statusCode":"300", "message":"操作失败!{"str的内容"}"</param>
    /// <returns></returns>
    public string failure(string str)
    {
        return "{\"statusCode\":\"300\", \"message\":\"" + str + "操作失败!\"}";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}