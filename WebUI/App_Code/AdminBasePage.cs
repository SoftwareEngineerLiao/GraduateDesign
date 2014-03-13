using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///AdminBasePage 的摘要说明
/// </summary>
public class AdminBasePage : System.Web.UI.Page
{
    public AdminBasePage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 重写判断Session
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        if (Session["user"] == null)
        {
           Response.Write("<script language='javascript'>SessionOut();</script>");
            return;
        }
    }
}
