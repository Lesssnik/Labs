<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PresentationLayer.EditUser" 
MasterPageFile="~/Site.Master" Theme="EditUser"%>
<%@ Register TagPrefix="my" TagName="UC" Src="~/EditUserControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <my:UC runat="server" />
</asp:Content>