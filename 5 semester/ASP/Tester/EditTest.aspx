<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTest.aspx.cs" Inherits="PL.EditTest"
    MasterPageFile="~/Site.Master" Theme="AddTest"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="add_test">
        <div class="part">
            Название
            <input id="NameId" runat="server" type="text" size="30">
            Описание
            <input id="DescrId" runat="server" type="text" size="30">
            Тип<br />
            <asp:DropDownList ID="TypesId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypesId_SelectedIndexChanged" />
            <hr />
        </div>
        <div class="part">
            Вопрос
            <asp:DropDownList runat="server" ID="Questions" AutoPostBack="True" OnSelectedIndexChanged="Questions_SelectedIndexChanged"/><br />
            Ответы
            <table>
            <tr>
                <td><input id="Answer1" runat="server" type="text" size="30"/></td>
                <td><input runat="server" id="CheckResAnswer1" type="checkbox"/></td>
            </tr>
            <tr>
                <td><input id="Answer2" runat="server" type="text" size="30"/></td> 
                <td><input runat="server" id="CheckResAnswer2" type="checkbox"/></td>
            </tr>
            <tr>
                <td><input id="Answer3" runat="server" type="text" size="30"/></td> 
                <td><input runat="server" id="CheckResAnswer3" type="checkbox"/></td>
            </tr>
            <tr>
                <td><input id="Answer4" runat="server" type="text" size="30"/></td> 
                <td><input runat="server" id="CheckResAnswer4" type="checkbox"/></td>
            </tr>
            <tr>
                <td><input id="Answer5" runat="server" type="text" size="30"/></td> 
                <td><input runat="server" id="CheckResAnswer5" type="checkbox"/></td>
            </tr>
            <tr>
                <td><input id="Answer6" runat="server" type="text" size="30"/></td> 
                <td><input runat="server" id="CheckResAnswer6" type="checkbox"/></td>
            </tr>
            </table>

            <asp:Button ID="Button1" runat="server" Text="Сохранить вопрос" OnClick="Unnamed1_Click" />
            <hr />
        </div>
        <asp:Button ID="Button2" runat="server" Text="Сохранить тест" OnClick="Update_Click" />
    </div>
</asp:Content>
