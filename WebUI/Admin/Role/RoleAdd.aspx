<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="WebUI.Admin.RoleAdd" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Role/RoleManage.ashx?method=RoleAdd" class="pageForm required-validate"
        onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </div>
            <div class="unit">
                <label>
                    角色名：</label>
                <input type="text" name="RName" size="30" maxlength="20" class="required" /><span
                    class="unit">20位字符以内</span>
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

