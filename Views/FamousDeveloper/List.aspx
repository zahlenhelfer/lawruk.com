<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<lawrukmvc.ViewModels.FamousDeveloperViewModel>>" %>

<asp:Content ID="Content11" ContentPlaceHolderID="HeadTitleContent" runat="server">
	Famous <%=ViewData["subTitle"] %> Developers
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Famous <%=ViewData["subTitle"] %> Developers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <%Html.RenderPartial("TitleUrlList", Model.Cast<lawrukmvc.Models.ITitleUrl>().ToList()); %>

</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="RightContent" runat="server">
<%Html.RenderPartial("Ads"); %>
</asp:Content>

<asp:Content ID="Content10" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
