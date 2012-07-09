<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RachelEmmett.master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import namespace="lawrukmvc.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Weather
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p><%Html.RenderPartial("RSSList", Helpers.GetRSSList("http://weather.yahooapis.com/forecastrss?w=2418046", 1));%></p>
    <p><%Html.RenderPartial("RSSList", Helpers.GetRSSList("http://weather.yahooapis.com/forecastrss?w=561075", 1));%></p>   
</asp:Content>

