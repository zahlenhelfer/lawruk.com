using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;

namespace lawrukmvc.Controllers
{
    public class EnergyController : Controller
    {
        //
        // GET: /Energy/

        public ActionResult Index(string tag)
        {
            //TODO Refactor and combine with News
            tag = tag.ToLower();
            var data = new List<TagTitleUrl>()
            {             
             { new TagTitleUrl("electricity-prices-by-year", "Electicity Prices By Year", "http://www.eia.doe.gov/cneaf/electricity/epm/table5_3.html")},
             { new TagTitleUrl("electricity-prices-by-state","Electicity Prices By State", "http://www.eia.doe.gov/electricity/epm/table5_6_a.html")},
            { new TagTitleUrl("electricity-by-energy-source","Electicity By Energy Source", "http://www.eia.doe.gov/cneaf/electricity/epm/table1_1.html")}
            
             
            };
            if (tag == "")
            {
                var model = new ViewModels.TagTitleUrlListViewModel();
                model.Title = "Energy";
                model.BaseUrl = "energy";
                model.TagTitleUrls = data;
                return View("TagTitleUrlList", model); 
            }
            var found = data.Find(r => r.Tag == tag);
            ViewData["title"] = found.Title;
            ViewData["data"] = Helpers.HTMLParser.GetTable(found.Url, 2, 5) +
                "<p>Source:<a href='" + found.Url + "'>Energy Information Administration</a>";
                
            return View("TitleData");
        }

    }
}
