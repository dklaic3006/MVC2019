using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _821_Citanje_Iz_Baze.Models
{
    public class PolaznikModel
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
    }
}