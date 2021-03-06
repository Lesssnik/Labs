﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PresentationLayer.Admin" Theme="Admin"%>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--[if IE]>  
		<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>  
	<![endif]-->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Default.css" type="text/css" />
    <title>Tester - система тестирования знаний</title>
</head>
<body>
    <form id="Form1" runat="server">
        <header>
            <asp:DropDownList runat="server" ID="Info" CssClass="info" AutoPostBack="true" OnSelectedIndexChanged="Info_SelectedIndexChanged"/>
            <div style="float : right;"><asp:Button ID="Button1" runat="server" CssClass="exit_button" OnClick="Exit_Click" Text="Выйти"/></div>
        </header>
        <section>
            <%if (Info.SelectedIndex == 0)
              {%>
            <asp:GridView ID="RepeaterTests" runat="server" BorderWidth=1 AllowPaging=true EditRowStyle-BorderWidth=1 AutoGenerateEditButton=true AutoGenerateDeleteButton=true AutoGenerateColumns=false GridLines=None PageSize=20 PagerSettings-Mode=Numeric OnPageIndexChanging="Page_IndexChanging" OnRowEditing="RepeaterTests_RowEditing" OnRowDeleting="RepeaterTests_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-BorderWidth=1 ItemStyle-CssClass="test">
                        <ItemTemplate>                            
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%}
              else
              {%>
              <asp:GridView ID="RepeaterUsers" runat="server" BorderWidth=1 AllowPaging=true AutoGenerateColumns=false PageSize=20 PagerSettings-Mode=Numeric OnPageIndexChanging="Page_IndexChanging">
                <Columns>
                    <asp:TemplateField ItemStyle-BorderWidth=1 ItemStyle-CssClass="test">
                        <ItemTemplate>                            
                            <%# Eval("Login") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-BorderWidth=1 ItemStyle-CssClass="test">
                        <ItemTemplate>                            
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/UserStatistic.aspx?user=" + Eval("Login") %>' Text="Посмотреть статистику" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%} %>
        </section>
    <div class="clear">
    </div>
    </form>
</body>
</html>