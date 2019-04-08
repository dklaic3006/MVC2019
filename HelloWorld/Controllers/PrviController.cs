using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PrviController : Controller
    {
        // GET: Prvi
        public string Pozdrav()
        {
            return "Pozdrav s prvog kontrolera";
        }

        public string KontekstniPodaci()
        {
            string serverName = Server.MachineName;
            DateTime dateStamp = HttpContext.Timestamp;
            return "<h2>Kontekstni Podaci iz zahtjeva</h2>" +
                "<ul>" +
                "<li>" + serverName + "</li>" +
                "<li>" + dateStamp.ToString() + "</li>" +
                "</ul>";
        }

        public string MetodaSaParametrima(string id)
        {
            return "Pozdrav " + id +"!";
        }
    }
} 