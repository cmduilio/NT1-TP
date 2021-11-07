using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Solicitudes")]
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public Categoria Categoria { get; set; }

        [Required]
        public string Imagen { get; set; }
        
        [Required]
        public Usuario Creador { get; set; }

        public Usuario Resolutor { get; set; }

        public bool Aprobado { get; set; }

        public Juego Juego { get; set; }

    }
}
