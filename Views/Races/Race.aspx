<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.RaceViewModel>" %>
<%@ Import namespace="lawrukmvc.ViewModels" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
   <%= Model.Race.Date.Year %> <%= Model.Race.Title %> Race Results    
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Race.Date.Year %> <%= Model.Race.Title %> Race Results    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3><%= Model.DisplayDate %></h3>
    <%= Model.Race.GetText() %>

</asp:Content>

<asp:Content ID="Right" ContentPlaceHolderID="RightContent" runat="server">
<ul>
<% foreach (RaceViewModel race in Model.RelatedRaces) { %>  
   <li><a href="<%=race.Url %>"><%=race.Race.Title %></a></li>
<%} %>
</ul>
</asp:Content>