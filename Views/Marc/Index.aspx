<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lawrukmvc.ViewModels.MarcLineViewModel>" %>


<asp:Content ID="headTitle" ContentPlaceHolderID="HeadTitleContent" runat="server">
    MARC Train Live - <%=Model.Title %> Line
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
     MARC Train Live - <%=Model.Title %> Line
</asp:Content>
<asp:Content ID="meta" ContentPlaceHolderID="HeadContent" runat="server">
<META HTTP-EQUIV="Refresh" content="60">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul>
<%foreach (lawrukmvc.ViewModels.MarcTrainViewModel train in Model.Trains)
  { %>
  <li>
  Train: <%=train.TrainNumber %> <%=train.DelayText %><br />
  Next Station: <%=train.NextStation %> &nbsp;<%=train.MinutesToNextStation.ToString() %> min &nbsp;<%=train.EstDepart %> <br />
  Last Updated: <%=train.MinutesLastUpdated%> min ago &nbsp;<%=train.LastUpdateText %>
  </li>
<%} %>
</ul>
</asp:Content>
<asp:Content  ID="TopMenuContent" ContentPlaceHolderID="TopMenuContent" runat="server">
<ul>
<li><a href="/marc/brunswick">Brunswick Line</a></li>
<li><a href="/marc/penn">Penn Line</a></li>
<li><a href="/marc/camden">Camden Line</a></li>
</ul>
</asp:Content>
<asp:Content  ID="Footer" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
