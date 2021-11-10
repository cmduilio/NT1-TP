using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp.Database;
using tp.Models;
using tp.Models.ViewModel;


namespace tp.Controllers
{
    public class UsuarioController : Controller
    {
        private JuegoDbContext _usuarioDbContext;

        public UsuarioController(JuegoDbContext usuarioDbContext)
        {
            this._usuarioDbContext = usuarioDbContext;
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            var roles = _usuarioDbContext.Roles
                        .Select(x => new SelectListItem
                        {
                            Text = x.Nombre,
                            Value = x.Id.ToString()
                        })
                        .ToList();
            var rolesVm = new CrearUsuarioViewModel
            {
                Roles = roles,
            };

            return View(rolesVm);
        }

        [HttpGet]
        public IActionResult Ingresar()
        {
            var usuarioVM = new IngresarUsuarioViewModel{};

            return View(usuarioVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioDbContext.Usuarios
                        .Include(x => x.Rol)
                        .Include(x => x.Votos)
                        .Include(x => x.SolicitudesEmitidas)
                        .Include(x => x.SolicitudesResueltas)
                        .ToList();

            return Json(usuarios);
        }

        [HttpPost]
        public IActionResult CrearUsuario(CrearUsuarioViewModel usuarioVm)
        {
            var roles = _usuarioDbContext.Roles
            .Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            })
            .ToList();

            var rolesVm = new CrearUsuarioViewModel
            {
                Roles = roles,
            };
            if (ModelState.IsValid)
            {
                //falta el insert de roles para que no se rompa
                var rolSeleccionado = _usuarioDbContext.Roles.Where(x => x.Id == usuarioVm.Rol).FirstOrDefault();

                //¿si no selecciona rol: redirije al home, salta error o qué hacemos?
                if (rolSeleccionado == null)
                {
                    return View();
                }

                var usuario = new Usuario
                {
                    Nombre = usuarioVm.Nombre,
                    Password = usuarioVm.Password,
                    Email = usuarioVm.Email,
                    Rol = rolSeleccionado,
                };

                _usuarioDbContext.Usuarios.Add(usuario);
                _usuarioDbContext.SaveChanges();
                return RedirectToAction("GetAll", "Juego");
            }
            return View(rolesVm);
        }

        public IActionResult AccesoDenegado() 
        {
            return View();
        }

          [HttpGet]
        public IActionResult GetMisJuegos()
        {
            var MisJuegos = _juegoDbContext.Juegos
                                    .Include(x => x.Categoria)
                                    .ToList();
            
            var juegos = JuegosCompletos.Select(x => new MisJuegosViewModel
            {  
                IdJuego = x.Id,
                Nombre = x.Nombre,
                PuntajeTotalJugador = x.CantidadVotosJugador != 0 ? x.PuntajeTotalJugador / x.CantidadVotosJugador : 0,
                PuntajeTotalPeriodista = x.CantidadVotosPeriodista != 0 ? x.PuntajeTotalPeriodista / x.CantidadVotosPeriodista : 0,
                Imagen = x.Imagen,
                Categoria = x.Categoria
            }).ToList();
            return View(juegos);
        }

        public IActionResult Salir() 
        {
            return View();
        }

        public IActionResult Votar()
        {
            return View();
        }

      
    }
}