using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.ViewModels
{
    public class ThumbnailListViewModel
    {
        public bool EditMode { get; set; }
        public List<ListItem> Items { get; set; }
    }    
}