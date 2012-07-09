<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import namespace="lawrukmvc.Helpers" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    Recent Runs
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    Recent Runs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
<%Html.RenderPartial("RSSList", Helpers.GetRSSList("http://connect.garmin.com/feed/rss/activities?feedname=Garmin%20Connect%20-%20jimlawruk&owner=jimlawruk", 20));%>
</asp:Content>

