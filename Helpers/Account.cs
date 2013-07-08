using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.Helpers
{
    public class Account
    {
        public static string Email 
        {
            get
            {
                var email = HttpContext.Current.Session["email"];
                if (email != null)
                    return email.ToString().ToLower();
                return "";
            }
            
        }

        public static bool LoggedIn
        {
            get { return !string.IsNullOrEmpty(Email); }
        }

        public static bool AdminLoggedIn
        {
            get { return lawrukmvc.Helpers.Account.UserType == lawrukmvc.Helpers.UserType.Admin; }
        }

        //TODO use enum
        public static int Visibility
        {
            get
            {
                return (int)UserType;
            }
        }

      public static UserType UserType
      {
          get
          {
              if (Email == "jimlawruk@yahoo.com" || HttpContext.Current.User.Identity.IsAuthenticated)
              {
                  return UserType.Admin;
              }
              else if (Email.Contains("lawruk"))
                  return UserType.Family;
              else if (LoggedIn)
                  return UserType.LoggedIn;
              else
                  return UserType.Unknown;                  
          }
      }    

    }

    public enum UserType
    {
        Unknown = 0,
        LoggedIn = 1,
        Known = 2,
        Friend = 3,
        Family = 5,
        Admin = 10
    }
}
