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
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Local> Locals { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Percurso> Percursos { get; set; }
        public DbSet<SugerirPOI> SugerirPOI { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        public static DatumContext Create()
        {
            return new DatumContext();
        }

        public System.Data.Entity.DbSet<ClassLibrary.Model.Categoria> Categorias { get; set; }
    }
}