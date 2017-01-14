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

            context.Locals.AddOrUpdate(i => i.LocalID,

                 new Local { Nome = "Praça Gonçalves Zarco 1", Latitude = 41.1678, Longitude = -8.6822 },
                 new Local { Nome = "Avenida da Boavista 1", Latitude = 41.1623, Longitude = -8.6555 },
                 new Local { Nome = "Avenida Marechal Gomes da Costa", Latitude = 41.1601, Longitude = -8.6599 },
                 new Local { Nome = "Praça Império", Latitude = 41.1551, Longitude = -8.6726 },
                 new Local { Nome = "R.Cel.Raúl Peres", Latitude = 41.1519, Longitude = -8.6779 },
                 new Local { Nome = "Largo António Calem", Latitude = 41.1483, Longitude = -8.6535 },
                 new Local { Nome = "R.Dom Pedro de Meneses", Latitude = 41.1511, Longitude = -8.6565 },
                 new Local { Nome = "Rua do Campo Alegre 1216", Latitude = 41.1541, Longitude = -8.6424 },
                 new Local { Nome = "Avenida da Boavista 2", Latitude = 41.1598, Longitude = -8.6406 },
                 new Local { Nome = "Praça de Mouzinho de Albuquerque", Latitude = 41.1579, Longitude = -8.6299 },
                 new Local { Nome = "Rua do Campo Alegre 312", Latitude = 41.1526, Longitude = -8.6322 },
                 new Local { Nome = "Rua de Júlio Dinis 386", Latitude = 41.1525, Longitude = -8.6261 },
                 new Local { Nome = "Rua do Rosário", Latitude = 41.1473, Longitude = -8.6206 },
                 new Local { Nome = "Largo do Prof.Abel Salazar", Latitude = 41.1472, Longitude = -8.6172 },
                 new Local { Nome = "Rua das Carmelitas 100", Latitude = 41.1464, Longitude = -8.6143 },
                 new Local { Nome = "Rua de Monchique 110", Latitude = 41.1447, Longitude = -8.6268 },
                 new Local { Nome = "Rua Infante D.Henrique 109", Latitude = 41.1407, Longitude = -8.6155 },
                 new Local { Nome = "Terreiro da Sé", Latitude = 41.1429, Longitude = -8.6117 },
                 new Local { Nome = "Praça Almeida Garret", Latitude = 41.1454, Longitude = -8.6108 },
                 new Local { Nome = "Praça da Liberdade", Latitude = 41.1468, Longitude = 8.6114 },
                 new Local { Nome = "R.de Passos Manuel 40", Latitude = 41.1472, Longitude = -8.6079 },
                 new Local { Nome = "Rua da Alegria 299", Latitude = 41.1512, Longitude = -8.6043 },
                 new Local { Nome = "Rua da Alegria 889", Latitude = 41.1594, Longitude = -8.6011 },
                 new Local { Nome = "Rua da Constituição 204", Latitude = 41.1613, Longitude = -8.6002 },
                 new Local { Nome = "Rua de Camões 234", Latitude = 41.1535, Longitude = -8.6099 },
                 new Local { Nome = "Rua da Lapa", Latitude = 41.1552, Longitude = -8.6133 },
                 new Local { Nome = "Rua da Constituicao 1084", Latitude = 41.1627, Longitude = -8.6112 },
                new Local { Nome = "R.Carlos Malheiro Dias 16", Latitude = 41.1605, Longitude = -8.5936 },
                new Local { Nome = "Av.de Fernão de Magalhães 1700", Latitude = 41.1641, Longitude = -8.5894 },
                new Local { Nome = "Via Futebol Clube do Porto 26", Latitude = 41.1622, Longitude = -8.5853 },
                new Local { Nome = "R.de Sao Filipe de Nery", Latitude = 41.1459, Longitude = -8.6142 },
                new Local { Nome = "R.do Dr.Magalhaes Lemos 83", Latitude = 41.1476, Longitude = -8.6096 },
                new Local { Nome = "Rua da Bolsa 16", Latitude = 41.1416, Longitude = -8.6145 },
                new Local { Nome = "Rua do Ouro", Latitude = 41.1482, Longitude = -8.6364 },
                new Local { Nome = "Praça de Gonçalves Zarco 2", Latitude = 41.1686, Longitude = -8.6899 },
                new Local { Nome = "Av.de Fernão de Magalhães 910", Latitude = 41.1576, Longitude = -8.5937 },
                new Local { Nome = "Campo 24 de Agosto 31", Latitude = 41.1491, Longitude = -8.5988 });

            context.POIs.AddOrUpdate(i => i.PoiID,
                new POI { Nome = "Estádio do Dragão", LocalID = 30, CategoriaID = 1, duracaoVisita = 45 },
                new POI { Nome = "Casa da Música", LocalID = 10, CategoriaID = 5, duracaoVisita = 35 },
                new POI { Nome = "Torre dos Clérigos", LocalID = 31, CategoriaID = 4, duracaoVisita = 15 },
                new POI { Nome = "Estação Ferroviária de Porto São Bento", LocalID = 19, CategoriaID = 4, duracaoVisita = 30 },
                new POI { Nome = "Sé do Porto", LocalID = 18, CategoriaID = 4, duracaoVisita = 25 },
                new POI { Nome = "Palácio da Bolsa", LocalID = 17, CategoriaID = 3, duracaoVisita = 33 },
                new POI { Nome = "Museu Serralves", LocalID = 3, CategoriaID = 3, duracaoVisita = 50 },
                new POI { Nome = "Forte de S.Franscisco do Queijo", LocalID = 35, CategoriaID = 2, duracaoVisita = 15 },
                new POI { Nome = "Igreja de S.Franscisco", LocalID = 33, CategoriaID = 4, duracaoVisita = 20 },
                new POI { Nome = "Coliseu do Porto", LocalID = 21, CategoriaID = 6, duracaoVisita = 19 },
                new POI { Nome = "Palácio de Cristal", LocalID = 12, CategoriaID = 4, duracaoVisita = 29 },
                new POI { Nome = "Casa do Infante", LocalID = 17, CategoriaID = 3, duracaoVisita = 15 },
                new POI { Nome = "Alfandega do Porto", LocalID = 16, CategoriaID = 4, duracaoVisita = 10 },
                new POI { Nome = "Teatro Rivoli", LocalID = 32, CategoriaID = 6, duracaoVisita = 26 },
                new POI { Nome = "Rotunda da Boavista", LocalID = 10, CategoriaID = 2, duracaoVisita = 10 },
                new POI { Nome = "Mercado Ferreira Borges", LocalID = 27, CategoriaID = 2, duracaoVisita = 30 },
                new POI { Nome = "Jardim Botanico", LocalID = 11, CategoriaID = 2, duracaoVisita = 60 },
                new POI { Nome = "Sealife Matosinhos", LocalID = 1, CategoriaID = 3, duracaoVisita = 120 },
                new POI { Nome = "Livralia Lello", LocalID = 15, CategoriaID = 4, duracaoVisita = 40 }
                );

            context.Categorias.AddOrUpdate(i => i.CategoriaID,
                new Categoria { nome = "Desporto" },
                new Categoria { nome = "Ar Livre" },
                new Categoria { nome = "Museus" },
                new Categoria { nome = "História" },
                new Categoria { nome = "Música" },
                new Categoria { nome = "Teatro" }
                );

            POI p1 = context.POIs.Find(1);
            POI p2 = context.POIs.Find(2);
            POI p3 = context.POIs.Find(3);

            var listPoi = new List<POI>();
            listPoi.Add(p1);
            listPoi.Add(p2);
            listPoi.Add(p3);

            context.Hashtags.AddOrUpdate(i => i.ID,
                new Hashtag { Nome = "#Happy", POIs = listPoi },
                new Hashtag { Nome = "#PORTO", POIs = listPoi });

            context.SugerirPOI.AddOrUpdate(i => i.SugerirPoiID,
                new SugerirPOI { Nome = "Estádio do Bessa", LocalID = 1, CategoriaID = 1, duracaoVisita = 45, UserCreator = 1 }
                );
            //AddOrUpdatePOI(context, 3, 3);
            context.Visitas.AddOrUpdate(i => i.idVisita,
                new Visita { data = "10/01/2017", descrição = "Visita de TukTuk", horaInicio = "10:00:00", idPercurso = 4, idUser = 1, userEmail = "admin@isep.ipp.pt" },
                new Visita { data = "11/01/2017", descrição = "Visita á la pata", horaInicio = "09:20:00", idPercurso = 5, idUser = 1, userEmail = "admin@isep.ipp.pt" },
                new Visita { data = "12/01/2017", descrição = "Visita estadio Dragao", horaInicio = "12:02:00", idPercurso = 4, idUser = 1, userEmail = "admin@isep.ipp.pt" },
                new Visita { data = "13/01/2017", descrição = "Visita de autocarro", horaInicio = "14:22:00", idPercurso = 5, idUser = 1, userEmail = "admin@isep.ipp.pt" },
                new Visita { data = "14/01/2017", descrição = "Visita de Tu", horaInicio = "16:18:00", idPercurso = 5, idUser = 1, userEmail = "admin@isep.ipp.pt" },
                new Visita { data = "15/01/2017", descrição = "Visita de TukTuktuk", horaInicio = "17:11:00", idPercurso = 4, idUser = 1, userEmail = "admin@isep.ipp.pt" });

        }
    }
}

