using System.ComponentModel.DataAnnotations;

namespace Ahorcado_Grupo5.Models
{
    public class Jugador
    {
        [Key] // Esto define 'Identificacion' como la llave primaria
        [Required(ErrorMessage = "La identificación es obligatoria")]
        [Range(1, 999999999, ErrorMessage = "La identificación debe ser un número entero positivo entre 1 y 999999999")]
        [Display(Name = "Identificación")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Marcador")]
        public int Marcador { get; set; }

        [Display(Name = "Partidas Ganadas")]
        public int PartidasGanadas { get; set; }

        [Display(Name = "Partidas Perdidas")]
        public int PartidasPerdidas { get; set; }

        public string AvatarUrl { get; set; }
    }
}