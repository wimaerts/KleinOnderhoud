using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KleinOnderhoudApi.Models
{
    public class ControlePunt
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public bool Resultaat { get; set; }
    }
}