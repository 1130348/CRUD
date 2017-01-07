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
                        PoiID = c.Int(nullable: false),
                        POI_PoiID = c.Int(),
                        SugerirPOI_SugerirPoiID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.POIs", t => t.POI_PoiID)
                .ForeignKey("dbo.POIs", t => t.PoiID, cascadeDelete: true)
                .ForeignKey("dbo.SugerirPOIs", t => t.SugerirPOI_SugerirPoiID)
                .Index(t => t.PoiID)
                .Index(t => t.POI_PoiID)
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
                        Hashtag_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PoiID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Locals", t => t.LocalID, cascadeDelete: true)
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_ID)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Hashtag_ID);
            
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
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SugerirPoiID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Locals", t => t.LocalID, cascadeDelete: true)
                .Index(t => t.LocalID)
                .Index(t => t.CategoriaID);
            
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
            DropForeignKey("dbo.POIs", "Hashtag_ID", "dbo.Hashtags");
            DropForeignKey("dbo.Hashtags", "PoiID", "dbo.POIs");
            DropForeignKey("dbo.PercursoPOIs", "POI_PoiID", "dbo.POIs");
            DropForeignKey("dbo.PercursoPOIs", "Percurso_PercursoID", "dbo.Percursoes");
            DropForeignKey("dbo.POIs", "LocalID", "dbo.Locals");
            DropForeignKey("dbo.Hashtags", "POI_PoiID", "dbo.POIs");
            DropForeignKey("dbo.POIs", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.PercursoPOIs", new[] { "POI_PoiID" });
            DropIndex("dbo.PercursoPOIs", new[] { "Percurso_PercursoID" });
            DropIndex("dbo.SugerirPOIs", new[] { "CategoriaID" });
            DropIndex("dbo.SugerirPOIs", new[] { "LocalID" });
            DropIndex("dbo.Percursoes", new[] { "SugerirPOI_SugerirPoiID" });
            DropIndex("dbo.POIs", new[] { "Hashtag_ID" });
            DropIndex("dbo.POIs", new[] { "CategoriaID" });
            DropIndex("dbo.POIs", new[] { "LocalID" });
            DropIndex("dbo.Hashtags", new[] { "SugerirPOI_SugerirPoiID" });
            DropIndex("dbo.Hashtags", new[] { "POI_PoiID" });
            DropIndex("dbo.Hashtags", new[] { "PoiID" });
            DropTable("dbo.PercursoPOIs");
            DropTable("dbo.SugerirPOIs");
            DropTable("dbo.Percursoes");
            DropTable("dbo.Locals");
            DropTable("dbo.POIs");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Categorias");
        }
    }
}
