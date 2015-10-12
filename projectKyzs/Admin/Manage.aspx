<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="projectKyzs.Admin.Manage"  ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/formanage.css" rel="stylesheet" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            document.onkeydown = function () {
                if (event.keyCode == 116 || (event.ctrlKey && event.keyCode == 82)) {
                    event.keyCode = 0;
                    alert("已禁用刷新！");
                    event.returnValue = false;
                }
            }
        </script>
        <div>
            <div class="banner">
                欢迎你， <%=ReturnAdminName() %> ，<asp:LinkButton Text="退出管理" runat="server" ID="Exit" OnClick="Exit_Click" />
            </div>
            <div class="leftbar">
                <asp:LinkButton Text="控制管理员" runat="server" ID="admin" OnClick="admin_Click" />
                <br />
                <br />
                <asp:LinkButton Text="科院相册" runat="server" ID="kyxc" OnClick="kyxc_Click" /><br />
                <asp:LinkButton Text="招生信息" runat="server" ID="kyxw" OnClick="kyxw_Click" /><br />
                <!--<asp:LinkButton Text="录取信息" runat="server" ID="lqxx" sOnClick="lqxx_Click" /><br />-->
                <asp:LinkButton Text="招生政策" runat="server" ID="zszc" OnClick="zszc_Click" /><br />
                <asp:LinkButton Text="招生计划" runat="server" ID="zsjh" OnClick="zsjh_Click" /><br />
                <asp:LinkButton Text="录取分数" runat="server" ID="zsxx" OnClick="zsxx_Click" /><br />
                <asp:LinkButton Text="入学指南" runat="server" ID="rxzn" OnClick="rxzn_Click" /><br />
                <asp:LinkButton Text="考生问答" runat="server" ID="kswd" OnClick="kswd_Click" /><br />
                <br />
                <div style="font-size: 14px; padding: 44px;">
                    <img src="../images/footer_logo.png" /><br />
                    华北电力大学网络管理协会&copy;2015
                </div>
            </div>
            <div class="main">
                <div class="main_index">
                    <asp:TextBox runat="server" Width="100" BorderWidth="0" ReadOnly="true" Font-Bold="true" Font-Names="Microsoft YaHei" Font-Size="Larger" Text="科院新闻" ID="Functions" />
                    <p><%=ReturnInstructions() %></p>
                    <asp:Button Text="管理员操控" runat="server" ID="ManageLink" Visible="false" OnClick="ManageLink_Click" />
                </div>
                <div class="main_id">
                    <asp:DropDownList runat="server" ID="picnewsdpl" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="picnewsdpl_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="docdpl" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="docdpl_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="FileDpl">
                    </asp:DropDownList>
                    <asp:Button Text="刷新" runat="server" ID="RefreshButton" Visible="false" OnClick="RefreshButton_Click" />
                    <asp:Button Text="删除该文件" runat="server" ID="DeleteFile" OnClick="DeleteFile_Click" />
                </div>
                <div class="main_title">
                    <asp:TextBox runat="server" Text="标题" ID="TitlePlace" Width="60" BorderWidth="0" ReadOnly="true" />
                    <asp:TextBox runat="server" Text="请在此输入标题文本" Width="600" ID="TitleBox" TextMode="SingleLine" MaxLength="60" />
                </div>
                <div class="main_text">
                    <asp:TextBox runat="server" Text="正文" ID="TextPlace" Width="60" BorderWidth="0" ReadOnly="true" />
                    <asp:TextBox runat="server" ID="tbContent" TextMode="MultiLine" class="ckeditor" Height="50"></asp:TextBox>
                    <script type="text/javascript">
                        CKEDITOR.replace('tbContent');
                    </script>
                    <div class="UploadSelector">
                        <asp:FileUpload ID="lqUpload" runat="server" />
                        <asp:Button ID="Upload" runat="server" Text="上传" OnClick="Upload_Click" />
                        <asp:Label ID="MessageLbl" runat="server" Text="" Style="color: Red"></asp:Label>
                    </div>
                    <p>
                        <asp:DropDownList runat="server" ID="OntopDpl" Visible="false" AutoPostBack="true">
                            <asp:ListItem Text="置顶" Value="ontop" />
                            <asp:ListItem Text="非置顶" Value="notontop" Selected="True" />
                        </asp:DropDownList>
                        <asp:Button Text="删除本文章" runat="server" ID="SuperDelete" Visible="false" OnClick="SuperDelete_Click" />
                        <asp:TextBox runat="server" Text="选择适当的图片上传作为图片新闻的首页图，请预裁剪图片到“280x160”大小" Width="450" ReadOnly="true" BorderWidth="0" ID="PicNewsInstruction" Visible="false" />
                        <asp:FileUpload ID="FileUpload" runat="server" Visible="false" />
                        <asp:Button ID="FileUploadButton" runat="server" OnClick="Button_Click" Text="上传" Visible="false" />
                        <asp:DropDownList runat="server" ID="Docdl" Visible="false">
                            <asp:ListItem Text="激活" Value="0" />
                            <asp:ListItem Text="不激活" Value="1" />
                        </asp:DropDownList>
                    </p>
                    <div class="main_submit">
                        <asp:Button Text="提交新闻" runat="server" ID="submit_News" Visible="false" OnClick="submit_News_Click" />
                        <asp:Button Text="修改新闻" runat="server" ID="submit_Edit" Visible="false" OnClick="submit_Edit_Click" ForeColor="White" Height="22" BorderWidth="0" BackColor="Red" />
                        <asp:Button Text="创建新页" runat="server" ID="submit_CreateDoc" Visible="false" OnClick="submit_CreateDoc_Click" />
                        <asp:Button Text="修改此页" runat="server" ID="submit_EditDoc" Visible="false" OnClick="submit_EditDoc_Click" ForeColor="White" Height="22" BorderWidth="0" BackColor="Red" />
                    </div>
                    <div class="PictureReplace">
                        <asp:Button Text="修改封面1" runat="server" ID="ConfirmReplace1" OnClick="ConfirmReplace1_Click" />
                        <asp:Button Text="修改封面2" runat="server" ID="ConfirmReplace2" OnClick="ConfirmReplace2_Click" />
                        <asp:Button Text="修改封面3" runat="server" ID="ConfirmReplace3" OnClick="ConfirmReplace3_Click" />
                        <br />
                        <asp:Image runat="server" ImageUrl="~/img/show1.png" ID="imgb1" Width="256" Height="100" />
                        <asp:Image runat="server" ImageUrl="~/img/show2.png" ID="imgb2" Width="256" Height="100" />
                        <asp:Image runat="server" ImageUrl="~/img/show3.png" ID="imgb3" Width="256" Height="100" />
                        <br />
                        <asp:DropDownList runat="server" ID="PicturesSelector" Visible="false">
                        </asp:DropDownList>
                        <asp:Button Text="上传" runat="server" ID="PicturesUpload" OnClick="PicturesUpload_Click" Visible="false" />
                        <asp:Button Text="修改" runat="server" ID="PicturesReplace" OnClick="PicturesReplace_Click" Visible="false" />
                        <asp:Button Text="删除" runat="server" ID="PicturesDelete" OnClick="PicturesDelete_Click" Visible="false" />
                    </div>
                    <style type="text/css">
                        .QA textarea {
                            width: 600px;
                            height: 150px;
                            resize: none;
                        }
                    </style>
                    <div class="QA">
                        <asp:DropDownList runat="server" ID="QADpl" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="QADpl_SelectedIndexChanged" Width="150">
                        </asp:DropDownList>
                        <asp:Button Text="忽略" ID="QA_Ignore" runat="server" OnClick="QA_Ignore_Click" />
                        <br />
                        <asp:TextBox runat="server" ID="QAText" Visible="false" Width="600" TextMode="MultiLine" /><br />
                        <asp:TextBox runat="server" ID="QAReply" Visible="false" TextMode="MultiLine" />
                        <br />
                        <asp:Button Text="回复" runat="server" ID="QA_Reply" Visible="false" OnClick="QA_Reply_Click" />
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
