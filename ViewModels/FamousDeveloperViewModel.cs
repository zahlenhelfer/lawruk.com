using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Helpers;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class FamousDeveloperViewModel : ITitleUrl
    {
        public FamousDeveloper FamousDeveloper {get;set;}

        public string Url
        {
            get { return "/famousdevs/profile/" + this.FamousDeveloper.Id + "/" + this.Title.ToUrl(); }
        }

        public FamousDeveloperViewModel(FamousDeveloper famousDev)
        {
            this.FamousDeveloper = famousDev;            
        }

        public string Title
        {
            get { return FamousDeveloper.FirstName + " " + FamousDeveloper.MiddleName + " " + FamousDeveloper.LastName; }
        }

        public string ProfileLinks
        {
            get
            {
                var titleUrls = new List<ITitleUrl>();
                AddTitleUrl(titleUrls, "Wikipedia Entry", "http://en.wikipedia.org/wiki/" , FamousDeveloper.WikipediaUrl);
                AddTitleUrl(titleUrls, "Follow on Twitter", "http://twitter.com/",FamousDeveloper.TwitterUrl);
                AddTitleUrl(titleUrls, "StackOverflow Profile", "http://stackoverflow.com/users/", StackOverflowUserUrl);
                AddTitleUrl(titleUrls, "Facebook Profile", "http://twitter.com/",FamousDeveloper.FacebookUrl);
                return Helpers.Helpers.ULAList(titleUrls);
            }
        }

        private void AddTitleUrl(List<ITitleUrl> titleUrls, string title, string url1, string url2)
        {
            string url = Helpers.Helpers.BothOrEmpty(url1,url2);
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            titleUrls.Add(new TitleUrl(title, url));
        }

        public string StackOverflowUserUrl
        {
            get
            {
                if (string.IsNullOrEmpty(FamousDeveloper.StackOverflowUrl))
                {
                    return "";
                }
                int temp;
                string url;
                if (int.TryParse(FamousDeveloper.StackOverflowUrl, out temp))
                {
                    url = FamousDeveloper.StackOverflowUrl + "/" + FamousDeveloper.FirstName + "-" + FamousDeveloper.LastName;
                }
                else
                {
                    url = FamousDeveloper.StackOverflowUrl;
                }
                return url;
            }
        }

        public string PrimaryLanguageUrl
        {
            get
            {
                if (FamousDeveloper.PrimaryLanguage == "C#")
                    return "CSharp";
                return FamousDeveloper.PrimaryLanguage;
            }
        }

        public string MoreDevelopersOfTheSameLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(FamousDeveloper.PrimaryLanguage))
                {
                    return Helpers.Helpers.A("See More " + FamousDeveloper.PrimaryLanguage +
                        " Developers", "/famousdevs/language/" + PrimaryLanguageUrl);
                }
                return "";
            }
        }

    }
}