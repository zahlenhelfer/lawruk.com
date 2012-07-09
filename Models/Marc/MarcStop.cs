using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Models.Marc
{
    public class MarcStop
    {
        public MarcStation Station { get; set; }
        public DateTime Time { get; set; }
        public MarcTrain Train { get; set; }
    }
}