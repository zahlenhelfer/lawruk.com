<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.Video>" %>

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
            <h3>YouTubeId:</h3>
            <%: Html.TextBox("youtubeid", Model.YouTubeId)%>
            <h3>Submit:</h3>
             <input type="submit" value="Submit" />
       <%} %>
</asp:Content>

