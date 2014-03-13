<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalSetting.aspx.cs" Inherits="WebUI.Admin.User.PersonalSetting" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/User/UserManage.ashx?method=PersonalSettings&ID=<%=user.user_id %>"
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    登录名：</label>
                <input type="text" name="UserName" size="30" minlength="2" maxlength="20" readonly="readonly"
                    class="required alphanumeric" value="<%=user.user_name %>" />
            </div>
            <div class="unit">
                <label>
                    真实姓名：</label>
                <input type="text" name="RealName" readonly="readonly" size="30" minlength="2" maxlength="8"
                    class="required" value="<%=user.real_name %>" />
            </div>
            <div class="unit">
                <label>
                    密码：</label>
                <input type="password" name="UserPwd" size="30" readonly="readonly" class="required alphanumeric"
                    value="<%=user.user_pwd %>" />
            </div>
            <div class="unit">
                <label>
                    新密码：</label>
                <input type="password" name="NewUserPwd" size="30" minlength="6" maxlength="16" class="alphanumeric" />
            </div>
           
            <div class="unit">
                <label>
                    所属角色：</label>
                <input type="text" name="RealName" readonly="readonly" size="30" minlength="2" maxlength="8"
                    class="required" value="<%=GetRole() %>" />
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
