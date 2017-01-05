using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class DatumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatumContext>
    {

        protected override void Seed(DatumContext context)
        {
            var locais = new List<Local>
            {
                new Local { LocalID=1,Nome="Porto Avenida dos Aliados",Latitude="41° 8′ 52.86″ N",Longitude="8° 36′ 39.97″ W" },
            };

            locais.ForEach(l => context.Locals.Add(l));
            context.SaveChanges();

            //var categorias = new List<Categoria>
            //{
            //    new Categoria { ID=1,nome="Restauração" },
            //    new Categoria { ID=2,nome="Cultura" },
            //};

            //categorias.ForEach(c => context.Categorias.Add(c));
            //context.SaveChanges();

            //var pois = new List<POI>
            //{
            //    new POI { PoiID=1,Nome="McDonald's",Descricao="Restaurante",LocalID=1,CategoriaID=1 },
            //    new POI { PoiID=2,Nome="A Abundância",Descricao="Monumento",LocalID=1,CategoriaID=2 },
            //    new POI { PoiID=3,Nome="A Nacional",Descricao="Monumento",LocalID=1,CategoriaID=2 }
            //};

            //pois.ForEach(p => context.POIs.Add(p));
            //context.SaveChanges();

            var hashtags = new List<Hashtag>
            {
                new Hashtag { ID=1,Nome="#restaurante",PoiID=1 },
                new Hashtag { ID=2,Nome="#sofat",PoiID=1 },
            };

            hashtags.ForEach(h => context.Hashtags.Add(h));
            context.SaveChanges();

        }

    }
}
