using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tp.Models
{
    public class Juego
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string PuntajeTotalJugador { get; set; }

        [Required]
        public string CantidadVotosJugador { get; set; }

        [Required]
        public string PuntajeTotalPeriodista { get; set; }

        [Required]
        public string CantidadVotosPeriodista { get; set; }
        
        [Required]
        public ICollection<TipoJuego> TipoJuego { get; set; }

        [Required]
        public Imagen Imagen { get; set; }

    }
}
