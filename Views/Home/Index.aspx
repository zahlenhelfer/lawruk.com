<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import namespace="lawrukmvc.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadTitleContent" runat="server">
    Lawruk.com
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
   Welcome to Lawruk.com
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    
    <div class="col-left">
    <h2>Steeler News</h2>
    <%Html.RenderPartial("RSSList", Helpers.GetRSSList("http://www.post-gazette.com/rss/steelers.xml", 5, false));%>
    </div>
    <div class="col-right">
    <h2>Golf News</h2>
    <%Html.RenderPartial("RSSList", Helpers.GetRSSList("http://sports.yahoo.com/golf/rss.xml", 5, false));%>
    </div>
    <div style="clear:both;">
    <h2>About this Site</h2>
    <p>Lawruk.com started back in 2001 as a place for me to learn Web development.  
    Back then it was static pages with some hacky JavaScript, PHP, and inline CSS.  
    It was re-built a few more times with Classic ASP and ASP.NET.
    This time I used ASP.NET MVC and hosted it on an Amazon EC2 instance. 
    Like in 2001, it still has recent Steeler news, random photos, hacky JavaScript and a bit of inline CSS.</p>
    </div>
</asp:Content>
<asp:Content ID="right" runat="server" ContentPlaceHolderID="RightContent">
    <img src="http://www.gravatar.com/avatar/23ed258730d5bc9526140ee261b2bea3?s=128&d=identicon&r=PG" alt="Jim Lawruk" style="float:left;" />
    <p id="description">
      Hello, Welcome to my Web site.  I am a Web developer living in Bethesda, MD with my wonderful wife and daughter.  
      
      You can contact me via: <a href="http://www.facebook.com/jameslawruk">Facebook</a> or 
      <a href="http://www.linkedin.com/in/lawruk">LinkedIn</a>              
    </p>

    <script type="text/javascript">
        var rpxJsHost = (("https:" == document.location.protocol) ? "https://" : "http://static.");
        document.write(unescape("%3Cscript src='" + rpxJsHost +
"rpxnow.com/js/lib/rpx.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
    RPXNOW.overlay = true;
    RPXNOW.language_preference = 'en';
</script>


</asp:Content>
