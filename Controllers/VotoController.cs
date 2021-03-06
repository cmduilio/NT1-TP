using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tp.Models;
using tp.Models.ViewModel;
using tp.Database;
using Microsoft.EntityFrameworkCore;

namespace tp.Controllers
{
    public class VotoController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public VotoController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        [HttpGet]
        public IActionResult Create(int IdJuego, int IdUsuario)
        {
            Juego juego = _juegoDbContext.Juegos.Where(x=> x.Id == IdJuego).Include(x=>x.Categoria).FirstOrDefault();
            juego.PuntajeTotalPeriodista = juego.CantidadVotosPeriodista != 0 ? juego.PuntajeTotalPeriodista / juego.CantidadVotosPeriodista : 0;
            juego.PuntajeTotalJugador = juego.CantidadVotosJugador != 0 ? juego.PuntajeTotalJugador / juego.CantidadVotosJugador : 0;
            Usuario Usuario = _juegoDbContext.Usuarios.Where(x => x.Id == IdUsuario).FirstOrDefault(); 
            var votoVm = new VotoViewModel
            {
                IdJuego = IdJuego,
                Juego = juego,
                Usuario = Usuario,
            };
            return View(votoVm);
        }

        [HttpPost]
        public IActionResult Create(VotoViewModel votoViewModel)
        {
            Juego Juego = _juegoDbContext.Juegos.Where(x => x.Id == votoViewModel.IdJuego).FirstOrDefault(); 
            Usuario Usuario = _juegoDbContext.Usuarios.Where(x => x.Id == votoViewModel.IdUsuario).Include(x=> x.Votos).FirstOrDefault(); 
            Voto Voto = new Voto
            {
                Juego = Juego,
                Puntaje = votoViewModel.Puntaje,
                IdUsuario = Usuario.Id
            };

            Usuario.Votos.Add(Voto);

            if (Usuario.Rol == Rol.PERIODISTA)
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
            return RedirectToAction("GetAll", "Juego");
        }

        [HttpGet]
        public IActionResult GetAll(int IdUsuario){
            var Votos = _juegoDbContext.Votos
                                    .Where(x => x.IdUsuario == IdUsuario)
                                    .Include(x => x.Juego)
                                    .Include(x => x.Juego.Categoria)
                                    .Select(x => new VotoViewModel{
                                        IdJuego = x.Juego.Id,
                                        Juego = x.Juego,
                                        Puntaje = x.Puntaje,
                                        IdUsuario = IdUsuario
                                    }).ToList();
            return View(Votos);
        }
    }
}
