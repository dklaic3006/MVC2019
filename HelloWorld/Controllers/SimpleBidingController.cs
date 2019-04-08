using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class SimpleBidingController : Controller
    {
        // GET: SimpleBiding
        public ViewResult SimpleBindMetoda()
        {
            return View("SimpleBind");
        }

        [HttpPost]
        public ViewResult SimpleBindMetoda(string ime)
        {
            string pozdrav = "Pozdrav " + ime + "!";
            return View("SimpleBind", (object)pozdrav);
        }
    }
}