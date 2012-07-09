using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.ViewModels;
namespace lawrukmvc.Models
{
    public class LawrukRepository
    {
        lawrukEntities lawrukEntities = new lawrukEntities();
     
        public List<ListItem> GetBlogPostViewModels()
        {
            //Set up a list of ViewModels
            List<lawrukmvc.ViewModels.BlogPostViewModel> viewModels = new List<lawrukmvc.ViewModels.BlogPostViewModel>();
            var blogPosts = lawrukEntities.BlogPosts.OrderByDescending(i => i.Date).ToList();
            var items = new List<ListItem>();
            foreach (var b in blogPosts)
            {
                var item = new ListItem();
                item.UrlBasePath = "blog";
                item.Title = b.Title;
                item.Id = b.Id;
                item.ThumbnailUrl = GetBlogThumbnailUrl(b);
                item.Date = b.Date;
                items.Add(item);
            }           
            return items;
        }

        private string GetBlogThumbnailUrl(BlogPost b)
        {
            string url = b.FlickrImageUrl;
            if (string.IsNullOrEmpty(url))
            {
                url = "http://farm7.static.flickr.com/6084/6142564278_5573968475.jpg";//default
            }
            url = url.Replace(".jpg", "_t.jpg");
            return url;
        }

        internal List<ListItem> GetVideoViewModels()
        {
            //Set up a list of ViewModels
            List<lawrukmvc.ViewModels.VideoViewModel> viewModels = new List<lawrukmvc.ViewModels.VideoViewModel>();
            var videos = from v in lawrukEntities.Videos
                         orderby v.Date descending
                         select new ListItem()
                         {
                             UrlBasePath = "videos",
                             Title = v.Title,
                             Id = v.Id,
                             ThumbnailUrl = "http://i.ytimg.com/vi/" + v.YouTubeId + "/default.jpg",
                             Date = v.Date
                         };
            return videos.ToList();
        }

        private static DateTime Midnight
        {
            get
            {
                DateTime now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day);
            }
        }

        private List<CalendarEntry> GetCalendarEntries()
        {
            return lawrukEntities.CalendarEntries.
                Where(ce => ce.Date > LawrukRepository.Midnight).ToList();
        } 

        private List<CalendarEntry> GetCalendarEntryByType(CalendarEntryType type)
        {
            return lawrukEntities.CalendarEntries.
                Where(ce => ce.Date > LawrukRepository.Midnight && ce.Type == (int)type).ToList();
        }

        public List<CalendarEntryViewModel> GetCalendarEntryViewModels()
        {
            var calendarEntries = GetCalendarEntries();
            return ConvertToViewModels(calendarEntries);
        }

        private List<CalendarEntryViewModel> ConvertToViewModels(List<CalendarEntry> entries)
        {
            var viewModels = new List<CalendarEntryViewModel>();
            foreach (CalendarEntry ce in entries)
            {
                viewModels.Add(new lawrukmvc.ViewModels.CalendarEntryViewModel(ce));
            }
            return viewModels;
        }

        public List<ICalendarEntry> GetPersonViewModels()
        {
            var people = lawrukEntities.People.Where(p => p.BirthdayMonth.HasValue);
            var viewModels = new List<PersonViewModel>();
            foreach (Person person in people)
            {
                viewModels.Add(new PersonViewModel(person));
            }
            return viewModels.Cast<ICalendarEntry>().ToList();
        }

        public List<ICalendarEntry> GetICalendarEntries()
        {            
            var viewModels = new List<lawrukmvc.Models.ICalendarEntry>();
            var calendarEntries = GetCalendarEntryViewModels();
            viewModels.AddRange(calendarEntries);
            var persons = GetPersonViewModels();
            viewModels.AddRange(persons);            
            return viewModels.OrderBy(ce => ce.Date).ToList();
        }
       
         public List<ICalendarEntry> GetICalendarEntriesByType(CalendarEntryType type)
        {
            if (CalendarEntryType.Birthday == type)
            {
                return GetPersonViewModels();
            }
            else
            {
                var entries =  GetCalendarEntryByType(type);
                return ConvertToViewModels(entries).Cast<ICalendarEntry>().ToList();
            }
        }

        
    }
}
