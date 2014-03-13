<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassAdd.aspx.cs" Inherits="WebUI.Admin.Class.ClassAdd" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Class/ClassManage.ashx?method=Add"
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <p>
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </p>
            <%--<p>
                <label>
                    选择学年：</label>
                <select name="SchoolYear">
                    <%=GetData("SchoolYear")%>
                </select>
            </p>
            <p>
                <label>
                    选择学期：</label>
                <select name="term">
                    <option value="上学期">上学期</option>
                    <option value="下学期">下学期</option>
                </select>
            </p>--%>
            <div class="unit">
                <label>
                    选择年级：</label>
                <select name="year">
                    <%=GetData("Class")%>
                </select>
            </div>
            <div class="unit">
                <label>
                    班级编号：</label>
                <input type="text" name="ClassID" size="30" maxlength="20" class="required" alt="请输入班级名称" /><span
                    class="unit">限制20位字符以内。</span>
            </div>
            <div class="unit">
                <label>
                    班级名：</label>
                <input type="text" name="Name" size="30" maxlength="20" class="required" alt="请输入班级名称" /><span
                    class="unit">限制20位字符以内。</span>
            </div>
              <div class="unit">
                <label>
                    班级人数：</label>
                <input type="text" name="num" size="15" maxlength="50" class="required number" /><span
                    class="unit">只能是数字。</span>
            </div>
              <div class="unit">
                <label>
                    班主任：</label>
                <input type="text" name="mnum" size="30"  maxlength="20" class="required" alt="请输入班主任姓名" /><span
                    class="unit"></span>
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