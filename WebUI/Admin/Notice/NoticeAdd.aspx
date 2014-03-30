<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeAdd.aspx.cs" Inherits="WebUI.Admin.Class.ClassAdd" %>
<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Notice/NoticeManage.ashx?method=Add" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;带<span style="color: Red;" class="unit">*</span>为必填项目</label>
            </div>
           <div class="unit">
                <label>
                    标题：
                <input type="text" name="title" size="60" minlength="2" maxlength="50" class="required" />
                </label><span class="info">2-50字</span>
           </div>
            <div class="unit">
                <label>
                    内容:</label>
            
                <textarea name="content" class="required editor"  rows="10" cols="93"
                  upLinkUrl="../DWZ/xheditor/upload.aspx?immediate=1" upLinkExt="zip,rar,txt,doc,docx,xls,xlsx,ppt,pptx" 
								upImgUrl="../DWZ/xheditor/upload.aspx?immediate=1" upImgExt="jpg,jpeg,gif,png" 
								upFlashUrl="../DWZ/xheditor/upload.aspx?immediate=1" upFlashExt="swf"
								upMediaUrl="../DWZ/xheditor/upload.aspx?immediate=1" upMediaExt="mov,avi,wmv">
								</textarea>
            </div>
            <div class="unit">
                <label>
                    通知类型:</label>
               <select name="type" class="required">
                    <option value="通知公告" >通知公告</option>
                   <option value="招聘信息" >招聘信息</option>
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