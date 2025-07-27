using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Grupo5.Models
{
    public class Palabra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debes ingresar una palabra.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "La palabra debe tener entre 5 y 10 letras.")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "La palabra solo puede contener letras.")]
        public string TextoPalabra { get; set; }

        public bool HaSidoUsada { get; set; }

    }
}