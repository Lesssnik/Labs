<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTests.aspx.cs" Inherits="PL.MyTests"
    MasterPageFile="~/Site.Master" Theme="Default"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:Repeater Id="RepeaterTests" runat="server">
        <ItemTemplate>
            <div class="Test">
                <table>
                    <tr>
                        <td width="250px"><i style="color:grey"><%# Eval("Type") %></i></td>
                        <td width="190px"><h1><%# Eval("Name") %></h1></td>
                        <td></td>
                    </tr>
                </table>
                    <div class="descr"><%# Eval("Description") %></div> 
                    <table width="700px">
                        <tr>
                            <td width="310px" class="author"><asp:HyperLink runat="server" NavigateUrl='<%# "~/User.aspx?user=" + Eval("Author") %>'><%#"Автор : " + Eval("Author") %></asp:HyperLink></td>
                            <td width="190px"><asp:HyperLink  runat="server" ID="TestLink" Text='Пройти тест' NavigateUrl='<%# "~/Test.aspx?name=" + Eval("Name") %>'/></td>
                            <td width="200px" class="time"><%#"Время выполнения : " + Eval("Time") %></td>
                        </tr>
                        <tr><td colspan=3><hr /></td></tr>
                        <tr>
                            <td><asp:HyperLink runat="server" NavigateUrl='<%#"~/EditTest.aspx?test=" + Eval("ID")%>'><i>Редактировать тест</i></asp:HyperLink></td>
                        </tr>
                    </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
