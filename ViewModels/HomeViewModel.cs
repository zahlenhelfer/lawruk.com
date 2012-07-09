using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Helpers;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class HomeViewModel
    {
        public List<HomeButton> HomeButtons { get; set; }
    }

    public class HomeButton
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public HomeButton(string title, string url, string imageUrl, string description)
        {
            Title = title;
            Url = url;
            ImageUrl = imageUrl;
            Description = description;
        }      
    }
}