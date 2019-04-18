using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace parcijalni_1.Controllers
{
    public class IspitController : Controller
    {
        // GET: Vrijeme
        public ActionResult Prvi()
        {
            DateTime Vrijeme = DateTime.Now;

            ViewBag.Vrijeme = Vrijeme;

            return View();
        }
    }
}