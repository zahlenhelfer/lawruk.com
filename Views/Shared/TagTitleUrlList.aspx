<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.TagTitleUrlListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Model.Title %></h2>
    <%foreach (var item in Model.TagTitleUrls)
      {%>
  <p><a href="/<%=Model.BaseUrl %>/<%=item.Tag %>"><%=item.Title %></a></p>
    <%} %>

</asp:Content>

