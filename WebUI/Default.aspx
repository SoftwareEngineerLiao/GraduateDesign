<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    
    <title>后台管理界面</title>
    <link href="themes/default/style.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="themes/css/core.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="themes/css/print.css" rel="stylesheet" type="text/css" media="print"/>
   <link href="themes/css/dwzextends.css" rel="stylesheet" type="text/css" />

    <script src="DWZ/js/speedup.js" type="text/javascript"></script>
    <script src="DWZ/js/jquery-1.7.2.js" type="text/javascript"></script>
   

    <script src="DWZ/js/dwz.theme.js" type="text/javascript"></script>

    <script src="DWZ/js/jquery.cookie.js" type="text/javascript"></script>
    <script src="DWZ/js/jquery.validate.js" type="text/javascript"></script>
    <script src="DWZ/js/jquery.bgiframe.js" type="text/javascript"></script>
   
    <script src="DWZ/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="DWZ/js/dwz.switchEnv.js" type="text/javascript"></script>
    
    <script src="DWZ/js/jquery.validate.min.js" type="text/javascript"></script> 
 <script src="DWZ/js/dwz.min.js" type="text/javascript"></script>
 
    <script src="DWZ/xheditor/xheditor-1.2.1.min.js" type="text/javascript"></script>
    <script src="DWZ/xheditor/xheditor_lang/zh-cn.js" type="text/javascript"></script>
    
    <script src="DWZ/js/dwz.regional.zh.js" type="text/javascript"></script>
    <script src="DWZ/uploadify/scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <script src="DWZ/uploadify/scripts/jquery.uploadify.js" type="text/javascript"></script>
    <script src="JS/Help.js" type="text/javascript"></script>

    <script src="DWZ/chart/raphael.js" type="text/javascript"></script>
    <script src="DWZ/chart/g.bar.js" type="text/javascript"></script>
    <script src="DWZ/chart/g.dot.js" type="text/javascript"></script>
    <script src="DWZ/chart/g.line.js" type="text/javascript"></script>
    <script src="DWZ/chart/g.pie.js" type="text/javascript"></script>
    <script src="DWZ/chart/g.raphael.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function(){
	        DWZ.init("../DWZ/dwz.frag.xml", {
		        //loginUrl:"login_dialog.html", loginTitle:"登录",	// 弹出登录对话框
		        loginUrl:"Login.aspx",	// 跳到登录页面
		        debug:false,	// 调试模式 【true|false】
		        callback:function(){
			        initEnv();
			        $("#themeList").theme({themeBase:"themes"});
        			
		        }
	        });
        });
     
    </script>
</head>

<body scroll="no">
	<div id="layout">
		<div id="header">
			<div class="headerNav">
		
				<ul class="nav">
				    <li><a href="../Index.aspx" target="_Blank"  rel="jp">教育均衡首页</a></li>
					<li><a href="Admin/User/PersonalSetting.aspx" target="dialog"  width="550" height="300" rel="ps">设置</a></li>
					 <li><a id="exit" href="#">退出</a></li>
				</ul>
				<ul class="themeList" id="themeList">
					<li theme="default" ><div class="selected">蓝色</div></li>
					<li theme="green"><div>绿色</div></li>
					<li theme="purple"><div>紫色</div></li>
					<li theme="silver"><div>银色</div></li>
					<li theme="azure"><div >天蓝</div></li>
				</ul>
			</div>
	
		</div>
		<div id="leftside">
			<div id="sidebar_s">
				<div class="collapse">
					<div class="toggleCollapse"><div></div></div>
				</div>
			</div>
			<div id="sidebar">
				<div class="toggleCollapse"><h2>主菜单</h2><div>收缩</div></div>

				<div class="accordion" fillSpace="sidebar">
				 <%=GetLeftList()%>
				</div>

			</div>
		</div>
		<div id="container">
			<div id="navTab" class="tabsPage">
				<div class="tabsPageHeader">
					<div class="tabsPageHeaderContent"><!-- 显示左右控制时添加 class="tabsPageHeaderMargin" -->
						<ul class="navTab-tab">
							<li tabid="main" class="main"><a href="javascript:void(0)"><span><span class="home_icon">我的主页</span></span></a></li>
						</ul>
					</div>
					<div class="tabsLeft">left</div><!-- 禁用只需要添加一个样式 class="tabsLeft tabsLeftDisabled" -->
					<div class="tabsRight">right</div><!-- 禁用只需要添加一个样式 class="tabsRight tabsRightDisabled" -->
					<div class="tabsMore">more</div>
				</div>
				<ul class="tabsMoreList">
					<li><a href="javascript:void(0)">我的主页</a></li>
				</ul>
			
				<div class="navTab-panel tabsPageContent layoutBox">
				<div>
						<div class="accountInfo">
							
                            <div class="right">
                                <p>
                                </p>
                                
                            </div>
                            
                            
                        </div>
 <div class="pageFormContent" layouth="80">
      <p>
      IP地址：<%Response.Write(Request.ServerVariables["LOCAl_ADDR"]); %>
       </p>
       <p>
        IE版本：<%Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Version Vector"); Response.Write(key.GetValue("IE", "未检测到").ToString()); %></p>
       
       <div class="divider">
     </div>
    <pre style="margin: 5px; line-height: 1.4em">
<span style="color: Green;">为了有更好的体验效果请使用IE8+或者chrome等浏览器打开，如有异常，请及时联系网站管理人员。</span>
</pre>
        </div>
    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
        CopyRight&copy;<script language="JavaScript" type="text/javascript">
                          <!--
                           var today = new Date();
                           var thisYear = today.getFullYear();
                           window.document.write(thisYear);
                          -->
                          </script>
    </div>
    
    <div id='progressBar' class='progressBar'>
        数据加载中，请稍等...</div>
</body>
</html>