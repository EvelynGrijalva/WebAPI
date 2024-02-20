using Microsoft.EntityFrameworkCore;
using ML;

namespace DL
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<ML.Libro> Libros { get; set; }
        public DbSet<ML.Usuario> Usuarios { get; set; }
        public DbSet<ML.Prestamo> Prestamos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BiblioteaEClock;User ID=sa;Password=pass@word1; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany()
                .HasForeignKey(p => p.LibroId);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Prestamos)
                .HasForeignKey(p => p.UsuarioId);

            base.OnModelCreating(modelBuilder);
        }

        public static void EnsureSeedData(BibliotecaContext context)
        {
            if (!context.Libros.Any())
            {
                var libros = new List<Libro>
            {
                new Libro { Titulo = "100 años de soledad", Autor = "Gabriel G. Marquez", Stock = 10 },
                new Libro { Titulo = "La Sociedad del miedo", Autor = "Heinz Bude", Stock = 5 },
            };

                context.Libros.AddRange(libros);
                context.SaveChanges();
            }

            if (!context.Usuarios.Any())
            {
                var usuarios = new List<Usuario>
            {
                new Usuario { Nombre = "Evelyn", ApellidoPaterno = "Grijalva", Correo = "egrijalva@email.com", Contraseña = "egrijalva" }
            };

                context.Usuarios.AddRange(usuarios);
                context.SaveChanges();
            }

            if (!context.Prestamos.Any())
            {
                var prestamos = new List<Prestamo>
                {
                    new Prestamo { LibroId = 1, UsuarioId = 1, FechaPrestamo = DateTime.Now, FechaDevolucion = DateTime.Now.AddDays(5), Estado = EstadoPrestamo.EnCurso}
                };
            }
        }
    }



}