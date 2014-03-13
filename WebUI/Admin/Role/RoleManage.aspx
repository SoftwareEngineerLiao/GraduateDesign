<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="WebUI.Admin.Role.RoleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色管理</title>

    <script src="../../JS/Help.js" type="text/javascript"></script>
</head>
<body>
    <form id="pagerForm" method="post" action="Admin/Role/RoleManage.aspx">
	<input type="hidden" name="keyString" value="<%=KeyString %>" />
	<input type="hidden" name="pageNum" value="1" />
	<input type="hidden" name="numPerPage" value="<%=NumPerPage%>" />
	<input type="hidden" name="orderField"    value="<%= orderField %>" />  
    <input type="hidden" name="orderDirection"  value="<%= orderDirection %>" />
</form>

<script type="text/javascript">
            function dbltable(target, rel) {
                if (target == 'sys_role') {
                    $.pdialog.open("Admin/Role/RoleEdit.aspx?id=" + rel, "pdialogid", "修改", { max: false, mask: false, width: 700, height: 400 });
                }
            }
             $(function () {
                var orderField = "<%=orderField %>";
                var orderDirection = "<%=orderDirection %>";
                $(navTab.getCurrentPanel() || $.pdialog.getCurrent()).find("thead [orderField='" + orderField + "']").attr("class", orderDirection).siblings().removeClass();
            });
</script>
 <div class="page">
 	<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" action="Admin/Role/RoleManage.aspx" method="post">
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
               <%=p[0].ToString() == "" ? "<li><a class=\"add\" href=\"#\" onclick=\"navMenuAddTodo('Admin/Role/RoleAdd.aspx','Add','添加角色',500,300)\"><span>新增角色</span></a></li>" : ""%>
               <%--<li><a class="add" href="Admin/Role/RoleAdd.aspx" target="dialog"  maxable="true" mask="true" minable="true" resizable="true" drawable="true" rel="dlg_add"><span>添加</span></a></li>--%>
                <li class="line">line</li>
                <%=p[2].ToString() == "" ? "<li><a class=\"delete\" href=\"#\" onclick=\"navMenuTodo('../AJAX/Role/RoleManage.ashx?method=RoleDelete','role_id','您确定要删除已勾选信息吗?')\"><span>删除</span></a></li>" : ""%>
                <li class="line">line</li>
                 <% if(p[1].ToString() == "")
                {%>
                <li><a class="edit" href="#" onclick="navMenuEditTodo('Admin/Role/RoleEdit.aspx','role_id','Edit','修改',700, 400)"><span>修改</span></a></li>
                <li class="line">line</li>
                <% }%>
            </ul>
        </div>
           <table class="table" layouth="133" width="100%" >
			<thead>
				<tr >  
				<th style="width: 5%;"  align="center">
               <input id="chkAddAll" align="center" onclick="AllCheck('role_id','chkAddr')" type="checkbox" name="chkAddr" />
                        </th>
				<th style="width: 5%; text-align: center" >
                            序号
                        </th>
					<th width="30%" align="center" orderField="role_name" class="asc" >角色名</th>
					<th width="20%" align="center" orderField="role_time" >创建时间</th>
					 <% if (p[1].ToString() == "" && p[3].ToString() == "" && p[4].ToString() == "")
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
	target="sys_role" 
	<% }%>
	rel="<%# Eval("role_id") %>"> 
	
      <td align="center">
      <input type="checkbox"  name="role_id" value="<%# Eval("role_id") %>" />
      </td>
	  <td style="text-align: center">
          <%# Convert.ToInt32(Container.ItemIndex) + 1 + (NumPerPage * PageNum - NumPerPage)%>
      </td>
	    <td align="center"><%# Eval("role_name")%></td>
	    <td align="center"><%# Eval("role_time").ToString()%></td>
	    <% if (p[1].ToString() == "" && p[3].ToString() == "" && p[4].ToString() == "")
     {%>
	 <td align="center">
	 <% if(p[1].ToString() == "")
     {%>
        <a href="#"  onclick="navMenuEditTodoid('Admin/Role/RoleEdit.aspx','<%# Eval("role_id") %>','Edit','修改角色',550,200)">修改</a>
     <% }%>
     <% if(p[3].ToString() == "")
     {%>
        <a href="#" onclick="navMenuEditTodoid('Admin/Role/RoleShow.aspx','<%# Eval("role_id") %>','RoleShow','查看权限',700,500)">查看权限</a>
         <% }%>
         <% if(p[4].ToString() == "")
          {%>
        <a href="#" onclick="navMenuEditTodoid('Admin/Role/RoleCompetence.aspx','<%# Eval("role_id") %>','RoleCompetence','分配权限',700,500)">分配权限</a>
        <% }%>
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
</body>
</html>
