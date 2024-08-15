using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoriosDemo.Entidades
{
    [Table("Servicio")]
    public class Servicio : EntidadBase
    {
        // Propiedades adicionales específicas de Servicio
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(500)]
        public string? Observaciones { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Email: {Email}, Observaciones: {Observaciones}");
            Console.WriteLine("");
        }
    }
}
