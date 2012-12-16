 <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="PresentationLayer._Search" Theme="Default"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:TextBox runat="server" ID="SearchText" Width="600px"/>
        <asp:Button ID="Search_button" runat="server" OnClick="Find_Click" Text="Найти" Width="90px"/>
    </p>
    <p id="NullText" runat="server" visible="false"><center>Тестов не найдено</center></p>
    <asp:Repeater Id="RepeaterTests" runat="server">
        <ItemTemplate>
            <div class="Test">
                <h1><%# DataBinder.Eval(Container.DataItem, "Name") %></h1>
                    <div class="descr"><%# DataBinder.Eval(Container.DataItem, "Description") %></div> 
                    <table width="700px">
                        <tr>
                            <td width="310px" class="author"><%#"Автор : " + Eval("Author") %></td>
                            <td width="190px"><asp:HyperLink  runat="server" ID="TestLink" Text='Пройти тест' NavigateUrl='<%# "~/Test.aspx?name=" + Eval("Name") %>'/></td>
                            <td width="200px" class="time"><%#"Время выполнения : " + Eval("Time") %></td>
                        </tr>
                    </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
