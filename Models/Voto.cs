using System.ComponentModel.DataAnnotations;

namespace tp.Models
{
    public class Voto
    {
        public int Id { get; set; }

        [Required]
        public Juego Juego { get; set; }

        [Required]
        public float Puntaje { get; set; }

        [Required]
        public Usuario Usuario { get; set; }
    }
}
