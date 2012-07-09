<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.PhotosViewModel>" %>
<%@ Import namespace="lawrukmvc.Helpers" %>
      
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
   Photos<%=Model.Title %>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">      
        
        <%Html.RenderPartial("PhotosList", Helpers.GetPhotos(Model.ConsistentTag + "," + Model.OtherTags, 20));%>
       
       
</asp:Content>
<asp:Content ID="rightContent" ContentPlaceHolderID="RightContent" runat="server">
<div class="photos-right">
       
        <ul>
        <%foreach (string key in Model.TagListOptions.Keys) {%>
         <li><a href="<%= Model.BaseUrl + "/" + Model.TagListOptions[key]%>"><%= key%></a></li>
            <%} %>
        </ul>    
       </div>
</asp:Content> 