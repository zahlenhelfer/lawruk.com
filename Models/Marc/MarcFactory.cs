using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Models.Marc
{
    public class MarcFactory
    {
        private MarcStation CurrentStation {get;set;}
        private List<MarcStop> CurrentStops { get; set; }    
        public List<MarcStop> GetTrainsByStation(string urlTitle)
        {
            CurrentStation = new MarcStation() {Title = "Garrett-Park"};
            CurrentStops = new List<MarcStop>();
            
            switch (urlTitle)
            {
                case "garrettpark":
                    AddStopPM("p871", 2,1);
                    AddStopPM("p873", 3, 56);
                    AddStopPM("p893", 5, 39);
                    AddStopPM("p879", 5, 58);
                    AddStopPM("p881", 6, 23);
                    AddStopPM("p895", 6, 53);
                    AddStopPM("p883", 6, 37);
                    break;
            }
            return CurrentStops;
        }

        private void AddStopPM(string trainNumber, int hour, int minute)
        {
            if (hour == 12)
            {
                hour = 0;
            }
            AddStop(trainNumber, hour + 12, minute);
        }

        private void AddStop(string trainNumber, int hour, int minute)
        {            
            var train = new MarcTrain() {Number = trainNumber.ToUpper()};
            var now = DateTime.Now;
            var time = new DateTime(now.Year,now.Month,now.Day, hour + 12,minute, 0);
            var stop = new MarcStop();
            stop.Station = CurrentStation;
            stop.Time = time;
            stop.Train = train;
            CurrentStops.Add(stop);
        }

       

    }
}