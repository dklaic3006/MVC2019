using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class GenIzlazController : Controller
    {
        // GET: GenIzlaz
        public ViewResult Index()
        {
            ViewBag.Vrijeme = DateTime.Now;
            return View("PrimjerPogleda");
        }

        public RedirectResult Redirect()
        {
            return Redirect("/Prvi/Pozdrav");
        }

        public RedirectToRouteResult Redirect2()
        {
            return RedirectToAction("pozdrav", "Prvi");
        }
    }
}