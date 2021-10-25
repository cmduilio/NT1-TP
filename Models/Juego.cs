using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Juegos")]
    public class Juego
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public double PuntajeTotalJugador { get; set; }

        [Required]
        public int CantidadVotosJugador { get; set; }

        [Required]
        public double PuntajeTotalPeriodista { get; set; }

        [Required]
        public int CantidadVotosPeriodista { get; set; }
        
        [Required]
        public ICollection<TipoJuego> TiposJuego { get; set; }

        [Required]
        public Imagen Imagen { get; set; }

    }
}
