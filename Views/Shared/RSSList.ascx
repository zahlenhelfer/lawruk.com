<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<lawrukmvc.ViewModels.SyndicationItemViewModel>>" %>
<div class="rss-list">
<ul class="rss-list">
<%foreach (lawrukmvc.ViewModels.SyndicationItemViewModel item in Model) { %>
    <li>
        <a href="<% =item.Url %>"><% =item.Title %></a><br />
        <div class="date"><% = item.DisplayDate %></div>
        <%if (item.DisplaySummary)
          { %>
        <% = item.Summary%>    
        <%} %>
    </li>
    <%} %>
</ul>
</div>