<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeBehind="Pictures.aspx.cs" Inherits="projectKyzs.Pictures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/xiangce.js"></script>
    <script type="text/javascript">
        // You can also use "$(window).load(function() {"
        $(function () {
            // Slideshow 4
            $("#slider4").responsiveSlides({
                auto: false,
                pager: false,
                nav: true,
                speed: 500,
                namespace: "callbacks",
                before: function () {
                    $('.events').append("<li>before event fired.</li>");
                },
                after: function () {
                    $('.events').append("<li>after event fired.</li>");
                }
            });
        });
    </script>
    <style type="text/css">
        a:link, a:visited, a:hover {
            text-decoration: none;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="conter" style="height: 617px;">
                <div class="box" id="box" style="height: 556px; z-index: 1;">
                    <ul>
                        <asp:Repeater runat="server" ID="picturesRep">
                            <ItemTemplate>
                                <li>
                                    <img src="<%#Eval("picurl") %>" width="100%" height="100%" alt="<%#Eval("id") %>" /></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="bg"></div>
                <div id="bottom">
                    <ul>
                        <li class="prev"></li>
                        <li class="img"></li>
                        <li class="next"></li>
                        <li class="close"></li>
                    </ul>
                </div>
                <div id="frame"></div>
                <div class="paginator">
                    <style type="text/css">
                        a:link {
                            text-decoration: none;
                            cursor: default;
                        }

                        a:visited {
                            text-decoration: none;
                            cursor: default;
                        }

                        a:hover {
                            text-decoration: none;
                            cursor: default;
                        }
                    </style>
                    <asp:LinkButton Text="上一页" runat="server" ID="PreviousPage" OnClick="PreviousPage_Click" />
                    <span><span id="page"><%=ReturnPageIndex() %></span>/<%=ReturnPagesIntotal() %></span>
                    <asp:LinkButton Text="下一页" runat="server" ID="NextPage" OnClick="NextPage_Click" />
                </div>
            </div>
</asp:Content>
