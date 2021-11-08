using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tp.Models;
using tp.Models.ViewModel;
using tp.Database;

namespace tp.Controllers
{
    public class VotosController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public VotosController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] VotoViewModel votoViewModel)
        {
            Juego Juego = _juegoDbContext.Juegos.Where(x => x.Id == votoViewModel.Juego.Id).FirstOrDefault(); 
            Usuario Usuario = _juegoDbContext.Usuarios.Where(x => x.Id == votoViewModel.Usuario.Id).FirstOrDefault(); 
            Voto Voto = new Voto
            {
                Juego = Juego,
                Puntaje = votoViewModel.Puntaje,
                Usuario = Usuario
            };

            Usuario.Votos.Add(Voto);

            if (votoViewModel.Usuario.Rol.Nombre == "Periodista")
            {
                Juego.CantidadVotosPeriodista++;
                Juego.PuntajeTotalPeriodista += votoViewModel.Puntaje;
            } else {
                Juego.CantidadVotosJugador++;
                Juego.PuntajeTotalJugador += votoViewModel.Puntaje;
            }

            _juegoDbContext.Votos.Add(Voto);
            _juegoDbContext.Juegos.Update(Juego);
            _juegoDbContext.SaveChanges();
            return Json(Voto);
        }
        

        [HttpGet]
        public IActionResult GetAll(){
            var Votos = _juegoDbContext.Votos
                                    .ToList();
            
            return Json(Votos);
        }

        [HttpGet]
        public IActionResult GetAll(int UsuarioId){
            var Votos = _juegoDbContext.Votos
                                    .Where(x => x.Usuario.Id == UsuarioId)
                                    .FirstOrDefault();
            
            return Json(Votos);
        }
    }
}
