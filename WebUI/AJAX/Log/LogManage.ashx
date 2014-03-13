<%@ WebHandler Language="C#"  Class="LogManage" %>

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

public class LogManage : IHttpHandler, IRequiresSessionState
{
    Help help = new Help();
    public void ProcessRequest(HttpContext context)
    {   
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";

        string method = context.Request["method"];
        switch (method)
        {

            case "OperateLogDelete":
                OperateLogDelete(context);
                break;
            case "ErrorLogDelete":
                ErrorLogDelete(context);
                break;
        }
    }

    /// <summary>
    ///  删除
    /// </summary>
    public void OperateLogDelete(HttpContext context)
    {
        try
        {
            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  log where log_id in (" + id + ") and log_type='1' ");
            help.SysWriteLog("删除操作日志" , 0);
            context.Response.Write(success());
        }
        catch (Exception e)
        {
            help.SysWriteLog("删除操作日志失败：" + e.Message, 0);
            context.Response.Write(failure());
        }
    }

    public void ErrorLogDelete(HttpContext context)
    {
        try
        {
            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  log where log_id in (" + id + ") and log_type='0'");
            help.SysWriteLog("删除错误日志" , 0);
            context.Response.Write(success());
        }
        catch (Exception e)
        {
            help.SysWriteLog("删除错误日志失败：" + e.Message, 0);
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
        return "{\"statusCode\":\"300\", \"message\":\"操作失败\"}";
    }
    /// <summary>
    /// 失败的json {"statusCode":"300", "message":"操作失败!{str的内容}"}"
    /// </summary>
    /// <param name="str">{"statusCode":"300", "message":"操作失败!{str的内容}"}"</param>
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
