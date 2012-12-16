<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginDisplayControl.ascx.cs"
    Inherits="PresentationLayer.LoginDisplayControl" %>

<div class="loginDisplay">
    <%if (Session["UserLogin"] != null)
      { %>
    <div id="header_menu">
        <%if ("Admin".CompareTo(Session["UserLogin"].ToString()) == 0)
          {%>
        <div>
            <a href="Admin.aspx">
                <%# Session["UserLogin"] %></a></div>
        <%}
          else
          {%>
        <div>
            <a href="User.aspx">
                <%# Session["UserLogin"] %></a></div>
        <%} %>
        <div>
            <a href="Search.aspx">Найти тест</a></div>
        <div>
            <a href="AddTest.aspx">Добавить тест</a></div>
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Exit_Click" Text="Выйти" /></div>
    </div>
    <%}
      else
      {%>
    <a href="~/Account/Login.aspx" id="A1" runat="server">Войти</a><br />
    <a href="~/Account/Register.aspx" id="A2" runat="server">Зарегистрироваться</a>
    <%} %>
</div>
