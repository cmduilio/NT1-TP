using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tp.Models;
using tp.Database;

namespace tp.Controllers
{
    public class RolController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public RolController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Rol Rol)
        {
            _juegoDbContext.Roles.Add(Rol);
            _juegoDbContext.SaveChanges();
            return Json(Rol);
        }
        

        [HttpGet]
        public IActionResult GetAll(){
            var Roles = _juegoDbContext.Roles
                                    .ToList();
            
            return Json(Roles);
        }
    }
}
