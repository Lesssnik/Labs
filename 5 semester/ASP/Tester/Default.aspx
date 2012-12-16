<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PresentationLayer._Default" Theme="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p runat="server" id="NullText" visible="false"><center>Еще не создано ни одного теста</center></p>
    <asp:GridView ID="RepeaterTests" runat="server" AllowPaging=true AutoGenerateColumns=false GridLines=None PageSize=5 PagerSettings-Mode=Numeric OnPageIndexChanging="Page_IndexChanging">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="Test">
                        <table>
                            <tr>
                                <td width="250px">
                                    <i style="color: grey">
                                        <%# Eval("Type") %></i>
                                </td>
                                <td width="190px">
                                    <h1>
                                        <%# Eval("Name") %></h1>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <div class="descr">
                            <%# Eval("Description") %></div>
                        <table width="700px">
                            <tr>
                                <td width="310px" class="author">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/User.aspx?user=" + Eval("Author") %>'><%#"Автор : " + Eval("Author") %></asp:HyperLink>
                                </td>
                                <td width="190px">
                                    <asp:HyperLink runat="server" ID="TestLink" Text='Пройти тест' NavigateUrl='<%# "~/Test.aspx?name=" + Eval("Name") %>' />
                                </td>
                                <td width="200px" class="time">
                                    <%#"Время выполнения : " + Eval("Time") %>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
