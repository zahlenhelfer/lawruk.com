using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Models
{
    public class TagTitleUrl : TitleUrl
    {
        public string Tag { get; set; }       

        public TagTitleUrl(string tag, string title, string url)
        {
            Tag = tag; Title = title; Url = url;
        }
    }

}