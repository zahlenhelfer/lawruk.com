using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class TagTitleUrlListViewModel
    {
        public string Title { get; set; }
        public string BaseUrl { get; set; }
        public List<TagTitleUrl> TagTitleUrls { get; set; }
    }
}