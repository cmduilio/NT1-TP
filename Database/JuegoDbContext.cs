using tp.Models;
using Microsoft.EntityFrameworkCore;

namespace tp.Database
{
    public class JuegoDbContext : DbContext
    {
        public JuegoDbContext(DbContextOptions<JuegoDbContext> options) : base(options){}

        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoJuego> TiposJuego { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voto> Votos { get; set; }
    }
}