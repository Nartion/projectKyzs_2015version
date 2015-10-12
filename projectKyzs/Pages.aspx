<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="projectKyzs.Pages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pages">
        <div class="show_2">
            <img src="images/show_2.png" alt="" />
        </div>
        <div class="conter" style="min-height: 425px;">
            <div class="title" id="conter_title" runat="server">
                <a style="color: #507aa7;" href="Pages.aspx?tid=<%=ReturnTableID() %>"><%=ReturnTitle() %></a>
            </div>
            <div class="title" style="font-size: 16px;" id="conter_texttitle" runat="server">
                <%=ReturnTextTitle() %>
            </div>
            <div class="conter_text" id="conter_text" runat="server" style="border:initial;">
                <%=ReturnMainText() %>
            </div>
            <div class="conter_nav" id="conter_nav" runat="server">
                <ul>
                    <asp:Repeater runat="server" ID="TablePagesRep">
                        <ItemTemplate>
                            <li>
                                <a href="Pages.aspx?tid=<%#Eval("pageid") %>&pid=<%#Eval("id") %>"><%#(SubstringTitle(Eval("title").ToString(),60)) %><span><%#(SubstringCompleteDate((Eval("time").ToString()))) %></span></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="paginator" id="paginator" runat="server" style="position:absolute;bottom:0;">
                <table style="text-align: center; width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            <asp:LinkButton Text="上一页" runat="server" ID="ppage" OnClick="ppage_Click" />
                        </td>
                        <td>当前第&#32;<%=ReturnPageIndex() %>&#32;页，转到第
                            <asp:Repeater runat="server" ID="PageSelector">
                                <ItemTemplate>
                                    <a href="Pages.aspx?tid=<%=ReturnTableID() %>&pageid=<%=(Convert.ToInt32(ReturnPageIndex())+1).ToString() %>"><%#Eval("pageid") %></a>
                                </ItemTemplate>
                            </asp:Repeater>
                            页
                        </td>
                        <td style="text-align: left;">
                            <asp:LinkButton Text="下一页" runat="server" ID="npage" OnClick="npage_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
