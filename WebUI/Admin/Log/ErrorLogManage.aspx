<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorLogManage.aspx.cs" Inherits="WebUI.Admin.Log.ErrorLogManage" %>
<script src="../../JS/Help.js" type="text/javascript"></script>
<form id="pagerForm" method="post" action="Admin/Log/ErrorLogManage.aspx">
	<input type="hidden" name="keyString" value="<%=KeyString %>" />
	<input type="hidden" name="pageNum" value="1" />
	<input type="hidden" name="numPerPage" value="<%=NumPerPage%>" />
	<input type="hidden" name="orderField"    value="<%= orderField %>" />  
    <input type="hidden" name="orderDirection"  value="<%= orderDirection %>" />
 
</form>

<script type="text/javascript">
          
             $(function () {
                var orderField = "<%=orderField %>";
                var orderDirection = "<%=orderDirection %>";
                $(navTab.getCurrentPanel() || $.pdialog.getCurrent()).find("thead [orderField='" + orderField + "']").attr("class", orderDirection).siblings().removeClass();
            });
</script>
 <div class="page">
 	<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" action="Admin/Log/ErrorLogManage.aspx" method="post">
        <div class="searchBar">
            关键字
            <input name="KeyString" size="30" type="text" value="<%=KeyString%>" />
           初始日期
            <input type="text" name="DateStart" class="date" dateFmt="yyyy-MM-dd HH:mm:ss" size="30" readonly="true" value="<%=DateStart%>"/>	
           结束日期	
           <input type="text" name="DateEnd" class="date" size="30" dateFmt="yyyy-MM-dd HH:mm:ss" readonly="true" value="<%=DateEnd%>"/>	
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
            <% if(p[0].ToString() == "")
            {%>
                <li><a class="delete" href="#" onclick="navMenuTodo('../AJAX/Log/LogManage.ashx?method=ErrorLogDelete','log_id','您确定要删除已勾选信息吗?')"><span>删除</span></a></li>
                <li class="line">line</li>
                <% }%>
            </ul>
        </div>
           <table class="table" layouth="133" width="100%" >
			<thead>
				<tr >  
				<th style="width: 4%;" align="center">
               <input id="chkAddAll" align="center" onclick="AllCheck('log_id','chkAddu')" type="checkbox" name="chkAddu" />
                        </th>
				<th style="width: 10%; text-align: center" class="asc">
                            序号
                        </th>
					<th style="width: 20%; text-align: center" orderField="log_content" >错误日志</th>
					<th style="width: 20%; text-align: center" orderField="write_time" >出错时间</th>
					<th style="width: 20%; text-align: center" orderField="log_type" >错误类型</th>							
				</tr>
			</thead>
				<tbody>
	<asp:Repeater ID="Repeater1" runat="server"  >
	<ItemTemplate>
	<tr id="flag" target="sys_log" rel="<%# Eval("log_id") %>"> 
	
      <td align="center">
      <input type="checkbox"  name="log_id" value="<%# Eval("log_id") %>" />
      </td>
	  <td style="text-align: center">
          <%# Convert.ToInt32(Container.ItemIndex) + 1 + (NumPerPage * PageNum - NumPerPage)%>
      </td>
	    <td align="center"><%# Eval("log_content")%></td>
	    <td align="center"><%# Eval("write_time").ToString() %></td>
	    <td align="center"><%# (Eval("log_type") == "0") ? "操作日志" : "错误日志"%></td>
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
