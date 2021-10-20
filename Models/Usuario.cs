using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Rol Rol { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}
