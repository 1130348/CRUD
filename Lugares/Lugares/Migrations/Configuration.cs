namespace Lugares.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassLibrary.Model;
    using System.Collections.Generic;
    using ClassLibrary.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<DatumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DatumContext context)
        {

            //context.Locals.AddOrUpdate(i => i.LocalID,
            //     new Local { Nome = "Antas", Latitude = 41.16177, Longitude = -8.5857797 },
            //     new Local { Nome = "Avenida da Boavista", Latitude = 41.158881, Longitude = -8.6328847 },
            //     new Local { Nome = "Rua Infante D.Henrique", Latitude = 41.1410111, Longitude = -8.617906 },
            //     new Local { Nome = "Rua de Passos Manuel", Latitude = 41.1469917, Longitude = -8.6076057 },
            //     new Local { Nome = "Rua de Dom Manuel II", Latitude = 41.1483403, Longitude = -8.6278264 },
            //     new Local { Nome = "Rua da Alfandega", Latitude = 41.1407457, Longitude = -8.6167303 },
            //     new Local { Nome = "Rua de São Filipe de Nery", Latitude = 41.1457899, Longitude = -8.6164093 },
            //     new Local { Nome = "Praça de Almeida Garret", Latitude = 41.145607, Longitude = -8.612715 },
            //     new Local { Nome = "Terreiro da Sé", Latitude = 41.142826, Longitude = -8.6133723 },
            //     new Local { Nome = "Rua da Bolsa", Latitude = 41.1413772, Longitude = -8.6178612 },
            //     new Local { Nome = "Rua Nova da Alfandega", Latitude = 41.1431567, Longitude = -8.6236837 },
            //     new Local { Nome = "Praça D.João I", Latitude = 41.1477497, Longitude = -8.6117241 },
            //     new Local { Nome = "Praça de Mouzinho Albuquerque", Latitude = 41.1579742, Longitude = -8.6313003 },
            //     new Local { Nome = "Rua de Mouzinho Silveira", Latitude = 41.1418164, Longitude = -8.6170775 },
            //     new Local { Nome = "Rua do Campo Alegre", Latitude = 41.1537401, Longitude = -8.6448158 },
            //     new Local { Nome = "Via do Castelo do Queijo", Latitude = 41.1686451, Longitude = -8.6897382 },
            //     new Local { Nome = "Rua das Carmelitas", Latitude = 41.1469055, Longitude = -8.6169633 },
            //     new Local { Nome = "Avenida Marechal Gomes da Costa", Latitude = 41.1597898, Longitude = -8.6618548 },
            //     new Local { Nome = "Praça de Gonçalves Zarco", Latitude = 41.1685555, Longitude = -8.6902649 }
            //     );

            //context.POIs.AddOrUpdate(i => i.PoiID,
            //    new POI { Nome = "Estádio do Dragão", LocalID = 1, CategoriaID = 1, duracaoVisita = 45 },
            //    new POI { Nome = "Casa da Música", LocalID = 2, CategoriaID = 5, duracaoVisita = 35 },
            //    new POI { Nome = "Torre dos Clérigos", LocalID = 7, CategoriaID = 4, duracaoVisita = 15 },
            //    new POI { Nome = "Estação Ferroviária de Porto São Bento", LocalID = 8, CategoriaID = 4, duracaoVisita = 30 },
            //    new POI { Nome = "Sé do Porto", LocalID = 9, CategoriaID = 4, duracaoVisita = 25 },
            //    new POI { Nome = "Palácio da Bolsa", LocalID = 10, CategoriaID = 3, duracaoVisita = 33 },
            //    new POI { Nome = "Museu Serralves", LocalID = 18, CategoriaID = 3, duracaoVisita = 50 },
            //    new POI { Nome = "Forte de S.Franscisco do Queijo", LocalID = 19, CategoriaID = 2, duracaoVisita = 15 },
            //    new POI { Nome = "Igreja de S.Franscisco", LocalID = 3, CategoriaID = 4, duracaoVisita = 20 },
            //    new POI { Nome = "Coliseu do Porto", LocalID = 4, CategoriaID = 6, duracaoVisita = 19 },
            //    new POI { Nome = "Palácio de Cristal", LocalID = 5, CategoriaID = 4, duracaoVisita = 29 },
            //    new POI { Nome = "Casa do Infante", LocalID = 6, CategoriaID = 3, duracaoVisita = 15 },
            //    new POI { Nome = "Alfandega do Porto", LocalID = 11, CategoriaID = 4, duracaoVisita = 10 },
            //    new POI { Nome = "Teatro Rivoli", LocalID = 12, CategoriaID = 6, duracaoVisita = 26 },
            //    new POI { Nome = "Rotunda da Boavista", LocalID = 13, CategoriaID = 2, duracaoVisita = 10 },
            //    new POI { Nome = "Mercado Ferreira Borges", LocalID = 14, CategoriaID = 2, duracaoVisita = 30 },
            //    new POI { Nome = "Jardim Botanico", LocalID = 15, CategoriaID = 2, duracaoVisita = 60 },
            //    new POI { Nome = "Sealife Matosinhos", LocalID = 16, CategoriaID = 3, duracaoVisita = 120 },
            //    new POI { Nome = "Livralia Lello", LocalID = 17, CategoriaID = 4, duracaoVisita = 40 }
            //    );

            //context.Categorias.AddOrUpdate(i => i.CategoriaID,
            //    new Categoria { nome = "Desporto" },
            //    new Categoria { nome = "Ar Livre" },
            //    new Categoria { nome = "Museus" },
            //    new Categoria { nome = "História" },
            //    new Categoria { nome = "Música" },
            //    new Categoria { nome = "Teatro" }
            //    );

            //POI p1 = context.POIs.Find(1);
            //POI p2 = context.POIs.Find(2);
            //POI p3 = context.POIs.Find(3);

            //var listPoi = new List<POI>();
            //listPoi.Add(p1);
            //listPoi.Add(p2);
            //listPoi.Add(p3);

            //context.Hashtags.AddOrUpdate(i => i.ID,
            //    new Hashtag { Nome = "#Happy", POIs = listPoi},
            //    new Hashtag { Nome = "#PORTO", POIs = listPoi });

            //context.SugerirPOI.AddOrUpdate(i => i.SugerirPoiID,
            //    new SugerirPOI { Nome = "Estádio do Bessa", LocalID = 1, CategoriaID = 1, duracaoVisita = 45, UserID = 1 }
            //    );
            //AddOrUpdatePOI(context, 3, 3);
        //    context.Visitas.AddOrUpdate(i => i.idVisita,
        //        new Visita { data = "10/01/2017", descrição = "Visita de TukTuk", horaInicio = "10:00:00", idPercurso = 4, idUser = 1 },
        //        new Visita { data = "11/01/2017", descrição = "Visita á la pata", horaInicio = "09:20:00", idPercurso = 5, idUser = 1 },
        //        new Visita { data = "12/01/2017", descrição = "Visita estadio Dragao", horaInicio = "12:02:00", idPercurso = 4, idUser = 1 },
        //        new Visita { data = "13/01/2017", descrição = "Visita de autocarro", horaInicio = "14:22:00", idPercurso = 5, idUser = 1 },
        //        new Visita { data = "14/01/2017", descrição = "Visita de Tu", horaInicio = "16:18:00", idPercurso = 5, idUser = 1 },
        //        new Visita { data = "15/01/2017", descrição = "Visita de TukTuktuk", horaInicio = "17:11:00", idPercurso = 4, idUser = 1 });
        //}

        
    }

    }

