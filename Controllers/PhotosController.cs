using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;

using lawrukmvc.Models;
using lawrukmvc.ViewModels;

namespace lawrukmvc.Controllers
{
    public class PhotosController : Controller
    {
        //
        // GET: /Photos/

        //public ActionResult Index(string tag, string tags)
        //{
        //    IQueryable<Photo> photos = GetPhotosFromFlickr(tag + "," + tags);
        //    return View(photos);
        //}

        public ActionResult Index(string baseUrl, string consistentTag, string otherTags)
        {
            string masterName = "Site";
            PhotosViewModel photosViewModel = new PhotosViewModel();
            photosViewModel.BaseUrl = baseUrl;
            photosViewModel.ConsistentTag = consistentTag;
            photosViewModel.OtherTags = otherTags;            
            if (consistentTag == "rachelemmett")
            {
                masterName = "RachelEmmett";
                photosViewModel.TagListOptions = RachelEmmettTagLists;
            }
            else
            {
                photosViewModel.TagListOptions = TagLists;
            }

            if (photosViewModel.TagListOptions.ContainsKey(otherTags))
            {
                photosViewModel.Title = " - " + photosViewModel.TagListOptions[otherTags];
            }
            
            return View("Photos", masterName, photosViewModel);
        }

        private static Dictionary<string, string> TagLists
        {
            get
            {
                Dictionary<string, string> tagLists = new Dictionary<string, string>();
                tagLists.Add("Jordan", "jordan");
                tagLists.Add("Halloween","halloween");
                tagLists.Add("Washington DC", "washington");
                tagLists.Add("Running", "running");
                tagLists.Add("DeSales", "desales");
                tagLists.Add("Yosemite", "yosemite");
                tagLists.Add("Death Valley", "death-valley");
                tagLists.Add("Grand Canyon", "grand-canyon");
                tagLists.Add("Shenandoah", "shenandoah");
                tagLists.Add("White Mountians", "white-mountians");
                return tagLists;
            }
        }

        private static Dictionary<string, string> RachelEmmettTagLists
        {
            get
            {
                Dictionary<string, string> tagLists = new Dictionary<string, string>();
                tagLists.Add("bridel,shower", "Bridal Shower");
                tagLists.Add("shower,september","September Shower");
                tagLists.Add("wedding,party","Wedding Party");
                tagLists.Add( "engagement","Engagement");
                tagLists.Add("family", "Family");
                tagLists.Add("travels", "Travels");
                tagLists.Add("marathon", "Marathon");
                tagLists.Add("other", "Other");
                return tagLists;
            }
        }       

    }//class
}//namespace
