using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Helpers
{
    public static class Date
    {
        public static string GetLongDisplay(DateTime datetime)
        {
            return datetime.ToString("MMMM dd, yyyy");
        }

        public static string GetShortDisplay(this DateTime datetime)
        {
            return datetime.ToString("MMM dd, yyyy");
        }

        public static string GetMonthName(int month)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        public static string GetHHMMSSFromSeconds(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            if (t.Hours > 0)
                return string.Format("{0:00}:{1:00}:{2:00}", t.Hours, t.Minutes, t.Seconds);
            else
                return string.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);
        }
    }
}