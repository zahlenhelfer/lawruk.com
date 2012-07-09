using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class PhotoViewModel
    {
        Photo photo;
        public int Index { get; set; }
        public string Url { get { return this.photo.Url; } }
        public string CSSDisplay { get { return (this.Index == 0) ? "block" : "none"; } }

        public PhotoViewModel(Photo photo)
        {
            this.photo = photo;
        }

    }
}
