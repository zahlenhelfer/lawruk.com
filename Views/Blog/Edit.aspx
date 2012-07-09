<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" ValidateRequest="false" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.BlogPost>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Blog</h2>
    <% using (Html.BeginForm())
       { %>                        
            <h3>Title:</h3>
            <%: Html.TextBox("title",Model.Title)%>
            <h3>Date:</h3>
            <%: Html.TextBox("date", Model.Date)%>
            <h3>Tags:</h3>
            <%: Html.TextBox("tags", "")%>
            <h3>Flickr Image Url:</h3>
            <%: Html.TextBox("flickrimageurl", Model.FlickrImageUrl)%>
            <h3>Body:</h3>
            <%: Html.TextArea("body", Model.Body)%>
            <h3>Submit:</h3>
             <input type="submit" value="Submit" />
       <%} %>
</asp:Content>


