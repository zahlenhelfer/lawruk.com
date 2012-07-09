<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IQueryable<lawrukmvc.Models.Photo>>" %>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
    Photos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    
    <p><input id="txt" type="text" /> <input id="btn" type="button" value="Search Tags" /></p>
    <div class="thumbnail-list">
    <% foreach (var photo in Model) { %>
        <%= photo.Url %><br />    
    <%} %> 
    </div>
</asp:Content>
