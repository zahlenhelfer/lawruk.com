using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class ListItem : ITitleUrl
    {
        public int Id {get;set;}
        public string Title { get; set; }
        public string UrlBasePath { get; set; }
        public DateTime Date { get; set; }
        public virtual string ThumbnailUrl { get; set; }
        public string Summary { get; set; }

        public ListItem() { }

        //public ListItem(string type, int id, string title)
        //{
        //    Type = type;
        //    Id = id;
        //    Title = title;            
        //}

        //public ListItem(string type, int id, string title, DateTime date)
        //    : this(type, id, title)
        //{
        //    Date = date;
        //}

        public string Url 
        {
            get
            {
                return "/" + UrlBasePath.ToLower() + "/" + Id.ToString() + "/" + Title.ToUrl();
            }
        }


        public string DisplayDate
        {
            get { return this.Date.GetShortDisplay(); }
        }       

        public string EditLink
        {
            get
            {
                return "<a href=\"/" + UrlBasePath.ToLower() + "/edit/" + Id + "\">Edit</a>";
            }
        }
    }
}