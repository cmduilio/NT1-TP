using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp.Models.ViewModel   
{
    public class CrearUsuarioViewModel
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [MaxLength(20, ErrorMessage = "El maximo permitido es 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio.")]
        [StringLength(30, ErrorMessage = "La contraseña debe tener mínimo 5 carácteres y máximo 30.", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Rol { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}