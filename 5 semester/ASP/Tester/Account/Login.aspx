<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="PresentationLayer.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center>
        <h2>Авторизация</h2>
    <span class="failureNotification">
        <asp:Label ID="FailureText" runat="server"></asp:Label>
    </span>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="LoginUserValidationGroup" /></center>
    <center><table>
        <tr>
            <td><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label></td>
            <td><asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
            <td><asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr class="submitButton">
        <td colspan=2><center><asp:Button ID="LoginButton" runat="server" OnClick="Login_Click" Text="Войти" ValidationGroup="LoginUserValidationGroup" /></center></td>
        </tr>
    </table></center>
</asp:Content>
