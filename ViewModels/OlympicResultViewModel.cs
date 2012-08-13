using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.ViewModels
{
    public class OlympicResultViewModel
    {
        public string Title { get; set; }
        public List<OlympicResult> Results { get; set; }
        public List<string> Events { get; set; }
        public bool ShowEvent { get; set; }
    }
}
