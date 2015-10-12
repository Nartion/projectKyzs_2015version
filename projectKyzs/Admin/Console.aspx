<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Console.aspx.cs" Inherits="projectKyzs.Admin.Console" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/formanage.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="banner">
            欢迎你，高权限管理员，<asp:LinkButton Text="退出管理" runat="server" ID="Exit" OnClick="Exit_Click" />
        </div>
        <div style="top: 60px; position: absolute; left: 0; padding-left: 20px; font-family: 'Microsoft YaHei'; width: 1000px;">
            <div>
                <asp:TextBox runat="server" ID="RelogText" Visible="true" ReadOnly="true" BorderWidth="0" /><br />
                <asp:TextBox runat="server" ID="Pwd" TextMode="Password" Visible="true" /><br />
                <asp:Button Text="检验" runat="server" ID="Check_Button" Visible="true" OnClick="Check_Button_Click" />
            </div>
            <div>
                <asp:TextBox runat="server" Text="当前管理员有：" Visible="false" ID="AdminSelectorText" BorderWidth="0" Width="80" />
                <asp:DropDownList runat="server" ID="AdminSelector" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="AdminSelector_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button Text="添加管理员" runat="server" ID="Create" Visible="false" OnClick="Create_Click" />
                <asp:Button Text="返回" runat="server" ID="GoBack" OnClick="GoBack_Click" Visible="false" />
                <br />
                <asp:TextBox runat="server" Text="当前操作：" Visible="false" ID="Text" ReadOnly="true" BorderWidth="0" Width="80" />
                <asp:Label Text="text" runat="server" Visible="false" ID="AdminIndicator" />
                <asp:TextBox runat="server" Text="当前操作：" Visible="false" ID="Status" ReadOnly="true" BorderWidth="0" Width="60" /><br />
                <asp:Button Text="删除此管理员" runat="server" ID="Delete" Visible="false" BackColor="Red" ForeColor="White" BorderWidth="0" OnClick="Delete_Click" />
                <asp:Button Text="冻结/解冻" runat="server" ID="Freeze" Visible="false" BackColor="Blue" ForeColor="White" BorderWidth="0" OnClick="Freeze_Click" />
                <asp:Button Text="修改信息" runat="server" ID="Edit" Visible="false" BackColor="Green" ForeColor="White" BorderWidth="0" OnClick="Edit_Click" />
            </div>
            <div>
                <table runat="server" visible="false" id="CreateTable">
                    <tr>
                        <td>用户名</td>
                        <td>
                            <asp:TextBox runat="server" ID="Create_name" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>密码</td>
                        <td>
                            <asp:TextBox runat="server" ID="Create_pwd" Visible="false" TextMode="Password" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="创建" ID="Confirm" Visible="false" OnClick="Confirm_Click" />
                            <asp:Button Text="确认修改" runat="server" ID="ConfirmEdit" Visible="false" OnClick="ConfirmEdit_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
