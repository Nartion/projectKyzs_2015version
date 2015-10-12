<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="projectKyzs.Comment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=11;IE=10;IE=9;IE=8;chrome=1" />
    <meta name="renderer" content="webkit" />
    <title>招生信息网</title>
    <link href="css/forQA.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script src="js/jquery-1.11.2.min.js"></script>
    <script src="js/comment.js"></script>
    <link rel="stylesheet" href="css/style.css" />
    <style type="text/css">
        a:link, a:visited, a:hover {
            text-decoration: none;
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            <div class="logo">
                招生信息网
            </div>
            <div class="nav">
                <ul>
                    <li>
                        <a href="Default.aspx">招生首页</a>
                    </li>
                    <li>
                        <a href="http://www.hdky.edu.cn/xuegong/">学工首页</a>
                    </li>
                    <li>
                        <a href="Pages.aspx?tid=1">招生政策</a>
                    </li>
                    <li>
                        <a href="Pages.aspx?tid=2">招生计划</a>
                    </li>
                    <li>
                        <a href="Pages.aspx?tid=3">招生信息</a>
                    </li>
                    <li>
                        <a href="Majors.aspx">专业设置</a>
                    </li>
                    <li>
                        <a href="Admission.aspx">录取分数</a>
                    </li>
                    <li>
                        <a href="http://www.hdky.edu.cn/chengguozhan.htm">学院风采</a>
                    </li>
                    <li>
                        <a href="Comment.aspx">咨询专区</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="QA_Post" id="float">
            <div class="QA_Post_content">
                <table>
                    <tr>
                        <td>姓名：</td>
                        <td>
                            <asp:TextBox runat="server" ID="name" MaxLength="8" Width="110" />&nbsp;&nbsp;&nbsp;省份：
                    <asp:DropDownList runat="server" ID="prov">
                        <asp:ListItem Text="北京" Value="北京" />
                        <asp:ListItem Text="天津" Value="天津" />
                        <asp:ListItem Text="四川" Value="四川" />
                        <asp:ListItem Text="河北" Value="河北" />
                        <asp:ListItem Text="上海" Value="上海" />
                        <asp:ListItem Text="江苏" Value="江苏" />
                        <asp:ListItem Text="福建" Value="福建" />
                        <asp:ListItem Text="广东" Value="广东" />
                        <asp:ListItem Text="河南" Value="河南" />
                        <asp:ListItem Text="湖北" Value="湖北" />
                        <asp:ListItem Text="湖南" Value="湖南" />
                        <asp:ListItem Text="辽宁" Value="辽宁" />
                        <asp:ListItem Text="山东" Value="山东" />
                        <asp:ListItem Text="吉林" Value="吉林" />
                        <asp:ListItem Text="山西" Value="山西" />
                        <asp:ListItem Text="陕西" Value="陕西" />
                        <asp:ListItem Text="安徽" Value="安徽" />
                        <asp:ListItem Text="云南" Value="云南" />
                        <asp:ListItem Text="重庆" Value="重庆" />
                        <asp:ListItem Text="贵州" Value="贵州" />
                        <asp:ListItem Text="青海" Value="青海" />
                        <asp:ListItem Text="宁夏" Value="宁夏" />
                        <asp:ListItem Text="广西" Value="广西" />
                        <asp:ListItem Text="浙江" Value="浙江" />
                        <asp:ListItem Text="西藏" Value="西藏" />
                        <asp:ListItem Text="内蒙古" Value="内蒙古" />
                        <asp:ListItem Text="黑龙江" Value="黑龙江" />
                        <asp:ListItem Text="台湾省" Value="台湾省" />
                        <asp:ListItem Text="香港" Value="香港" />
                        <asp:ListItem Text="澳门" Value="澳门" />
                        <asp:ListItem Text="江西" Value="江西" />
                        <asp:ListItem Text="甘肃" Value="甘肃" />
                        <asp:ListItem Text="新疆" Value="新疆" />
                        <asp:ListItem Text="海南" Value="海南" />
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Button Text="提问" ID="PostQA" runat="server" OnClick="PostQA_Click" /></td>
                    </tr>
                    <tr>
                        <td>提问：</td>
                        <td>
                            <asp:TextBox runat="server" Width="845" TextMode="SingleLine" ID="Text" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mainbody" style="padding-top: 60px;">
            <asp:DropDownList runat="server" ID="PageSelector" AutoPostBack="true" OnSelectedIndexChanged="PageSelector_SelectedIndexChanged"></asp:DropDownList>
            <asp:Repeater runat="server" ID="QARep">
                <ItemTemplate>
                    <div class="QA">
                        <div class="QA_Info">
                            <%#Eval("province") %>考生：<span>发表于<%#Eval("questime") %></span>
                        </div>
                        <hr />
                        <div>
                            Q:<%#Eval("question") %>
                        </div>
                        <hr />
                        <div class="QA_Reply">
                            A:<%#Eval("reply") %><span>回复于<%#Eval("replytime") %></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="footer">
            <div class="footer_1"></div>
            <div class="footer_2">
                <img src="images/footer_logo.png" alt="" />
                <div class="footer_text">
                    <p>
                        学院地址: 河北省保定市瑞祥大街282号   咨询电话: 0312-7523462 
	                    <br/> 
		            	<script type="text/javascript">
			              function jump() {
			                                window.open("Admin/Login.aspx");
			                              }
                        </script>网址: http://www.hdky.edu.cn/    招生办邮箱: hdkyzs@163.com  <a href="#" onclick="javascript:jump()">管理入口</a>  
                        <br/>    
                        Copyright © 华北电力大学科技学院       技术支持: 华北电力大学网络管理协会     
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
