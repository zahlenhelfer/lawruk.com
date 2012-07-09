<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<lawrukmvc.ViewModels.PhotoViewModel>>" %>

<script type="text/javascript">

    function photoIncrement(numToAdd) {
        var photoTotal = $('#photoTotal').val();
        var currentImgIndex = $('input:hidden[name=currentImgIndex]').val();

        $("#img" + currentImgIndex).hide(1);
        currentImgIndex = (parseInt(currentImgIndex) + parseInt(numToAdd) + parseInt(photoTotal)) % photoTotal;
        $('input:hidden[name=currentImgIndex]').val(currentImgIndex);
        $("#img" + currentImgIndex).show(1);
        $("#countDisplay").html((((currentImgIndex + parseInt(photoTotal)) % photoTotal) + 1) + " of " + photoTotal);

    }	
		
</script>

<div style="width:530px; float:left; ">    
    <div class="flickrPhotos" style="height:380px;" >
        <%foreach (lawrukmvc.ViewModels.PhotoViewModel photo in Model)
          { %>
        <div><img id="img<%=photo.Index %>" src="<%= photo.Url %>" alt="" style="display:<%= photo.CSSDisplay %>" /></div>    
        <%} %>
    </div>
 
     <div style="text-align:left; padding-bottom:10px;">
        <a href="JavaScript:photoIncrement(-1);" class="photoLinks"><< Previous</a>&nbsp;&nbsp;
            <a href="JavaScript:photoIncrement(1);" class="photoLinks">Next >></a>
        
            <span id="countDisplay">1 of <% = Model.Count%></span>
    </div>
</div>
<input name="photoTotal" type="hidden" id="photoTotal" value="<% = Model.Count%>" />
 <input type="hidden" name="currentImgIndex" value="0"/> 