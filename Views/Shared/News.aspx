<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.NewsViewModel>" %>
<%@ Import namespace="lawrukmvc.Helpers" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    News: <% = Model.CurrentRSSFeed.Title %>
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    News: <% = Model.CurrentRSSFeed.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%Html.RenderPartial("RSSList", Helpers.GetRSSList(Model.CurrentRSSFeed.Url, 20));%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
<h3>Other News</h3>
<ul>
    <% foreach (var rssFeed in Model.RSSFeeds)
       { %>
    <li> <a href="/news/<% = rssFeed.Tag %>"><% = rssFeed.Title %></a></li>
    <%} %>
</ul>
</asp:Content>