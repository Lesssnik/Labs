<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PL.Test"
    MasterPageFile="~/Site.Master" Theme="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="Div1" class="Test" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load">
            <ContentTemplate>
                <label>
                    Осталось времени:
                </label>
                <asp:Label runat="server" ID="timeLeft"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        </asp:UpdateProgress>
        <div>
            <h1>
                <%# TestName %></h1>
            <i>
                <%# CurrQuestion %></i><br />
            <asp:CheckBoxList runat="server" ID="CheckAnswerList" />
            <asp:RadioButtonList runat="server" ID="RadioAnswerList" />
            <asp:Button runat="server" Text="Следующий вопрос" OnClick="Check_Click" />
        </div>
    </div>
</asp:Content>
