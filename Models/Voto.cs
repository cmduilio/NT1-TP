using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Votos")]
    public class Voto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Juego Juego { get; set; }

        [Required]
        public float Puntaje { get; set; }

        [Required]
        public Usuario Usuario { get; set; }
    }
}
