using Lugares.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Lugares.DAL
{
    public class DatumContext : DbContext
    {

        public DatumContext() : base("LugaresContext")
        {
        }

        public DbSet<Local> Locals { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}