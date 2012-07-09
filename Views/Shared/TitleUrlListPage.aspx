<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.TitleUrlListViewModel>" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    <%=Model.Title %>
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
   <%=Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <%foreach (var item in Model.TitleUrls)
      {%>
  <p><a href="/<%=Model.Url%>"><%=item.Title %></a></p>
    <%} %>

</asp:Content>

