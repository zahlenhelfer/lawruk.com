<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.CalendarViewModel>" %>
<%@ Import namespace="lawrukmvc.Models" %>
<%@ Import namespace="lawrukmvc.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <ul>
    <% foreach (var calendarEntry in Model.CalendarEntries)
       { %>
                
    <li><% =lawrukmvc.Helpers.Date.GetShortDisplay(calendarEntry.Date)%> - 
    <%= TitleUrl.GetLinkOrTitle(calendarEntry.Title, calendarEntry.Url)%>
    <%} %>
   </li>
</ul>
</asp:Content>