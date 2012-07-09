using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.ViewModels
{
    public class MarcTrainViewModel
    {
        public string TrainNumber { get; set; }
        public string NextStation { get; set; }
        public string EstDepart { get; set; }
        public string Status { get; set; }
        public string Delay { get; set; }
        public string LastUpdate { get; set; }
        public string Message { get; set; }

        public string DelayText
        {
            get
            {
                if (!string.IsNullOrEmpty(Delay))
                {
                    return "Delay: " + Delay;
                }
                return "On Time";
            }
        }

        public DateTime? NextStationArrival
        {
            get
            {
                return GetDate(EstDepart);
            }
        }

        public DateTime? LastUpdateDate
        {
            get
            {
                return GetDate(LastUpdate);
            }
        }

        public string LastUpdateText
        {
            get
            {
                if (LastUpdateDate.HasValue)
                    return LastUpdateDate.Value.ToString("h:mm t\\M");
                else
                    return "";
            }
        }
        
        public int MinutesToNextStation { get { return MinutesInFuture(EstDepart); } }
        public int MinutesLastUpdated { get { return -MinutesInFuture(LastUpdate); } }

        private DateTime? GetDate(string s)
        {
            try
            {
                var dateTime = DateTime.Parse(s);
                return dateTime;
            }
            catch
            {
                return null;
            }
        }

        private int MinutesInFuture(string s)
        {
            var dateTime = GetDate(s);
            var now = DateTime.Now;
            if (dateTime.HasValue)
            {
                return (int)(dateTime.Value.ToUniversalTime() - now.ToUniversalTime()).TotalMinutes;
            }
            return 0;             
        }
    }
}