<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace=Models %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>AdminLogin</title>
</head>
<body>
    <form method="post" action="/AdminLogin/Login">
        用户名：<input type="text" name="LoginId" /><br />
        密码：<input type="password" name="LoginPwd" /><br />
        <input type="submit" name="btnLogin" value="登录" />
    </form>
    <%=ViewData["Current"]%>

    <a href="/Students">学生管理</a>
</body>
</html>
