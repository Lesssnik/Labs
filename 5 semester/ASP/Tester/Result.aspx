<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="PresentationLayer.Result"
    MasterPageFile="~/Site.Master" Theme="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center><table border="1px">
        <asp:Repeater runat="server" ID="RepeaterStats">
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
    </table></center>
</asp:Content>
