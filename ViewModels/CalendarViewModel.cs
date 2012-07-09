using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class CalendarViewModel
    {
        public List<ICalendarEntry> CalendarEntries { get; set; }
        public DateTime FirstMonday{ get; set; }

        public CalendarViewModel()
        {
            this.FirstMonday = GetFirstMonday();
        }

        public DateTime GetFirstMonday()
        {
            var now = DateTime.Now;
            var dayOfWeek = (int)now.DayOfWeek;
            var daysToSubtract = (dayOfWeek + 6) % 7;
            return now.AddDays(-daysToSubtract);            
        }

        public string GetTRHTML()
        {
            var text = new System.Text.StringBuilder();            
            var thisDay = FirstMonday;
            for (int i = 0; i < 52; ++i)
            {
                text.Append("<tr>");
                for (int j = 0; j < 7; ++j)
                {                    
                    text.Append("<td>");
                    var thisDaysTitles = CalendarEntries.Where(c => c.Date.Date == thisDay.Date).Select(c=>TitleUrl.GetLinkOrTitle(c.Title, c.Url)).ToArray();                                       
                    text.Append("<span>" + thisDay.Month.ToString() + "/" + thisDay.Day.ToString() + "</span>");
                    text.Append(string.Join("<br/>", thisDaysTitles));
                    text.Append("</td>");
                    thisDay = thisDay.AddDays(1);
                }
                text.Append("</tr>");
            }
            return text.ToString();
        }
    }
}
