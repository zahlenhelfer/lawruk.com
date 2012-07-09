<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
         
    <%= ViewData["Data"] %>
    
</asp:Content>
