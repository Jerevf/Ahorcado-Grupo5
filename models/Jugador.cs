using System.ComponentModel.DataAnnotations;

namespace Ahorcado_Grupo5.Models
{
    public class Jugador
    {
        [Key] // Esto define 'Identificacion' como la llave primaria
        public int Identificacion { get; set; }

        [Required] // Indica que el nombre es obligatorio
        public string Nombre { get; set; }

        public int Marcador { get; set; }
        public int PartidasGanadas { get; set; }
        public int PartidasPerdidas { get; set; }
    }
}