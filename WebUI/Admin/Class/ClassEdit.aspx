<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassEdit.aspx.cs" Inherits="WebUI.Admin.Class.ClassEdit1" %>

<div class="page">
    <div class="pageContent">
        <form method="post" action="AJAX/Class/ClassManage.ashx?method=Add" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
        <div class="pageFormContent" layouth="56">
            <div class="unit">
                <label>
                    &nbsp;</label>带<span style="color: Red;">*</span>为必填项目，请全部填写！
            </div>
              <input type="hidden" name="ID" class="required " value="<%=getData().Rows[0]["class_no"]%>" />
            <div class="unit">
                <label>
                     班级编号：</label>
                <input type="text" name="class_no" size="30" value="<%=getData().Rows[0]["class_no"].ToString()%>" minlength="2" maxlength="20" class="required" />
                <span class="info">2-20字母、数字、下划线组成</span>
           </div>
                  <div class="unit">
                <label>
                     学院名称：</label>
                <input type="text" name="academy_no" size="30" value="<%=getData().Rows[0]["academy_no"].ToString()%>" minlength="2" maxlength="20" class="required" />
                <span class="info">20个中文字符内</span>
           </div>
      <div class="unit">
                <label>
                     专业：</label>
                <input type="text" name="major" size="30" value="<%=getData().Rows[0]["major"].ToString()%>" minlength="2" maxlength="20" class="required" />
                <span class="info">20个中文字符内</span>
           </div>
           <div class="unit">
                <label>
                     班级人数：</label>
                <input type="text" name="number" size="30" value="<%=getData().Rows[0]["number"].ToString()%>" minlength="2" maxlength="20" class="required" />
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
