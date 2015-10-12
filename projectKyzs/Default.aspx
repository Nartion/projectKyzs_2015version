<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projectKyzs.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="show">
        <div id="wrapper">
            <div class="callbacks_container">
                <ul class="rslides" id="slider4">
                    <li>
                        <img src="img/show1.png" alt="" />
                    </li>
                    <li>
                        <img src="img/show2.png" alt="" />
                    </li>
                    <li>
                        <img src="img/show3.png" alt="" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="conter">
        <div class="left">
            <div class="left_">
                <div class="left_1">
                    <div class="left_1_more"><a href="Picnews.aspx">more></a></div>
                    <p>招生信息</p>
                    <!--<p>科院新闻</p>-->
                </div>
                <div class="left_2">
                    <a href="<%=QueryTopPictureNewsId() %>">
                        <div class="left_2_1">
                            <img src="<%=QueryTopPictureNewsPic() %>" alt="Alternate Text" width="280" height="160" />
                        </div>
                        <div class="left_2_2"><%=QueryTopPictureNewsTitle() %></div>
                    </a>
                </div>

                <div class="top-news">
                    <ul>
                        <asp:Repeater runat="server" ID="TopPictureNewsRep">
                            <ItemTemplate>
                                <li>
                                    <a href="Picnews.aspx?pnid=<%#Eval("id") %>"><%#(SubstringTitle(Convert.ToString(Eval("title")),15))%><span><%#(SubstringDate(Convert.ToString(Eval("posttime")))) %></span></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="left_3">
                    <ul>
                        <asp:Repeater runat="server" ID="PictureNewsRep">
                            <ItemTemplate>
                                <li>
                                    <a href="Picnews.aspx?pnid=<%#Eval("id") %>"><%#(SubstringTitle(Convert.ToString(Eval("title")),15))%><span><%#(SubstringDate(Convert.ToString(Eval("posttime"))+"$"+Convert.ToString(Eval("ontop")))) %></span></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="left_4">
                    <a href="http://202.206.208.40/zs/">
                        <img src="images/left_pic.png" alt="" /></a>
                </div>
                <div class="left_5">
                    <a href="http://goto.ncepu.edu.cn/">
                        <img src="images/right_pic.png" alt="" /></a>
                </div>
            </div>
            <div class="right">
                <div class="right_div">
                    <div class="right_div_1">
                        <div class="right_div_1_more">
                            <a href="Pages.aspx?tid=1">more></a>
                        </div>
                        <p>招生政策</p>
                    </div>
                    <div class="right_div_2">
                        <ul>
                            <asp:Repeater runat="server" ID="PolicyPagesRep">
                                <ItemTemplate>
                                    <li>
                                        <a href="Pages.aspx?tid=1&pid=<%#Eval("id") %>"><%#(SubstringTitle(Eval("title").ToString(),20)) %><span><%#(SubstringCompleteDate((Eval("time").ToString()))) %></span></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="right_div">
                    <div class="right_div_1">
                        <div class="right_div_1_more">
                            <a href="Pages.aspx?tid=2">more></a>
                        </div>
                        <p>招生计划</p>
                    </div>
                    <div class="right_div_2">
                        <ul>
                            <asp:Repeater runat="server" ID="PlanPagesRep">
                                <ItemTemplate>
                                    <li>
                                        <a href="Pages.aspx?tid=2&pid=<%#Eval("id") %>"><%#(SubstringTitle(Eval("title").ToString(),20)) %><span><%#(SubstringCompleteDate((Eval("time").ToString()))) %></span></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="right_div">
                    <div class="right_div_1">
                        <div class="right_div_1_more">
                            <a href="Pages.aspx?tid=3">more></a>
                        </div>
                        <p>录取分数</p>
                        <!-- <p>招生信息</p>-->
                    </div>
                    <div class="right_div_2">
                        <ul>
                            <asp:Repeater runat="server" ID="InfoPagesRep">
                                <ItemTemplate>
                                    <li>
                                        <a href="Pages.aspx?tid=3&pid=<%#Eval("id") %>"><%#(SubstringTitle(Eval("title").ToString(),20)) %><span><%#(SubstringCompleteDate((Eval("time").ToString()))) %></span></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="right_div right-div-links">
                    <div class="links-button links-button-north links-button-west" href="baidu.com">
                        <div class="link-box">
                            <span>录取查询</span>
                        </div>
                        <div class="link-box">
                            <img src="images/search_80_80.png" alt="search" />
                        </div>
                        <a class="links-button link-box-cover" href="http://202.206.208.40/zs/query_lqmore.asp">&nbsp;</a>
                    </div>
                    <div class="links-button links-button-north">
                        <div class="links-button links-button-north links-button-west">
                            <div class="link-box">
                                <span>科院相册</span>
                            </div>
                            <div class="link-box">
                                <img src="images/gallery_80_80.png" alt="gallery" />
                            </div>
                            <a class="links-button link-box-cover" href="Pictures.aspx">&nbsp;</a>
                        </div>
                    </div>
                    <div class="links-button links-button-west">
                        <div class="links-button links-button-north links-button-west">
                            <div class="link-box">
                                <span>入学指南</span>
                            </div>
                            <div class="link-box">
                                <img src="images/instruction_80_80.png" alt="instruction" />
                            </div>
                            <a class="links-button link-box-cover" href="Pages.aspx?tid=4">&nbsp;</a>
                        </div>
                    </div>
                    <div class="links-button">
                        <div class="links-button links-button-north links-button-west">
                            <div class="link-box">
                                <span>考生问答</span>
                            </div>
                            <div class="link-box">
                                <img src="images/faq_80_80.png" alt="faq" />
                            </div>
                            <a class="links-button link-box-cover" href="Comment.aspx">&nbsp;</a>
                        </div>
                    </div>
                    <!--
                <div class="links-button links-button-south links-button-west">
                    <div class="links-button links-button-north links-button-west">
                        <div class="link-box">
                            <span>录取分数</span>
                        </div>
                        <div class="link-box">
                            <img src="images/grades_80_80.png" alt="grades" />
                        </div>
                        <a class="links-button link-box-cover" href="Admission.aspx">&nbsp;</a>
                    </div>
                </div>-->
                    <div class="links-button links-button-south">
                        <div class="links-button links-button-north links-button-west">
                            <div class="link-box">
                                <span>专业设置</span>
                            </div>
                            <div class="link-box">
                                <img src="images/settings_80_80.png" alt="settings" />
                            </div>
                            <a class="links-button link-box-cover" href="Majors.aspx">&nbsp;</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
