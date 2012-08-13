using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;
using System.Data.Objects.DataClasses;

namespace lawrukmvc.Controllers
{
    public class OlympicsController : Controller
    {
        protected lawrukEntities lawrukEntities = new lawrukEntities();
        protected lawrukmvc.Models.LawrukRepository lawrukRepository = new Models.LawrukRepository();

        protected List<string> Events;

        public ActionResult Index(string tag)
        {
            Events = new List<string>();
            Events.Add("Marathon");
            Events.Add("10K");
            Events.Add("5K");            
            var viewModel = new OlympicResultViewModel();
           
            IQueryable<OlympicResult> results;

            string eventName = tag.ToLower().Replace("top-us-olympic-", "").Replace("performances","").Replace("-", "");
           
            if (eventName.Contains("medal"))
            {
                results = this.lawrukEntities.OlympicResults.Where(o=>o.Place <= 3);
                viewModel.Title = "United States Olympic Long Distance Running Medal Performances";
            }
            else if (eventName.Contains("long"))
            {
                eventName = "";
                viewModel.ShowEvent = true;            
                results = this.lawrukEntities.OlympicResults;
                viewModel.Title = "Top United States Olympic Long Distance Running Performances";
            }
            else
            {
                viewModel.Title = "Top United States Olympic " + eventName + " Performances";
                results = this.lawrukEntities.OlympicResults.Where(o => o.Event == eventName);
            }
            results = results.OrderBy(o => o.Place).ThenByDescending(o => o.Year);
            viewModel.Results = results.ToList();
            
            viewModel.Events = Events;
            return View(viewModel);
        }



    }
}
