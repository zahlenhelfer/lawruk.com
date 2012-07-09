using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace lawrukmvc.Models
{
    public class MetroStation : ITitleUrl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Body { get; set; }
        public MetroLine[] Lines { get; set; }

        public MetroStation(int id, string tag, string title, MetroLine[] lines)
        {
            Id = id; Tag = tag; Title = title; Lines = lines;          
        }

        public MetroStation(int id, string tag, string title, MetroLine line)
        {
            new MetroStation(id, tag, title, new MetroLine[] { line });
        }


        public string Url
        {
            get { return "/metro/" + Tag; }
        }      
        

    }

    public enum MetroLine
    {
        Red = 1,
        Orange =2,
        Blue = 3,
        Green = 4,
        Yellow = 5
    }

}
