<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcademyEdit.aspx.cs" Inherits="WebUI.Admin.Academy.AcademyEdit" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Academy/AcademyManage.ashx?method=Edit" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>为必填项目，请全部填写！
            </div>
            <input type="hidden" name="ID" class="required " value="<%=getData().Rows[0]["academy_no"]%>" />
            <div class="unit">
                <label>
                     学院编号：</label>
                <input type="text" name="txt_academy_no" size="30" value="<%=getData().Rows[0]["academy_no"].ToString()%>" minlength="2" maxlength="20" class="required" />
                <span class="info">2-20字母、数字、下划线组成</span>
           </div>
                  <div class="unit">
                <label>
                     学院名称：</label>
                <input type="text" name="txt_academy_name" size="30" value="<%=getData().Rows[0]["academy_name"].ToString()%>" minlength="2" maxlength="20" class="required" />
                <span class="info">20个中文字符内</span>
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
