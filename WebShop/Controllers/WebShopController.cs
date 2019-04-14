using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class WebShopController : Controller
    {
        // GET: WebShop
        private WebShopEntities db = new WebShopEntities();

        // GET: Proizvodi
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodi.Include(p => p.MjereProizvoda);
            return View(proizvodi.ToList());
        }
    }
}