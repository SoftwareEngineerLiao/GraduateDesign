jQuery(function($) {
    var username = $("#username");
    var pwd = $("#pwd");

    ShowCookie();
    $("#Login").click(function() {
        saveCookie(username.val())

        $.post("AJAX/User/Login.ashx?method=AdminLogin", {username: username.val(), pwd: pwd.val()},
		        function(data) {
		            if (data.result == 'ok') {

		                top.location.href = "Default.aspx";
		            }
		            else {
		                alert(data.result);
		                return false;
		            }

		        }, "json");
    });

    $("#favorite").click(function() {
        AddFavorite(document.title);
    });


    $("#home").click(function() {
        SetHome(this, window.location);
    });

});

function jumpUrl(url) {

    document.getElementById("check_code").src = url;
}

function AddFavorite(sTitle) {
    try {
        window.external.addFavorite(window.location, sTitle);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(sTitle, window.location, "");
        }
        catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}

function SetHome(obj, vrl) {
    try {
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        }
    }
}


function saveCookie(name)//保存
{
    var num = jQuery("[name='check']:checked").length;
    var expires = new Date();
    expires.setTime(expires.getTime() + 3 * 30 * 24 * 60 * 60 * 1000);
    if (num != 1)
        name = "";

    var str = 'name=' + name + ';expires=' + expires.toGMTString();
    document.cookie = str;
}

function AllCheck(id) {
    var $check = $("[name='" + id + "']");
    $check.each(function() {
        $(this).attr("checked", 'true');
    });
}

//读取，在读页面时就得读取
function ShowCookie()//保存
{
    var cookieString = document.cookie;
    var cookieName = "name";
    var users = $("#username");
    var start = cookieString.indexOf(cookieName + '=');

    if (start == -1) {
        users.val("");
    }
    else {
        start += cookieName.length + 1;
        var end = cookieString.indexOf(';', start);

        if (end == -1) {
            AllCheck("check");
            users.val(cookieString.substring(start));
        }
        else {
            AllCheck("check");
            users.val(cookieString.substring(start, end));
        }
    }
}
