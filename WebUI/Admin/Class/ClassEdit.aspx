<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassEdit.aspx.cs" Inherits="WebUI.Admin.Class.ClassEdit" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Class/ClassManage.ashx?method=Edit&id=<%=getData().Rows[0]["class_id"].ToString()%>"
        class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>号的项目为必选项, 请全部填写
            </div>
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
                    <option value="上学期" <%=Convert.ToString(ds.Tables[0].Rows[0]["CXueQi"])=="上学期"?"selected=\"selected\"":"" %>>
                        上学期</option>
                    <option value="下学期" <%=Convert.ToString(ds.Tables[0].Rows[0]["CXueQi"])=="下学期"?"selected=\"selected\"":"" %>>
                        下学期</option>
                </select>
            </p>--%>
            <div class="unit">
                <label>
                    选择年级：</label>
                <select name="grade">
                    <%=GetData("grade")%>
                </select>
            </div>
             <div class="unit">
                <label>
                    班级编号：</label>
                <input type="hidden" name="CID" size="30" value="<%=getData().Rows[0]["class_id"].ToString()%>"
                    class="required" />
                <input type="text" name="class_id" size="30" maxlength="20" value="<%=getData().Rows[0]["class_id"].ToString()%>"
                    class="required" /><span class="unit">限制20位字符以内。</span>
            </div>
            <div class="unit">
                <label>
                    班级名：</label>
                <input type="hidden" name="CName" size="30" value="<%=getData().Rows[0]["class_name"].ToString()%>"
                    class="required" />
                <input type="text" name="Name" size="30" maxlength="20" value="<%=getData().Rows[0]["class_name"].ToString()%>"
                    class="required" /><span class="unit">限制20位字符以内。</span>
            </div>
            <div class="unit">
                <label>
                    班级人数：</label>
                <input type="text" name="num" size="15" maxlength="5" class="required number" value="<%=getData().Rows[0]["class_num"].ToString()%>" /><span
                    class="unit">只能是数字。</span>
            </div>
            <div class="unit">
                <label>
                    班主任：</label>
                <input type="text" name="mnum" size="30" maxlength="20" class="required" value="<%=getData().Rows[0]["class_teacher"].ToString()%>" /><span
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
