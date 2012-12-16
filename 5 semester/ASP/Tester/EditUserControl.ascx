<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUserControl.ascx.cs"
    Inherits="PresentationLayer.EditUserControl"%>

<div id="edit_user" style="width:210px; padding-top : 50px;	padding-left : 50px;">
    Имя
    <input id="NameId" runat="server" type="text" size="30">
    Фамилия
    <input id="SurnameId" runat="server" type="text" size="30">
    Город
    <input id="CityId" runat="server" type="text" size="30">
    <hr />
    Старый пароль
    <input id="OldPassword" runat="server" type="password" size="30">
    Новый пароль
    <input id="NewPassword" runat="server" type="password" size="30">
    <asp:Button ID="Button1" runat="server" OnClick="Update_User" Text="Сохранить изменения" />
</div>
