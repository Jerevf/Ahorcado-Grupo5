using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace Ahorcado_Grupo5.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AhorcadoContext : DbContext
    {
        public AhorcadoContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Palabra> Palabras { get; set; }
        public DbSet<Partida> Partidas { get; set; }
    }
}