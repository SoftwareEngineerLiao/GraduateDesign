﻿jQuery(function($) {
    $("#exit").click(function() {
        alertMsg.confirm('您确认需要退出系统吗？', {
            okCall: function() {
                window.location = "Login.aspx";
                return false;
            }
        });
    });

});

//pjd 点击连接新增navtable
function navMenuEditTodoid(url, id, rel, title, width, height)
{
  if (width != null && height != null) {
            $.pdialog.open(url + "?id=" + id, rel, title, { width: width, height: height });
        }
        else
            $.pdialog.open(url + "?id=" + id, rel, title, { width: 500, height: 400 });
}


function SessionOut() {
    alertMsg.error('您登录已超时，请重新登录！', {
        okCall: function() {
            window.location = 'Login.aspx';
            return false;
        }
    });
}

function navMenuTodo(url, id, info, data) {
    var number = 0;
    var userid = "";
    $(":checkbox[name=" + id + "]:checked").each(function() {
        number++;
        userid += "'" + $(this).val() + "',";
    });
    if (number == 0) {
        alertMsg.info("至少勾选一项，请重新选择！");
        return false;
    }
    else {
        userid = userid.substring(0, userid.length - 1)
        alertMsg.confirm(info, {
            okCall: function() {
                $.ajax({
                    type: 'POST',
                    url: url + "&id=" + userid,
                    data: data,
                    dataType: "json",
                    cache: false,
                    success: navTabAjaxDone,
                    error: DWZ.ajaxError
                });
            }
        });
    }
}

function navMenuEditTodo(url, id, rel, title, width, height) {
    var number = 0;
    var userid = "";
    $(":checkbox[name=" + id + "]:checked").each(function() {
        number++;
        userid = $(this).val();
    });
    if (number == 1) {
        if (width != null && height != null) {
            $.pdialog.open(url + "?id=" + userid, rel, title, { width: width, height: height });
        }
        else
            $.pdialog.open(url + "?id=" + userid, rel, title, { width: 500, height: 400 });
    }
    else {
        alertMsg.info('只能勾选一项，请重新选择！');
        return false;
    }
}

function navMenuRejectTodo(url, id, rel, title, width, height) {

    var number = 0;
    var userid = "";
    $(":checkbox[name=" + id + "]:checked").each(function() {
        number++;
        userid += "'" + $(this).val() + "',";
    });
    if (number == 0) {
        alertMsg.info('至少勾选一项，请重新选择！');
        return false;
    }
    else {
        userid = userid.substring(0, userid.length - 1)
        if (width != null && height != null) {
            $.pdialog.open(url + "?id=" + userid, rel, title, { width: width, height: height });
        }
        else
            $.pdialog.open(url + "?id=" + userid, rel, title, { width: 500, height: 400 });
    }
}



function AllCheck(id) {
    var $check = $("[name='" + id + "']");
    $check.each(function() {
        if ($(this).attr("checked")) {
            $(this).removeAttr("checked");
        }
        else {
            $(this).attr("checked", 'true');
        }
    });
}


function navTabMenuTodo(url, id, rel, title) {
    var number = 0;
    var userid = "";
    $(":checkbox[name=" + id + "]:checked").each(function() {
        number++;
        userid = $(this).val();
    });
    if (number == 1) {

        navTab.openTab(rel, title, url + "?id=" + userid);
    }
    else {
        alertMsg.info('只能勾选一项，请重新选择！');
        return false;
    }
}

function navMenuEditTodoType(url, id, rel, title, type, width, height) {
    var number = 0;
    var userid = "";
    $(":checkbox[name=" + id + "]:checked").each(function() {
        number++;
        userid = $(this).val();
    });
    if (number == 1) {
        if (width != null && height != null) {
            $.pdialog.open(url + "?id=" + userid + "&method=" + type, rel, title, { width: width, height: height });
        }
        else
            $.pdialog.open(url + "?id=" + userid + "&method=" + type, rel, title, { width: 400, height: 200 });
    }
    else {
        alertMsg.error('只能选择一项，请重新选择！');
        return false;
    }
}


function navMenuAddTodoType(url, id, rel, title, Type, width, height) {
    if (width != null && height != null) {
        $.pdialog.open(url + "?id=" + id + "&method=" + Type, rel, title, { width: width, height: height });

    }
    else
        $.pdialog.open(url + "?id=" + id + "&method=" + Type, rel, title, { width: 400, height: 200 });
}

function navMenuAddTodo(url, rel, title, width, height) {
    if (width != null && height != null) {
        $.pdialog.open(url, rel, title, { width: width, height: height });
    }
    else
        $.pdialog.open(url, rel, title, { width: 500, height: 400 });
}


function navMenuUpdateTodo(url, id, rel, title, Type, width, height) {
    if (width != null && height != null) {
        $.pdialog.open(url + "?id=" + id + "&method=" + Type, rel, title, { width: width, height: height });

    }
    else
        $.pdialog.open(url + "?id=" + id + "&method=" + Type, rel, title, { width: 400, height: 200 });
}



//个人文件柜删除
function navMenuTodoType(url, id, type, info, data) {

    alertMsg.confirm(info, {
        okCall: function() {
            $.ajax({
                type: 'POST',
                url: url + "&id=" + id + "&type=" + type,
                data: data,
                dataType: "json",
                cache: false,
                success: navTabAjaxDone,
                error: DWZ.ajaxError
            });
        }
    });
}


function _select() {
    var select = document.getElementById("Select");
    document.getElementById("words").innerHTML = select.options[select.selectedIndex].text;
    document.getElementById("_words").value = select.options[select.selectedIndex].text;

}


 