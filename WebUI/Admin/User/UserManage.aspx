﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="WebUI.Admin.User.UserManage" %>

<script src="../../JS/Help.js" type="text/javascript"></script>
<form id="pagerForm" method="post" action="Admin/User/UserManage.aspx">
	<input type="hidden" name="keyString" value="<%=KeyString %>" />
	<input type="hidden" name="pageNum" value="1" />
	<input type="hidden" name="numPerPage" value="<%=NumPerPage%>" />
	<input type="hidden" name="orderField"    value="<%= orderField %>" />  
    <input type="hidden" name="orderDirection"  value="<%= orderDirection %>" />
 
</form>
<script type="text/javascript">
    function dbltable(target, rel) {
        if (target == 'user') {
            $.pdialog.open("Admin/User/UserEdit.aspx?id=" + rel, "pdialogid", "修改", { max: false, mask: false, width: 700, height: 400 });
        }
    }
    $(function() {
        var orderField = "<%=orderField %>";
        var orderDirection = "<%=orderDirection %>";
        $(navTab.getCurrentPanel() || $.pdialog.getCurrent()).find("thead [orderField='" + orderField + "']").attr("class", orderDirection).siblings().removeClass();
    });
</script>
 <div class="page">
 	<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" action="Admin/User/UserManage.aspx" method="post">
        <div class="searchBar">
            关键字
            <input name="keyString" size="30" type="text" value="<%=KeyString%>" />
            <div class="subBar">
                <ul>
                    <li>
                        <div class="buttonActive">
                            <div class="buttonContent">
                                <button type="submit">
                                    检索</button></div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        </form>
	</div>
     <div class="pageContent">
        <div class="panelBar">
            <ul class="toolBar">
               <%--<li><a class="add" href="#" onclick="navMenuAddTodo('Admin/AddUser.aspx','Add','添加',700,500)"><span>添加</span></a></li>--%>
               <% if(p[0].ToString() == "")
                {%>
               <li><a class="add" href="Admin/User/UserAdd.aspx" target="dialog"   rel="dlg_add"><span>添加用户</span></a></li>
                <li class="line">line</li>
                <% }%>
                <% if(p[2].ToString() == "")
                {%>
                <li><a class="delete" href="#" onclick="navMenuTodo('../AJAX/User/UserManage.ashx?method=UserDelete','user_id','您确定要删除已勾选信息吗?')"><span>删除</span></a></li>
                <li class="line">line</li>
                <% }%>
                <% if(p[1].ToString() == "")
                {%>
                <li><a class="edit" href="#" onclick="navMenuEditTodo('Admin/User/UserEdit.aspx','user_id','Edit','修改',700, 400)"><span>修改</span></a></li>
                <li class="line">line</li>
                <% }%>
            </ul>
        </div>
           <table class="table" layouth="133" width="100%" >
			<thead>
				<tr >  
				<th style="width: 5%;"  align="center">
               <input id="chkAddAll" align="center" onclick="AllCheck('user_id','chkAddu')" type="checkbox" name="chkAddu" />
                        </th>
				<th style="width: 5%; text-align: center" >
                            序号
                        </th>
					<th width="30%" align="center" orderField="user_name" class="asc" >用户名</th>
					<th width="30%" align="center" orderField="role_name" class="asc" >角色名</th>
					
					<% if(p[1].ToString() == "")
                {%>
				   <th style="width: 40%;" align="center">操作</th>		
				   <% }%> 						
				</tr>
			</thead>
				<tbody>
	<asp:Repeater ID="Repeater1" runat="server"  >
	<ItemTemplate>
	<tr id="flag"  
	<% if(p[1].ToString() == "")
                {%>
                target="user" 
                <% }%> 
                rel="<%# Eval("user_id") %>"> 
	
      <td align="center">
      <input type="checkbox"  name="user_id" value="<%# Eval("user_id") %>" />
      </td>
	  <td style="text-align: center">
          <%# Convert.ToInt32(Container.ItemIndex) + 1 + (NumPerPage * PageNum - NumPerPage)%>
      </td>
	    <td align="center"><%# Eval("user_name")%></td>
	    <td align="center"><%# Eval("role_name")%></td>

	 <% if(p[1].ToString() == "")
                {%>
         <td align="center">
        <a href="#" title="修改" class="btnEdit" onclick="navMenuEditTodoid('Admin/User/UserEdit.aspx','<%# Eval("user_id") %>','Edit','修改',700,400)" >修改</a>
        </td>
        <% }%>
    
	</tr>
	</ItemTemplate>
	<FooterTemplate>
       <tr id="tr1" runat="server" Visible="<%# 0 == Repeater1.Items.Count %>"  >
           <td colspan="8" rowspan="2" style="color:Red; text-align:center; font-weight:bold; height:60px;">对不起，没有您要查找的数据！</td>
             </tr>
          </FooterTemplate>
     </asp:Repeater>

	</tbody>
		</table>
        <div class="panelBar">
            <div class="pages">
                <span>显示</span>
               
                <select  name="numPerPage" onchange="navTabPageBreak({numPerPage:this.value})">
                <option value="<%=NumPerPage%>"><%=NumPerPage%></option>
                    <option value="20">20</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                    <option value="200">200</option>
                </select>
                <span>条，总共<%=TotalCount%>条，每页<%=NumPerPage%>条，当前第<%=PageNum%>页</span>
            </div>
         <div class="pagination" targettype="navTab" totalcount="<%=TotalCount%>" numperpage="<%=NumPerPage%>" pagenumshown="<%=PageNumShown%>" currentpage="<%=PageNum%>"></div>
            </div>
             
        </div>
    </div>