using tp.Models;
using Microsoft.EntityFrameworkCore;

namespace tp.Database
{
    public class JuegoDbContext : DbContext
    {
        public JuegoDbContext(DbContextOptions<JuegoDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Solicitud>().HasOne(s => s.Creador).WithMany(u => u.SolicitudesEmitidas);
            builder.Entity<Solicitud>().HasOne(s => s.Resolutor).WithMany(u => u.SolicitudesResueltas);
        }

        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
    }
}