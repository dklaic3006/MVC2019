using Parcijalni_2.Models;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcijalni_2.Controllers
{
    public class PokloniController : Controller
    {
        private Parcijalni2Entities db = new Parcijalni2Entities();

        // GET: Pokloni
        public ActionResult Index()
        {

            //  var proizvodi = db.Proizvodi;
            // return View(proizvodi.ToList());

            List<Proizvodi> lstPokloni = (from p in db.Proizvodi where p.kupljen == false select p).ToList();

            return View(lstPokloni);
        }
    }
}