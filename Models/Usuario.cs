using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Rol Rol { get; set; }

        public ICollection<Voto> Votos { get; set; }
        public ICollection<Solicitud> SolicitudesEmitidas { get; set; }
        public ICollection<Solicitud> SolicitudesResueltas { get; set; }
    }
}
