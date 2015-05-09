using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KleinOnderhoudApi.Models
{
    public class Wagen
    {
        public int Id { get; set; }
        public string Merk { get; set; }
        public string Nummerplaat { get; set; }
        public int Km { get; set; }
        public string Type { get; set; }
    }
}