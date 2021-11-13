using System.Collections.Generic;

namespace tp.Models.ViewModel
{  
    public class MisJuegosViewModel
    {
        public int IdJuego { get; set; }

        public string Nombre { get; set; }

        public double PuntajeTotalJugador { get; set; }

        public double PuntajeTotalPeriodista { get; set; }

        public string Imagen { get; set; }

        public Categoria Categoria { get; set; } 

        public Voto MiVoto { get; set; }
    }
}