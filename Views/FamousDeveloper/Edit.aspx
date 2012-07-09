<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.FamousDeveloper>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       { %>                        
            <h3>First Name:</h3>
            <%: Html.TextBox("FirstName",Model.FirstName)%>
            <h3>Last Name:</h3>
            <%: Html.TextBox("LastName", Model.LastName)%>
            <h3>Midle Name:</h3>
            <%: Html.TextBox("MiddleName", Model.MiddleName)%>
            <h3>Nicname:</h3>
            <%: Html.TextBox("Nickname", Model.Nickname)%>
            <h3>Summary:</h3>
            <%: Html.TextArea("Summary", Model.Summary)%>
            <h3>Websites:</h3>
            <%: Html.TextBox("Websites", Model.Websites)%>
            <h3>WikipediaUrl:</h3>
            <%: Html.TextBox("WikipediaUrl", Model.WikipediaUrl)%>
            <h3>StackOverflowUrl:</h3>
            <%: Html.TextBox("StackOverflowUrl", Model.StackOverflowUrl)%>
            <h3>PhotoUrl:</h3>
            <%: Html.TextBox("PhotoUrl", Model.PhotoUrl)%>
            <h3>FacebookUrl:</h3>
            <%: Html.TextBox("FacebookUrl", Model.FacebookUrl)%>
            <h3>TwitterUrl:</h3>
            <%: Html.TextBox("TwitterUrl", Model.TwitterUrl)%>            
            <h3>Books:</h3>
            <%: Html.TextBox("Books", Model.Books)%>
            <h3>Primary Language:</h3>
            <%: Html.TextBox("PrimaryLanguage", Model.PrimaryLanguage)%>
            

            <h3>Submit:</h3>
             <input type="submit" value="Submit" />
       <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadTitleContent" runat="server">
Edit Famous Developer
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="LogoContent" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="TopMenuContent" runat="server">
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="MenuContent" runat="server">
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>

<asp:Content ID="Content10" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
