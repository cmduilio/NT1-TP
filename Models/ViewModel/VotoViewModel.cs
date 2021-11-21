using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp.Models.ViewModel   
{
    public class VotoViewModel
    {
        public int IdJuego { get; set; }
        public Juego Juego { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "El puntaje debe ser entre 1 y 5")]
        public int Puntaje { get; set; }
        
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}