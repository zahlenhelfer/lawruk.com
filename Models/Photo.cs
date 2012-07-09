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
    public class Photo
    {
        public string Url { get; set; }

        public Photo(string url)
        {
            this.Url = url;
        }
    }
}
