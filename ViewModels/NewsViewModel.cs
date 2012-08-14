using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;

namespace lawrukmvc.ViewModels
{
    public class NewsViewModel
    {       
        public TagTitleUrl CurrentRSSFeed { get; set; }
        public List<TagTitleUrl> RSSFeeds { get; set; }
        public TitleUrlListViewModel TitleUrlListViewModel { get; set; }
    }

}