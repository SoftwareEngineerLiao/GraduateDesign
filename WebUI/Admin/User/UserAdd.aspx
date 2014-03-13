<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="WebUI.Admin.User.UserAdd" %>

<div class="page" runat="server">
    <div class="pageContent" runat="server">
        <form method="post" action="AJAX/User/UserManage.ashx?method=UserAdd" class="pageForm required-validate"
        onsubmit="return validateCallback(this, dialogAjaxDone);" runat="server">
        <div class="pageFormContent" layouth="56" runat="server">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </div>
            <div class="unit">
                <label>
                    用户名：</label>
                <input type="text" name="user_name" size="30" maxlength="20" class="required" /><span
                    class="unit">20位字符以内</span>
            </div>
            <div class="unit">
                <label>
                    真实姓名：</label>
                <input type="text" name="real_name" size="30" maxlength="20" class="required" /><span
                    class="unit">20位字符以内</span>
            </div>
            <div class="unit" runat="Server">
                <label>
                    角色名：</label>
                <select name="Role" class="required">
                    <%=GetRole()%>
                </select>
            </div>
            <div class="unit">
                <label>
                    密码：</label>
                <input type="password" name="pwd" size="30" maxlength="20" class="required alphanumeric textInput" /><span
                    class="unit">2-20位字符、数字、下划线</span>
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