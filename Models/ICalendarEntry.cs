using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lawrukmvc.Models
{
    public interface ICalendarEntry : ITitleUrl
    {
        DateTime Date { get; }
        string Title { get;  }
        string Url { get; }
    }
}
