<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.BlogPostListViewModel>" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
   Blog
</asp:Content>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    Blog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="blog-list"> 
    <ul>
     <% foreach (var viewModel in Model.BlogPostViewModels) { %>
        <li style="height:80px;">
        <img src="<%=viewModel.ThumbnailUrl %>" height="75" width="100" style="float:left;" />
        <a href="<%=viewModel.Url%>"><%=viewModel.BlogPost.Title %></a><br />       
        <div class="date">Date: <%= viewModel.DisplayDate%></div>
        <%if (Model.EditMode)
          {%>
          <%=viewModel.EditLink%>
        <%} %>
        
        </li>
    <%} %> 
    </ul>
</div>
</asp:Content>
