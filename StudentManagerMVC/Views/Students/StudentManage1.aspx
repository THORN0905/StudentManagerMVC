<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<%
    string userName = ((Models.Admins)Session["CurrentUser"]).LoginName;
%>
<html>
<head>
    <title>学员信息管理</title>
    <link href="../../styles/stuManage.css" rel="stylesheet" />
</head>
<body>
    <div id="container">
        <h2>当前用户：<%=userName %></h2>
        <div id="querydiv">
            <div id="formdiv">
                <form method="post" action="/Students/StudentManage">
                    班级：
                    <input type="text" name="className" value="<%=ViewBag.className==null?"":ViewBag.className %>" />
                    <input type="submit" value="查询" />
                </form>
            </div>
            <div id="adddiv"><a href="#">新增学员</a>    </div>
        </div>
        <div id="studiv">
            <%
                if (ViewBag.stuList != null)
                {
                    foreach (Models.Ext.StudentsExt stu in ViewBag.stuList)
                    { %>
            <div class="stuList">
                <div class="stuItem"><%=stu.StudentId %></div>         
                <div class="stuItem"><%=stu.StudentName %></div> 
                <div class="stuItem"><%=stu.ClassName%></div>  
                <div class="stuItem"> <a href="#">查看详细</a>  </div>
                <div class="stuItem"> <a href="#">修改</a> </div>
                <div class="stuItem">  <a href="#">删除</a>  </div>
            </div>

            <%     }
                }
            %>
        </div>
    </div>
</body>
</html>
