using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Configuration;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;
using lawrukmvc.Helpers;
using System.Data;
using System.Data.Objects.DataClasses;

namespace lawrukmvc.Controllers
{

    public class RacesController : BaseController
    {
        
        public ActionResult Results()
        {            
            return View(GetRacesByDateDescending());
        }      

        private List<RaceViewModel> GetRacesByDateDescending()
        {
            var races = GetRaces();
            races = races.OrderByDescending(r => r.DateTime).ToList();
            return races;
        }

        public ActionResult Race(string urlTitle, string year)
        {
            var races = GetRaces();
            var filteredRaces = races.Where(r => r.Race.Title.ToUrl() == urlTitle);

            RaceViewModel race = null;
            if (year != "")
            {
                race = filteredRaces.First(r => r.Race.Date.Year == int.Parse(year));
            }
            else
            {
                race = filteredRaces.OrderByDescending(r => r.Race.Date.Year).First();
            }
            return View(race);
        } 

        public List<RaceViewModel> GetRaces()
        {
            var races = new List<RaceViewModel>();
            var di = new DirectoryInfo(WebConfigurationManager.AppSettings["RootDirectory"] + "\\Races");
            foreach (FileInfo fi in di.GetFiles())
            {
                try
                {
                    string name = fi.Name.ToLower();
                    if (name.Contains("-allison") || name.Contains("-none"))
                    {
                        continue;
                    }
                    Race race = new Race(fi.Name);
                    string[] array = fi.Name.Split('-');
                    int year = int.Parse(array[0].Substring(0, 4));
                    int month = int.Parse(array[0].Substring(4, 2));
                    int day = int.Parse(array[0].Substring(6, 2));
                    race.Date = new DateTime(year, month, day);
                    race.Distance = array[1];
                    race.Title = array[2].Replace("_", " ");
                    race.City = array[3].Replace("_", " ");
                    string state = array[4];
                    if (state.Contains("."))
                    {
                        state = state.Substring(0, state.IndexOf('.'));
                    }
                    race.State = state;
                    races.Add(new RaceViewModel(race));
                }
                catch { }
            }

            var raceResults = lawrukEntities.RaceResults;
            foreach (RaceResult raceResult in raceResults)
            {
                races.Add(new RaceViewModel(raceResult));
            }

            return races;
        }

        public override EntityObject NewItem()
        {
            return new RaceResult();
        }

        public override EntityObject GetItem(int id)
        {
            return lawrukEntities.RaceResults.First(r => r.Id == id);     
        }

        public override object GetDetailModel(int id)
        {
            throw new NotImplementedException();
        }

        public override EntityObject PopulateItem(EntityObject item)
        {
            RaceResult raceResult = item as RaceResult;
            raceResult.Title = Request.Params["title"];
            raceResult.Date = DateTime.Parse(Request.Params["date"]);
            raceResult.Url = Request.Params["urllink"];
            raceResult.Distance = Request.Params["distance"];
            raceResult.City = Request.Params["city"];
            raceResult.State = Request.Params["state"];
            string time = Request.Params["time"];
            if (!string.IsNullOrEmpty(time))
            {                
                int[] ssmmhh = {0,0,0};
                var hhmmss = time.Split(':');
                var reversed = hhmmss.Reverse();
                int i = 0;
                reversed.ToList().ForEach(x=> ssmmhh[i++] = int.Parse(x));                           
                raceResult.Seconds = (int)(new TimeSpan(ssmmhh[2], ssmmhh[1], ssmmhh[0])).TotalSeconds;   
            }
            return raceResult;
        }

        public override object GetListModel(bool editMode)
        {
            var races = GetRacesByDateDescending();
            races.ForEach(r => r.Edit = editMode);
            return races;
        }

        protected override string ListView
        {
            get { return "Results"; }
            set { return;  } 
        }

        
       
    }//class
}//namespace
