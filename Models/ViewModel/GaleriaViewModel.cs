using System.Collections.Generic;

namespace tp.Models.ViewModel
{  
    public class GaleriaViewModel
    {
        public int IdJuego { get; set; }

        public string Nombre { get; set; }

        public double PuntajeTotalJugador { get; set; }

        public double PuntajeTotalPeriodista { get; set; }

        public int CantidadVotosJugador { get; set; }

        public int CantidadVotosPeriodista { get; set; }

        public string Imagen { get; set; }

        public Categoria Categoria { get; set; } 
    }
}