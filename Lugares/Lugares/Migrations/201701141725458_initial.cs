namespace Lugares.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        SugerirPOI_SugerirPoiID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SugerirPOIs", t => t.SugerirPOI_SugerirPoiID)
                .Index(t => t.SugerirPOI_SugerirPoiID);
            
            CreateTable(
                "dbo.POIs",
                c => new
                    {
                        PoiID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        LocalID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        duracaoVisita = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PoiID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Locals", t => t.LocalID, cascadeDelete: true)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Locals",
                c => new
                    {
                        LocalID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocalID);
            
            CreateTable(
                "dbo.Percursoes",
                c => new
                    {
                        PercursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        SugerirPOI_SugerirPoiID = c.Int(),
                    })
                .PrimaryKey(t => t.PercursoID)
                .ForeignKey("dbo.SugerirPOIs", t => t.SugerirPOI_SugerirPoiID)
                .Index(t => t.SugerirPOI_SugerirPoiID);
            
            CreateTable(
                "dbo.SugerirPOIs",
                c => new
                    {
                        SugerirPoiID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        LocalID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        duracaoVisita = c.Int(nullable: false),
                        UserCreator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SugerirPoiID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Locals", t => t.LocalID, cascadeDelete: true)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Visitas",
                c => new
                    {
                        idVisita = c.Int(nullable: false, identity: true),
                        data = c.String(),
                        descrição = c.String(),
                        horaInicio = c.String(),
                        idPercurso = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        userEmail = c.String(),
                    })
                .PrimaryKey(t => t.idVisita);
            
            CreateTable(
                "dbo.POIHashtags",
                c => new
                    {
                        POI_PoiID = c.Int(nullable: false),
                        Hashtag_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.POI_PoiID, t.Hashtag_ID })
                .ForeignKey("dbo.POIs", t => t.POI_PoiID, cascadeDelete: true)
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_ID, cascadeDelete: true)
                .Index(t => t.POI_PoiID)
                .Index(t => t.Hashtag_ID);
            
            CreateTable(
                "dbo.PercursoPOIs",
                c => new
                    {
                        Percurso_PercursoID = c.Int(nullable: false),
                        POI_PoiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Percurso_PercursoID, t.POI_PoiID })
                .ForeignKey("dbo.Percursoes", t => t.Percurso_PercursoID, cascadeDelete: true)
                .ForeignKey("dbo.POIs", t => t.POI_PoiID, cascadeDelete: true)
                .Index(t => t.Percurso_PercursoID)
                .Index(t => t.POI_PoiID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Percursoes", "SugerirPOI_SugerirPoiID", "dbo.SugerirPOIs");
            DropForeignKey("dbo.SugerirPOIs", "LocalID", "dbo.Locals");
            DropForeignKey("dbo.Hashtags", "SugerirPOI_SugerirPoiID", "dbo.SugerirPOIs");
            DropForeignKey("dbo.SugerirPOIs", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.PercursoPOIs", "POI_PoiID", "dbo.POIs");
            DropForeignKey("dbo.PercursoPOIs", "Percurso_PercursoID", "dbo.Percursoes");
            DropForeignKey("dbo.POIs", "LocalID", "dbo.Locals");
            DropForeignKey("dbo.POIHashtags", "Hashtag_ID", "dbo.Hashtags");
            DropForeignKey("dbo.POIHashtags", "POI_PoiID", "dbo.POIs");
            DropForeignKey("dbo.POIs", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.PercursoPOIs", new[] { "POI_PoiID" });
            DropIndex("dbo.PercursoPOIs", new[] { "Percurso_PercursoID" });
            DropIndex("dbo.POIHashtags", new[] { "Hashtag_ID" });
            DropIndex("dbo.POIHashtags", new[] { "POI_PoiID" });
            DropIndex("dbo.SugerirPOIs", new[] { "CategoriaID" });
            DropIndex("dbo.SugerirPOIs", new[] { "LocalID" });
            DropIndex("dbo.Percursoes", new[] { "SugerirPOI_SugerirPoiID" });
            DropIndex("dbo.POIs", new[] { "CategoriaID" });
            DropIndex("dbo.POIs", new[] { "LocalID" });
            DropIndex("dbo.Hashtags", new[] { "SugerirPOI_SugerirPoiID" });
            DropTable("dbo.PercursoPOIs");
            DropTable("dbo.POIHashtags");
            DropTable("dbo.Visitas");
            DropTable("dbo.SugerirPOIs");
            DropTable("dbo.Percursoes");
            DropTable("dbo.Locals");
            DropTable("dbo.POIs");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Categorias");
        }
    }
}
