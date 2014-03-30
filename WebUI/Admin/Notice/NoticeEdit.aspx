<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeEdit.aspx.cs" Inherits="WebUI.Admin.Class.ClassEdit" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Notice/NoticeManage.ashx?method=Edit" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>为必填项目，请全部填写！
            </div>
            <input type="hidden" name="ID" class="required " value="<%=getData().Rows[0]["id"]%>" />
            <div class="unit">
                <label>
                     标题：</label>
                <input type="text" name="title" size="50" value="<%=getData().Rows[0]["title"].ToString()%>" minlength="2" maxlength="50" class="required" />
                <span class="info">50字内</span>
           </div>
                 <div class="unit">
                <label style="color: #0066FF">
                  内容：</label>
                  <textarea name="content" class="required editor"  rows="25" cols="95"
                  upLinkUrl="../DWZ/xheditor/upload.aspx?immediate=1" upLinkExt="zip,rar,txt,doc,docx,xls,xlsx,ppt,pptx" 
								upImgUrl="../DWZ/xheditor/upload.aspx?immediate=1" upImgExt="jpg,jpeg,gif,png" 
								upFlashUrl="../DWZ/xheditor/upload.aspx?immediate=1" upFlashExt="swf"
								upMediaUrl="../DWZ/xheditor/upload.aspx?immediate=1" upMediaExt="mov,avi,wmv">
								<%=getData().Rows[0]["content"].ToString()%></textarea>
     
            </div>
            <div class="unit">
                <label>
                    通知类型：</label>
                <select name="type" class="required">
                    <option value="<%=getData().Rows[0]["type"].ToString()%>" ><%=getData().Rows[0]["type"].ToString()%></option>
                   <option value="通知公告">通知公告</option>
                   <option value="招聘信息">招聘信息</option>
                </select>
                </div>
        </div>
        <div class="formBar">
            <ul>
                <li>
                    <div class="buttonActive">
                        <div class="buttonContent">
                            <button type="submit">
                                提交</button></div>
                    </div>
                </li>
                <li>
                    <div class="button">
                        <div class="buttonContent">
                            <button type="button" class="close">
                                取消</button></div>
                    </div>
                </li>
            </ul>
        </div>
        </form>
    </div>
</div>