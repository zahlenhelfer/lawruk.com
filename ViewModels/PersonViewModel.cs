using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class PersonViewModel : ICalendarEntry
    {
        public Person Person { get; set; }
        public DateTime Date
        {
            get
            {
                DateTime now = DateTime.Now;
                DateTime birthday = new DateTime(now.Year, this.Person.BirthdayMonth.Value, this.Person.BirthdayDay.Value);
                DateTime yesterday = now.AddDays(-1);
                DateTime yesterdayMidnight = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day);
                if (birthday < yesterday)
                {
                    birthday = birthday.AddYears(1);
                }
                return birthday;
            }
        }

        public string Title
        {
            get { return Person.FirstName + " " + Person.LastName; }
        }

        public string Url
        {
            get { return this.Person.Url; }
        }

        public PersonViewModel(Person person)
        {
            this.Person = person;
        }
    }
}