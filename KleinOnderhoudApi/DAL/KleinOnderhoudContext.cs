using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KleinOnderhoudApi.Models;

namespace KleinOnderhoudApi.DAL
{
    public class KleinOnderhoudContext : DbContext
    {
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Controle> Controles { get; set; }
        public DbSet<ControlePunt> ControlePunten { get; set; }
        public DbSet<Wagen> Wagens { get; set; }

        public KleinOnderhoudContext()
            : base("DefaultConnection")
        {

        }
    }
}