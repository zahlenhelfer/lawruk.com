using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class CalendarEntryViewModel : ICalendarEntry
    {
        public CalendarEntry CalendarEntry { get; set; }        

        public string DisplayDate
        {
            get { return this.CalendarEntry.Date.GetShortDisplay(); }
        }

        public string Url { get; set; }

        public CalendarEntryViewModel(CalendarEntry calendarEntry)
        {
            this.CalendarEntry = calendarEntry; 
            this.Url = this.CalendarEntry.Url;
        }

        public string Title
        {
            get { return CalendarEntry.Title; }
        }

        public DateTime Date { get { return this.CalendarEntry.Date; } }
    }
}