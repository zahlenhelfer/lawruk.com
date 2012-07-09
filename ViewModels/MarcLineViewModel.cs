using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.ViewModels
{
    public class MarcLineViewModel
    {
        public string Title { get; set; }
        public string TableText { get; set; }
        public List<MarcTrainViewModel> Trains { get; set; }
    }
}