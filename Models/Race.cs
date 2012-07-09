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
    public class Race
    {
        public string Filename { get; private set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Distance { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Text { get; set; }

        public Race(string filename)
        {
            Filename = filename;
        }

        public string GetText()
        {
            string text;
            using (var sr = new StreamReader(WebConfigurationManager.AppSettings["RootDirectory"] + "\\Races\\" + Filename))
            {
                text = sr.ReadToEnd();
                string toLower = text.ToLower();
                int body = toLower.IndexOf("<body");                 
                int start =0;
                int end = text.Length - 1;                

                if (body >= 0)
                {
                    start = text.IndexOf(">", body) + 1;                    
                }
                int script = toLower.IndexOf("<script",start);
                if (script >= 0)
                {
                    end = script - 1;
                }
                int endBody = toLower.IndexOf("</body");
                if (endBody < end)
                {
                    end = endBody;
                }

                text = text.Substring(start, end - start);
            }
            return text;
        }
    }
}
