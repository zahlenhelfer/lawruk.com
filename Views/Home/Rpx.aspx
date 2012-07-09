<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rpx
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>You are logged in as:</h2>
    <h3>Welcome <%=Session["displayName"]%> </h3>
    <p>Identifier:<%=Session["identifier"]%></p>
    <p>Preferred Username:<%=Session["preferredUsername"]%></p>
    <p>Verified Email:<%=Session["verifiedEmail"]%></p>    
    <p>XML:<%=Session["rpxXml"]%></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadTitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="LogoContent" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="TopMenuContent" runat="server">
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content10" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
