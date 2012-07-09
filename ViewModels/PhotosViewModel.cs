using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.ViewModels
{
    public class PhotosViewModel
    {        
        public string BaseUrl { get; set; }
        public string ConsistentTag { get; set; }
        public string OtherTags { get; set; }
        public string Title { get; set; }
        public Dictionary<string, string> TagListOptions { get; set; }
    }
}