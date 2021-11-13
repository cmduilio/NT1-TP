using System.Collections.Generic;

namespace tp.Models.ViewModel
{
    public class VerDatosViewModel
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public Rol Rol { get; set; }

        public ICollection<Voto> Votos { get; set; }

        public ICollection<Solicitud> SolicitudesEmitidas { get; set; }
        
        public ICollection<Solicitud> SolicitudesResueltas { get; set; }
    }
}