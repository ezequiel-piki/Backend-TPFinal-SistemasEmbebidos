using Microsoft.EntityFrameworkCore;
using TPFinalSistemasEmbebidos_BenitezEzequiel.Entidades;

namespace TPFinalSistemasEmbebidos_BenitezEzequiel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasKey(prop => prop.Identificador);
            modelBuilder.Entity<Usuario>().Property(prop => prop.Nombre)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(prop => prop.Apellido)
                .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(prop => prop.Email)
               .IsRequired()
               .HasMaxLength(150)
               .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
