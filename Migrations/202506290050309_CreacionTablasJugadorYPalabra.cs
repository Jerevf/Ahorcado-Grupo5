namespace Ahorcado_Grupo5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionTablasJugadorYPalabra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jugadors",
                c => new
                    {
                        Identificacion = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
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
                        TextoPalabra = c.String(nullable: false, unicode: false),
                        HaSidoUsada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Palabras");
            DropTable("dbo.Jugadors");
        }
    }
}
