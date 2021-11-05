using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp.Models.ViewModel   
{
    public class IngresarUsuarioViewModel
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [MaxLength(20, ErrorMessage = "El maximo permitido es 20 caracteres")]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }
    }
}