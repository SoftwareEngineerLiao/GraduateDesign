<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title></title>
    <link href="themes/css/login.css" rel="stylesheet" type="text/css" />

    <script src="JS/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="JS/Login.js" type="text/javascript"></script>

</head>
<body>
    <div id="login">
        <div id="login_header">
            <h1 class="login_logo">
                <a href="#">
                    <img src="themes/default/images/login_logo.gif" /></a>
            </h1>
            <div class="login_headerContent">
                <div class="navList">
                    <ul>
                        <li><a id="home" href="#">设为首页</a></li>
                        <li><a id="favorite" href="#">加入收藏</a></li> 
                    </ul>
                </div>
                <h1 class="login_title">
                    <img src="themes/default/images/login_title.png" /></h1>
            </div>
        </div>
        <div id="login_content">
            <div class="loginForm">
                <p>
                    <label>
                        帐号：</label>
                    <input type="text" id="username" size="16" class="login_input" />
                </p>
                <p>
                    <label>
                        密码：</label>
                    <input type="password" id="pwd" size="16" class="login_input"  />
                </p>
                <p>
                    <label>
                        &nbsp;
                    </label>
                    <input type="checkbox" id="check" name="check" checked="checked" />记住用户名
                </p>
                <div class="login_bar">
                    <input class="sub" id="Login" type="submit" value=" " />
                </div>
            </div>
            <div class="login_banner" style="margin-left: -2px;">
                <img src="themes/default/images/login_banner.jpg" /></div>
            <div class="login_main">
                <div class="login_inner">
                </div>
            </div>
        </div>
        <div id="login_footer">
             CopyRight&copy;<script language="JavaScript" type="text/javascript">
                          <!--
                           var today = new Date();
                           var thisYear = today.getFullYear();
                           window.document.write(thisYear);
                          -->
                          </script> 协同创新 版权所有
        </div>
    </div>
</body>
</html>
