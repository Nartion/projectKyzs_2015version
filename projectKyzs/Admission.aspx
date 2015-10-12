<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeBehind="Admission.aspx.cs" Inherits="projectKyzs.Admission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="show_2">
            <img src="images/show_2.png" alt="" />
        </div>
        <div class="conter" style="min-height: 450px;">
            <div class="title">
                录取分数
            </div>
            <div class="conter_nav">
                <ul>
                    <asp:Repeater runat="server" ID="AdmRep">
                        <ItemTemplate>
                            <li><a href="files/admissionscores/<%#Eval("filename") %>"><%#Eval("filename") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="paginator" id="paginator" runat="server" style="position: absolute; bottom: 0;">
                <table style="text-align: center; width: 100%;">
                    <tr>
                        <td style="text-align: right;">
                            <asp:LinkButton Text="上一页" runat="server" ID="ppage" OnClick="ppage_Click" />
                        </td>
                        <td>当前第&#32;<%=ReturnPageIndex() %>&#32;页，转到第
                            <asp:Repeater runat="server" ID="PageSelector">
                                <ItemTemplate>
                                    <a href="Pages.aspx?tid=<%=ReturnTableID() %>&pageid=<%=(Convert.ToInt32(ReturnPageIndex())+1).ToString() %>"><%#Eval("filename") %></a>
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
