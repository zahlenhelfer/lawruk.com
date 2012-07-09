<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<lawrukmvc.Models.ITitleUrl>>" %>
<%foreach (var item in Model)
      {%>
  <p><a href="<%=item.Url%>"><%=item.Title %></a></p>
    <%} %>