using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp.Models;
using tp.Database;
using System.Linq;
using tp.Models.ViewModel;

namespace tp.Controllers
{
    public class JuegoController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public JuegoController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Juego Juego)
        {
            _juegoDbContext.Juegos.Add(Juego);
            _juegoDbContext.SaveChanges();
            return Json(Juego);
        }

        [HttpGet]
        public IActionResult GetAll(){
            var JuegosCompletos = _juegoDbContext.Juegos
                                    .Include(x => x.TiposJuego)
                                    .Include(x => x.Imagen)
                                    .ToList();
            
            var juegos = JuegosCompletos.Select(x => new GaleriaViewModel
            {  
                IdJuego = x.Id,
                Nombre = x.Nombre,
                PuntajeTotalJugador = x.PuntajeTotalJugador,
                PuntajeTotalPeriodista = x.PuntajeTotalPeriodista,
                Imagen = x.Imagen,
                TiposJuego = x.TiposJuego
            }).ToList();
            return View(juegos);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
