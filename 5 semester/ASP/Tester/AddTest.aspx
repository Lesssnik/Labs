<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTest.aspx.cs" Inherits="PL.AddTest"
    MasterPageFile="~/Site.Master" Theme="AddTest"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="add_test">
        <div class="part">
            Название
            <input id="NameId" runat="server" type="text" size="30"/>
            Описание
            <input id="DescrId" runat="server" type="text" size="30"/>
            Время выполнения:
            <table width="500px">
                <tr><td>Часов</td><td><input id="HourTimeId" runat="server" type="text" size="10" /></td>
                <td width="300px"><asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" ControlToValidate="HourTimeId" MinimumValue="0" MaximumValue="3">Число должно быть в диапозоне 0-3</asp:RangeValidator></td></tr>
                <tr><td>Минут</td><td><input id="MinuteTimeId" runat="server" type="text" size="10" /></td>
                <td width="300px"><asp:RangeValidator ID="RangeValidator2" runat="server" Type="Integer" ControlToValidate="MinuteTimeId" MinimumValue="0" MaximumValue="59">Число должно быть в диапозоне 0-59</asp:RangeValidator></td></tr>
                <tr><td>Секунд</td><td><input id="SecondTimeId" runat="server" type="text" size="10" /></td>
                <td width="300px"><asp:RangeValidator ID="RangeValidator3" runat="server" Type="Integer" ControlToValidate="SecondTimeId" MinimumValue="0" MaximumValue="59">Число должно быть в диапозоне 0-59</asp:RangeValidator></td></tr>
            </table>
            Тип<br />
            <asp:DropDownList ID="TypesId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypesId_SelectedIndexChanged" />
            <hr />
        </div>
        <div class="part">
            Текст вопроса
            <asp:TextBox runat="server" ID="QuestionText"></asp:TextBox>
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

            <asp:Button ID="Button1" runat="server" Text="Добавить вопрос" OnClick="Unnamed1_Click" />
            <hr />
        </div>
        <asp:Button ID="Button2" runat="server" Text="Создать" OnClick="Create_Click" />
    </div>
</asp:Content>
