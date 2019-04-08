using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;



namespace HelloWorld.Controllers
{
    public class OsobeController : Controller
    {
        // GET: Osobe
        public ViewResult PopuniOsobu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrikaziOsobu(Osoba osoba)
        {
            return View(osoba);
        }
    }
}