<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.RaceResult>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Race Result</h2>
    <% using (Html.BeginForm())
       { %>                        
            <h3>Title:</h3>
            <%: Html.TextBox("title",Model.Title)%>
            <h3>Date:</h3>
            <%: Html.TextBox("date", Model.Date)%>  
            <h3>Url:</h3>
            <%: Html.TextBox("urllink", Model.Url)%> 
            <h3>Distance:</h3>
            <%: Html.TextBox("distance", Model.Distance)%>      
            <h3>City:</h3>
            <%: Html.TextBox("city", Model.City)%>      \
            <h3>State:</h3>
            <%: Html.TextBox("state", Model.State)%>   
            <h3>Seconds:</h3>
            <%: Html.TextBox("time", lawrukmvc.Helpers.Date.GetHHMMSSFromSeconds(Model.Seconds))%>           
            <h3>Submit:</h3>
            <input type="submit" value="Submit" />
       <%} %>
</asp:Content>