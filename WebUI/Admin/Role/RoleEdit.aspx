
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="WebUI.Admin.Role.RoleEdit" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Role/RoleManage.ashx?method=RoleEdit&id=<%=getData().Rows[0]["role_id"].ToString()%> "
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </div>
            <div class="unit">
                <label>
                    角色名：</label>
                <input type="text" name="RoleName" size="30" minlength="2" maxlength="20" 
                    class="required" value="<%=getData().Rows[0]["role_name"].ToString()%>" /><span class="unit">1-8位中文字符组合。</span>
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