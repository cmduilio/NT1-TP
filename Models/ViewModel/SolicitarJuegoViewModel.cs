using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp.Models.ViewModel
{
    public class SolicitarJuegoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es un campo obligatorio.")]
        [MaxLength(20, ErrorMessage = "El maximo permitido es 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Categoria es un campo obligatorio.")]
        public int Categoria {get; set; }
        
        public IEnumerable<SelectListItem> Categorias { get; set; }

        [Required(ErrorMessage = "La Imagen es un campo obligatorio.")]
        public string Imagen { get; set; }

        
        public Usuario Creador { get; set; }

        public Juego Juego { get; set; }
    }
}