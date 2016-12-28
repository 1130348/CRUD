using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace ClassLibrary.DAL
{
    public class DatumContext : DbContext
    {

        public DatumContext() : base("DatumContext")
        {
        }

        public DbSet<Local> Locals { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}