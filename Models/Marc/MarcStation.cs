using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Models.Marc
{
    public class MarcStation
    {
        public string Title { get; set; }
        public List<MarcStop> MarcStops { get; set; }

       
    }
}