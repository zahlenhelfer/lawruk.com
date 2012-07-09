<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.FamousDeveloperViewModel>" %>
<%@ Import Namespace="lawrukmvc.Helpers" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadTitleContent" runat="server">
	<%=Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
    <td class="col1">
        <%=Helpers.Img(Model.FamousDeveloper.PhotoUrl)%>
        <%=Model.ProfileLinks %>
    </td>
    <td class="col2">
        <h2><%=Model.Title %></h2>
        <%=Helpers.P("Nickname", Model.FamousDeveloper.Nickname) %>
        <p><%=Model.FamousDeveloper.Summary %></p>
        <%=Helpers.UrlList(Model.FamousDeveloper.Books) %>
        <%=Helpers.UrlList(Model.FamousDeveloper.Websites) %>
        <%=Helpers.P("Primary Langauge", Model.FamousDeveloper.PrimaryLanguage) %>
    </td>
    </tr>
    </table>   
    <%=Model.MoreDevelopersOfTheSameLanguage%>
    <p><a href="/famousdevs">Full List</a></p>
   
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="RightContent" runat="server">
<%Html.RenderPartial("Ads"); %>
</asp:Content>

