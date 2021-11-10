using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp.Models.ViewModel   
{
    public class VotoViewModel
    {
        public Juego Juego { get; set; }

        public int Puntaje { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}