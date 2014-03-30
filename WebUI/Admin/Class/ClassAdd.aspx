<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassAdd.aspx.cs" Inherits="WebUI.Admin.Class.ClassAdd1" %>




<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Class/ClassManage.ashx?method=Add" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;带</label><span style="color: Red;">*</span>为必填项目，请全部填写
            </div>
           <div class="unit">
                <label>
                    字段名：</label>
                <input type="text" name="class_no" size="30" minlength="2" maxlength="20" class="required" />
                <span class="info">2-20数字 字母 下划线组成</span>
           </div>
            <div class="unit">
                <label>
                    字段名:</label>
                <input type="text" name="academy_name" size="30" minlength="2" maxlength="8" class="required" />
                <span class="inputInfo">2-8中文字符组成</span>
            </div>
            <div class="unit">
                <label>
                    字段名:</label>
                <input type="password" name="major" size="30" minlength="6" maxlength="16" class="required alphanumeric" />
                <span class="inputInfo">6-16数字 字母 下划线组成</span>
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
