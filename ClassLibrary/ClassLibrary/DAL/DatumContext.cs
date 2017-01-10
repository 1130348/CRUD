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
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Local> Locals { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Percurso> Percursos { get; set; }
        public DbSet<SugerirPOI> SugerirPOI { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<POI>().HasMany(c => c.Hashtags).WithMany(i => i.POIs).
            //    Map(t => t.MapLeftKey("PoiID").MapRightKey("Nome").ToTable("HashTag_POI"));
        }

        public static DatumContext Create()
        {
            return new DatumContext();
        }

       
    }
}