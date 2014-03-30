<%@ WebHandler Language="C#"  Class="AcademyManage" %>

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

public class AcademyManage : IHttpHandler, IRequiresSessionState
{
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
    /// 添加
    /// </summary>
    public void Add(HttpContext context)
    {
        AcademyBusi academyBusi = new AcademyBusi();
        try
        {
            string txt_academy_no = context.Request.Form["academy_no"];
            if (academyBusi.ChecAcademy(txt_academy_no, "academy", "academy_no"))
            {
                context.Response.Write(failure("学院编号重复，请重新填写！"));
                return;
            }
            string txt_academy_name = context.Request.Form["academy_name"];
            
            string sql = "insert into academy(academy_no,academy_name) Values('" + txt_academy_no + "','" + txt_academy_name + "') ";
            Common comm = new Common();
            comm.ExecuteNonQuery(sql);
            context.Response.Write(success("添加", "X001"));     
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

            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  academy where academy_no in (" + id + ") ");
            context.Response.Write(success());
        }
        catch
        {
            context.Response.Write(failure());
        }
    }

    /// <summary>
    /// 修改
    /// </summary>
    public void Edit(HttpContext context)
    {
        try
        {
            string ID = context.Request["ID"];
            Common comm = new Common();
            string txt_academy_no = context.Request.Form["txt_academy_no"];
            string txt_academy_name = context.Request.Form["txt_academy_name"];
            string sql = "update academy  set academy_name = '" + txt_academy_name + "',academy_no = '" + txt_academy_no + "'  where academy_no = '" + ID + "' ";
            comm.ExecuteNonQuery(sql);
            context.Response.Write(success("增加", "X001"));
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
