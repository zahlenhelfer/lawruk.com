using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.Controllers
{
    public class RachelEmmettController : Controller
    {
        //
        // GET: /RachelEmmett/

        public ActionResult Page(string page)
        {
            return View(page,"RachelEmmett");
        }

    }
}
