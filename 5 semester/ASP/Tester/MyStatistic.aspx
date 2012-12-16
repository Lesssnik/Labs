<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyStatistic.aspx.cs" Inherits="PL.MyStatistic" 
MasterPageFile="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p runat="server" id="NullText" visible="false"><center>Пользователь не прошел еще ни одного теста</center></p>
    <asp:Repeater ID="RepeaterStats" runat="server">
        <ItemTemplate>
            <center><table border="1px" width="400px" style="margin-top:20px;">
            <tr><td><center><strong><%# Eval("Item1") %></strong></center></td></tr>
            <tr><td><center><i><%# Eval("Item2") + " / " + Eval("Item3") + " ( " + (double.Parse(Eval("Item2").ToString())/double.Parse(Eval("Item3").ToString()))*100 + "% )" %></i></center></td></tr>
            </table></center>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
