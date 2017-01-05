namespace Lugares.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassLibrary.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary.DAL.DatumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ClassLibrary.DAL.DatumContext context)
        {

            context.Locals.AddOrUpdate(i => i.LocalID,
                 new Local { Nome = "Porto Avenida dos Aliados", Latitude = 41.2, Longitude = -8.0 },
                 new Local { Nome = "Campanha", Latitude = 40.8, Longitude = -7.0 }
                 );

            context.POIs.AddOrUpdate(i => i.PoiID,
                new POI { Nome = "McDonald's", Descricao = "Restaurante", LocalID = 1 },
                new POI { Nome = "A Abundância", Descricao = "Monumento", LocalID = 2 },
                new POI { Nome="A Nacional",Descricao="Monumento",LocalID=1 }
                );
        }
    }
}
