namespace Ahorcado_Grupo5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialSQLServer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jugadors",
                c => new
                    {
                        Identificacion = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Marcador = c.Int(nullable: false),
                        PartidasGanadas = c.Int(nullable: false),
                        PartidasPerdidas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Identificacion);
            
            CreateTable(
                "dbo.Palabras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoPalabra = c.String(nullable: false),
                        HaSidoUsada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Victoria = c.Boolean(nullable: false),
                        Nivel = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        JugadorId = c.Int(nullable: false),
                        PalabraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jugadors", t => t.JugadorId, cascadeDelete: true)
                .ForeignKey("dbo.Palabras", t => t.PalabraId, cascadeDelete: true)
                .Index(t => t.JugadorId)
                .Index(t => t.PalabraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partidas", "PalabraId", "dbo.Palabras");
            DropForeignKey("dbo.Partidas", "JugadorId", "dbo.Jugadors");
            DropIndex("dbo.Partidas", new[] { "PalabraId" });
            DropIndex("dbo.Partidas", new[] { "JugadorId" });
            DropTable("dbo.Partidas");
            DropTable("dbo.Palabras");
            DropTable("dbo.Jugadors");
        }
    }
}
