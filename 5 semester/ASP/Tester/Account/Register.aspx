<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="PresentationLayer.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center><h2>
        Регистрация
    </h2>
    <span class="failureNotification">
        <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
    </span>
    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" /></center>
    <center>
         <table>
            <tr>
                <td><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                <td><asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label></td>
                <td><asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox></td>
                <td><asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="Email" ErrorMessage="Invalid Email Format" 
                    ToolTip="Invalid Email Format" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                <td><asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan=2><asp:Button ID="CreateUserButton" runat="server" OnClick="Register_User" Text="Создать пользователя"
                ValidationGroup="RegisterUserValidationGroup" /></td>
            </tr>
        </table>
    </center>
</asp:Content>