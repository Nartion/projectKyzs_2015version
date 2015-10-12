<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeBehind="Picnews.aspx.cs" Inherits="projectKyzs.Picnews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pages">
        <div class="show_2">
            <img src="images/show_2.png" alt="" />
        </div>
        <div class="conter" style="min-height:425px;">
            <asp:Repeater runat="server" ID="PicRep">
                <ItemTemplate>
                    <div class="title" style="font-size: 16px;" id="conter_texttitle" runat="server">
                        <p><%#Eval("title") %></p>
                    </div>
                    <div style="text-align: center;">
                        <p>
                            <%#Eval("posttime") %>
                        </p>
                    </div>
                    <img src="<%#Eval("picurl") %>"/>
                    <div class="conter_text" id="conter_text" runat="server">
                        <%#Eval("details") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="pages_div">
                <div class="pages_div_2">
                    <div class="title" id="title" runat="server">招生信息</div>
                    <div class="conter_nav">
                        <ul>
                            <asp:Repeater runat="server" ID="TopPicNews">
                                <ItemTemplate>
                                    <li>
                                        <a href="Picnews.aspx?pnid=<%#Eval("id") %>">TOP <%#Eval("title") %><span><%#ReformStringDate((Eval("posttime")+"$"+"False")) %></span>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Repeater runat="server" ID="PicTitle">
                                <ItemTemplate>
                                    <li>
                                        <a href="Picnews.aspx?pnid=<%#Eval("id") %>">> <%#Eval("title") %><span><%#(ReformStringDate((Eval("posttime")+"$"+Convert.ToString(Eval("ontop"))))) %></span>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
