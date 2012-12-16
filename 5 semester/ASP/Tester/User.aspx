<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="PL.User" 
MasterPageFile="~/Site.Master" Theme="User"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%if (user != null)
      { %>
    <h1><%# user.Login %></h1>
    <h2><%# user.Name + " " + user.Surname %></h2>
    <h3><%# user.City %></h3>
    <a href="MyStatistic.aspx">Моя статистика</a><br />
    <a href="MyTests.aspx">Мои тесты</a><br />
    <%if (Session["UserLogin"] != null && Session["UserLogin"].ToString().CompareTo(user.Login) == 0)
      { %>
    <a href='<%# "EditUser.aspx?=" + user.Login %>'>Редактировать данные</a>
    <%} %>
    <%}
      else Response.Redirect("404.aspx");%>

</asp:Content>