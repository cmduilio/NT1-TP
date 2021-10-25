using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp.Models;
using tp.Database;

namespace tp.Controllers
{
    public class JuegoController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public JuegoController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        public IActionResult Create()
        {
            var Juego = new Juego {
                Nombre = "Half life 2",
                PuntajeTotalJugador = 5,
                CantidadVotosJugador = 30,
                PuntajeTotalPeriodista = 5,
                CantidadVotosPeriodista = 23,
                TiposJuego = new List<TipoJuego> {
                    new TipoJuego {
                        Nombre = "Shooter"
                    }
                },
                Imagen = new Imagen{
                    Url = "http://"
                }
            };
            _juegoDbContext.Juegos.Add(Juego);
            _juegoDbContext.SaveChanges();
            return Json(Juego);
        }

        public IActionResult GetAll(){
            var Juegos = _juegoDbContext.Juegos;
            var JuegosCompletos = _juegoDbContext.Juegos
                                    .Include(x => x.TiposJuego)
                                    .Include(x => x.Imagen);
            return Json(JuegosCompletos);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
