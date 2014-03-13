<%@ WebHandler Language="C#"  Class="RoleManage" %>

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

public class RoleManage : IHttpHandler, IRequiresSessionState
{
    Help help = new Help();
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "application/json";
        context.Response.ContentType = "text/plain";
        
        string method = context.Request["method"];
        switch (method)
        {
            case "RoleAdd":
                RoleAdd(context);
                break;
            case "RoleDelete":
                RoleDelete(context);
                break;
            case "RoleEdit":
                RoleEdit(context);
                break;
            case "RCompetence":
                RCompetence(context);
                break;
        }
    }

    /// <summary>
    ///  创建
    /// </summary>
    public void RoleAdd(HttpContext context)
    {
        try
        {
            RoleEntity model = new RoleEntity();
            model.role_name = context.Request.Form["RName"];
            if (help.ChecUser(model.role_name, "role", "role_name"))
            {
                context.Response.Write(failure("角色名重复,"));
                return;
            }
            RoleDAL role = new RoleDAL();
            model.role_time = DateTime.Now;
            model.rights_code = "";
            role.InsertRoleDAL(model);
            help.SysWriteLog("创建新角色：" + model.role_name, 1);
            context.Response.Write(success("角色创建", "R000"));
        }
        catch (Exception e)
        {
            help.SysWriteLog("创建角色出错：" + e.Message, 0);
            context.Response.Write(failure());
        }
    }

    /// <summary>
    ///  删除
    /// </summary>
    public void RoleDelete(HttpContext context)
    {
        try
        {
            string id = context.Request["id"];
            Common comm = new Common();
            int count = comm.ExecuteNonQuery("delete from  role where role_id in (" + id + ") ");
            help.SysWriteLog("删除角色" , 1);
            context.Response.Write(success());
        }
        catch
        {
            help.SysWriteLog("删除角色出错" , 1);
            context.Response.Write(failure());
        }
    }

    /// <summary>
    ///  修改
    /// </summary>
    public void RoleEdit(HttpContext context)
    {
        try
        {
            string ID = context.Request["id"];
            Common comm = new Common();
            string roleName = context.Request.Form["RoleName"];//Form获取值是根据name="RoleName"
            String time = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = " update role set role_name= '" + roleName + "', role_time='"+ time +"' where role_id='" + ID + "' ";
            comm.ExecuteNonQuery(sql);
            context.Response.Write(success("修改", "R000"));
            help.SysWriteLog("修改角色", 1);
        }
        catch
        {
            help.SysWriteLog("修改角色出错", 1);
            context.Response.Write(failure());
        }
    }

    /// <summary>
    ///  权限分配
    /// </summary>
    public void RCompetence(HttpContext context)
    {
        Help help = new Help();
        try
        {
           
            RoleEntity roleModel = new RoleEntity();
            
            RoleDAL roleDAL = new RoleDAL();


            roleModel.rights_code = context.Request.Form["pid"];
            roleModel.role_id = Convert.ToInt32(context.Request.Form["RID"]);
            roleModel.role_name = context.Request.Form["RName"];
            roleModel.role_time = DateTime.Now;

            roleDAL.UpdateRoleDAL(roleModel);
            help.SysWriteLog("给" + roleModel.role_name + "角色分配了权限", 1);
            context.Response.Write(success("权限分配", "R000"));
        }
        catch (Exception e)
        {
            help.SysWriteLog("Ajax_Role.ashx角色权限分配出错：" + e.Message, 0);
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
