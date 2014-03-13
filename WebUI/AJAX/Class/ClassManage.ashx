<%@ WebHandler Language="C#"  Class="ClassManage" %>

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

public class ClassManage : IHttpHandler, IRequiresSessionState
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
    /// 添加
    /// </summary>
    public void Add(HttpContext context)
    {
        try
        {
            string class_id = context.Request.Form["ClassID"];
            if (help.ChecUser(class_id, "class", "class_id"))
            {
                context.Response.Write(failure("班级编号重复,"));
                return;
            }
            string txt_class_id = context.Request.Form["ClassID"];
            string txt_grade = context.Request.Form["year"];
            string txt_class_name = context.Request.Form["Name"];
            string txt_class_num = context.Request.Form["num"];
            string txt_class_teacher = context.Request.Form["mnum"];

            string sql = "insert into class( class_id,grade,class_name,class_num,class_teacher) Values('" + txt_class_id + "','" + txt_grade + "','" + txt_class_name + "','" + txt_class_num + "','" + txt_class_teacher + "')";
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
    ///  删除
    /// </summary>
    public void Delete(HttpContext context)
    {
        try
        {

            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  class where class_id in (" + id + ") ");
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
            string txt_class_id = context.Request.Form["class_id"];
            string txt_grade = context.Request.Form["grade"];
            string txt_class_name = context.Request.Form["Name"];
            int txt_class_num = Convert.ToInt32(context.Request.Form["num"]);
            string txt_class_teacher = context.Request.Form["mnum"];
            string sql = "update class  set class_id = '" + txt_class_id + "', class_num = '" + txt_class_num + "', grade = '" + txt_grade + "',class_name = '" + txt_class_name + "',class_teacher = '" + txt_class_teacher + "'where class_id = '" + ID + "' ";
            comm.ExecuteNonQuery(sql);
            context.Response.Write(success("修改", "C001"));
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