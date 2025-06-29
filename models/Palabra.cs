using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Grupo5.Models
{
    public class Palabra
    {
        [Key] // Llave primaria autoincremental
        public int Id { get; set; }

        [Required]// Campo obligatorio para la palabra
        public string TextoPalabra { get; set; }

        public bool HaSidoUsada { get; set; }
    }
}