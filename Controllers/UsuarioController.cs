using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp.Models;
using tp.Database;

namespace tp.Controllers
{
    public class UsuarioController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public UsuarioController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario Usuario)
        {
            _juegoDbContext.Usuarios.Add(Usuario);
            _juegoDbContext.SaveChanges();
            return Json(Usuario);
        }

        [HttpGet]
        public IActionResult GetUser(){
            var Usuarios = _juegoDbContext.Usuarios
                                    .Include(x => x.Rol)
                                    .Include(x => x.Votos)
                                    .ToList();
            return Json(Usuarios);
        }

        [HttpGet]
        public IActionResult GetUser(string Nombre, string Pass){
            var Usuarios = _juegoDbContext.Usuarios
                                    .Include(x => x.Rol)
                                    .Include(x => x.Votos)
                                    .ToList();
            return Json(Usuarios);
        }

    }
}
