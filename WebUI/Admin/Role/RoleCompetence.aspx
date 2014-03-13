<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleCompetence.aspx.cs" Inherits="WebUI.Admin.RoleCompetence" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Role/RoleManage.ashx?method=RCompetence"
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <input type="hidden" name="RID" size="30" maxlength="20" class="required" value="<%=roleEntity.role_id %>" />
            <input type="hidden" name="RName" size="30" maxlength="20" class="required" value="<%=roleEntity.role_name %>" />
            <p>
                <label>
                    &nbsp;</label><span style="color: Red;">已勾选表示已有此权限,未勾选表示没有权限</span></p>
            <%=GetListRole()%>
        </div>
        <div class="formBar">
            <ul>
                <li>
                    <div class="button">
                        <div class="buttonContent">
                            <button type="button" onclick="AllCheck('pid')">
                                全选/反选</button></div>
                    </div>
                </li>
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
