using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Web.Configuration;

namespace lawrukmvc.Models
{
    public partial class Person
    {

        public DateTime Date
        {
            get
            {
                DateTime birthday = new DateTime(DateTime.Now.Year, this.BirthdayMonth.Value, this.BirthdayDay.Value);
                DateTime tomorrow =  DateTime.Now.AddDays(1);
                DateTime tomorrowMidnight = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day);
                if (birthday < tomorrowMidnight)
                {
                    birthday = birthday.AddYears(1);
                }
                return birthday;
            }
            set
            {
                this.Date = value;       
            }
        }

        public string Title
        {
            get
            {
                return this.FirstName + " " + this.LastName + "'s Birthday";
            }           
        }
       
    }

}
