using System.ComponentModel.DataAnnotations;

namespace RepositoriosDemo.Entidades
{
    /// <summary>
    ///  Es una clase abstracta que contiene las propiedades comunes a todas las entidades. Todas las entidades que heredan de esta clase tendrán estas propiedades.
    ///  Una clase abstracta en C# es como un plano o plantilla para otras clases. No se puede crear una instancia directamente de una clase abstracta; en cambio, se utiliza como base para que otras clases la hereden y utilicen o personalicen sus funcionalidades.
    /// </summary>
    public abstract class EntidadBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; } = true;

        [Required]
        public DateTime FechaAlta { get; set; }

        [Required]
        [MaxLength(50)]
        public string UsuarioAlta { get; set; } = string.Empty;
        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        [MaxLength(50)]
        public string? UsuarioBaja { get; set; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Activo: {Activo}");
        }
    }

}
