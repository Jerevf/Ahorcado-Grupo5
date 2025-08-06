namespace Ahorcado_Grupo5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregaAvatarAJugador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jugadors", "AvatarUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jugadors", "AvatarUrl");
        }
    }
}
