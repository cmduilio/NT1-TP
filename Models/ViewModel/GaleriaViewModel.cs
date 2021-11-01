using System.Collections.Generic;

namespace tp.Models.ViewModel
{  
    public class GaleriaViewModel
    {
        public int IdJuego { get; set; }

        public string Nombre { get; set; }

        public double PuntajeTotalJugador { get; set; }

        public double PuntajeTotalPeriodista { get; set; }

        public Imagen Imagen { get; set; }

        public ICollection<TipoJuego> TiposJuego { get; set; } 
    }
}