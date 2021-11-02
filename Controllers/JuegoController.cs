using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                                    .Include(x => x.Imagen).ToList();
            return Json(JuegosCompletos);
        }
    }
}
