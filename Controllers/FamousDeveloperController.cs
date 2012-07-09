using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;

namespace lawrukmvc.Controllers
{
    public class FamousDeveloperController : Controller
    {
        lawrukEntities lawrukEntities = new lawrukEntities();
        lawrukmvc.Models.LawrukRepository lawrukRepository = new Models.LawrukRepository();

        public ActionResult Index()
        {
            var devs = lawrukEntities.FamousDevelopers.OrderBy(d => d.LastName).ToList();
            return GetViewModelList(devs, "");
        }

        public ActionResult Language(string p1)
        {
            p1 = p1.ToLower();
            if (p1 == "csharp")
            { 
                p1 = "C#"; 
            }

            var devs = lawrukEntities.FamousDevelopers.Where(d => d.PrimaryLanguage == p1).OrderBy(d => d.LastName).ToList();
            return GetViewModelList(devs, Helpers.Helpers.TitleCase(p1), "List");
        }

        private ActionResult GetViewModelList(List<FamousDeveloper> developers, string subTitle, string viewName = "")
        {
            ViewData["subTitle"] = subTitle;
            var vms = new List<FamousDeveloperViewModel>();
            foreach (var dev in developers)
            {
                vms.Add(new FamousDeveloperViewModel(dev));
            }
            if (viewName == "")
                return View(vms);
            else
                return View(viewName, vms);
        }

        public ActionResult Profile(int p1)
        {
            return View(new FamousDeveloperViewModel(lawrukEntities.FamousDevelopers.FirstOrDefault(d => d.Id == p1)));
        }

        [Authorize]
        public ActionResult Edit(string p1)
        {
            int id;
            int.TryParse(p1, out id);
            FamousDeveloper famousDev;
            if (id > 0)
            {
                famousDev = GetFamousDeveloper(id);
            }
            else
            {
                famousDev = new FamousDeveloper ();
            }
            return View(famousDev);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string p1, string p2)
        {
            int id;
            int.TryParse(p1, out id);
            var famousDev = GetFamousDeveloper(id);
            if (famousDev == null)
            {
                famousDev = new FamousDeveloper();
            }

            famousDev.FirstName = Request.Params["FirstName"];
            famousDev.LastName = Request.Params["LastName"];
            famousDev.MiddleName = Request.Params["MiddleName"];
            famousDev.Nickname = Request.Params["Nickname"];
            famousDev.WikipediaUrl = Request.Params["WikipediaUrl"];
            famousDev.PhotoUrl = Request.Params["PhotoUrl"];
            famousDev.StackOverflowUrl = Request.Params["StackOverflowUrl"];
            famousDev.TwitterUrl = Request.Params["TwitterUrl"];
            famousDev.FacebookUrl = Request.Params["FacebookUrl"];
            famousDev.Books = Request.Params["Books"];
            famousDev.Websites = Request.Params["Websites"];
            famousDev.Summary = Request.Params["Summary"];
            famousDev.PrimaryLanguage = Request.Params["PrimaryLanguage"];


            if (famousDev.EntityState == System.Data.EntityState.Added || famousDev.EntityState == System.Data.EntityState.Detached)
            {
                lawrukEntities.FamousDevelopers.AddObject(famousDev);
            }
            lawrukEntities.SaveChanges();
            return Redirect("/famousdevs/edit/" + famousDev.Id.ToString());
        }

        private FamousDeveloper GetFamousDeveloper(int id)
        {
            return lawrukEntities.FamousDevelopers.FirstOrDefault(i => i.Id == id);
        }


    }
}
