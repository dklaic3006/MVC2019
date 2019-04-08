using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacije.Models;

namespace Validacije.Controllers
{
    public class ValidacijeController : Controller
    {
        // GET: Validacije
        public ActionResult IzdavanjeRacuna()
        {
            return View(new Racun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }

        public ActionResult IzdavanjeRacuna2()
        {
            return View(new Racun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }

        public ActionResult MetaIzdavanjeRacuna()
        {
            return View(new MetaRacun() { Datum = DateTime.Now, BrojRacuna = "/" + DateTime.Now.Year.ToString() });
        }


        [HttpPost]
        public ActionResult IzdavanjeRacuna(Racun racun, string id)
        {

            //OBAVEZNE VRIJEDNOSTI
            if (string.IsNullOrEmpty(racun.BrojRacuna))
            {
                ModelState.AddModelError("BrojRacuna", "Broj računa je obavezan!");
            }
            if (string.IsNullOrEmpty(racun.Zaposlenik))
            {
                ModelState.AddModelError("Zaposlenik", "Ime zaposlenika je obavezno!");
            }
            if (string.IsNullOrEmpty(racun.Kupac))
            {
                ModelState.AddModelError("Kupac", "Naziv kupca je oavezan!");
            }
           

            //MODEL-LEVEL VALIDACIJA
            if (ModelState.IsValidField("Datum"))
            {
                if (racun.Datum < DateTime.Today.AddDays(- 3))
                {
                    ModelState.AddModelError("", "Datum ne smije bitii manji za više od 3 dana");
                }
            }

            //UKUPNA PROVJERA VALIDACIJE
            if (ModelState.IsValid)
            {
                return View("RacunIzdan", racun);
            }
            else
            {
                if ( id=="IzdavanjeRacuna2")
                    {
                        return View("IzdavanjeRacuna2");
                    }
                else
                    {
                        return View();
                    }
                
            }

        }
        [HttpPost]
        public ActionResult MetaIzdavanjeRacuna(MetaRacun metaracun)
        {
            if (ModelState.IsValid)
            {
                return View("MetaRacunIzdan", metaracun);
            }
            else
            {
                return View();
            }
        }


    }
}