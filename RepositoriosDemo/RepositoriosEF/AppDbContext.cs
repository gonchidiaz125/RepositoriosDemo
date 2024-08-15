using Microsoft.EntityFrameworkCore;
using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosEF
{
    /// <summary>
    /// Contexto de BD. Clase clave en EF para configurar la conexión a la BD y los sets de entidades a vincular a la BD mediante EF
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<CentroDeAtencion> CentrosDeAtencion { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        // Configuración adicional...

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=RepositoriosDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
