<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.MetroViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% = Model.CurrentMetroStation.Title %> - Realtime Metro Station Arrivals
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="metro">
    <h2><% = Model.CurrentMetroStation.Title %> - Realtime Metro Station Arrival Times</h2>
    <% = Model.CurrentMetroStation.Body %>
    </div>
    <p style="clear:both">Courtesy of <a href="http://www.wmata.com/rail/stations.cfm">wmata.com</a></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
<h3>Other Metro Stations</h3>
<ul>
    <% foreach (var metroStation in Model.MetroStations)
       { %>
    <li> <a href="/metro/<% = metroStation.Tag %>"><% = metroStation.Title%></a></li>
    <%} %>
</ul>
</asp:Content>
