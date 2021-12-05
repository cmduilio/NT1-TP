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
            List<SolicitarJuego> Solicitudes;

            if(IdUsuario > 0){
                Solicitudes = _juegoDbContext.Solicitudes
                                    .Include(x => x.Categoria)
                                    .Where(x => x.Creador.Id == IdUsuario)
                                    .Select(x => new SolicitarJuego{
                                        Id = x.Id,
                                        Nombre = x.Nombre,
                                        Categoria = x.Categoria,
                                        Imagen = x.Imagen,
                                        Aprobado = x.Aprobado,
                                        Status = x.Resolutor == null ? "Pendiente" : ( x.Aprobado ? "Aprobado" : "Rechazado"),
                                        Display = "none"
                                    }).ToList();
            } else {
                Solicitudes = _juegoDbContext.Solicitudes
                                    .Include(x => x.Categoria)
                                    .Select(x => new SolicitarJuego{
                                        Id = x.Id,
                                        Nombre = x.Nombre,
                                        Categoria = x.Categoria,
                                        Imagen = x.Imagen,
                                        Aprobado = x.Aprobado,
                                        Status = x.Resolutor == null ? "Pendiente" : ( x.Aprobado ? "Aprobado" : "Rechazado"),
                                        Display = x.Resolutor != null ? "none" : "flex"
                                    }).ToList();
            }
            
            return View(new SolicitarJuegoViewModel{
                solicitudes = Solicitudes
            });
        }
        
        [HttpPost]
        public IActionResult Aprobar(SolicitarJuegoViewModel Solicitud)
        {
            ResolverSolicitud(Solicitud.IdResolutor, Solicitud.IdSolicitud, true);
            return RedirectToAction("GetAll", "Solicitud", Solicitud.IdResolutor);
        }
        
        [HttpPost]
        public IActionResult Rechazar(SolicitarJuegoViewModel Solicitud)
        {
            ResolverSolicitud(Solicitud.IdResolutor, Solicitud.IdSolicitud, false);
            return RedirectToAction("GetAll", "Solicitud", Solicitud.IdResolutor);
        }

        private void ResolverSolicitud(int IdResolutor, int IdSolicitud, bool aprobada)
        {

            Solicitud Solicitud = _juegoDbContext.Solicitudes
                                .Include(x => x.Categoria)
                                .Include(x => x.Creador)
                                .Where(x => x.Id == IdSolicitud)
                                .FirstOrDefault();

            Usuario usuario = _juegoDbContext.Usuarios
                                .Where( x=> x.Id == IdResolutor)
                                .FirstOrDefault();

            Solicitud.Resolutor = usuario;
            Solicitud.Aprobado = aprobada;

            if(aprobada){
                Juego juego = new Juego{
                    Nombre = Solicitud.Nombre,
                    PuntajeTotalJugador = 0,
                    CantidadVotosJugador = 0,
                    PuntajeTotalPeriodista = 0,
                    CantidadVotosPeriodista = 0,
                    Categoria = Solicitud.Categoria,
                    Imagen = Solicitud.Imagen
                };

                _juegoDbContext.Juegos.Add(juego);
                Solicitud.Juego = juego;
            }


            _juegoDbContext.Solicitudes.Update(Solicitud);
            _juegoDbContext.SaveChanges();
        }
    }
}
