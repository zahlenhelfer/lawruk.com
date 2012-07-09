using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class RaceViewModel
    {
        public Race Race { get; private set; }
        public List<RaceViewModel> OtherYears { get; set; }
        public List<RaceViewModel> RelatedRaces { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Distance { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateTime { get; set; }

        public int Id {get;set;}
        public bool Edit { get; set; }
        public string TimeText { get;set;}

        public RaceViewModel(Race race)
        {
            string trip = "1-3 of 3 trip";
            string[] array = trip.Split(' ');
            int theNumberYouWant = int.Parse(array[2]);

            this.Race = race;
            this.Title = race.Title;
            this.Url = "/races/" + this.Race.Filename;
            this.Distance = race.Distance;
            this.City = race.City;
            this.State = race.State;
            this.DateTime = Race.Date;
            this.RelatedRaces = new List<RaceViewModel>();
        }

        public RaceViewModel(RaceResult raceResult)
        {
            this.Id = raceResult.Id;
            this.Title = raceResult.Title;
            this.Url = raceResult.Url;
            this.Distance = raceResult.Distance;
            this.City = raceResult.City;
            this.State = raceResult.State;
            this.DateTime = raceResult.Date;
            this.TimeText = raceResult.Seconds > 0 ? Helpers.Date.GetHHMMSSFromSeconds(raceResult.Seconds): "";
            this.RelatedRaces = new List<RaceViewModel>();
        }

        public string DisplayDate
        {
            get
            {
                return Helpers.Date.GetShortDisplay(this.DateTime);
            }
        }


        public string EditLink
        {
            get
            {
               if (Edit && Id > 0) 
               {
                 return "<a href=\"/races/edit/" + Id + "\">Edit</a>";
               }
               return "";
            }
        }
        

    }
}