﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private WebShopEntities db = new WebShopEntities();
        // GET: Checkout
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include ="Id, Ime, Prezime,Email, AdresaDostave, Kontakt, Napomena")] Korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Korisnici.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("CreateOrder", korisnici);
            }

            return View(korisnici);
        }

        public ActionResult CreateOrder(Korisnici korisnici)
        {

            Narudzbe narudzba = new Narudzbe();
            narudzba.KorisnikId = korisnici.Id;
            narudzba.DatumKreiranja = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            narudzba.DatumVrijemeDostave = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            narudzba.JeDostavljeno = false;
            db.Narudzbe.Add(narudzba);db.SaveChanges();

            int narudzbaID = narudzba.Id;

            if (Session["Cart"] != null)
            {
                List<Proizvodi> lstProizvodi = Session["Cart"] as List<Proizvodi>;
                List<int> dinstictProizvodi = (from proiz in lstProizvodi select proiz.Id).Distinct().ToList();

                foreach (int distItem in dinstictProizvodi)
                {
                    NarudzbeDetalji detalji = new NarudzbeDetalji();
                    detalji.NarudzbaId = narudzbaID;
                    detalji.ProizvodId = distItem;
                    detalji.Kolicina = lstProizvodi.Where(x => x.Id == distItem).Count();
                    detalji.JedCijena = lstProizvodi.Where(x => x.Id == distItem).FirstOrDefault().Cijena;
                    db.NarudzbeDetalji.Add(detalji);
                    db.SaveChanges();

                }

                Session["narudzbaID"] = narudzbaID;
                return RedirectToAction("OrderDetails");
            }

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult OrderDetails()
        {
            int id = int.Parse(Session["narudzbaID"].ToString());
            Narudzbe narudzba = db.Narudzbe.Find(id);

            if (narudzba == null)
            {
                return HttpNotFound();
            }

            List<NarudzbeDetalji> lstDetalji = (from detalji in db.NarudzbeDetalji where detalji.NarudzbaId == id select detalji).ToList();

            ViewBag.Detalji = lstDetalji;
            return View(narudzba);
        }

        public ActionResult Confirm()
        {
            Session["Cart"] = null;
            return RedirectToAction("Index", "WebShop");
        }
    }
}