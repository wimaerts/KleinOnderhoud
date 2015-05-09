using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KleinOnderhoudApi.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Wagen> lstWagen { get; set; }
        public List<Controle> lstControle { get; set; }

        public Klant(string naam)
        {
            this.Naam = naam;
        }
    }
}