using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class TagsViewModel
    {
        public bool Edit { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }

    public class TagViewModel
    {
        public lawrukmvc.Tag Tag {get;set;}

        public TagViewModel(Tag tag)
        {
            Tag = tag;
        }
    }
}