using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tp.Models;
using tp.Models.ViewModel;
using tp.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace tp.Controllers
{
    public class SolicitudController : Controller
    {
        private JuegoDbContext _juegoDbContext;

        public SolicitudController(JuegoDbContext juegoDbContext)
        {
            _juegoDbContext = juegoDbContext;
        }
        
        [HttpGet]
        public IActionResult GetAll(int IdUsuario){
            List<SolicitarJuegoViewModel> Solicitudes;

            if(IdUsuario > 0){
                Solicitudes = _juegoDbContext.Solicitudes
                                    .Include(x => x.Categoria)
                                    .Where(x => x.Creador.Id == IdUsuario)
                                    .Select(x => new SolicitarJuegoViewModel{
                                        Nombre = x.Nombre,
                                        Categoria = x.Categoria,
                                        Imagen = x.Imagen,
                                        Aprobado = x.Aprobado
                                    }).ToList();
            } else {
                Solicitudes = _juegoDbContext.Solicitudes
                                    .Include(x => x.Categoria)
                                    .Select(x => new SolicitarJuegoViewModel{
                                        Nombre = x.Nombre,
                                        Categoria = x.Categoria,
                                        Imagen = x.Imagen,
                                        Aprobado = x.Aprobado
                                    }).ToList();
            }
            
            return View(Solicitudes);
        }
    }
}
