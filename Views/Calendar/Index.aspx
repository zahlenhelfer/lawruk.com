<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.CalendarViewModel>" %>
<%@ Import namespace="lawrukmvc.Models" %>
<%@ Import namespace="lawrukmvc.Helpers" %>
<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    Calendar
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    Calendar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <thead>
    <tr>
        <th>Monday</th>
        <th>Tuesday</th>
        <th>Wednesday</th>
        <th>Thursday</th>
        <th>Friday</th>
        <th>Saturday</th>
        <th>Sunday</th>
    </tr>
    </thead>
    <tbody>
    <%=Model.GetTRHTML()%>
    </tbody>
    </table>
</asp:Content>


