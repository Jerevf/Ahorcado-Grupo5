using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahorcado_Grupo5.Models
{
    public class Partida
    {
        [Key]
        public int Id { get; set; }

        public bool Victoria { get; set; } // true = ganada, false = perdida
        public string Nivel { get; set; } // "Fácil", "Normal", "Difícil"
        public DateTime Fecha { get; set; }

        // Llave foránea para el Jugador
        public int JugadorId { get; set; }
        [ForeignKey("JugadorId")]
        public virtual Jugador Jugador { get; set; }

        // Llave foránea para la Palabra
        public int PalabraId { get; set; }
        [ForeignKey("PalabraId")]
        public virtual Palabra Palabra { get; set; }
    }
}