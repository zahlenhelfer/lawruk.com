<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.BlogPostViewModel>" %>

<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
   <%=Model.BlogPost.Title %> - Blog | Lawruk.com
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Model.BlogPost.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <p class="blog-detail-date">Date: <%=Model.DisplayDate %></p>
    <div id="body">
    <%=Model.BlogPost.Body %>
    </div>    
    <%if (!lawrukmvc.Helpers.Mobile.ShowMobileSite())
      { %>
    <div id="facebook-comments">
        <h3>Facebook Comments</h3>
        <div id="fb-root"></div>
        <script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
        <fb:comments href="http://www.lawruk.com/blog/<%=Model.BlogPost.Id %>/facebook"></fb:comments>
    </div> 
    <%} %>   
</asp:Content>

<asp:Content ID="rightContent" ContentPlaceHolderID="RightContent" runat="server">
    <h3>Other Posts</h3>
    <%Html.RenderPartial("TitleUrlList", Model.RelatedPosts.Cast<lawrukmvc.Models.ITitleUrl>().ToList());%>
</asp:Content>
