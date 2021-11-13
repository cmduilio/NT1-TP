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
        private JuegoDbContext _juegoDbContext;

        public UsuarioController(JuegoDbContext usuarioDbContext)
        {
            this._juegoDbContext = usuarioDbContext;
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            var roles = _juegoDbContext.Roles
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
            var usuarios = _juegoDbContext.Usuarios
                        .Include(x => x.Rol)
                        .Include(x => x.Votos)
                        .Include(x => x.SolicitudesEmitidas)
                        .Include(x => x.SolicitudesResueltas)
                        .ToList();

            return Json(usuarios);
        }

        [HttpGet]
        public IActionResult VerDatos(int userId)
        {
            var usuario = _usuarioDbContext.Usuarios.Where(x => x.Id == userId)
                        .Include(x => x.Rol)
                        .Include(x => x.Votos)
                        .Include(x => x.SolicitudesEmitidas)
                        .Include(x => x.SolicitudesResueltas).FirstOrDefault();
            var verDatos = new VerDatosViewModel
            {
                IdUsuario = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol,
                Votos = usuario.Votos,
                SolicitudesEmitidas = usuario.SolicitudesEmitidas,
                SolicitudesResueltas = usuario.SolicitudesResueltas,
            };
            return View(verDatos);
        }

        [HttpPost]
        public IActionResult CrearUsuario(CrearUsuarioViewModel usuarioVm)
        {
            var roles = _juegoDbContext.Roles
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
                var rolSeleccionado = _juegoDbContext.Roles.Where(x => x.Id == usuarioVm.Rol).FirstOrDefault();

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

                _juegoDbContext.Usuarios.Add(usuario);
                _juegoDbContext.SaveChanges();
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
            
            var juegos = _juegoDbContext.Juegos
                .Include(x => x.Categoria)
                .Select(x => new MisJuegosViewModel
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