<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="projectKyzs.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/adminlogin.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员登录</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginbox">
            <div class="title">
                科技学院后台管理登录
            </div>
            <div>
                <p>
                    管理账户名
                        <asp:TextBox runat="server" ID="Username" TextMode="Singleline"/>
                </p>
                <p>
                    管理员密码
                        <asp:TextBox runat="server" ID="Userpwd" TextMode="Password"/>
                </p>
                <div class="button">
                    <div style="border-radius: 5px 5px; width: 60px;margin-right:40px; height: 25px; float: left; line-height: 25px; background-color: #eeeeee; color: #417ca3;">
                        <asp:Button Text="登录" runat="server" ForeColor="#417ca3" BorderWidth="0" BackColor="#eeeeee" Width="50" Height="20" ID="Checkin" OnClick="Checkin_Click" />
                    </div>
                    <div style="border-radius: 5px 5px; width: 60px; height: 25px; float: left; line-height: 25px; background-color: #eeeeee; color: #417ca3;">
                        <asp:Button Text="返回" runat="server" ForeColor="#417ca3" BorderWidth="0" BackColor="#eeeeee" Width="50" Height="20" ID="GoBack" OnClick="GoBack_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>