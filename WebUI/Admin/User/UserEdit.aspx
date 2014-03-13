<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="WebUI.Admin.User.UserEdit" %>

    <div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/User/UserManage.ashx?method=UserEdit"
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </div>
            <div class="unit">
                <label>
                    用户名：</label>
                     <input type="hidden" name="UID" class="required " value="<%=model.user_id %>" />
                <input type="text" name="UserName" size="30" minlength="2" maxlength="20" 
                    class="required" value="<%=model.user_name %>" /><span class="unit">1-8位中文字符组合。</span>
            </div>
            <div class="unit">
                <label>
                    真实姓名：</label>
                <input type="text" name="RealName" size="30" minlength="2" maxlength="8" class="required"
                    value="<%=model.real_name %>" /><span class="unit">2-8位中文字符组合。</span>
            </div>
            <div class="unit">
                <label>
                    密码：</label>
                <input type="password" name="UserPwd" size="30" readonly="readonly" class="required alphanumeric"
                    value="<%=model.user_pwd %>" />
            </div>
            <div class="unit">
                <label>
                    新密码：</label>
                <input type="password" name="NewUserPwd" size="30" minlength="6" maxlength="16" class="alphanumeric" /><span
                    class="unit">6-16位数字、字母或下划线组合。</span>
            </div>
            <div class="unit">
                <label>
                    所属角色：</label>
                <select name="Role" class="required">
                    <%=GetRole()%>
                </select>
            </div>
            <div class="unit">
                <label>
                    当前状态：</label>
                <select name="State" class="required">
                    <option value="1" <%=model.status==1?"selected=\"selected\"":"" %>>启用</option>
                    <option value="0" <%=model.status==0?"selected=\"selected\"":"" %>>禁用</option>
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
