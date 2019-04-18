using Parcijalni_2.Models;
using System.Data;
using System.Data.Entity;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcijalni_2.Controllers
{
    public class CreateController : Controller
    {

        private Parcijalni2Entities db = new Parcijalni2Entities();

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Proizvodi proizvod)
        {
            if(ModelState.IsValid)
            {
                db.Proizvodi.Add(proizvod);
                db.SaveChanges();
                return View (ViewBag.podaci = "podaci su sninljeni");
            }
            return View(proizvod);
        }
    }
}