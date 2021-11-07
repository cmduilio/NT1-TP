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
            Voto Voto = new Voto
            {
                Juego = votoViewModel.Juego,
                Puntaje = votoViewModel.Puntaje,
                Usuario = votoViewModel.Usuario
            };

            if (votoViewModel.Usuario.Rol.Nombre == "Periodista")
            {
                votoViewModel.Juego.CantidadVotosPeriodista++;
                votoViewModel.Juego.PuntajeTotalJugador += votoViewModel.Puntaje;
            } else {
                
            }

            _juegoDbContext.Votos.Add(Voto);
            _juegoDbContext.Juegos.Update(votoViewModel.Juego);
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
