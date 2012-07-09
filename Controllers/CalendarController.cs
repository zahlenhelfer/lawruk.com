using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;
using lawrukmvc.Helpers;
using lawrukmvc.ViewModels;

namespace lawrukmvc.Controllers
{
    public class CalendarController : Controller
    {
        lawrukEntities lawrukEntities = new lawrukEntities();
        lawrukmvc.Models.LawrukRepository lawrukRepository = new Models.LawrukRepository();
        public ActionResult Index(string tag)
        {
            var calendarViewModel = new CalendarViewModel();
            CalendarEntryType enumValue;
            Enum.TryParse<CalendarEntryType>(tag, true, out enumValue);
            if (enumValue > 0)
            {
                calendarViewModel.CalendarEntries = lawrukRepository.GetICalendarEntriesByType(enumValue);
            }
            else
            {
                calendarViewModel.CalendarEntries = lawrukRepository.GetICalendarEntries();
            }
            return View(calendarViewModel);
        }

        [Authorize]
        public ActionResult Edit(string tag)
        {
            int id = 0;
            if (string.IsNullOrEmpty(tag))
            {
                var viewModels = lawrukRepository.GetCalendarEntryViewModels();
                foreach (var entry in viewModels)
                {
                    var cevm = entry as CalendarEntryViewModel;
                    cevm.Url = "/calendar/edit/" + cevm.CalendarEntry.Id;
                }
                var calendarViewModel = new CalendarViewModel();
                calendarViewModel.CalendarEntries = viewModels.Cast<ICalendarEntry>().ToList();
                return View("Index", calendarViewModel);
            }
            else
            {
                CalendarEntry calendarEntry;
                id = int.Parse(tag);
                if (id > 0)
                {
                    calendarEntry = GetCalendarEntry(id);
                }
                else
                {
                    calendarEntry = new CalendarEntry();
                    var now = DateTime.Now;
                    calendarEntry.Date = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
                }
                return View(calendarEntry);
            }            
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string dummy, string tag)
        {
            CalendarEntry calendarEntry = GetCalendarEntry(int.Parse(tag));
            if (calendarEntry == null)
            {
                calendarEntry = new CalendarEntry();
            }
            
            calendarEntry.Title = Request.Params["title"];
            calendarEntry.Date = DateTime.Parse(Request.Params["date"]);
            calendarEntry.Url = Request.Params["urllink"];
            calendarEntry.Type = int.Parse(Request.Params["type"]);
           
            if (calendarEntry.EntityState == System.Data.EntityState.Added || calendarEntry.EntityState == System.Data.EntityState.Detached)
            {
                lawrukEntities.CalendarEntries.AddObject(calendarEntry);
            }
            lawrukEntities.SaveChanges();
            return RedirectToAction("Edit");
        }

        private CalendarEntry GetCalendarEntry(int id)
        {
            return lawrukEntities.CalendarEntries.FirstOrDefault(i => i.Id == id);
        }    

    }
}
//