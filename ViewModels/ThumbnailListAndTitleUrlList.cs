using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.ViewModels
{
    public class ThumbnailListAndTitleUrlList
    {
        public string Title { get; set; }
        public ThumbnailListViewModel ThumbnailListViewModel { get; set; }
        public TitleUrlListViewModel TitleUrlListViewModel { get; set; }
    }
}
