<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserStatistic.aspx.cs"
    Inherits="PresentationLayer.UserStatistic" MasterPageFile="~/Site.Master" Theme="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p runat="server" id="NullText" visible="false"><center>Пользователь не прошел еще ни одного теста</center></p>
    <asp:Repeater ID="RepeaterStats" runat="server">
        <ItemTemplate>
            <center>
                <table border="1px" style="margin-top:20px;">
                    <tr><td colspan=2><%# Eval("Item1") %></td></tr>
                    <asp:Repeater runat="server" DataSource='<%# Eval("Item2") %>'>
                        <ItemTemplate>
                            <tr>
                                <td width="200px">
                                    <%# Eval("Item1") %>
                                </td>
                                <td width="200px">
                                    <%# Eval("Item2") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </center>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
