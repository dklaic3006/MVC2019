using _7._1._1_Unos_podataka_s_validacijom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7._1._1_Unos_podataka_s_validacijom.Controllers
{
    public class OsobaController : Controller
    {
        // GET: Osoba
        public ActionResult UnesiOsobu()
        {
            return View(new Osoba());
        }

        [HttpPost]
        public ActionResult UnesiOsobu(Osoba osoba)
        {
            if(string.IsNullOrEmpty(osoba.Ime))
            {
                ModelState.AddModelError("Ime", "Ime je obavezno!");
            }
            if (string.IsNullOrEmpty(osoba.Prezime))
            {
                ModelState.AddModelError("Prezime", "Prezime je obavezno!");
            }

            if (ModelState.IsValid)
            {
                return View("ProvjeriOsobu");
            }
            else
            {
                return View();
            }
            
        }
    }
}